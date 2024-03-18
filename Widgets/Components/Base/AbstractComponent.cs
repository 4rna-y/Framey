using Framey.Widgets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framey.Widgets.Components.Base
{
    public abstract class AbstractComponent
    {
        public bool IsEnable { get; set; }
        public AbstractWidget Parent { get; set; }
        public abstract void Update();
    }
}
