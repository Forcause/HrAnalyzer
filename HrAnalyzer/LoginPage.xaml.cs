using HrAnalyzer.Db;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Windows.Input;
using HrAnalyzer.Helpers;
using HrAnalyzer.Services;

namespace HrAnalyzer;

public partial class LoginPage : ContentPage
{
    private readonly IAuthenticationService _authenticationService;
    private readonly AppDbContext _context;

    public LoginPage(IAuthenticationService authenticationService)
    {
        InitializeComponent();
        _context = ServiceLocator.GetService<AppDbContext>();
        _authenticationService = authenticationService;
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordHasher.HashPassword(PasswordEntry.Text);

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == username && u.Password == password);

        if (user != null)
        {
            // Login successful
            await DisplayAlert("Success", "Login successful!", "OK");
            _authenticationService.LoggedInUser = user;
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
        else
        {
            // Login failed
            await DisplayAlert("Error", "Invalid username or password", "OK");
        }
    }
}

