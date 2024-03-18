using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Framey.Helper
{
    public class ArrayHelper
    {
        public static void Adjust<T>(ref T[] array) where T : class
        {
            for (int i = 0; i < array.Length; i++) 
            {
                if (i + 1 == array.Length - 1) break;
                if (array[i] == null)
                {
                    array[i] = array[i + 1];
                    array[i + 1] = null;
                }
            }

            int last = GetLastIndex(array);
            if (array.Length - 1 == last) return;
            Array.Resize(ref array, last + 1);
        }

        public static void Add<T>(ref T[] array, T element)
        {
            int last = GetLastIndex(array);
            int insertIndex;
            if (array.Length -1 == last || array.Length == 0)
            {
                Array.Resize(ref array, array.Length + 1);
                insertIndex = array.Length - 1;
            }
            else
            {
                insertIndex = last + 1;
            }

            array[insertIndex] = element;
        }

        public static int GetLastIndex<T>(T[] array)
        {
            int i = 0;
            for (; i < array.Length; i++) 
            {
                if (array[i] == null) break;
            }
            return i;
        }
    }
}
