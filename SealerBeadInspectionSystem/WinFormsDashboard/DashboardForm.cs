using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsDashboard;

public sealed class DashboardForm : Form
{
    private readonly TableLayoutPanel rootLayout = new();
    private readonly TableLayoutPanel cardsLayout = new();
    private readonly TableLayoutPanel analyticsLayout = new();

    public DashboardForm()
    {
        Text = "Q1 2020 Business Dashboard";
        BackColor = Color.FromArgb(27, 26, 45);
        ClientSize = new Size(1280, 720);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        StartPosition = FormStartPosition.CenterScreen;

        InitializeLayout();
        BuildMetricCards();
        BuildAnalyticsPanels();
    }

    private void InitializeLayout()
    {
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Padding = new Padding(18);
        rootLayout.RowCount = 2;
        rootLayout.ColumnCount = 1;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        cardsLayout.Dock = DockStyle.Fill;
        cardsLayout.ColumnCount = 5;
        cardsLayout.RowCount = 1;
        cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        cardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        cardsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        cardsLayout.Padding = new Padding(0, 0, 0, 14);

        analyticsLayout.Dock = DockStyle.Fill;
        analyticsLayout.ColumnCount = 3;
        analyticsLayout.RowCount = 1;
        analyticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        analyticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        analyticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        analyticsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        rootLayout.Controls.Add(cardsLayout, 0, 0);
        rootLayout.Controls.Add(analyticsLayout, 0, 1);

        Controls.Add(rootLayout);
    }

    private void BuildMetricCards()
    {
        cardsLayout.Controls.Add(new MetricCard(
            title: "Revenue: Q1 2020",
            value: "$2.32M",
            delta: "↑",
            deltaColor: Color.FromArgb(98, 210, 123),
            subtitle: "Q4 2019: $1.87M"), 0, 0);

        cardsLayout.Controls.Add(new MetricCard(
            title: "Expense: Q1 2020",
            value: "$42.76K",
            delta: "↓",
            deltaColor: Color.FromArgb(242, 99, 115),
            subtitle: "Q4 2019: $148.90K"), 1, 0);

        cardsLayout.Controls.Add(new MetricCard(
            title: "Profit: Q1 2020",
            value: "$516.76K",
            delta: "↑",
            deltaColor: Color.FromArgb(98, 210, 123),
            subtitle: "Q4 2019: $471.63K"), 2, 0);

        cardsLayout.Controls.Add(new MetricCard(
            title: "Revenue per Employee",
            value: "$110.01K",
            delta: string.Empty,
            deltaColor: Color.Transparent,
            subtitle: string.Empty), 3, 0);

        cardsLayout.Controls.Add(new MetricCard(
            title: "Active Customers",
            value: "3.63K",
            delta: string.Empty,
            deltaColor: Color.Transparent,
            subtitle: string.Empty), 4, 0);
    }

    private void BuildAnalyticsPanels()
    {
        var barPanel = BuildPanel("Revenue vs Expense Trend");
        var barChart = BuildBarChart();
        barChart.Dock = DockStyle.Fill;
        barPanel.Content.Controls.Add(barChart);
        analyticsLayout.Controls.Add(barPanel.Container, 0, 0);

        var donutPanel = BuildPanel("Revenue by Projects");
        var donutChart = BuildDonutChart();
        donutChart.Dock = DockStyle.Fill;
        donutPanel.Content.Controls.Add(donutChart);
        analyticsLayout.Controls.Add(donutPanel.Container, 1, 0);

        var mapPanel = BuildPanel("Customers Distribution");
        var mapCanvas = new MapCanvas();
        mapCanvas.Dock = DockStyle.Fill;
        mapPanel.Content.Controls.Add(mapCanvas);
        analyticsLayout.Controls.Add(mapPanel.Container, 2, 0);
    }

    private static (Panel Container, Panel Content) BuildPanel(string title)
    {
        var container = new Panel
        {
            BackColor = Color.FromArgb(35, 34, 57),
            Dock = DockStyle.Fill,
            Padding = new Padding(16),
            Margin = new Padding(0, 0, 14, 0)
        };

        var titleLabel = new Label
        {
            Text = title,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
            Dock = DockStyle.Top,
            Height = 28
        };

        var content = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 6, 0, 0)
        };

        container.Controls.Add(content);
        container.Controls.Add(titleLabel);

        return (container, content);
    }

    private static Chart BuildBarChart()
    {
        var chart = new Chart
        {
            BackColor = Color.Transparent,
            Palette = ChartColorPalette.None
        };

        var area = new ChartArea
        {
            BackColor = Color.Transparent,
            AxisX =
            {
                MajorGrid = { Enabled = false },
                LineColor = Color.FromArgb(64, 64, 88),
                LabelStyle = { ForeColor = Color.FromArgb(198, 202, 223) }
            },
            AxisY =
            {
                MajorGrid = { LineColor = Color.FromArgb(52, 52, 78) },
                LineColor = Color.FromArgb(64, 64, 88),
                LabelStyle = { ForeColor = Color.FromArgb(198, 202, 223) }
            }
        };

        chart.ChartAreas.Add(area);

        var revenueSeries = new Series("Revenue")
        {
            ChartType = SeriesChartType.Column,
            Color = Color.FromArgb(120, 214, 157),
            IsValueShownAsLabel = true,
            LabelForeColor = Color.FromArgb(214, 220, 236),
            Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        };

        var expenseSeries = new Series("Expense")
        {
            ChartType = SeriesChartType.Column,
            Color = Color.FromArgb(242, 99, 115),
            IsValueShownAsLabel = true,
            LabelForeColor = Color.FromArgb(214, 220, 236),
            Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        };

        var months = new[] { "Oct 2019", "Nov 2019", "Dec 2019", "Jan 2020", "Feb 2020", "Mar 2020" };
        var revenue = new[] { 116.21, 282.98, 221.35, 214.04, 214.37, 131.1 };
        var expense = new[] { 45.4, 71.47, 32.04, 17.88, 23.4, 1.48 };

        for (var i = 0; i < months.Length; i++)
        {
            revenueSeries.Points.AddXY(months[i], revenue[i]);
            expenseSeries.Points.AddXY(months[i], expense[i]);
        }

        chart.Series.Add(revenueSeries);
        chart.Series.Add(expenseSeries);

        return chart;
    }

    private static Chart BuildDonutChart()
    {
        var chart = new Chart
        {
            BackColor = Color.Transparent,
            Palette = ChartColorPalette.None
        };

        var area = new ChartArea
        {
            BackColor = Color.Transparent
        };

        chart.ChartAreas.Add(area);

        var series = new Series("Projects")
        {
            ChartType = SeriesChartType.Doughnut,
            Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point),
            LabelForeColor = Color.White
        };

        series.Points.Add(new DataPoint(0, 52) { Color = Color.FromArgb(84, 116, 219), LegendText = "ERP" });
        series.Points.Add(new DataPoint(0, 23) { Color = Color.FromArgb(93, 190, 239), LegendText = "Consulting Services" });
        series.Points.Add(new DataPoint(0, 13) { Color = Color.FromArgb(245, 143, 64), LegendText = "OEM Mobile Apps" });
        series.Points.Add(new DataPoint(0, 6) { Color = Color.FromArgb(255, 211, 74), LegendText = "Certification Program" });
        series.Points.Add(new DataPoint(0, 6) { Color = Color.FromArgb(126, 207, 79), LegendText = "App Builder" });

        chart.Series.Add(series);

        var legend = new Legend
        {
            Docking = Docking.Bottom,
            ForeColor = Color.FromArgb(198, 202, 223),
            BackColor = Color.Transparent
        };

        chart.Legends.Add(legend);

        return chart;
    }
}

public sealed class MetricCard : Panel
{
    public MetricCard(string title, string value, string delta, Color deltaColor, string subtitle)
    {
        BackColor = Color.FromArgb(35, 34, 57);
        Padding = new Padding(14);
        Margin = new Padding(0, 0, 12, 0);
        Dock = DockStyle.Fill;

        var titleLabel = new Label
        {
            Text = title,
            ForeColor = Color.FromArgb(198, 202, 223),
            Dock = DockStyle.Top,
            Height = 20,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        };

        var valueLayout = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 38,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false
        };

        var valueLabel = new Label
        {
            Text = value,
            ForeColor = Color.White,
            AutoSize = true,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        };

        var deltaLabel = new Label
        {
            Text = delta,
            ForeColor = deltaColor,
            AutoSize = true,
            Padding = new Padding(6, 8, 0, 0),
            Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point)
        };

        valueLayout.Controls.Add(valueLabel);
        if (!string.IsNullOrWhiteSpace(delta))
        {
            valueLayout.Controls.Add(deltaLabel);
        }

        var subtitleLabel = new Label
        {
            Text = subtitle,
            ForeColor = Color.FromArgb(148, 153, 178),
            Dock = DockStyle.Top,
            Height = 18,
            Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
        };

        Controls.Add(subtitleLabel);
        Controls.Add(valueLayout);
        Controls.Add(titleLabel);
    }
}

public sealed class MapCanvas : Panel
{
    public MapCanvas()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var graphics = e.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        using var mapBrush = new SolidBrush(Color.FromArgb(48, 53, 88));
        using var dotBrush = new SolidBrush(Color.FromArgb(84, 146, 226));
        using var dotBrushAlt = new SolidBrush(Color.FromArgb(240, 133, 146));
        using var dotBrushGold = new SolidBrush(Color.FromArgb(255, 207, 96));

        graphics.FillRoundedRectangle(mapBrush, ClientRectangle, 18);

        DrawRegionDots(graphics, dotBrush, dotBrushAlt, dotBrushGold);
        DrawRegionLabels(graphics);
    }

    private void DrawRegionDots(Graphics graphics, Brush dotBrush, Brush altBrush, Brush goldBrush)
    {
        var positions = new[]
        {
            new PointF(120, 160),
            new PointF(200, 200),
            new PointF(250, 140),
            new PointF(300, 220),
            new PointF(420, 170),
            new PointF(460, 120),
            new PointF(520, 200),
            new PointF(620, 140),
            new PointF(720, 170),
            new PointF(760, 220)
        };

        for (var i = 0; i < positions.Length; i++)
        {
            var brush = i % 3 == 0 ? altBrush : i % 2 == 0 ? goldBrush : dotBrush;
            var size = i % 4 == 0 ? 18 : 12;
            graphics.FillEllipse(brush, positions[i].X, positions[i].Y, size, size);
        }
    }

    private void DrawRegionLabels(Graphics graphics)
    {
        using var textBrush = new SolidBrush(Color.FromArgb(150, 158, 192));
        using var font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);

        graphics.DrawString("NORTH\nAMERICA", font, textBrush, 60, 190);
        graphics.DrawString("SOUTH\nAMERICA", font, textBrush, 150, 270);
        graphics.DrawString("EUROPE", font, textBrush, 430, 140);
        graphics.DrawString("AFRICA", font, textBrush, 470, 230);
        graphics.DrawString("ASIA", font, textBrush, 640, 170);
        graphics.DrawString("OCEANIA", font, textBrush, 760, 270);
    }
}

internal static class GraphicsExtensions
{
    public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int radius)
    {
        using var path = new System.Drawing.Drawing2D.GraphicsPath();
        var diameter = radius * 2;

        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        graphics.FillPath(brush, path);
    }
}
