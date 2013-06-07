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
    public partial class ThreadPoolForm : Form
    {
        private AutoResetEvent doneEvent;
        private int threadCounter;
        private int threadPoolCounter;

        public ThreadPoolForm()
        {
            InitializeComponent();
        }

        private void MyWorkerThread()
        {
            Interlocked.Increment(ref threadCounter);
            if (threadCounter == 200)
                doneEvent.Set();
        }

        private void MyWaitCallBack(object stateInfo)
        {
            Interlocked.Increment(ref threadPoolCounter);
            if (threadPoolCounter == 200)
                doneEvent.Set();
        }

        private void btnCrateThread_Click(object sender, EventArgs e)
        {
            btnCrateThread.Enabled = false;
            threadCounter = 0;
            doneEvent = new AutoResetEvent(false);
            textBox1.Text = "";
            int elapsedTime = Environment.TickCount;
            for (int i = 0; i < 200; i++)
            {
                Thread workerThread = new Thread(MyWorkerThread);
                workerThread.Start();
            }
            doneEvent.WaitOne();
            elapsedTime = Environment.TickCount - elapsedTime;
            textBox1.Text = "Creating threads: " + elapsedTime.ToString() + " msec";
            btnCrateThread.Enabled = true;
        }

        private void btnCreateThreadPool_Click(object sender, EventArgs e)
        {
            btnCreateThreadPool.Enabled = false;
            threadPoolCounter = 0;
            doneEvent = new AutoResetEvent(false);
            textBox2.Text = "";
            int elapsedTime = Environment.TickCount;
            for (int i = 0; i < 200; i++)
            {
                ThreadPool.QueueUserWorkItem(MyWaitCallBack);
            }
            doneEvent.WaitOne();
            elapsedTime = Environment.TickCount - elapsedTime;
            textBox2.Text = "Creating threads: " + elapsedTime.ToString();
            btnCreateThreadPool.Enabled = true;
        }
    }
}