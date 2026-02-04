using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SealerBeadInspectionSystem.ViewModels;

public sealed class MainViewModel : INotifyPropertyChanged
{
    private int _okCount;
    private int _ngCount;
    private string _currentDateTime = "2026년 1월 13일 11:22:04";

    public MainViewModel()
    {
        _okCount = 1495;
        _ngCount = 5;

        InputIndicators = new ObservableCollection<IndicatorItem>
        {
            new("01", true),
            new("02", false),
            new("03", false),
            new("Se", true),
            new("BY", false),
            new("RE", false),
        };

        OutputIndicators = new ObservableCollection<IndicatorItem>
        {
            new("OK", true),
            new("NG", false),
            new("BY", false),
        };

        SystemLogs = new ObservableCollection<string>
        {
            "[2026-01-13 09:00:01] [SYSTEM] Application Started Successfully.",
            "[2026-01-13 09:00:05] [CONFIG] Loading Config: SIDE OTR LHD (R12).",
            "[2026-01-13 09:00:09] [PLC] Communication Link established (TCP/IP).",
            "[2026-01-13 09:05:02] [PLC] Received Model ID: 10 (SIDE OTR LHD).",
            "[2026-01-13 09:05:14] [VISION] Deep Learning Model Loaded: Sealer_V2.1.engine.",
            "[2026-01-13 09:05:20] [INSPECT] Sealer Start Signal Received (Trigger ON).",
            "[2026-01-13 09:05:25] [INSPECT] Result: OK (Width: 5.45mm, Score: 95%).",
            "[2026-01-13 09:05:26] [PLC] Sent Final Judgement: OK (Code: 1).",
        };

        HeaderIconCommand = new RelayCommand(_ => { });
    }

    public string Title => "Sealer Bead Inspection System";

    public string Version => "v1.26.1.3";

    public string CurrentDateTime
    {
        get => _currentDateTime;
        set
        {
            if (_currentDateTime == value)
            {
                return;
            }

            _currentDateTime = value;
            OnPropertyChanged();
        }
    }

    public string ProductName => "Side OTR LHD";

    public string EquipmentId => "R12";

    public string ProgressText => "100.0% (1025EA)";

    public string SealerWidthValue => "5.43mm";

    public string SealerWidthStandard => "(기준: 3~8mm)";

    public string ScoreValue => "96.5%";

    public string ScoreStandard => "(기준: 93.5% ↑)";

    public string SectionValue => "None";

    public string SectionStandard => "(기준: None)";

    public int OkCount
    {
        get => _okCount;
        set
        {
            if (_okCount == value)
            {
                return;
            }

            _okCount = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TotalCount));
        }
    }

    public int NgCount
    {
        get => _ngCount;
        set
        {
            if (_ngCount == value)
            {
                return;
            }

            _ngCount = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TotalCount));
        }
    }

    public int TotalCount => OkCount + NgCount;

    public ObservableCollection<IndicatorItem> InputIndicators { get; }

    public ObservableCollection<IndicatorItem> OutputIndicators { get; }

    public ObservableCollection<string> SystemLogs { get; }

    public string Camera1CaptionPrefix => "CAM01 : 실러폭 ";

    public string Camera1WidthValue => "5.43mm";

    public string Camera1ScoreValue => "96.5%";

    public string Camera2CaptionPrefix => "CAM02 : 실러폭 ";

    public string Camera2WidthValue => "0.00mm";

    public string Camera2ScoreValue => "0.0%";

    public ICommand HeaderIconCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
