using HrAnalyzer.Models;

namespace HrAnalyzer.Services;

public class AuthenticationService : IAuthenticationService
{
    public User LoggedInUser { get; set; }
}