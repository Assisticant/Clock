namespace Clock
{
    class TimeDisplay
    {
        readonly OSClock _clock;

        public TimeDisplay(OSClock clock)
        {
            _clock = clock;
        }

        public string Time => $"{_clock.GetTime():T}";
    }
}
