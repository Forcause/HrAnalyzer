namespace HrAnalyzer.Models;

public class User
{
    public int Id { get; set; }

    public string Password { get; set; }

    public byte Age { get; set; }

    public string Name { get; set; }

    public double Weight { get; set; }

    public double Height { get; set; }

    public Gender Gender { get; }
}