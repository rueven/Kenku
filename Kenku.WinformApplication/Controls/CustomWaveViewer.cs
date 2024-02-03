using NAudio.Wave;
using System.ComponentModel;

namespace Kenku.WinformApplication.Controls
{
    internal class CustomWaveViewer : UserControl
    {
        public CustomWaveViewer()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            this.DoubleBuffered = true;
            this.WaveFormColor = Color.DodgerBlue;
            this.BackColor = Color.Black;
            this.HighlightBackColor = Color.Gray;
            this.HighlightWaveFormColor = Color.White;
            this.PenWidth = 1;
        }

        private Container components = null;
        private WaveStream waveStream;
        private int InnerSamplesPerPixel = 128;
        private int BytesPerSample { get; set; }
        public Color WaveFormColor { get; set; }
        public Color HighlightWaveFormColor { get; set; }
        public Color HighlightBackColor { get; set; }
        public float PenWidth { get; set; }
        public int? SelectionAnchor { get; set; }
        public int SelectionStart { get; set; }
        public int SelectionEnd { get; set; }
        public TimeSpan SelectionStartTimeSpan { get; set; }
        public TimeSpan SelectionEndTimeSpan { get; set; }

        /// <summary>
        /// sets the associated wavestream
        /// </summary>
        public WaveStream WaveStream
        {
            get => waveStream;
            set
            {
                waveStream = value;
                if (waveStream != null)
                {
                    this.BytesPerSample = (waveStream.WaveFormat.BitsPerSample / 8) * waveStream.WaveFormat.Channels;
                    this.SelectionStartTimeSpan = TimeSpan.FromSeconds(0);
                    this.SelectionEndTimeSpan = waveStream.TotalTime;
                    this.FitToScreen();
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// The zoom level, in samples per pixel
        /// </summary>
        public int SamplesPerPixel
        {
            get => InnerSamplesPerPixel;
            set
            {
                InnerSamplesPerPixel = Math.Max(1, value);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Start position (currently in bytes)
        /// </summary>
        public long StartPosition { get; set; }

        public bool ShouldZoom { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components
                    .Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.WaveStream != null)
            {
                this.SelectionAnchor = e.X;
                this.CaptureMouseSelection(e, this.SelectionAnchor.Value);
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.SelectionAnchor.HasValue && this.WaveStream != null)
            {
                if (e.X == -1)
                {
                    return;
                }
                this.CaptureMouseSelection(e, this.SelectionAnchor.Value);
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.SelectionAnchor.HasValue && e.Button == MouseButtons.Left && this.WaveStream != null)
            {
                var (leftPosition, rightPosition) = this.CaptureMouseSelection(e, this.SelectionAnchor.Value);
                this.SelectionAnchor = null;
                if (this.ShouldZoom)
                {
                    this.Zoom(leftPosition, rightPosition);
                }
                this.Invalidate();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                this.FitToScreen();
            }
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.WaveStream != null)
            {
                this.WaveStream.Position = 0;
                int bytesRead;
                var waveData = new byte[this.SamplesPerPixel * this.BytesPerSample];
                this.WaveStream.Position = this.StartPosition + (e.ClipRectangle.Left * this.BytesPerSample * this.SamplesPerPixel);
                using var waveFormPen = new Pen(this.WaveFormColor, this.PenWidth);
                using var backColor = new SolidBrush(this.BackColor);
                using var highlightWaveFormPen = new Pen(this.HighlightWaveFormColor, this.PenWidth);
                using var highlightBackColor = new SolidBrush(this.HighlightBackColor);
                e.Graphics.FillRectangle
                (
                    backColor,
                    e.ClipRectangle
                );
                e.Graphics.FillRectangle
                (
                    highlightBackColor,
                    new Rectangle
                    (
                        new Point(this.SelectionStart, 0),
                        new Size(this.SelectionEnd - this.SelectionStart, e.ClipRectangle.Height)
                    )
                );
                for (float x = e.ClipRectangle.X; x < e.ClipRectangle.Right; x += 1)
                {
                    short low = 0;
                    short high = 0;
                    bytesRead = this
                        .WaveStream
                        .Read(waveData, 0, this.SamplesPerPixel * this.BytesPerSample);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    for (int n = 0; n < bytesRead; n += 2)
                    {
                        var sample = BitConverter
                            .ToInt16(waveData, n);
                        if (sample < low)
                        {
                            low = sample;
                        }
                        if (sample > high)
                        {
                            high = sample;
                        }
                    }
                    float lowPercent = (((float)low) - short.MinValue) / ushort.MaxValue;
                    float highPercent = (((float)high) - short.MinValue) / ushort.MaxValue;
                    var pen = x >= this.SelectionStart && x < this.SelectionEnd ? highlightWaveFormPen : waveFormPen;
                    e.Graphics.DrawLine(pen, x, this.Height * lowPercent, x, this.Height * highPercent);
                }
            }
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.FitToScreen();
        }

        private (int leftPosition, int rightPosition) CaptureMouseSelection(MouseEventArgs e, int selectionAnchor)
        {
            this.SelectionEnd = Math.Max(selectionAnchor, e.X);
            this.SelectionStart = Math.Min(selectionAnchor, e.X);
            var leftPosition = (int)(this.StartPosition / this.BytesPerSample + this.SamplesPerPixel * this.SelectionStart);
            var rightPosition = (int)(this.StartPosition / this.BytesPerSample + this.SamplesPerPixel * this.SelectionEnd);
            this.SelectionStartTimeSpan = this.CalculateTimeSpan(leftPosition * this.BytesPerSample);
            this.SelectionEndTimeSpan = this.CalculateTimeSpan(rightPosition * this.BytesPerSample);
            return (leftPosition, rightPosition);
        }

        private TimeSpan CalculateTimeSpan(long position)
        {
            var originalPostion = this
                .WaveStream
                .Position;
            this.WaveStream.Position = position;
            var output = this
                .WaveStream
                .CurrentTime;
            this.waveStream.Position = originalPostion;
            return output;
        }

        private void InitializeComponent() => this.components = new Container();

        public void FitToScreen()
        {
            if (this.WaveStream == null)
            {
                return;
            }
            int samples = (int)(this.WaveStream.Length / this.BytesPerSample);
            this.StartPosition = 0;
            this.SamplesPerPixel = samples / this.Width;
        }

        public void Zoom(int leftSample, int rightSample)
        {
            this.StartPosition = leftSample * this.BytesPerSample;
            this.SamplesPerPixel = (rightSample - leftSample) / this.Width;
        }

        private void DrawVerticalLine(int x) => ControlPaint
            .DrawReversibleLine
            (
                this.PointToScreen(new Point(x, 0)),
                this.PointToScreen(new Point(x, Height)),
                Color.Black
            );
    }
}