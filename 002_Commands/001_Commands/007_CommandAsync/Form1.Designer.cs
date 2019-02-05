namespace CBS.ADO_NET.ExecuteAsync
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.getdataAsyncButtom = new System.Windows.Forms.Button();
            this.getDataButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // getdataAsyncButtom
            // 
            this.getdataAsyncButtom.Location = new System.Drawing.Point(414, 102);
            this.getdataAsyncButtom.Name = "getdataAsyncButtom";
            this.getdataAsyncButtom.Size = new System.Drawing.Size(89, 23);
            this.getdataAsyncButtom.TabIndex = 0;
            this.getdataAsyncButtom.Text = "Execute Async";
            this.getdataAsyncButtom.UseVisualStyleBackColor = true;
            this.getdataAsyncButtom.Click += new System.EventHandler(this.getdataAsyncButtom_Click);
            // 
            // getDataButton
            // 
            this.getDataButton.Location = new System.Drawing.Point(13, 102);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(75, 23);
            this.getDataButton.TabIndex = 2;
            this.getDataButton.Text = "Execute";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(490, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(13, 43);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(490, 23);
            this.progressBar2.TabIndex = 4;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(13, 73);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(490, 23);
            this.progressBar3.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 131);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.getDataButton);
            this.Controls.Add(this.getdataAsyncButtom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

       
        #endregion

        private System.Windows.Forms.Button getdataAsyncButtom;
        private System.Windows.Forms.Button getDataButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
    }
}

