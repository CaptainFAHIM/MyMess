namespace MyMess
{
    partial class UpdateRoleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateRoleForm));
            this.roleEmailTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.managerRadio = new System.Windows.Forms.RadioButton();
            this.memberRadio = new System.Windows.Forms.RadioButton();
            this.giveRoleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roleEmailTxt
            // 
            this.roleEmailTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.roleEmailTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleEmailTxt.Location = new System.Drawing.Point(16, 47);
            this.roleEmailTxt.Multiline = true;
            this.roleEmailTxt.Name = "roleEmailTxt";
            this.roleEmailTxt.Size = new System.Drawing.Size(298, 42);
            this.roleEmailTxt.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Email:";
            // 
            // managerRadio
            // 
            this.managerRadio.AutoSize = true;
            this.managerRadio.Location = new System.Drawing.Point(16, 106);
            this.managerRadio.Name = "managerRadio";
            this.managerRadio.Size = new System.Drawing.Size(67, 17);
            this.managerRadio.TabIndex = 50;
            this.managerRadio.TabStop = true;
            this.managerRadio.Text = "Manager";
            this.managerRadio.UseVisualStyleBackColor = true;
            // 
            // memberRadio
            // 
            this.memberRadio.AutoSize = true;
            this.memberRadio.Location = new System.Drawing.Point(121, 106);
            this.memberRadio.Name = "memberRadio";
            this.memberRadio.Size = new System.Drawing.Size(63, 17);
            this.memberRadio.TabIndex = 51;
            this.memberRadio.TabStop = true;
            this.memberRadio.Text = "Member";
            this.memberRadio.UseVisualStyleBackColor = true;
            // 
            // giveRoleBtn
            // 
            this.giveRoleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.giveRoleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.giveRoleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giveRoleBtn.Location = new System.Drawing.Point(12, 137);
            this.giveRoleBtn.Name = "giveRoleBtn";
            this.giveRoleBtn.Size = new System.Drawing.Size(116, 41);
            this.giveRoleBtn.TabIndex = 52;
            this.giveRoleBtn.Text = "Give role";
            this.giveRoleBtn.UseVisualStyleBackColor = false;
            this.giveRoleBtn.Click += new System.EventHandler(this.giveRoleBtn_Click);
            // 
            // UpdateRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 190);
            this.Controls.Add(this.giveRoleBtn);
            this.Controls.Add(this.memberRadio);
            this.Controls.Add(this.managerRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roleEmailTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateRoleForm";
            this.Text = "Update Role";
            this.Load += new System.EventHandler(this.UpdateRoleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox roleEmailTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton managerRadio;
        private System.Windows.Forms.RadioButton memberRadio;
        private System.Windows.Forms.Button giveRoleBtn;
    }
}