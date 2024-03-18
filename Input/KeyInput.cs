using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Framey.Input
{
    public class KeyInput
    {
        private List<int> _downKeys;
        public KeyInput()
        {
            _downKeys = new List<int>();
        }

        public bool IsKeyDown(Key k) => Keyboard.IsKeyDown(k);
        public bool IsKeyUp(Key k) => Keyboard.IsKeyUp(k);
        public bool IsKeyDownOnce(Key k)
        {
            if (IsKeyDown(k))
            {
                if (_downKeys.Contains((int)k)) return false;
                _downKeys.Add((int)k);
                return true;
            }
            else
            if (IsKeyUp(k)) 
            {
                if (_downKeys.Contains((int)k))
                    _downKeys.Remove((int)k);
            }
            return false;
        }
    }
}
