using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SealerBeadInspectionSystem.Controls;

public partial class CameraPanelControl : UserControl
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(CameraPanelControl),
            new PropertyMetadata("Camera"));

    public static readonly DependencyProperty FrameBrushProperty =
        DependencyProperty.Register(nameof(FrameBrush), typeof(Brush), typeof(CameraPanelControl),
            new PropertyMetadata(Brushes.Green));

    public static readonly DependencyProperty CaptionPrefixProperty =
        DependencyProperty.Register(nameof(CaptionPrefix), typeof(string), typeof(CameraPanelControl),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ScorePrefixProperty =
        DependencyProperty.Register(nameof(ScorePrefix), typeof(string), typeof(CameraPanelControl),
            new PropertyMetadata(" / Score "));

    public static readonly DependencyProperty ValueTextProperty =
        DependencyProperty.Register(nameof(ValueText), typeof(string), typeof(CameraPanelControl),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ScoreTextProperty =
        DependencyProperty.Register(nameof(ScoreText), typeof(string), typeof(CameraPanelControl),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ValueBrushProperty =
        DependencyProperty.Register(nameof(ValueBrush), typeof(Brush), typeof(CameraPanelControl),
            new PropertyMetadata(Brushes.Lime));

    public static readonly DependencyProperty ShowRoiProperty =
        DependencyProperty.Register(nameof(ShowRoi), typeof(bool), typeof(CameraPanelControl),
            new PropertyMetadata(false));

    public static readonly DependencyProperty RoiLeftProperty =
        DependencyProperty.Register(nameof(RoiLeft), typeof(double), typeof(CameraPanelControl),
            new PropertyMetadata(120d));

    public static readonly DependencyProperty RoiTopProperty =
        DependencyProperty.Register(nameof(RoiTop), typeof(double), typeof(CameraPanelControl),
            new PropertyMetadata(140d));

    public static readonly DependencyProperty RoiWidthProperty =
        DependencyProperty.Register(nameof(RoiWidth), typeof(double), typeof(CameraPanelControl),
            new PropertyMetadata(220d));

    public static readonly DependencyProperty RoiHeightProperty =
        DependencyProperty.Register(nameof(RoiHeight), typeof(double), typeof(CameraPanelControl),
            new PropertyMetadata(140d));

    public CameraPanelControl()
    {
        InitializeComponent();
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public Brush FrameBrush
    {
        get => (Brush)GetValue(FrameBrushProperty);
        set => SetValue(FrameBrushProperty, value);
    }

    public string CaptionPrefix
    {
        get => (string)GetValue(CaptionPrefixProperty);
        set => SetValue(CaptionPrefixProperty, value);
    }

    public string ScorePrefix
    {
        get => (string)GetValue(ScorePrefixProperty);
        set => SetValue(ScorePrefixProperty, value);
    }

    public string ValueText
    {
        get => (string)GetValue(ValueTextProperty);
        set => SetValue(ValueTextProperty, value);
    }

    public string ScoreText
    {
        get => (string)GetValue(ScoreTextProperty);
        set => SetValue(ScoreTextProperty, value);
    }

    public Brush ValueBrush
    {
        get => (Brush)GetValue(ValueBrushProperty);
        set => SetValue(ValueBrushProperty, value);
    }

    public bool ShowRoi
    {
        get => (bool)GetValue(ShowRoiProperty);
        set => SetValue(ShowRoiProperty, value);
    }

    public double RoiLeft
    {
        get => (double)GetValue(RoiLeftProperty);
        set => SetValue(RoiLeftProperty, value);
    }

    public double RoiTop
    {
        get => (double)GetValue(RoiTopProperty);
        set => SetValue(RoiTopProperty, value);
    }

    public double RoiWidth
    {
        get => (double)GetValue(RoiWidthProperty);
        set => SetValue(RoiWidthProperty, value);
    }

    public double RoiHeight
    {
        get => (double)GetValue(RoiHeightProperty);
        set => SetValue(RoiHeightProperty, value);
    }
}
