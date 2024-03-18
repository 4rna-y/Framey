using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framey.Widgets.Base
{
    public interface IShape
    {
        public ShapeType Type { get; }
        public bool IsRendered { get; set; }
    }
}
