namespace MessageSender
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.friendsGrid = new System.Windows.Forms.DataGridView();
            this.Friend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.friedName = new System.Windows.Forms.TextBox();
            this.newFriend = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.friendsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.Location = new System.Drawing.Point(12, 13);
            this.welcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(100, 25);
            this.welcome.TabIndex = 0;
            this.welcome.Text = "Welcome ";
            // 
            // TextBoxFriend
            // 
            this.TextBoxFriend.Location = new System.Drawing.Point(14, 43);
            this.TextBoxFriend.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxFriend.Multiline = true;
            this.TextBoxFriend.Name = "TextBoxFriend";
            this.TextBoxFriend.Size = new System.Drawing.Size(369, 210);
            this.TextBoxFriend.TabIndex = 1;
            this.TextBoxFriend.TextChanged += new System.EventHandler(this.TextBoxFriend_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 307);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Your Message: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // friendsGrid
            // 
            this.friendsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.friendsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Friend,
            this.Status,
            this.Id});
            this.friendsGrid.Location = new System.Drawing.Point(408, 43);
            this.friendsGrid.Name = "friendsGrid";
            this.friendsGrid.Size = new System.Drawing.Size(295, 284);
            this.friendsGrid.TabIndex = 5;
            this.friendsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.friendsGrid_CellContentClick);
            // 
            // Friend
            // 
            this.Friend.HeaderText = "Friend";
            this.Friend.Name = "Friend";
            this.Friend.ReadOnly = true;
            this.Friend.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(404, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select a friend";
            // 
            // friedName
            // 
            this.friedName.Location = new System.Drawing.Point(408, 342);
            this.friedName.Name = "friedName";
            this.friedName.Size = new System.Drawing.Size(149, 20);
            this.friedName.TabIndex = 7;
            // 
            // newFriend
            // 
            this.newFriend.Location = new System.Drawing.Point(563, 339);
            this.newFriend.Name = "newFriend";
            this.newFriend.Size = new System.Drawing.Size(140, 23);
            this.newFriend.TabIndex = 8;
            this.newFriend.Text = "Add new friend";
            this.newFriend.UseVisualStyleBackColor = true;
            this.newFriend.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(308, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Sign Out";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // WorkSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 374);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.newFriend);
            this.Controls.Add(this.friedName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.friendsGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TextBoxFriend);
            this.Controls.Add(this.welcome);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorkSpace";
            this.Text = "Skype";
            this.Load += new System.EventHandler(this.WorkSpace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.friendsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome;
        public System.Windows.Forms.TextBox TextBoxFriend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox friedName;
        private System.Windows.Forms.Button newFriend;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.DataGridView friendsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friend;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}