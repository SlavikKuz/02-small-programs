namespace Dice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.box1 = new System.Windows.Forms.PictureBox();
            this.box2 = new System.Windows.Forms.PictureBox();
            this.labelSum = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).BeginInit();
            this.SuspendLayout();
            // 
            // box1
            // 
            this.box1.Location = new System.Drawing.Point(40, 66);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(100, 100);
            this.box1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box1.TabIndex = 1;
            this.box1.TabStop = false;
            // 
            // box2
            // 
            this.box2.Location = new System.Drawing.Point(160, 66);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(100, 100);
            this.box2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.box2.TabIndex = 2;
            this.box2.TabStop = false;
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(89, 217);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(0, 20);
            this.labelSum.TabIndex = 3;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(40, 346);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(220, 50);
            this.buttonGo.TabIndex = 4;
            this.buttonGo.Text = "Go!";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 424);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dice";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox box1;
        private System.Windows.Forms.PictureBox box2;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Button buttonGo;
    }
}

