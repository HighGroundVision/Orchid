using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid
{
    public class Timer : IDisposable
    {
        System.Diagnostics.Stopwatch watch;

        string message;

        public Timer(string msg)
        {
            message = msg;
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
        }

        public void Dispose()
        {
            watch.Stop();
            System.Diagnostics.Trace.TraceInformation("{0}: '{1}'", message, watch.Elapsed.ToString());
        }
    }
}
