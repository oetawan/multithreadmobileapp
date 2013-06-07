namespace MultiThreadMobileApp
{
    partial class ThreadPoolForm
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
            this.btnCrateThread = new System.Windows.Forms.Button();
            this.btnCreateThreadPool = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCrateThread
            // 
            this.btnCrateThread.Location = new System.Drawing.Point(14, 79);
            this.btnCrateThread.Name = "btnCrateThread";
            this.btnCrateThread.Size = new System.Drawing.Size(209, 20);
            this.btnCrateThread.TabIndex = 2;
            this.btnCrateThread.Text = "Create Thread";
            this.btnCrateThread.Click += new System.EventHandler(this.btnCrateThread_Click);
            // 
            // btnCreateThreadPool
            // 
            this.btnCreateThreadPool.Location = new System.Drawing.Point(14, 176);
            this.btnCreateThreadPool.Name = "btnCreateThreadPool";
            this.btnCreateThreadPool.Size = new System.Drawing.Size(209, 24);
            this.btnCreateThreadPool.TabIndex = 3;
            this.btnCreateThreadPool.Text = "Create Thread Pool";
            this.btnCreateThreadPool.Click += new System.EventHandler(this.btnCreateThreadPool_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(209, 21);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 149);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(209, 21);
            this.textBox2.TabIndex = 5;
            // 
            // ThreadPoolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCreateThreadPool);
            this.Controls.Add(this.btnCrateThread);
            this.Menu = this.mainMenu1;
            this.Name = "ThreadPoolForm";
            this.Text = "Thread vs ThreadPool";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrateThread;
        private System.Windows.Forms.Button btnCreateThreadPool;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}