using Framey.Widgets.Base;
using Framey.Widgets.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Framey.Widgets
{
    public class PanelWidget : ParentableWidget
    {
        private RoundedRectangleShape _shape;
        public override RoundedRectangleShape Shape => _shape;

        public PanelWidget(int x, int y, int width, int height, Color background) :
            this(x, y, width, height, background, 0, Colors.Transparent, 0, 0)
        {

        }

        public PanelWidget(
            int x, int y, int width, int height, Color background,
            int outlineThickness, Color outlineColor,
            double radiusX, double radiusY)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            _shape = new RoundedRectangleShape(
                background, outlineThickness, outlineColor, radiusX, radiusY);
        }
    }
}
