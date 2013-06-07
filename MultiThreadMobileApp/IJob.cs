using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadMobileApp
{
    public interface IJob
    {
        void Execute();
    }

    public interface IRunForeverJob: IJob
    {
    }

    public interface IScheduledJob : IJob
    {
        DateTime Time { get; }
    }
}