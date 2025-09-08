namespace TimeLibrary
{
    public class Time
    {
        private int _hours;
        private int _minutes;
        private int _seconds;
        private int _milliseconds;

        // --- Constructores ---
        public int Hours { get => _hours; set => _hours = value; }
        public int Minutes { get => _minutes; set => _minutes = value; }
        public int Seconds { get => _seconds; set => _seconds = value; }
        public int Milliseconds { get => _milliseconds; set => _milliseconds = value; }
        public Time() : this(0, 0, 0, 0) { }

        public Time(int hours) : this(hours, 0, 0, 0) { }

        public Time(int hours, int minutes) : this(hours, minutes, 0, 0) { }

        public Time(int hours, int minutes, int seconds) : this(hours, minutes, seconds, 0) { }

        public Time(int hours, int minutes, int seconds, int milliseconds)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentOutOfRangeException(nameof(hours), $"The hour: {hours}, is not valid.");
            if (minutes < 0 || minutes > 59)
                throw new ArgumentOutOfRangeException(nameof(minutes), $"The minutes: {minutes}, is not valid.");
            if (seconds < 0 || seconds > 59)
                throw new ArgumentOutOfRangeException(nameof(seconds), $"The seconds: {seconds}, is not valid.");
            if (milliseconds < 0 || milliseconds > 999)
                throw new ArgumentOutOfRangeException(nameof(milliseconds), $"The milliseconds: {milliseconds}, is not valid.");

            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _milliseconds = milliseconds;
        }

        


        public override string ToString()
        {
            DateTime dt = new DateTime(1, 1, 1, _hours, _minutes, _seconds, _milliseconds);
            return dt.ToString("hh:mm:ss.fff tt");
        }

        public long ToMilliseconds()
        {
            return (long)_hours * 3600000 + (long)_minutes * 60000 + (long)_seconds * 1000 + _milliseconds;
        }

        public long ToSeconds()
        {
            return (long)_hours * 3600 + (long)_minutes * 60 + _seconds;
        }

        public long ToMinutes()
        {
            return (long)_hours * 60 + _minutes;
        }

        public bool IsOtherDay(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            long oneDayMs = 24L * 60 * 60 * 1000;
            return totalMs >= oneDayMs;
        }

        public Time Add(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            long oneDayMs = 24L * 60 * 60 * 1000;
            totalMs %= oneDayMs; 

            int hours = (int)(totalMs / 3600000); totalMs %= 3600000;
            int mimutes = (int)(totalMs / 60000); totalMs %= 60000;
            int seconds = (int)(totalMs / 1000); totalMs %= 1000;
            int milliseconds = (int)totalMs;

            return new Time(_hours, _minutes, _seconds, _milliseconds);
        }

    }
}