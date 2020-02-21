using System;
using System.Threading;
namespace DualityEngine
{
    public static class RateLimiter
    {
        private static long LastCallMillis { get; set; } = 0;

        public static void LimitRate(int timesPerSecond)
        {
            while (CurrMillis - LastCallMillis < 1000 / timesPerSecond) ;
            LastCallMillis = CurrMillis;
        }

        private static long CurrMillis
        {
            get
            {
                return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
        }
    }
}
