
namespace Asynchronous_Programming
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pictureLoading = new System.Windows.Forms.PictureBox();
            this.pgReport = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(255, 247);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(242, 45);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 1;
            // 
            // pictureLoading
            // 
            this.pictureLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictureLoading.Image")));
            this.pictureLoading.Location = new System.Drawing.Point(208, 82);
            this.pictureLoading.Name = "pictureLoading";
            this.pictureLoading.Size = new System.Drawing.Size(161, 139);
            this.pictureLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLoading.TabIndex = 2;
            this.pictureLoading.TabStop = false;
            this.pictureLoading.Visible = false;
            // 
            // pgReport
            // 
            this.pgReport.Location = new System.Drawing.Point(414, 82);
            this.pgReport.Name = "pgReport";
            this.pgReport.Size = new System.Drawing.Size(126, 23);
            this.pgReport.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(400, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pgReport);
            this.Controls.Add(this.pictureLoading);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.PictureBox pictureLoading;
        private System.Windows.Forms.ProgressBar pgReport;
        private System.Windows.Forms.Button btnCancel;
    }
}

