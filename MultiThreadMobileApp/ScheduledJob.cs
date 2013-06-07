using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadMobileApp
{
    public abstract class ScheduledJob: IScheduledJob
    {
        int _repeatIntervalInMinutes;
        public ScheduledJob(DateTime date, int repeatIntervalInMinutes)
        {
            Time = date;
            _repeatIntervalInMinutes = repeatIntervalInMinutes;
        }

        #region IScheduledJob Members

        public DateTime Time { get; private set; }

        #endregion

        #region IJob Members

        public void Execute()
        {
            DoExecute();
            Time = DateTime.Now.AddMinutes(_repeatIntervalInMinutes);
        }

        #endregion

        protected abstract void DoExecute();
    }
}