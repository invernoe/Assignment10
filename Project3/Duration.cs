using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class Duration
    {
        public int Hours;
        public int Minutes;
        public int Seconds;

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Duration(int seconds)
        {
            Hours = seconds / 3600;
            Minutes = (seconds % 3600) / 60;
            Seconds = seconds % 60;
        }
        public Duration() : this(0, 0, 0) { }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Duration other = (Duration) obj;

            if(this.Hours - other.Hours == 0 
                && this.Minutes - other.Minutes == 0
                && this.Seconds - other.Seconds == 0)
                return true;
            
            return false;
        }

        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public override int GetHashCode()
        {
            return (Hours * 3600) + (Minutes * 60) + Seconds;
        }

        public static Duration operator +(Duration a, Duration b)
        {
            int seconds = a.Seconds + b.Seconds;
            int minutes = a.Minutes + b.Minutes + (seconds >= 60 ? 1 : 0);
            int hours = a.Hours + b.Hours + (minutes >= 60 ? 1 : 0);

            return new Duration(
                hours,
                minutes % 60,
                seconds % 60
                );
        }

        public static Duration operator +(Duration a, int seconds)
        {
            Duration b = new Duration(seconds);
            return a + b;
        }

        public static Duration operator +(int seconds, Duration a)
        {
            return a + seconds;
        }

        public static Duration operator ++(Duration a)
        {
            if (a.Minutes == 59)
            {
                a.Minutes = 0;
                a.Hours++;
            }
            else a.Minutes++;

            return a;
        }

        public static Duration operator --(Duration a)
        {
            if (a.Minutes == 0)
            {
                a.Minutes = 59;
                a.Hours--;
            }
            else a.Minutes--;

            return a;
        }

        public static Duration operator -(Duration a, Duration b)
        {
            int seconds = a.Seconds - b.Seconds;
            int minutes = a.Minutes - b.Minutes;
            int hours = a.Hours - b.Hours;

            if(seconds < 0)
            {
                minutes--;
                seconds += 60;
            }

            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }

            return new Duration(
                hours,
                minutes,
                seconds
                );
        }

        public static bool operator >(Duration a, Duration b)
        {
            int hours = a.Hours - b.Hours;
            if (hours == 0)
            {
                int minutes = a.Minutes - b.Minutes;
                if(minutes == 0)
                {
                    return (a.Seconds - b.Seconds) > 0;
                }

                return minutes > 0;
            }

            return hours > 0;
        }

        public static bool operator <(Duration a, Duration b)
        {
            int hours = a.Hours - b.Hours;
            if (hours == 0)
            {
                int minutes = a.Minutes - b.Minutes;
                if (minutes == 0)
                {
                    return (a.Seconds - b.Seconds) < 0;
                }

                return minutes < 0;
            }

            return hours < 0;
        }

        public static bool operator >=(Duration a, Duration b)
        {
            int hours = a.Hours - b.Hours;
            if (hours == 0)
            {
                int minutes = a.Minutes - b.Minutes;
                if (minutes == 0)
                {
                    return (a.Seconds - b.Seconds) >= 0;
                }

                return minutes >= 0;
            }

            return hours >= 0;
        }

        public static bool operator <=(Duration a, Duration b)
        {
            int hours = a.Hours - b.Hours;
            if (hours == 0)
            {
                int minutes = a.Minutes - b.Minutes;
                if (minutes == 0)
                {
                    return (a.Seconds - b.Seconds) <= 0;
                }

                return minutes <= 0;
            }

            return hours <= 0;
        }

        public static bool operator true(Duration a)
        {
            return a != null && a.Hours >= 0 && a.Minutes >= 0 && a.Seconds >= 0;
        }

        public static bool operator false(Duration a)
        {
            return a == null || a.Hours < 0 || a.Minutes < 0 || a.Seconds < 0;
        }

        public static explicit operator DateTime(Duration a)
        {
            return new DateTime(1, 1, 1, a.Hours, a.Minutes, a.Seconds);
        }
    }
}
