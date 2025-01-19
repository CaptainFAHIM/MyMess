namespace MyMess
{
    partial class DepositeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositeForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectUserCombo = new System.Windows.Forms.ComboBox();
            this.addAmmountBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.depositeAmmountTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.selectUserCombo);
            this.panel1.Controls.Add(this.addAmmountBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.depositeAmmountTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(116, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 358);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // selectUserCombo
            // 
            this.selectUserCombo.FormattingEnabled = true;
            this.selectUserCombo.Location = new System.Drawing.Point(27, 110);
            this.selectUserCombo.Name = "selectUserCombo";
            this.selectUserCombo.Size = new System.Drawing.Size(298, 21);
            this.selectUserCombo.TabIndex = 13;
            this.selectUserCombo.SelectedIndexChanged += new System.EventHandler(this.selectUserCombo_SelectedIndexChanged);
            // 
            // addAmmountBtn
            // 
            this.addAmmountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.addAmmountBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addAmmountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAmmountBtn.Location = new System.Drawing.Point(27, 245);
            this.addAmmountBtn.Name = "addAmmountBtn";
            this.addAmmountBtn.Size = new System.Drawing.Size(298, 41);
            this.addAmmountBtn.TabIndex = 12;
            this.addAmmountBtn.Text = "Add";
            this.addAmmountBtn.UseVisualStyleBackColor = false;
            this.addAmmountBtn.Click += new System.EventHandler(this.addAmmountBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enter Ammount";
            // 
            // depositeAmmountTxt
            // 
            this.depositeAmmountTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.depositeAmmountTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositeAmmountTxt.Location = new System.Drawing.Point(27, 184);
            this.depositeAmmountTxt.Multiline = true;
            this.depositeAmmountTxt.Name = "depositeAmmountTxt";
            this.depositeAmmountTxt.Size = new System.Drawing.Size(298, 40);
            this.depositeAmmountTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deposite";
            // 
            // DepositeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DepositeForm";
            this.Text = "Add Deposit";
            this.Load += new System.EventHandler(this.DepositeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addAmmountBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox depositeAmmountTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectUserCombo;
    }
}