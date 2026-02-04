using System.Drawing;
using System.Windows.Forms;

namespace SealerBeadInspectionSystem
{
    public partial class MainForm
    {
        private TableLayoutPanel rootLayout;
        private Panel headerPanel;
        private Label titleLabel;
        private Label versionLabel;
        private Panel statusPanel;
        private Label inputLabel;
        private FlowLayoutPanel inputIndicators;
        private Label outputLabel;
        private FlowLayoutPanel outputIndicators;
        private Panel summaryPanel;
        private Panel infoPanel;
        private Label infoHeaderLabel;
        private Label infoDetailsLabel;
        private Panel donutPanel;
        private Label donutTitleLabel;
        private Panel donutCircle;
        private Label donutCenterLabel;
        private Panel logPanel;
        private Label logHeaderLabel;
        private TextBox logTextBox;
        private Panel inspectionPanel;
        private Label inspectionLabel;
        private TableLayoutPanel cameraLayout;
        private Panel camera1Panel;
        private Panel camera2Panel;
        private Label camera1Label;
        private Label camera2Label;
        private PictureBox camera1Image;
        private PictureBox camera2Image;
        private Label camera1Footer;
        private Label camera2Footer;

        private void InitializeComponent()
        {
            rootLayout = new TableLayoutPanel();
            headerPanel = new Panel();
            titleLabel = new Label();
            versionLabel = new Label();
            statusPanel = new Panel();
            inputLabel = new Label();
            inputIndicators = new FlowLayoutPanel();
            outputLabel = new Label();
            outputIndicators = new FlowLayoutPanel();
            summaryPanel = new Panel();
            infoPanel = new Panel();
            infoHeaderLabel = new Label();
            infoDetailsLabel = new Label();
            donutPanel = new Panel();
            donutTitleLabel = new Label();
            donutCircle = new Panel();
            donutCenterLabel = new Label();
            logPanel = new Panel();
            logHeaderLabel = new Label();
            logTextBox = new TextBox();
            inspectionPanel = new Panel();
            inspectionLabel = new Label();
            cameraLayout = new TableLayoutPanel();
            camera1Panel = new Panel();
            camera2Panel = new Panel();
            camera1Label = new Label();
            camera2Label = new Label();
            camera1Image = new PictureBox();
            camera2Image = new PictureBox();
            camera1Footer = new Label();
            camera2Footer = new Label();

            SuspendLayout();

            rootLayout.Dock = DockStyle.Fill;
            rootLayout.BackColor = Color.FromArgb(20, 22, 26);
            rootLayout.RowCount = 3;
            rootLayout.ColumnCount = 1;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            Controls.Add(rootLayout);

            headerPanel.Dock = DockStyle.Fill;
            headerPanel.BackColor = Color.FromArgb(30, 33, 38);
            headerPanel.Padding = new Padding(16, 12, 16, 12);
            rootLayout.Controls.Add(headerPanel, 0, 0);

            titleLabel.Text = "Sealer Bead Inspection System";
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(12, 20);
            headerPanel.Controls.Add(titleLabel);

            versionLabel.Text = "v1.26.1.3";
            versionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            versionLabel.ForeColor = Color.Gainsboro;
            versionLabel.AutoSize = true;
            versionLabel.Location = new Point(370, 28);
            headerPanel.Controls.Add(versionLabel);

            statusPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusPanel.Size = new Size(420, 48);
            statusPanel.Location = new Point(Width - 460, 16);
            statusPanel.BackColor = Color.FromArgb(36, 40, 46);
            statusPanel.Padding = new Padding(10, 6, 10, 6);
            headerPanel.Controls.Add(statusPanel);

            inputLabel.Text = "Input";
            inputLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            inputLabel.ForeColor = Color.WhiteSmoke;
            inputLabel.AutoSize = true;
            inputLabel.Location = new Point(8, 6);
            statusPanel.Controls.Add(inputLabel);

            inputIndicators.FlowDirection = FlowDirection.LeftToRight;
            inputIndicators.Location = new Point(8, 22);
            inputIndicators.Size = new Size(160, 24);
            statusPanel.Controls.Add(inputIndicators);
            AddIndicator(inputIndicators, "01", Color.FromArgb(62, 203, 107));
            AddIndicator(inputIndicators, "02", Color.FromArgb(52, 56, 60));
            AddIndicator(inputIndicators, "03", Color.FromArgb(52, 56, 60));
            AddIndicator(inputIndicators, "Se", Color.FromArgb(62, 203, 107));
            AddIndicator(inputIndicators, "BY", Color.FromArgb(52, 56, 60));
            AddIndicator(inputIndicators, "RE", Color.FromArgb(52, 56, 60));

            outputLabel.Text = "Output";
            outputLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            outputLabel.ForeColor = Color.WhiteSmoke;
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(190, 6);
            statusPanel.Controls.Add(outputLabel);

            outputIndicators.FlowDirection = FlowDirection.LeftToRight;
            outputIndicators.Location = new Point(190, 22);
            outputIndicators.Size = new Size(200, 24);
            statusPanel.Controls.Add(outputIndicators);
            AddIndicator(outputIndicators, "OK", Color.FromArgb(62, 203, 107));
            AddIndicator(outputIndicators, "NG", Color.FromArgb(52, 56, 60));
            AddIndicator(outputIndicators, "BY", Color.FromArgb(52, 56, 60));

            summaryPanel.Dock = DockStyle.Fill;
            summaryPanel.Padding = new Padding(16, 12, 16, 12);
            rootLayout.Controls.Add(summaryPanel, 0, 1);

            infoPanel.BackColor = Color.FromArgb(28, 30, 35);
            infoPanel.Size = new Size(340, 240);
            infoPanel.Location = new Point(16, 12);
            infoPanel.Padding = new Padding(16, 12, 16, 12);
            summaryPanel.Controls.Add(infoPanel);

            infoHeaderLabel.Text = "세부정보";
            infoHeaderLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            infoHeaderLabel.ForeColor = Color.White;
            infoHeaderLabel.AutoSize = true;
            infoPanel.Controls.Add(infoHeaderLabel);

            infoDetailsLabel.Text = "제품\n  Side OTR LHD\n\n설비\n  R12\n\n진행률\n  34.5% (353EA)\n\n실러폭\n  5.43mm (기준: 3~8mm)\n\nScore\n  96.5% (기준: 93.5% ↑)\n\n단락\n  None (기준: None)";
            infoDetailsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            infoDetailsLabel.ForeColor = Color.WhiteSmoke;
            infoDetailsLabel.AutoSize = true;
            infoDetailsLabel.Location = new Point(0, 28);
            infoPanel.Controls.Add(infoDetailsLabel);

            donutPanel.BackColor = Color.FromArgb(28, 30, 35);
            donutPanel.Size = new Size(340, 240);
            donutPanel.Location = new Point(372, 12);
            donutPanel.Padding = new Padding(16, 12, 16, 12);
            summaryPanel.Controls.Add(donutPanel);

            donutTitleLabel.Text = "생산현황";
            donutTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            donutTitleLabel.ForeColor = Color.White;
            donutTitleLabel.AutoSize = true;
            donutPanel.Controls.Add(donutTitleLabel);

            donutCircle.Size = new Size(160, 160);
            donutCircle.Location = new Point(90, 50);
            donutCircle.BackColor = Color.FromArgb(0, 162, 86);
            donutCircle.Paint += (sender, args) =>
            {
                var graphics = args.Graphics;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(20, 22, 26)))
                {
                    graphics.FillEllipse(brush, 30, 30, 100, 100);
                }
                using (var pen = new Pen(Color.FromArgb(234, 62, 62), 14))
                {
                    graphics.DrawArc(pen, 10, 10, 140, 140, 300, 50);
                }
            };
            donutPanel.Controls.Add(donutCircle);

            donutCenterLabel.Text = "001500";
            donutCenterLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            donutCenterLabel.ForeColor = Color.White;
            donutCenterLabel.AutoSize = true;
            donutCenterLabel.Location = new Point(120, 112);
            donutPanel.Controls.Add(donutCenterLabel);

            logPanel.BackColor = Color.FromArgb(28, 30, 35);
            logPanel.Size = new Size(420, 240);
            logPanel.Location = new Point(728, 12);
            logPanel.Padding = new Padding(16, 12, 16, 12);
            summaryPanel.Controls.Add(logPanel);

            logHeaderLabel.Text = "시스템 로그";
            logHeaderLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            logHeaderLabel.ForeColor = Color.White;
            logHeaderLabel.AutoSize = true;
            logPanel.Controls.Add(logHeaderLabel);

            logTextBox.Multiline = true;
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.BorderStyle = BorderStyle.None;
            logTextBox.BackColor = Color.FromArgb(28, 30, 35);
            logTextBox.ForeColor = Color.Gainsboro;
            logTextBox.Font = new Font("Consolas", 9F, FontStyle.Regular);
            logTextBox.Location = new Point(0, 28);
            logTextBox.Size = new Size(400, 190);
            logTextBox.Text = "[2026-01-13 09:00:01] [SYSTEM] Application Started Successfully.\r\n" +
                              "[2026-01-13 09:00:05] [CONFIG] Loading Config: SIDE OTR LHD (R12).\r\n" +
                              "[2026-01-13 09:00:09] [PLC] Communication Link Established (TCP/IP).\r\n" +
                              "[2026-01-13 09:05:12] [PLC] Received Model ID: 10 (SIDE OTR LHD).\r\n" +
                              "[2026-01-13 09:05:14] [VISION] Deep Learning Model Loaded: Sealer_V2.1.engine.\r\n" +
                              "[2026-01-13 09:05:20] [INSPECT] Sealer Start Signal Received (Trigger ON).\r\n" +
                              "[2026-01-13 09:05:21] [INSPECT] Result: OK (Width: 5.45mm, Score: 95%).\r\n" +
                              "[2026-01-13 09:05:26] [PLC] Sent Final Judgement: OK (Code: 1).";
            logPanel.Controls.Add(logTextBox);

            inspectionPanel.Dock = DockStyle.Fill;
            inspectionPanel.Padding = new Padding(16, 8, 16, 12);
            rootLayout.Controls.Add(inspectionPanel, 0, 2);

            inspectionLabel.Text = "검사중";
            inspectionLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            inspectionLabel.ForeColor = Color.White;
            inspectionLabel.BackColor = Color.FromArgb(72, 74, 78);
            inspectionLabel.AutoSize = false;
            inspectionLabel.TextAlign = ContentAlignment.MiddleCenter;
            inspectionLabel.Size = new Size(380, 64);
            inspectionLabel.Location = new Point(740, 10);
            inspectionPanel.Controls.Add(inspectionLabel);

            cameraLayout.Dock = DockStyle.Bottom;
            cameraLayout.RowCount = 1;
            cameraLayout.ColumnCount = 2;
            cameraLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cameraLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cameraLayout.Height = 320;
            inspectionPanel.Controls.Add(cameraLayout);

            camera1Panel.Dock = DockStyle.Fill;
            camera1Panel.Padding = new Padding(12);
            camera1Panel.BackColor = Color.FromArgb(24, 26, 30);
            cameraLayout.Controls.Add(camera1Panel, 0, 0);

            camera2Panel.Dock = DockStyle.Fill;
            camera2Panel.Padding = new Padding(12);
            camera2Panel.BackColor = Color.FromArgb(24, 26, 30);
            cameraLayout.Controls.Add(camera2Panel, 1, 0);

            camera1Label.Text = "Camera 1";
            camera1Label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            camera1Label.ForeColor = Color.White;
            camera1Label.AutoSize = true;
            camera1Panel.Controls.Add(camera1Label);

            camera2Label.Text = "Camera 2";
            camera2Label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            camera2Label.ForeColor = Color.White;
            camera2Label.AutoSize = true;
            camera2Panel.Controls.Add(camera2Label);

            camera1Image.BackColor = Color.FromArgb(32, 34, 38);
            camera1Image.BorderStyle = BorderStyle.FixedSingle;
            camera1Image.Location = new Point(0, 32);
            camera1Image.Size = new Size(520, 230);
            camera1Panel.Controls.Add(camera1Image);

            camera2Image.BackColor = Color.FromArgb(32, 34, 38);
            camera2Image.BorderStyle = BorderStyle.FixedSingle;
            camera2Image.Location = new Point(0, 32);
            camera2Image.Size = new Size(520, 230);
            camera2Panel.Controls.Add(camera2Image);

            camera1Footer.Text = "CAM01 : 실러폭 5.43mm / Score 96.5%";
            camera1Footer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            camera1Footer.ForeColor = Color.FromArgb(67, 205, 107);
            camera1Footer.AutoSize = true;
            camera1Footer.Location = new Point(0, 270);
            camera1Panel.Controls.Add(camera1Footer);

            camera2Footer.Text = "CAM02 : 실러폭 0.00mm / Score 0.0%";
            camera2Footer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            camera2Footer.ForeColor = Color.FromArgb(234, 62, 62);
            camera2Footer.AutoSize = true;
            camera2Footer.Location = new Point(0, 270);
            camera2Panel.Controls.Add(camera2Footer);

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 22, 26);
            ClientSize = new Size(1280, 720);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            ForeColor = Color.White;
            Text = "Sealer Bead Inspection System";
            ResumeLayout(false);
        }

        private void AddIndicator(FlowLayoutPanel panel, string text, Color color)
        {
            var label = new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                BackColor = color,
                AutoSize = false,
                Width = 26,
                Height = 20,
                Margin = new Padding(2, 0, 2, 0)
            };
            panel.Controls.Add(label);
        }
    }
}
