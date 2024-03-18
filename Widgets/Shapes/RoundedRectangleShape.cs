using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Framey.Widgets.Shapes
{
    public class RoundedRectangleShape : RectangleShape
    {
        public double RadiusX { get; set; }
        public double RadiusY { get; set; }

        public RoundedRectangleShape(
            Color background, int outlineThickness, Color outlineColor, double radiusX, double radiusY) : base(background, outlineThickness, outlineColor)
        {
            RadiusX = radiusX;
            RadiusY = radiusY;
        }
    }
}
