namespace HrAnalyzer.Extensions
{
    public static class FilePickerExtensions
    {
        public static FilePickerFileType CsvFiles => new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
    {
        { DevicePlatform.WinUI, new[] { ".csv" } },
        { DevicePlatform.Android, new[] { "text/csv", "application/csv" } },
        { DevicePlatform.iOS, new[] { "public.comma-separated-values-text" } },
        { DevicePlatform.MacCatalyst, new[] { "public.comma-separated-values-text" } },
        { DevicePlatform.Tizen, new[] { "text/csv", "application/csv" } }
    });
    }

}
