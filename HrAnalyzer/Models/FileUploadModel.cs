using Microsoft.AspNetCore.Http;

namespace HrAnalyzer.Models;

public class FileUploadModel
{
    public IFormFile File { get; set; }
}