namespace Bug_Tracker.Views
{
    partial class Bugs
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
            this.panelBugs = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAssigned = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBugs.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelAssigned.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBugs
            // 
            this.panelBugs.BackColor = System.Drawing.Color.Brown;
            this.panelBugs.Controls.Add(this.panel3);
            this.panelBugs.Controls.Add(this.label1);
            this.panelBugs.ForeColor = System.Drawing.SystemColors.Window;
            this.panelBugs.Location = new System.Drawing.Point(-3, 4);
            this.panelBugs.Name = "panelBugs";
            this.panelBugs.Size = new System.Drawing.Size(1029, 281);
            this.panelBugs.TabIndex = 0;
            this.panelBugs.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBugs_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(243, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 100);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Method";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Project";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(391, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 94);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(467, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bugs\r\n";
            // 
            // panelAssigned
            // 
            this.panelAssigned.BackColor = System.Drawing.Color.LimeGreen;
            this.panelAssigned.Controls.Add(this.label2);
            this.panelAssigned.ForeColor = System.Drawing.SystemColors.Window;
            this.panelAssigned.Location = new System.Drawing.Point(-3, 291);
            this.panelAssigned.Name = "panelAssigned";
            this.panelAssigned.Size = new System.Drawing.Size(1029, 275);
            this.panelAssigned.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Work assigned to\r\n";
            // 
            // Bugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 564);
            this.Controls.Add(this.panelAssigned);
            this.Controls.Add(this.panelBugs);
            this.Name = "Bugs";
            this.Text = "Bugs";
            this.Load += new System.EventHandler(this.Bugs_Load);
            this.panelBugs.ResumeLayout(false);
            this.panelBugs.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelAssigned.ResumeLayout(false);
            this.panelAssigned.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBugs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAssigned;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}