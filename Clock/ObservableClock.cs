using Assisticant.Fields;
using System;
using System.Timers;

namespace Clock
{
    class ObservableClock : OSClock, IDisposable
    {
        readonly Timer _timer;
        readonly Observable<DateTime> _time;

        public ObservableClock()
        {
            _time = new Observable<DateTime>(DateTime.Now);

            _timer = new Timer(1000);
            _timer.AutoReset = true;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        public DateTime GetTime() => _time;

        public void Dispose()
        {
            _timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _time.Value = e.SignalTime;
        }
    }
}
