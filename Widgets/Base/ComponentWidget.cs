using Framey.Helper;
using Framey.Widgets.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framey.Widgets.Base
{
    public abstract class ComponentWidget : ParentableWidget
    {
        protected AbstractComponent[] Components;

        protected ComponentWidget()
        {
            Components = Array.Empty<AbstractComponent>();
        }

        public void AddComponent<T>() where T : AbstractComponent, new()
        {
            T c = new T();
            c.Parent = this;

            ArrayHelper.Add(ref Components, c);
        }
        public bool RemoveComponent<T>(T component) where T : AbstractComponent
        {
            int i = Array.IndexOf(Components, component);
            if (i == -1) return false;
            Components[i] = null;
            ArrayHelper.Adjust(ref Components);
            return true;
        }

        public T GetComponent<T>() where T : AbstractComponent
        {
            T component = null;
            for (int i = 0; i < Components.Length; i++)
            {
                if (Components[i] is T) component = (T)Components[i];
            }
            return component;
        }
        public AbstractComponent[] GetComponents() => Components;
    }
}
