namespace MyMess
{
    partial class MonthDetailsForm
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
            this.dgvDeposits = new System.Windows.Forms.DataGridView();
            this.profileName = new System.Windows.Forms.Label();
            this.dgvMeals = new System.Windows.Forms.DataGridView();
            this.dgvCosts = new System.Windows.Forms.DataGridView();
            this.mnthDetailsDwnBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCosts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDeposits
            // 
            this.dgvDeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeposits.Location = new System.Drawing.Point(44, 68);
            this.dgvDeposits.Name = "dgvDeposits";
            this.dgvDeposits.Size = new System.Drawing.Size(327, 500);
            this.dgvDeposits.TabIndex = 0;
            this.dgvDeposits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeposits_CellContentClick);
            // 
            // profileName
            // 
            this.profileName.AutoSize = true;
            this.profileName.Font = new System.Drawing.Font("Elephant", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileName.Location = new System.Drawing.Point(138, 22);
            this.profileName.Name = "profileName";
            this.profileName.Size = new System.Drawing.Size(129, 31);
            this.profileName.TabIndex = 4;
            this.profileName.Text = "Deposits";
            // 
            // dgvMeals
            // 
            this.dgvMeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeals.Location = new System.Drawing.Point(444, 68);
            this.dgvMeals.Name = "dgvMeals";
            this.dgvMeals.Size = new System.Drawing.Size(327, 500);
            this.dgvMeals.TabIndex = 5;
            // 
            // dgvCosts
            // 
            this.dgvCosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCosts.Location = new System.Drawing.Point(826, 68);
            this.dgvCosts.Name = "dgvCosts";
            this.dgvCosts.Size = new System.Drawing.Size(327, 500);
            this.dgvCosts.TabIndex = 6;
            // 
            // mnthDetailsDwnBtn
            // 
            this.mnthDetailsDwnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.mnthDetailsDwnBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mnthDetailsDwnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnthDetailsDwnBtn.Location = new System.Drawing.Point(558, 574);
            this.mnthDetailsDwnBtn.Name = "mnthDetailsDwnBtn";
            this.mnthDetailsDwnBtn.Size = new System.Drawing.Size(116, 41);
            this.mnthDetailsDwnBtn.TabIndex = 50;
            this.mnthDetailsDwnBtn.Text = "Download";
            this.mnthDetailsDwnBtn.UseVisualStyleBackColor = false;
            this.mnthDetailsDwnBtn.Click += new System.EventHandler(this.mnthDetailsDwnBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(564, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 31);
            this.label1.TabIndex = 52;
            this.label1.Text = "Meals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Elephant", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(943, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 53;
            this.label2.Text = "Costs";
            // 
            // MonthDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mnthDetailsDwnBtn);
            this.Controls.Add(this.dgvCosts);
            this.Controls.Add(this.dgvMeals);
            this.Controls.Add(this.profileName);
            this.Controls.Add(this.dgvDeposits);
            this.Name = "MonthDetailsForm";
            this.Text = "MonthDetailsForm";
            this.Load += new System.EventHandler(this.MonthDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCosts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeposits;
        private System.Windows.Forms.Label profileName;
        private System.Windows.Forms.DataGridView dgvMeals;
        private System.Windows.Forms.DataGridView dgvCosts;
        private System.Windows.Forms.Button mnthDetailsDwnBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}