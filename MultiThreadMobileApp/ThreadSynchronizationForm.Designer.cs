namespace MultiThreadMobileApp
{
    partial class ThreadSynchronizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtInterlockedSample = new System.Windows.Forms.TextBox();
            this.btnInterlockedSample = new System.Windows.Forms.Button();
            this.txtMonitorSample = new System.Windows.Forms.TextBox();
            this.btnMonitorSample = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkAutoReset = new System.Windows.Forms.CheckBox();
            this.btnSetEvent = new System.Windows.Forms.Button();
            this.btnEventSample = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInterlockedSample
            // 
            this.txtInterlockedSample.Location = new System.Drawing.Point(3, 3);
            this.txtInterlockedSample.Name = "txtInterlockedSample";
            this.txtInterlockedSample.Size = new System.Drawing.Size(234, 21);
            this.txtInterlockedSample.TabIndex = 0;
            // 
            // btnInterlockedSample
            // 
            this.btnInterlockedSample.Location = new System.Drawing.Point(27, 30);
            this.btnInterlockedSample.Name = "btnInterlockedSample";
            this.btnInterlockedSample.Size = new System.Drawing.Size(186, 20);
            this.btnInterlockedSample.TabIndex = 1;
            this.btnInterlockedSample.Text = "Interlocked Sample";
            this.btnInterlockedSample.Click += new System.EventHandler(this.btnInterlockedSample_Click);
            // 
            // txtMonitorSample
            // 
            this.txtMonitorSample.Location = new System.Drawing.Point(3, 67);
            this.txtMonitorSample.Name = "txtMonitorSample";
            this.txtMonitorSample.Size = new System.Drawing.Size(234, 21);
            this.txtMonitorSample.TabIndex = 2;
            // 
            // btnMonitorSample
            // 
            this.btnMonitorSample.Location = new System.Drawing.Point(27, 94);
            this.btnMonitorSample.Name = "btnMonitorSample";
            this.btnMonitorSample.Size = new System.Drawing.Size(186, 20);
            this.btnMonitorSample.TabIndex = 3;
            this.btnMonitorSample.Text = "Monitor Sample";
            this.btnMonitorSample.Click += new System.EventHandler(this.btnMonitorSample_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 21);
            this.textBox1.TabIndex = 4;
            // 
            // chkAutoReset
            // 
            this.chkAutoReset.Location = new System.Drawing.Point(47, 169);
            this.chkAutoReset.Name = "chkAutoReset";
            this.chkAutoReset.Size = new System.Drawing.Size(142, 20);
            this.chkAutoReset.TabIndex = 5;
            this.chkAutoReset.Text = "Auto Reset Event";
            this.chkAutoReset.CheckStateChanged += new System.EventHandler(this.chkAutoReset_CheckStateChanged);
            // 
            // btnSetEvent
            // 
            this.btnSetEvent.Location = new System.Drawing.Point(27, 195);
            this.btnSetEvent.Name = "btnSetEvent";
            this.btnSetEvent.Size = new System.Drawing.Size(186, 20);
            this.btnSetEvent.TabIndex = 6;
            this.btnSetEvent.Text = "Set Event";
            this.btnSetEvent.Click += new System.EventHandler(this.btnSetEvent_Click);
            // 
            // btnEventSample
            // 
            this.btnEventSample.Location = new System.Drawing.Point(27, 221);
            this.btnEventSample.Name = "btnEventSample";
            this.btnEventSample.Size = new System.Drawing.Size(186, 20);
            this.btnEventSample.TabIndex = 7;
            this.btnEventSample.Text = "Event Sample";
            this.btnEventSample.Click += new System.EventHandler(this.btnEventSample_Click);
            // 
            // ThreadSynchronizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnEventSample);
            this.Controls.Add(this.btnSetEvent);
            this.Controls.Add(this.chkAutoReset);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnMonitorSample);
            this.Controls.Add(this.txtMonitorSample);
            this.Controls.Add(this.btnInterlockedSample);
            this.Controls.Add(this.txtInterlockedSample);
            this.Menu = this.mainMenu1;
            this.Name = "ThreadSynchronizationForm";
            this.Text = "Thread Synchronization";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtInterlockedSample;
        private System.Windows.Forms.Button btnInterlockedSample;
        private System.Windows.Forms.TextBox txtMonitorSample;
        private System.Windows.Forms.Button btnMonitorSample;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkAutoReset;
        private System.Windows.Forms.Button btnSetEvent;
        private System.Windows.Forms.Button btnEventSample;
    }
}