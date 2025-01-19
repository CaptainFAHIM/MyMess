namespace MyMess
{
    partial class PasswordChangeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.passChangeTxt = new System.Windows.Forms.TextBox();
            this.passChangeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.passChangeRetypeTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.passChangeTxt);
            this.panel1.Controls.Add(this.passChangeBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.passChangeRetypeTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(116, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 358);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Enter new password";
            // 
            // passChangeTxt
            // 
            this.passChangeTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.passChangeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passChangeTxt.Location = new System.Drawing.Point(27, 116);
            this.passChangeTxt.Multiline = true;
            this.passChangeTxt.Name = "passChangeTxt";
            this.passChangeTxt.PasswordChar = '*';
            this.passChangeTxt.Size = new System.Drawing.Size(298, 40);
            this.passChangeTxt.TabIndex = 13;
            // 
            // passChangeBtn
            // 
            this.passChangeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.passChangeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.passChangeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passChangeBtn.Location = new System.Drawing.Point(27, 245);
            this.passChangeBtn.Name = "passChangeBtn";
            this.passChangeBtn.Size = new System.Drawing.Size(298, 41);
            this.passChangeBtn.TabIndex = 12;
            this.passChangeBtn.Text = "Change password";
            this.passChangeBtn.UseVisualStyleBackColor = false;
            this.passChangeBtn.Click += new System.EventHandler(this.passChangeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Re-type new password";
            // 
            // passChangeRetypeTxt
            // 
            this.passChangeRetypeTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.passChangeRetypeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passChangeRetypeTxt.Location = new System.Drawing.Point(27, 184);
            this.passChangeRetypeTxt.Multiline = true;
            this.passChangeRetypeTxt.Name = "passChangeRetypeTxt";
            this.passChangeRetypeTxt.PasswordChar = '*';
            this.passChangeRetypeTxt.Size = new System.Drawing.Size(298, 40);
            this.passChangeRetypeTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // PasswordChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.panel1);
            this.Name = "PasswordChangeForm";
            this.Text = "PasswordChangeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passChangeTxt;
        private System.Windows.Forms.Button passChangeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passChangeRetypeTxt;
        private System.Windows.Forms.Label label1;
    }
}