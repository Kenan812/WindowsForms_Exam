namespace WindowsFormsApp1.View
{
    partial class PostsForm
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
            this.userLoginTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addNewPostButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userLoginTextBox
            // 
            this.userLoginTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.userLoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userLoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userLoginTextBox.Location = new System.Drawing.Point(101, 40);
            this.userLoginTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userLoginTextBox.Name = "userLoginTextBox";
            this.userLoginTextBox.Size = new System.Drawing.Size(334, 30);
            this.userLoginTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(165, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 30);
            this.label2.TabIndex = 10;
            this.label2.Text = "Posts";
            // 
            // addNewPostButton
            // 
            this.addNewPostButton.Location = new System.Drawing.Point(532, 34);
            this.addNewPostButton.Name = "addNewPostButton";
            this.addNewPostButton.Size = new System.Drawing.Size(145, 51);
            this.addNewPostButton.TabIndex = 11;
            this.addNewPostButton.Text = "Add Post";
            this.addNewPostButton.UseVisualStyleBackColor = true;
            this.addNewPostButton.Click += new System.EventHandler(this.addNewPostButton_Click);
            // 
            // PostsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 610);
            this.Controls.Add(this.addNewPostButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userLoginTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PostsForm";
            this.Text = "PostsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userLoginTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addNewPostButton;
    }
}