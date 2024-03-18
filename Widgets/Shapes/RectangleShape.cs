using Framey.Widgets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Framey.Widgets.Shapes
{
    public class RectangleShape : IShape
    {
        public ShapeType Type => ShapeType.Rectangle;
        public bool IsRendered {  get; set; }

        public Color Background { get; set; }
        public int OutlineThickness { get; set; }
        public Color OutlineColor { get; set; }

        public RectangleShape(Color background, int outlineThickness, Color outlineColor) 
        {
            Background = background;
            OutlineThickness = outlineThickness;
            OutlineColor = outlineColor;
        }
    }
}
