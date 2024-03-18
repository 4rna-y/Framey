using Framey.Widgets.Components.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Framey.Widgets.Base
{
    public abstract class AbstractWidget
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int Z { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public abstract IShape Shape { get; }
        
    }
}
