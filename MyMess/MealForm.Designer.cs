namespace MyMess
{
    partial class MealForm
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
            this.addAmmountBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mealCostTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mealAmountTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mealAmountTxt);
            this.panel1.Controls.Add(this.addAmmountBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.mealCostTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(116, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 358);
            this.panel1.TabIndex = 5;
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
            this.addAmmountBtn.Text = "Meal done";
            this.addAmmountBtn.UseVisualStyleBackColor = false;
            this.addAmmountBtn.Click += new System.EventHandler(this.addAmmountBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Meal Cost";
            // 
            // mealCostTxt
            // 
            this.mealCostTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.mealCostTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mealCostTxt.Location = new System.Drawing.Point(27, 184);
            this.mealCostTxt.Multiline = true;
            this.mealCostTxt.Name = "mealCostTxt";
            this.mealCostTxt.Size = new System.Drawing.Size(298, 40);
            this.mealCostTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meal";
            // 
            // mealAmountTxt
            // 
            this.mealAmountTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.mealAmountTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mealAmountTxt.Location = new System.Drawing.Point(27, 116);
            this.mealAmountTxt.Multiline = true;
            this.mealAmountTxt.Name = "mealAmountTxt";
            this.mealAmountTxt.Size = new System.Drawing.Size(298, 40);
            this.mealAmountTxt.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Meal Amount";
            // 
            // MealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.panel1);
            this.Name = "MealForm";
            this.Text = "MealForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mealAmountTxt;
        private System.Windows.Forms.Button addAmmountBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mealCostTxt;
        private System.Windows.Forms.Label label1;
    }
}