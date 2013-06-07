using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadMobileApp
{
    public class ShowTimeJob: IRunForeverJob
    {
        Action<DateTime> _showTime;
        public ShowTimeJob(Action<DateTime> showTime)
        {
            _showTime = showTime;
        }

        #region IJob Members

        public void Execute()
        {
            if (_showTime != null)
            {
                _showTime(DateTime.Now);
            }
        }

        #endregion
    }
}