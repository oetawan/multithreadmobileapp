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
    public partial class ThreadSynchronizationForm : Form
    {
        private int counter;
        private bool thread1Running;
        private bool thread2Running;

        private Processing processing;
        private bool workerThread1Done;
        private bool workerThread2Done;

        private int eventWorkerThreadCounter = 0;
        private bool eventWorkerThreadDone = true;
        private Thread eventWorkerThread = null;
        private AutoResetEvent runOnceEvent = null;
        private ManualResetEvent runManyEvent = null;
        private bool useAutoResetEvent = false;
        private bool eventSampleRunning = false;

        public ThreadSynchronizationForm()
        {
            InitializeComponent();
        }

        private void WorkerThreadsFinished(object sender, System.EventArgs e)
        {
            if (!thread1Running && !thread2Running)
            {
                btnInterlockedSample.Enabled = true;
                txtInterlockedSample.Text = "The value of counter = " + counter.ToString();
            }
        }

        private void WorkerThreadsDone(object sender, System.EventArgs e)
        {
            if (workerThread1Done && workerThread2Done)
            {
                txtMonitorSample.Text = "Processing result: " +
                    processing.Counter.ToString();
                btnMonitorSample.Enabled = true;
            }
        }

        private void Thread1Function()
        {
            for (int i = 0; i < 10000000; i++)
            {
                Interlocked.Increment(ref counter);
            }
            thread1Running = false;
            this.Invoke(new EventHandler(WorkerThreadsFinished));
        }

        private void Thread2Function()
        {
            for (int i = 0; i < 10000000; i++)
            {
                Interlocked.Decrement(ref counter);
            }
            thread2Running = false;
            this.Invoke(new EventHandler(WorkerThreadsFinished));
        }

        private void Thread1Monitor()
        {
            processing.Function1();
            processing.Function2();
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
            workerThread1Done = true;
            this.Invoke(new EventHandler(WorkerThreadsDone));
        }

        private void Thread2Monitor()
        {
            processing.Function1();
            processing.Function2();
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
            workerThread2Done = true;
            this.Invoke(new EventHandler(WorkerThreadsDone));
        }
        
        private void btnInterlockedSample_Click(object sender, EventArgs e)
        {
            txtInterlockedSample.Text = "Worker Threads started";
            btnInterlockedSample.Enabled = false;
            counter = 0;
            Thread workerThread1 = new Thread(Thread1Monitor);
            Thread workerThread2 = new Thread(Thread2Monitor);
            thread1Running = true;
            thread2Running = true;
            workerThread1.Start();
            workerThread2.Start();
        }

        private void btnMonitorSample_Click(object sender, EventArgs e)
        {
            btnMonitorSample.Enabled = false;
            txtMonitorSample.Text = "Monitor sample running";
            processing = new Processing();
            workerThread1Done = false;
            workerThread2Done = false;
            Thread thread1 = new Thread(Thread1Monitor);
            Thread thread2 = new Thread(Thread2Monitor);
            thread1.Start();
            thread2.Start();
        }

        private void btnSetEvent_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Worker thread loop: " + eventWorkerThreadCounter.ToString();
            if (useAutoResetEvent)
            {
                runOnceEvent.Set();
            }
            else
            {
                if (btnSetEvent.Text == "Set Event")
                {
                    btnSetEvent.Text = "Reset Event";
                    runManyEvent.Set();
                }
                else
                {
                    btnSetEvent.Text = "Set Event";
                    runManyEvent.Reset();
                }
            }
        }

        private void btnEventSample_Click(object sender, EventArgs e)
        {
            if (eventSampleRunning)
            {
                btnSetEvent.Enabled = false;
                eventWorkerThreadDone = true;

                if (useAutoResetEvent)
                {
                    runOnceEvent.Set();
                }
                else
                {
                    runManyEvent.Set();
                }
                eventWorkerThread.Join();
                textBox1.Text = "";
                chkAutoReset.Enabled = true;
                btnEventSample.Text = "Event Sample";
                btnSetEvent.Text = "Set Event";
                eventSampleRunning = false;
            }
            else
            {
                eventWorkerThreadDone = false;
                eventWorkerThreadCounter = 0;
                chkAutoReset.Enabled = false;
                if (useAutoResetEvent)
                {
                    runOnceEvent = new AutoResetEvent(false);
                }
                else
                {
                    runManyEvent = new ManualResetEvent(false);
                }
                eventWorkerThread = new Thread(MyEventWorkerThread);
                eventWorkerThread.Start();
                btnSetEvent.Enabled = true;
                btnEventSample.Text = "Stop Event Sample";
                eventSampleRunning = true;
            }
        }

        private void MyEventWorkerThread()
        {
            WaitHandle nextEvent = useAutoResetEvent ? (WaitHandle)runOnceEvent :
                                                        (WaitHandle)runManyEvent;

            Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

            while (!eventWorkerThreadDone)
            {
                nextEvent.WaitOne();
                if (!eventWorkerThreadDone)
                {
                    eventWorkerThreadCounter++;
                    Thread.Sleep(10);
                }
            }
        }

        private void chkAutoReset_CheckStateChanged(object sender, EventArgs e)
        {
            useAutoResetEvent = chkAutoReset.Checked;
        }
    }
}