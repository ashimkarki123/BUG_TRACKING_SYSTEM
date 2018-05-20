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
            this.label1 = new System.Windows.Forms.Label();
            this.panelAssigned = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBugs.SuspendLayout();
            this.panelAssigned.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBugs
            // 
            this.panelBugs.BackColor = System.Drawing.Color.OliveDrab;
            this.panelBugs.Controls.Add(this.label1);
            this.panelBugs.ForeColor = System.Drawing.SystemColors.Window;
            this.panelBugs.Location = new System.Drawing.Point(-3, 4);
            this.panelBugs.Name = "panelBugs";
            this.panelBugs.Size = new System.Drawing.Size(1029, 281);
            this.panelBugs.TabIndex = 0;
            this.panelBugs.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBugs_Paint);
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
            this.panelAssigned.BackColor = System.Drawing.Color.YellowGreen;
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
            this.ClientSize = new System.Drawing.Size(1030, 564);
            this.Controls.Add(this.panelAssigned);
            this.Controls.Add(this.panelBugs);
            this.Name = "Bugs";
            this.Text = "Bugs";
            this.Load += new System.EventHandler(this.Bugs_Load);
            this.panelBugs.ResumeLayout(false);
            this.panelBugs.PerformLayout();
            this.panelAssigned.ResumeLayout(false);
            this.panelAssigned.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBugs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAssigned;
        private System.Windows.Forms.Label label2;
    }
}