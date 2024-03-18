using Framey.Widgets.Base;
using Framey.Widgets.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Framey.Widgets.Components
{
    public class PhisicalEffectComponent : AbstractComponent
    {
        public Vector _v;
        public PhisicalEffectComponent()
        { 
            _v = new Vector();
        }

        public override void Update()
        {
            double dt = Time.DeltaTime;

            _v.Y += 1d / 2d * 9.8d * dt * 25;

            Parent.X += _v.X;
            Parent.Y += _v.Y * dt;
        }
    }
}
