using HrAnalyzer.Models;
using System.ComponentModel;

namespace HrAnalyzer.ViewModels;

public class MainInfoViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    private AnalyzeResult _myObject;
    public AnalyzeResult MyObject
    {
        get => _myObject;
        set
        {
            _myObject = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyObject)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FormattedText)));
        }
    }

    public MainInfoViewModel(AnalyzeResult result)
    {
        MyObject = result;
    }

    public string FormattedText => $"Анализ временной области: {MyObject.TimeDomainFailures?.Errors}\n{string.Join(" : ", MyObject.TimeDomainFailures?.AboutErrors ?? new List<string>())}" +
                                   $"\nАнализ частотной области: {MyObject.FrequencyDomainFailures?.Errors}\n{string.Join(" : ", MyObject.FrequencyDomainFailures?.AboutErrors ?? new List<string>())}" +
                                   $"\nАнализ пульса: {MyObject.HeartDeceasePredictions?.Errors}\n{string.Join(" : ", MyObject.HeartDeceasePredictions?.AboutErrors ?? new List<string>())}" +
                                   $"\nОбщая информация по анализу: {MyObject.TechnicalInformation?.Errors} \n {string.Join(" : ", MyObject.TechnicalInformation?.AboutErrors ?? new List<string>())}";
    // Add other formatted strings as needed
}