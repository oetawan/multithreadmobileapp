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
    public partial class MainForm : Form
    {
        Thread workerThread;
        
        public MainForm()
        {
            InitializeComponent();
            mniStop.Enabled = false;
        }

        private void mniStart_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "\r\nWorker Thread Started.";
            mniStart.Enabled = false;
            mniStop.Enabled = true;
            workerThread = new Thread(BackgroundProcessing);
            workerThread.IsBackground = true;
            workerThread.Start();
            lblStatus.Text += "\r\nIs background: " + workerThread.IsBackground.ToString();
        }

        private void mniStop_Click(object sender, EventArgs e)
        {
            workerThread.Abort();
            workerThread.Join();
            lblStatus.Text = "\r\nWorker Thread terminated";
            mniStart.Enabled = true;
            mniStop.Enabled = false;
        }

        private void BackgroundProcessing()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(0);
                }
            }
            catch (ThreadAbortException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Thread.Sleep(2000);
            }
        }
    }
}