namespace MyMess
{
    partial class AllMembersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllMembersForm));
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.newMonthYes = new System.Windows.Forms.Button();
            this.updateRoleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(12, 12);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.Size = new System.Drawing.Size(314, 426);
            this.dgvMembers.TabIndex = 0;
            // 
            // newMonthYes
            // 
            this.newMonthYes.BackColor = System.Drawing.Color.Red;
            this.newMonthYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newMonthYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMonthYes.Location = new System.Drawing.Point(332, 27);
            this.newMonthYes.Name = "newMonthYes";
            this.newMonthYes.Size = new System.Drawing.Size(129, 41);
            this.newMonthYes.TabIndex = 44;
            this.newMonthYes.Text = "Delete Member";
            this.newMonthYes.UseVisualStyleBackColor = false;
            this.newMonthYes.Click += new System.EventHandler(this.newMonthYes_Click);
            // 
            // updateRoleBtn
            // 
            this.updateRoleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.updateRoleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateRoleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateRoleBtn.Location = new System.Drawing.Point(332, 74);
            this.updateRoleBtn.Name = "updateRoleBtn";
            this.updateRoleBtn.Size = new System.Drawing.Size(129, 41);
            this.updateRoleBtn.TabIndex = 45;
            this.updateRoleBtn.Text = "Update Role";
            this.updateRoleBtn.UseVisualStyleBackColor = false;
            this.updateRoleBtn.Click += new System.EventHandler(this.updateRoleBtn_Click);
            // 
            // AllMembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(473, 450);
            this.Controls.Add(this.updateRoleBtn);
            this.Controls.Add(this.newMonthYes);
            this.Controls.Add(this.dgvMembers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AllMembersForm";
            this.Text = "All Members";
            this.Load += new System.EventHandler(this.AllMembersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Button newMonthYes;
        private System.Windows.Forms.Button updateRoleBtn;
    }
}