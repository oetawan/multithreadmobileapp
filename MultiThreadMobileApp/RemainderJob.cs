using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadMobileApp
{
    public class RemainderJob: ScheduledJob
    {
        Action<string> _showMessageAction;
        string _msg;
        public RemainderJob(DateTime date, int repeatInvervalInMinutes, Action<string> showMessageAction, string msg)
            : base(date, repeatInvervalInMinutes)
        {
            _showMessageAction = showMessageAction;
            _msg = msg;
        }

        protected override void DoExecute()
        {
            if (_showMessageAction != null)
                _showMessageAction(_msg);
        }
    }
}