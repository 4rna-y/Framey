using Framey.Widgets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Framey.Widgets.Shapes
{
    public class TextShape : IShape
    {
        public ShapeType Type => ShapeType.Text;
        public bool IsRendered { get; set; }

        public string Text { get; set; }
        public Color Foreground { get; set; }
        public FontFamily FontFamily { get; set; }
        public double FontSize { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontWeight FontWeight { get; set; }
        public FontStretch FontStretch { get; set; }
        public double OutlineThickness { get; set; }
        public Color OutlineColor { get; set; }

        public TextShape(
            string text,
            Color innerLineColor,
            FontFamily family,
            double fontSize,
            FontStyle style,
            FontWeight weight,
            FontStretch stretch,
            double outlineThickness,
            Color outlineColor)
        {
            Text = text;
            Foreground = innerLineColor;
            FontFamily = family;
            FontSize = fontSize;
            FontSize = fontSize;
            FontStyle = style;
            FontWeight = weight;
            FontStretch = stretch;
            OutlineThickness = outlineThickness;
            OutlineColor = outlineColor;
        }
    }
}
