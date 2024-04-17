namespace HrAnalyzer;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
    }
}