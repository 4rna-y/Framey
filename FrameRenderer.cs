using Framey.Input;
using Framey.Widgets;
using Framey.Widgets.Base;
using Framey.Widgets.Components.Base;
using Framey.Widgets.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Framey
{
    public class FrameRenderer : Control
    {
        private Time _time;

        public delegate void FrameEventHandler();
        public event FrameEventHandler OnStart;
        public event FrameEventHandler OnUpdate;

        protected override void OnRender(DrawingContext ctx)
        { 
            if (_widgets.Length == 0) return;

            for (int i = 0; i < _widgets.Length; i++)
            {
                if (_widgets[i] is ComponentWidget cw)
                {
                    AbstractComponent[] c = cw.GetComponents();
                    for (int ci = 0; ci < c.Length; ci++)
                    {
                        if (c[ci].IsEnable) c[ci].Update();
                    }
                }

                if (!GetIsInRenderingArea(_widgets[i]))
                {
                    _widgets[i].Shape.IsRendered = false;
                    continue;
                }
                ShapeType type = _widgets[i].Shape.Type;
                if (type == ShapeType.Rectangle)
                {
                    DrawRect(ctx, _widgets[i]);
                }
                if (type == ShapeType.Text)
                { 
                    DrawText(ctx, _widgets[i]);
                }

                if (_widgets[i] is ParentableWidget pw)
                {
                    ParentableWidget[] c = pw.GetWidgets();
                    if (c.Length != 0)
                        RenderParentable(ctx, c, _widgets[i].X, _widgets[i].Y);
                }

                _widgets[i].Shape.IsRendered = true;
            
            }

            base.OnRender(ctx);
            _counter.OnUpdate();
        }

        private bool _isShowFps;
        public bool IsShowFps { get => _isShowFps; set => SetIsShowFps(value); }
        public KeyInput Keyboard { get; private set; }

        private AbstractWidget[] _widgets;
        private FrameRateCounter _counter;

        public FrameRenderer()
        {
            _widgets = Array.Empty<AbstractWidget>();
            _counter = new FrameRateCounter();
            _time = new Time(_counter);
            Keyboard = new KeyInput();
        }

        public void Start()
        {
            Initialize();
        }

        public void Add(AbstractWidget widget) 
        {
            Array.Resize(ref _widgets, _widgets.Length + 1);
            _widgets[_widgets.Length - 1] = widget;
            Array.Sort(_widgets, (x, y) => x.Z - y.Z);
        }

        public void Remove(AbstractWidget widget) 
        {
            int i = Array.IndexOf(_widgets, widget);
            _widgets[i] = null;
            for (int x = 0; x < _widgets.Length; x++) 
            {
                if (x + 1 == _widgets.Length) break;
                if (_widgets[x] == null)
                {
                    _widgets[x] = _widgets[x + 1];
                    _widgets[x + 1] = null;
                }
            }

            Array.Resize(ref _widgets, _widgets.Length - 1);
        }

        private void SetIsShowFps(bool value)
        {
            if (_isShowFps == value) return;
            _isShowFps = value;
            if (value)
            {
                Add(_counter.Text);
            }
            else 
            {
                Remove(_counter.Text);
            }
            
        }

        private void Initialize()
        {
            _counter.Start();

            OnStart?.Invoke();
            CompositionTarget.Rendering += OnRendering;
        }

        private void OnRendering(object sender, EventArgs e)
        {
            OnUpdate?.Invoke();
            this.InvalidateVisual();
        }

        private void DrawRect(DrawingContext ctx, AbstractWidget rw, double xOffset = 0, double yOffset = 0)
        {
            if (rw.Shape is RoundedRectangleShape shape) 
            {
                ctx.DrawRoundedRectangle(
                    new SolidColorBrush(shape.Background),
                    new Pen(new SolidColorBrush(shape.OutlineColor), shape.OutlineThickness),
                    new Rect(rw.X + xOffset, rw.Y + yOffset, rw.Width, rw.Height),
                    shape.RadiusX, shape.RadiusY);
                return;
            }
            RectangleShape rs = rw.Shape as RectangleShape;

            ctx.DrawRectangle(
                new SolidColorBrush(rs.Background),
                new Pen(new SolidColorBrush(rs.OutlineColor), rs.OutlineThickness),
                new Rect(rw.X + xOffset, rw.Y + yOffset, rw.Width, rw.Height));
        }
        
        private void DrawText(DrawingContext ctx, AbstractWidget tw, double xOffset = 0, double yOffset = 0)
        {
            TextShape ts = tw.Shape as TextShape;
            ctx.DrawGeometry(
                new SolidColorBrush(ts.Foreground),
                new Pen(new SolidColorBrush(ts.OutlineColor), ts.OutlineThickness),
                new FormattedText(
                    ts.Text,
                    CultureInfo.CurrentCulture,
                    FlowDirection,
                    new Typeface(ts.FontFamily, ts.FontStyle, ts.FontWeight, ts.FontStretch),
                    ts.FontSize,
                    new SolidColorBrush(ts.Foreground),
                    1.25)
                    .BuildGeometry(new Point(tw.X + xOffset, tw.Y + yOffset)));
        }

        private void RenderParentable(
            DrawingContext ctx, ParentableWidget[] children, double x, double y) 
        {
            for (int i = 0; i < children.Length; i++)
            {
                if (_widgets[i] is ComponentWidget cw)
                {
                    AbstractComponent[] c = cw.GetComponents();
                    for (int ci = 0; ci < c.Length; ci++)
                    {
                        if (c[ci].IsEnable) c[ci].Update();
                    }
                }

                if (!GetIsInRenderingArea(children[i]))
                {
                    children[i].Shape.IsRendered = false;
                    continue;
                }
                ShapeType type = children[i].Shape.Type;
                if (type == ShapeType.Rectangle)
                {
                    DrawRect(ctx, children[i], x, y);
                }
                if (type == ShapeType.Text)
                {
                    DrawText(ctx, children[i], x, y);
                }

                if (children[i] is ParentableWidget pw)
                {
                    ParentableWidget[] c = pw.GetWidgets();
                    if (c.Length != 0)
                        RenderParentable(ctx, c,  children[i].X, children[i].Y);
                }

                _widgets[i].Shape.IsRendered = true;
            }
        }


        private bool GetIsInRenderingArea(AbstractWidget widget)
        {
            double w = this.ActualWidth;
            double h = this.ActualHeight;
            if (widget.X + widget.Width < 0 || widget.X > w ||
                widget.Y + widget.Height < 0 || widget.Y > h) return false;
            return true;
        }
    }
}
