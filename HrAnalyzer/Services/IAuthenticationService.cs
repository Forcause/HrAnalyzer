using HrAnalyzer.Models;

namespace HrAnalyzer.Services;

public interface IAuthenticationService
{
    User LoggedInUser { get; set; }
}