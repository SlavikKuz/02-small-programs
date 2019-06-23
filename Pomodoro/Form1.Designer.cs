namespace Pomodoro
{
    partial class Form1
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttonTrinn1 = new System.Windows.Forms.Button();
            this.buttonTrinn2 = new System.Windows.Forms.Button();
            this.buttonTrinn3 = new System.Windows.Forms.Button();
            this.checkTrin1 = new System.Windows.Forms.CheckBox();
            this.checkTrin2 = new System.Windows.Forms.CheckBox();
            this.checkTrin3 = new System.Windows.Forms.CheckBox();
            this.checkSet1 = new System.Windows.Forms.CheckBox();
            this.checkSet2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(230, 60);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(260, 12);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(110, 60);
            this.buttonEnd.TabIndex = 1;
            this.buttonEnd.Text = "Pause";
            this.buttonEnd.UseVisualStyleBackColor = true;
            // 
            // buttonTrinn1
            // 
            this.buttonTrinn1.Location = new System.Drawing.Point(12, 87);
            this.buttonTrinn1.Name = "buttonTrinn1";
            this.buttonTrinn1.Size = new System.Drawing.Size(290, 60);
            this.buttonTrinn1.TabIndex = 2;
            this.buttonTrinn1.Text = "Trinn 1";
            this.buttonTrinn1.UseVisualStyleBackColor = true;
            this.buttonTrinn1.Click += new System.EventHandler(this.buttonTrinn1_Click);
            // 
            // buttonTrinn2
            // 
            this.buttonTrinn2.Location = new System.Drawing.Point(12, 168);
            this.buttonTrinn2.Name = "buttonTrinn2";
            this.buttonTrinn2.Size = new System.Drawing.Size(290, 60);
            this.buttonTrinn2.TabIndex = 3;
            this.buttonTrinn2.Text = "Trinn 2";
            this.buttonTrinn2.UseVisualStyleBackColor = true;
            // 
            // buttonTrinn3
            // 
            this.buttonTrinn3.Location = new System.Drawing.Point(12, 249);
            this.buttonTrinn3.Name = "buttonTrinn3";
            this.buttonTrinn3.Size = new System.Drawing.Size(290, 60);
            this.buttonTrinn3.TabIndex = 4;
            this.buttonTrinn3.Text = "Trinn 3";
            this.buttonTrinn3.UseVisualStyleBackColor = true;
            // 
            // checkTrin1
            // 
            this.checkTrin1.AutoSize = true;
            this.checkTrin1.Location = new System.Drawing.Point(329, 108);
            this.checkTrin1.Name = "checkTrin1";
            this.checkTrin1.Size = new System.Drawing.Size(22, 21);
            this.checkTrin1.TabIndex = 5;
            this.checkTrin1.UseVisualStyleBackColor = true;
            this.checkTrin1.CheckedChanged += new System.EventHandler(this.checkTrin1_CheckedChanged);
            // 
            // checkTrin2
            // 
            this.checkTrin2.AutoSize = true;
            this.checkTrin2.Location = new System.Drawing.Point(329, 189);
            this.checkTrin2.Name = "checkTrin2";
            this.checkTrin2.Size = new System.Drawing.Size(22, 21);
            this.checkTrin2.TabIndex = 6;
            this.checkTrin2.UseVisualStyleBackColor = true;
            // 
            // checkTrin3
            // 
            this.checkTrin3.AutoSize = true;
            this.checkTrin3.Location = new System.Drawing.Point(329, 270);
            this.checkTrin3.Name = "checkTrin3";
            this.checkTrin3.Size = new System.Drawing.Size(22, 21);
            this.checkTrin3.TabIndex = 7;
            this.checkTrin3.UseVisualStyleBackColor = true;
            // 
            // checkSet1
            // 
            this.checkSet1.AutoSize = true;
            this.checkSet1.Location = new System.Drawing.Point(101, 353);
            this.checkSet1.Name = "checkSet1";
            this.checkSet1.Size = new System.Drawing.Size(73, 24);
            this.checkSet1.TabIndex = 8;
            this.checkSet1.Text = "Set 1";
            this.checkSet1.UseVisualStyleBackColor = true;
            // 
            // checkSet2
            // 
            this.checkSet2.AutoSize = true;
            this.checkSet2.Location = new System.Drawing.Point(220, 353);
            this.checkSet2.Name = "checkSet2";
            this.checkSet2.Size = new System.Drawing.Size(73, 24);
            this.checkSet2.TabIndex = 9;
            this.checkSet2.Text = "Set 2";
            this.checkSet2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 417);
            this.Controls.Add(this.checkSet2);
            this.Controls.Add(this.checkSet1);
            this.Controls.Add(this.checkTrin3);
            this.Controls.Add(this.checkTrin2);
            this.Controls.Add(this.checkTrin1);
            this.Controls.Add(this.buttonTrinn3);
            this.Controls.Add(this.buttonTrinn2);
            this.Controls.Add(this.buttonTrinn1);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Pomodoro 45";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.Button buttonTrinn1;
        private System.Windows.Forms.Button buttonTrinn2;
        private System.Windows.Forms.Button buttonTrinn3;
        private System.Windows.Forms.CheckBox checkTrin1;
        private System.Windows.Forms.CheckBox checkTrin2;
        private System.Windows.Forms.CheckBox checkTrin3;
        private System.Windows.Forms.CheckBox checkSet1;
        private System.Windows.Forms.CheckBox checkSet2;
    }
}

