using Framey.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framey.Widgets.Base
{
    public abstract class ParentableWidget : AbstractWidget
    {
        protected ParentableWidget[] Children;

        protected ParentableWidget()
        {
            Children = Array.Empty<ParentableWidget>();
        }

        public void AddWidget(ParentableWidget widget)
        {
            ArrayHelper.Add(ref Children, widget);
        }

        public ParentableWidget GetWidget(int index) 
        {
            return Children[index];
        }

        public ParentableWidget[] GetWidgets()
        {
            return Children;
        }

        public bool RemoveWidget(ParentableWidget widget) 
        {
            int i = Array.IndexOf(Children, widget);
            if (i == -1) return false;
            Children[i] = null;
            ArrayHelper.Adjust(ref Children);
            return true;
        }
    }
}
