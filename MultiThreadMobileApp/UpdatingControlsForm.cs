using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MultiThreadMobileApp
{
    public partial class UpdatingControlsForm : Form
    {
        private Thread myThread;
        private delegate void UpdateTime(string dateTimeString);
        private bool workerThreadDone;

        public UpdatingControlsForm()
        {
            InitializeComponent();
        }

        private void MyWorkerThread()
        {
            UpdateTime timeUpdater = UpdateTimeMethod;
            string currentTime;
            while (!workerThreadDone)
            {
                currentTime = DateTime.Now.ToLongDateString() + " - " +
                                  DateTime.Now.ToLongTimeString();
                this.Invoke(timeUpdater, new object[] { currentTime });
                Thread.Sleep(0);
            }
            string statusInfo = "MyWorkerThread terminated!";
            this.BeginInvoke(timeUpdater, new object[] { statusInfo });
        }

        private void UpdateTimeMethod(string dateTimeString)
        {
            statusBar1.Text = dateTimeString;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            statusBar1.Text = "";
            workerThreadDone = false;
            myThread = new Thread(MyWorkerThread);
            myThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            workerThreadDone = true;
            myThread.Join();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}