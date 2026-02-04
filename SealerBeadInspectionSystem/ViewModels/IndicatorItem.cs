using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SealerBeadInspectionSystem.ViewModels;

public sealed class IndicatorItem : INotifyPropertyChanged
{
    private bool _isActive;

    public IndicatorItem(string label, bool isActive)
    {
        Label = label;
        _isActive = isActive;
    }

    public string Label { get; }

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive == value)
            {
                return;
            }

            _isActive = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
