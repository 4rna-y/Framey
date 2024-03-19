using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Framey.Input
{
    public class MouseInput
    {
        public Point GetMousePosition(IInputElement relativeTo = null)
        {
            Native.POINT p = new Native.POINT();
            Native.GetCursorPos(ref p);
            
            if (relativeTo is null) return new Point(p.X, p.Y);
            else return Mouse.GetPosition(relativeTo); 
        }

        public bool GetIsMouseButtonDown(MouseButtons btn)
        {
            if (btn == MouseButtons.Left) return Mouse.LeftButton == MouseButtonState.Pressed;
            else if (btn == MouseButtons.Right) return Mouse.RightButton == MouseButtonState.Released;
            else if (btn == MouseButtons.Middle) return Mouse.MiddleButton == MouseButtonState.Pressed;
            else if (btn == MouseButtons.X1) return Mouse.XButton1 == MouseButtonState.Pressed;
            else if (btn == MouseButtons.X2) return Mouse.XButton2 == MouseButtonState.Pressed;
            return false;
        }
    }
    public enum MouseButtons
    {
        Left,
        Middle,
        Right,
        X1,
        X2,
    }
}
