namespace bacsharp
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
            this.sendWhoIsbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendWhoIsbutton
            // 
            this.sendWhoIsbutton.Location = new System.Drawing.Point(22, 14);
            this.sendWhoIsbutton.Name = "sendWhoIsbutton";
            this.sendWhoIsbutton.Size = new System.Drawing.Size(95, 22);
            this.sendWhoIsbutton.TabIndex = 0;
            this.sendWhoIsbutton.Text = "Send \'who-is\'";
            this.sendWhoIsbutton.UseVisualStyleBackColor = true;
            this.sendWhoIsbutton.Click += new System.EventHandler(this.sendWhoIsbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.sendWhoIsbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sendWhoIsbutton;
    }
}