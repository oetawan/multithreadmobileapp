using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadMobileApp
{
    public class RemainderJob: IScheduledJob
    {
        Action<string> _showMessage;

        public RemainderJob(Action<string> showMessage)
        {
            _showMessage = showMessage;
            Time = DateTime.Now.AddMinutes(5);
        }

        #region IScheduledJob Members

        public DateTime Time { get; private set; }

        #endregion

        #region IJob Members

        public void Execute()
        {
            if (_showMessage != null)
                _showMessage("Go home: " + DateTime.Now.ToShortTimeString());
            Time = DateTime.Now.AddMinutes(1);
        }

        #endregion
    }
}