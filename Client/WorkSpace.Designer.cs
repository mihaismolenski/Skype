namespace Client
{
    partial class WorkSpace
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
            this.welcome = new System.Windows.Forms.Label();
            this.TextBoxFriend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.Location = new System.Drawing.Point(12, 9);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(126, 29);
            this.welcome.TabIndex = 0;
            this.welcome.Text = "Bun venit ";
            // 
            // TextBoxFriend
            // 
            this.TextBoxFriend.Location = new System.Drawing.Point(38, 92);
            this.TextBoxFriend.Multiline = true;
            this.TextBoxFriend.Name = "TextBoxFriend";
            this.TextBoxFriend.Size = new System.Drawing.Size(372, 163);
            this.TextBoxFriend.TabIndex = 1;
            // 
            // WorkSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 470);
            this.Controls.Add(this.TextBoxFriend);
            this.Controls.Add(this.welcome);
            this.Name = "WorkSpace";
            this.Text = "Skype";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome;
        public System.Windows.Forms.TextBox TextBoxFriend;
    }
}