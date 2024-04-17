using HrAnalyzer.Db;
using HrAnalyzer.Helpers;
using HrAnalyzer.Models;
using HrAnalyzer.ViewModels;

namespace HrAnalyzer;

public partial class RegisterPage : ContentPage
{
    private readonly AppDbContext _context;

    public RegisterPage()
    {
        InitializeComponent();
        _context = ServiceLocator.GetService<AppDbContext>();
        BindingContext = new RegisterViewModel();
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var user = new User
        {
            Name = UsernameEntry.Text,
            Password = PasswordHasher.HashPassword(PasswordEntry.Text),
            Age = byte.Parse(AgeEntry.Text),
            Weight = double.Parse(WeightEntry.Text),
            Height = double.Parse(HeightEntry.Text)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        await DisplayAlert("Success", "User registered successfully!", "OK");
    }
}
