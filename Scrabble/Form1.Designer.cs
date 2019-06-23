namespace Scrabble
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
            this.textWords = new System.Windows.Forms.TextBox();
            this.buttonPalindromes = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textLetters = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNumberWords = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textWords
            // 
            this.textWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWords.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWords.Location = new System.Drawing.Point(238, 12);
            this.textWords.Multiline = true;
            this.textWords.Name = "textWords";
            this.textWords.ReadOnly = true;
            this.textWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textWords.Size = new System.Drawing.Size(409, 497);
            this.textWords.TabIndex = 0;
            // 
            // buttonPalindromes
            // 
            this.buttonPalindromes.Location = new System.Drawing.Point(13, 13);
            this.buttonPalindromes.Name = "buttonPalindromes";
            this.buttonPalindromes.Size = new System.Drawing.Size(210, 55);
            this.buttonPalindromes.TabIndex = 1;
            this.buttonPalindromes.Text = "Palindromes";
            this.buttonPalindromes.UseVisualStyleBackColor = true;
            this.buttonPalindromes.Click += new System.EventHandler(this.buttonPalindromes_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(12, 242);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(210, 55);
            this.buttonFind.TabIndex = 2;
            this.buttonFind.Text = "Go find!";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonSimple_Click);
            // 
            // textLetters
            // 
            this.textLetters.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLetters.Location = new System.Drawing.Point(12, 209);
            this.textLetters.Name = "textLetters";
            this.textLetters.Size = new System.Drawing.Size(210, 27);
            this.textLetters.TabIndex = 3;
            this.textLetters.Text = "no";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Given letters:";
            // 
            // labelNumberWords
            // 
            this.labelNumberWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumberWords.AutoSize = true;
            this.labelNumberWords.Location = new System.Drawing.Point(238, 516);
            this.labelNumberWords.Name = "labelNumberWords";
            this.labelNumberWords.Size = new System.Drawing.Size(59, 20);
            this.labelNumberWords.TabIndex = 5;
            this.labelNumberWords.Text = "Found:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 544);
            this.Controls.Add(this.labelNumberWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textLetters);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.buttonPalindromes);
            this.Controls.Add(this.textWords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 320);
            this.Name = "Form1";
            this.Text = "Scrabble";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textWords;
        private System.Windows.Forms.Button buttonPalindromes;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textLetters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNumberWords;
    }
}

