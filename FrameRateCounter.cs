using Framey.Widgets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Framey
{
    public class FrameRateCounter
    {
        public double DeltaTime { get; set; }
        public int MinFps { get; private set; } = 100;
        public int Fps { get; private set; }
        public int MaxFps { get; private set; }
        public double GameTime { get; private set; }
        public TextWidget Text { get; private set; }

        private Stopwatch _sw;
        private double _delta;
        private double _previous;

        public FrameRateCounter()
        {
            Text = new TextWidget(0, 0, "", Colors.Black);
            Text.Shape.FontSize = 12;
        }

        public void Start()
        {
            _sw = Stopwatch.StartNew();
        }

        public void OnUpdate()
        {
            _delta = _sw.Elapsed.TotalMilliseconds - _previous;
            _previous = _sw.Elapsed.TotalMilliseconds;
            Fps = (int)(1000 / _delta);
            MinFps = Math.Min(Fps, MinFps);
            MaxFps = Math.Max(Fps, MaxFps);
            Text.Shape.Text = $"Fps: {Fps:d3} MinFps: {MinFps:d3} MaxFps: {MaxFps:d3}";

            DeltaTime = _delta / 1000;
            GameTime += DeltaTime;
        }
    }
}
