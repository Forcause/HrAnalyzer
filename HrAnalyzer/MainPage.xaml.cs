using HrAnalyzer.Extensions;
using HrAnalyzer.Models;
using HrAnalyzer.Services;
using HrAnalyzer.ViewModels;
using Microsoft.AspNetCore.Http.Internal;
using System.Text.Json;

namespace HrAnalyzer
{
    public partial class MainPage : ContentPage
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public MainPage(IAuthenticationService authenticationService, IUserService userService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
            _userService = userService;
        }

        private async void OnLoadFileButtonClicked(object sender, EventArgs e)
        {
            var file = await FilePicker.Default.PickAsync(new PickOptions
            {
                FileTypes = FilePickerExtensions.CsvFiles,
                PickerTitle = "Please pick a CSV file"
            });

            if (file != null)
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(500);

                var formData = new MultipartFormDataContent();

                var fileModel = new FileUploadModel
                {
                    File = new FormFile(File.OpenRead(file.FullPath), 0, File.OpenRead(file.FullPath).Length, null, "file.csv")
                };

                formData.Add(new StreamContent(fileModel.File.OpenReadStream()), "file", "file.csv");

                var user = _authenticationService.LoggedInUser;
                var uri = new Uri("http://localhost:5256/api/upload-file?" +
                                  $"age={user.Age}&" +
                                  $"name={user.Name}&" +
                                  $"weight={user.Weight}&" +
                                  $"height={user.Height}&" +
                                  $"gender={user.Gender}&");

                var response = await client.PostAsync(uri, formData);

                var contentString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<AnalyzeResult>(contentString);

                    var vm = new MainInfoViewModel(result);

                    textLabel.FormattedText = vm.FormattedText;
                }
                else
                {
                    await DisplayAlert("Failed", "Unexpected error", "OK");
                }
            }
        }
    }


}
