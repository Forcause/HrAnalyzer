using HrAnalyzer.Models;
using System.ComponentModel;

namespace HrAnalyzer.ViewModels;

public class RegisterViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private Gender _selectedGender;
    public Gender SelectedGender
    {
        get => _selectedGender;
        set
        {
            _selectedGender = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGender)));
        }
    }

    public List<Gender> Genders { get; } = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
}
