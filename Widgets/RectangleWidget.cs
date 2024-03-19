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
    public class RectangleWidget : AbstractWidget
    {
        private RectangleShape _shape;
        public override RectangleShape Shape => _shape;

        public RectangleWidget(int x, int y, int width, int height, Color background) :
            this(x, y, width, height, background, 0, Colors.Transparent)
        {
            
        }

        public RectangleWidget(
            int x, int y, int width, int height, Color background, 
            int outlineThickness, Color outlineColor)
        {
            X = x; 
            Y = y; 
            Width = width; 
            Height = height;

            _shape = new RectangleShape(background, outlineThickness, outlineColor);
        }
    }
}
