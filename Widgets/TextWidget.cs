using Framey.Widgets.Base;
using Framey.Widgets.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Framey.Widgets
{
    public class TextWidget : ParentableWidget
    {
        private TextShape _shape;

        public override TextShape Shape => _shape;

        public TextWidget(double x, double y, string text, Color foreground) :
            this(x, y, text, foreground, new FontFamily(), 12, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal)
        {
            
        }

        public TextWidget(
            double x, double y,
            string text, Color foreground,
            FontFamily family, double fontSize, FontStyle fontStyle, FontWeight weight, FontStretch fontStretch) :
            this(x, y, text, foreground, family, fontSize, fontStyle, weight, fontStretch, 0, Colors.Transparent)
        {

        }

        public TextWidget(
            double x, double y,
            string text, Color foreground,
            FontFamily family, double fontSize, FontStyle fontStyle, FontWeight weight, FontStretch fontStretch,
            double outlineThickness, Color outlineColor)
        {
            X = x; 
            Y = y;
            _shape = new TextShape(
                text, foreground, family, fontSize, fontStyle, weight, fontStretch, outlineThickness, outlineColor);
        }
    }
}
