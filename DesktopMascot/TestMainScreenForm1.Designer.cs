namespace DesktopMascot
{
    partial class TestMainScreenForm1
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
            this.label1 = new System.Windows.Forms.Label();
            this.CreateSubScreen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is TestMainScreenFrom1.";
            // 
            // CreateSubScreen
            // 
            this.CreateSubScreen.Location = new System.Drawing.Point(30, 58);
            this.CreateSubScreen.Name = "CreateSubScreen";
            this.CreateSubScreen.Size = new System.Drawing.Size(206, 32);
            this.CreateSubScreen.TabIndex = 1;
            this.CreateSubScreen.Text = "Create SubScreen";
            this.CreateSubScreen.UseVisualStyleBackColor = true;
            this.CreateSubScreen.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Delete All SubScreen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // TestMainScreenForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 150);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CreateSubScreen);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "TestMainScreenForm1";
            this.Text = "TestMainScreenForm1";
            this.Load += new System.EventHandler(this.TestMainScreenForm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateSubScreen;
        private System.Windows.Forms.Button button1;
    }
}