using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SealerBeadInspectionSystem.Controls;

public partial class DonutChartControl : UserControl
{
    public static readonly DependencyProperty OkCountProperty =
        DependencyProperty.Register(nameof(OkCount), typeof(int), typeof(DonutChartControl),
            new PropertyMetadata(0, OnChartValueChanged));

    public static readonly DependencyProperty NgCountProperty =
        DependencyProperty.Register(nameof(NgCount), typeof(int), typeof(DonutChartControl),
            new PropertyMetadata(0, OnChartValueChanged));

    public static readonly DependencyProperty TotalCountProperty =
        DependencyProperty.Register(nameof(TotalCount), typeof(int), typeof(DonutChartControl),
            new PropertyMetadata(0));

    public DonutChartControl()
    {
        InitializeComponent();
        SizeChanged += (_, _) => UpdateArcs();
        Loaded += (_, _) => UpdateArcs();
    }

    public int OkCount
    {
        get => (int)GetValue(OkCountProperty);
        set => SetValue(OkCountProperty, value);
    }

    public int NgCount
    {
        get => (int)GetValue(NgCountProperty);
        set => SetValue(NgCountProperty, value);
    }

    public int TotalCount
    {
        get => (int)GetValue(TotalCountProperty);
        set => SetValue(TotalCountProperty, value);
    }

    private static void OnChartValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DonutChartControl control)
        {
            control.UpdateArcs();
        }
    }

    private void UpdateArcs()
    {
        if (ActualWidth <= 0 || ActualHeight <= 0)
        {
            return;
        }

        var total = OkCount + NgCount;
        if (total <= 0)
        {
            OkArc.Data = null;
            NgArc.Data = null;
            return;
        }

        var center = new Point(ActualWidth / 2, ActualHeight / 2);
        var radius = Math.Max(0, Math.Min(ActualWidth, ActualHeight) / 2 - 12);
        var startAngle = -90.0;
        var okAngle = 360.0 * OkCount / total;
        var ngAngle = 360.0 * NgCount / total;

        OkArc.Data = CreateArcGeometry(center, radius, startAngle, startAngle + okAngle);
        NgArc.Data = CreateArcGeometry(center, radius, startAngle + okAngle, startAngle + okAngle + ngAngle);
    }

    private static Geometry CreateArcGeometry(Point center, double radius, double startAngle, double endAngle)
    {
        if (radius <= 0)
        {
            return Geometry.Empty;
        }

        var clampedEnd = Math.Min(endAngle, startAngle + 359.9);
        var isLargeArc = Math.Abs(clampedEnd - startAngle) > 180.0;

        var start = PointOnCircle(center, radius, startAngle);
        var end = PointOnCircle(center, radius, clampedEnd);

        var figure = new PathFigure
        {
            StartPoint = start,
            IsClosed = false,
            Segments = new PathSegmentCollection
            {
                new ArcSegment
                {
                    Point = end,
                    Size = new Size(radius, radius),
                    IsLargeArc = isLargeArc,
                    SweepDirection = SweepDirection.Clockwise
                }
            }
        };

        return new PathGeometry { Figures = new PathFigureCollection { figure } };
    }

    private static Point PointOnCircle(Point center, double radius, double angleDegrees)
    {
        var radians = angleDegrees * Math.PI / 180.0;
        return new Point(
            center.X + radius * Math.Cos(radians),
            center.Y + radius * Math.Sin(radians));
    }
}
