namespace CBS.ADO_NET.TableConstraints
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
            this.parentGridView = new System.Windows.Forms.DataGridView();
            this.childDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.parentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // parentGridView
            // 
            this.parentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parentGridView.Location = new System.Drawing.Point(13, 13);
            this.parentGridView.Name = "parentGridView";
            this.parentGridView.Size = new System.Drawing.Size(698, 150);
            this.parentGridView.TabIndex = 0;
            // 
            // childDataGridView
            // 
            this.childDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.childDataGridView.Location = new System.Drawing.Point(13, 170);
            this.childDataGridView.Name = "childDataGridView";
            this.childDataGridView.Size = new System.Drawing.Size(698, 150);
            this.childDataGridView.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 337);
            this.Controls.Add(this.childDataGridView);
            this.Controls.Add(this.parentGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.parentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView parentGridView;
        private System.Windows.Forms.DataGridView childDataGridView;
    }
}

