using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framey
{
    public class Time
    {
        public static double DeltaTime { get => GetDeltaTime(); }
        public static double GameTime { get => GetGameTime(); }
        public static int Fps { get => GetFps(); }

        private static FrameRateCounter _counter;
        private static Dictionary<int, double> _timerMap;
        public Time(FrameRateCounter counter) 
        {
            _counter = counter;
            _timerMap = new Dictionary<int, double>();
        }

        public static int CreateTimer()
        {
            int i = _timerMap.Count;
            _timerMap.Add(i, GameTime);
            return i;
        }

        public static double GetTimer(int id)
        {
            if (!_timerMap.ContainsKey(id)) return -1;
            return GameTime - _timerMap[id];
        }

        public static void DisposeTimer(int id) 
        {
            if (!_timerMap.ContainsKey(id)) return;
            _timerMap.Remove(id);
        }
        
        private static double GetDeltaTime()
        {
            return _counter.DeltaTime;
        }

        private static double GetGameTime()
        {
            return _counter.GameTime;
        }

        private static int GetFps()
        {
            return _counter.Fps;
        }

        
    }
}
