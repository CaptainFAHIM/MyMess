namespace MyMess
{
    partial class ResetMonthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetMonthForm));
            this.label22 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.newMonthNo = new System.Windows.Forms.Button();
            this.newMonthYes = new System.Windows.Forms.Button();
            this.newMonthNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DimGray;
            this.label22.Location = new System.Drawing.Point(12, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(256, 20);
            this.label22.TabIndex = 26;
            this.label22.Text = "Are you sure to start a new month?";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Red;
            this.label37.Location = new System.Drawing.Point(262, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(210, 20);
            this.label37.TabIndex = 41;
            this.label37.Text = "(All of your data will be gone)";
            // 
            // newMonthNo
            // 
            this.newMonthNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.newMonthNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newMonthNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMonthNo.Location = new System.Drawing.Point(138, 126);
            this.newMonthNo.Name = "newMonthNo";
            this.newMonthNo.Size = new System.Drawing.Size(116, 41);
            this.newMonthNo.TabIndex = 42;
            this.newMonthNo.Text = "No";
            this.newMonthNo.UseVisualStyleBackColor = false;
            this.newMonthNo.Click += new System.EventHandler(this.newMonthNo_Click);
            // 
            // newMonthYes
            // 
            this.newMonthYes.BackColor = System.Drawing.Color.Red;
            this.newMonthYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newMonthYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMonthYes.Location = new System.Drawing.Point(16, 126);
            this.newMonthYes.Name = "newMonthYes";
            this.newMonthYes.Size = new System.Drawing.Size(116, 41);
            this.newMonthYes.TabIndex = 43;
            this.newMonthYes.Text = "Yes";
            this.newMonthYes.UseVisualStyleBackColor = false;
            this.newMonthYes.Click += new System.EventHandler(this.newMonthYes_Click);
            // 
            // newMonthNameTxt
            // 
            this.newMonthNameTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.newMonthNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMonthNameTxt.Location = new System.Drawing.Point(16, 78);
            this.newMonthNameTxt.Multiline = true;
            this.newMonthNameTxt.Name = "newMonthNameTxt";
            this.newMonthNameTxt.Size = new System.Drawing.Size(298, 42);
            this.newMonthNameTxt.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "New month name:";
            // 
            // ResetMonthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 179);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newMonthNameTxt);
            this.Controls.Add(this.newMonthYes);
            this.Controls.Add(this.newMonthNo);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResetMonthForm";
            this.Text = "Start new Month";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button newMonthNo;
        private System.Windows.Forms.Button newMonthYes;
        private System.Windows.Forms.TextBox newMonthNameTxt;
        private System.Windows.Forms.Label label1;
    }
}