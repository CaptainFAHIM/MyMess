namespace MyMess
{
    partial class DeleteMemberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteMemberForm));
            this.label1 = new System.Windows.Forms.Label();
            this.deleteMemberTxt = new System.Windows.Forms.TextBox();
            this.deleteMemberBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Email:";
            // 
            // deleteMemberTxt
            // 
            this.deleteMemberTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.deleteMemberTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteMemberTxt.Location = new System.Drawing.Point(16, 56);
            this.deleteMemberTxt.Multiline = true;
            this.deleteMemberTxt.Name = "deleteMemberTxt";
            this.deleteMemberTxt.Size = new System.Drawing.Size(298, 42);
            this.deleteMemberTxt.TabIndex = 47;
            // 
            // deleteMemberBtn
            // 
            this.deleteMemberBtn.BackColor = System.Drawing.Color.Red;
            this.deleteMemberBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteMemberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteMemberBtn.Location = new System.Drawing.Point(16, 115);
            this.deleteMemberBtn.Name = "deleteMemberBtn";
            this.deleteMemberBtn.Size = new System.Drawing.Size(116, 41);
            this.deleteMemberBtn.TabIndex = 48;
            this.deleteMemberBtn.Text = "Delete";
            this.deleteMemberBtn.UseVisualStyleBackColor = false;
            this.deleteMemberBtn.Click += new System.EventHandler(this.deleteMemberBtn_Click);
            // 
            // DeleteMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 179);
            this.Controls.Add(this.deleteMemberBtn);
            this.Controls.Add(this.deleteMemberTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeleteMemberForm";
            this.Text = "Delete Member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deleteMemberTxt;
        private System.Windows.Forms.Button deleteMemberBtn;
    }
}