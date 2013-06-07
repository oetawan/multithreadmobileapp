using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace MultiThreadMobileApp
{
    public class JobScheduler
    {
        Timer _timer;
        List<IJob> _jobs;
        volatile bool _running = false;
        volatile bool _busy = false;
        
        public JobScheduler(int interval)
        {
            _jobs = new List<IJob>();
            _timer = new Timer(Timer_callback, null, interval, interval);
        }

        public void Register(IJob job)
        {
            try
            {
                Monitor.Enter(this);
                if (!_jobs.Exists(j => j.Equals(job)))
                {
                    _jobs.Add(job);
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public void Start()
        {
            try
            {
                Monitor.Enter(this);
                _running = true;
                _busy = false;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public void Stop()
        {
            try
            {
                Monitor.Enter(this);
                
                while (Busy())
                {
                    Thread.Sleep(100);
                }
                
                _running = false;
                _busy = false;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        private void Timer_callback(object state)
        {
            if (NotRunning())
                return;
            if (Busy())
                return;

            ExecuteAllJobs();
        }

        private bool Busy()
        {
            return _busy == true;
        }

        private bool NotRunning()
        {
            return _running == false;
        }

        private void ExecuteAllJobs()
        {
            try
            {
                Monitor.Enter(this);
                _busy = true;
                _jobs.Where(job => job is IRunForeverJob).ToList().ForEach(job => job.Execute());
                _jobs.Where(job => job is IScheduledJob && DateTime.Now >= ((IScheduledJob)job).Time).ToList().ForEach(job =>
                {
                    job.Execute();
                });
                _busy = false;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
}