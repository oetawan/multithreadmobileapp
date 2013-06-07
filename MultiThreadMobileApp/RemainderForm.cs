using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiThreadMobileApp
{
    public partial class RemainderForm : Form
    {
        JobScheduler js;
        delegate void ShowTimeHandler(DateTime time);
        delegate void ShowRemainderHandler(string msg);
        
        public RemainderForm()
        {
            InitializeComponent();
            js = new JobScheduler(1000);
            js.Register(new ShowTimeJob(ShowTime));
            js.Register(new RemainderJob(ShowRemainder));
        }

        private void ShowTime(DateTime time)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowTimeHandler(ShowTime), time);
            }
            else
            {
                listView1.Columns[0].Text = time.ToLongTimeString();
            }
        }

        private void ShowRemainder(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowRemainderHandler(ShowRemainder), msg);
            }
            else
            {
                listView1.Items.Add(new ListViewItem(msg));
                listView1.EnsureVisible(listView1.Items.Count - 1);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            js.Start();
            menuItem1.Enabled = false;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            js.Stop();
            menuItem1.Enabled = true;
        }
    }
}