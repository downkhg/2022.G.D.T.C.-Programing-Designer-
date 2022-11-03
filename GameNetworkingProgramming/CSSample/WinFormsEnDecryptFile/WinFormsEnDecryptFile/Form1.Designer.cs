
namespace WinFormsEnDecryptFile
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.KeyGen = new System.Windows.Forms.Button();
            this.EecryptFile = new System.Windows.Forms.Button();
            this.DecryptFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "PairKey";
            // 
            // KeyGen
            // 
            this.KeyGen.Location = new System.Drawing.Point(184, 25);
            this.KeyGen.Name = "KeyGen";
            this.KeyGen.Size = new System.Drawing.Size(131, 23);
            this.KeyGen.TabIndex = 1;
            this.KeyGen.Text = "KeyGen";
            this.KeyGen.UseVisualStyleBackColor = true;
            this.KeyGen.Click += new System.EventHandler(this.KeyGen_Click);
            // 
            // EecryptFile
            // 
            this.EecryptFile.Location = new System.Drawing.Point(184, 67);
            this.EecryptFile.Name = "EecryptFile";
            this.EecryptFile.Size = new System.Drawing.Size(131, 23);
            this.EecryptFile.TabIndex = 2;
            this.EecryptFile.Text = "EecryptFile";
            this.EecryptFile.UseVisualStyleBackColor = true;
            this.EecryptFile.Click += new System.EventHandler(this.EecryptFile_Click);
            // 
            // DecryptFile
            // 
            this.DecryptFile.Location = new System.Drawing.Point(184, 111);
            this.DecryptFile.Name = "DecryptFile";
            this.DecryptFile.Size = new System.Drawing.Size(131, 23);
            this.DecryptFile.TabIndex = 3;
            this.DecryptFile.Text = "DecryptFile";
            this.DecryptFile.UseVisualStyleBackColor = false;
            this.DecryptFile.Click += new System.EventHandler(this.DecryptFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 150);
            this.Controls.Add(this.DecryptFile);
            this.Controls.Add(this.EecryptFile);
            this.Controls.Add(this.KeyGen);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button KeyGen;
        private System.Windows.Forms.Button EecryptFile;
        private System.Windows.Forms.Button DecryptFile;
    }
}

