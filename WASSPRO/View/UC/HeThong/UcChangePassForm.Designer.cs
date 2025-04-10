namespace QLCongNo.View.UC.HeThong
{
    partial class UcChangePassForm
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
            this.label3 = new QLCongNo.View.Core.NovLabel();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.label4 = new QLCongNo.View.Core.NovLabel();
            this.txtUsername = new QLCongNo.View.Core.NovTextBox();
            this.txtRetype = new QLCongNo.View.Core.NovTextBox();
            this.txtNewPassword = new QLCongNo.View.Core.NovTextBox();
            this.txtPassword = new QLCongNo.View.Core.NovTextBox();
            this.closeButton = new QLCongNo.View.Core.NovButton();
            this.okButton = new QLCongNo.View.Core.NovButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(16, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(16, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nhập lần 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(16, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(16, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mật khẩu cũ";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Enabled = false;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(137, 17);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(176, 32);
            this.txtUsername.TabIndex = 15;
            // 
            // txtRetype
            // 
            this.txtRetype.BackColor = System.Drawing.Color.White;
            this.txtRetype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetype.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetype.ForeColor = System.Drawing.Color.Black;
            this.txtRetype.Location = new System.Drawing.Point(137, 158);
            this.txtRetype.Margin = new System.Windows.Forms.Padding(5);
            this.txtRetype.Name = "txtRetype";
            this.txtRetype.PasswordChar = '*';
            this.txtRetype.Size = new System.Drawing.Size(176, 32);
            this.txtRetype.TabIndex = 12;
            this.txtRetype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetype_KeyPress);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.Black;
            this.txtNewPassword.Location = new System.Drawing.Point(137, 112);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(176, 32);
            this.txtNewPassword.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(137, 64);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(176, 32);
            this.txtPassword.TabIndex = 10;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.closeButton.IconColor = System.Drawing.Color.White;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.closeButton.IconSize = 1;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(339, 62);
            this.closeButton.Margin = new System.Windows.Forms.Padding(5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.closeButton.Size = new System.Drawing.Size(131, 34);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "Thoát";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.okButton.IconColor = System.Drawing.Color.White;
            this.okButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.okButton.IconSize = 1;
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(339, 17);
            this.okButton.Margin = new System.Windows.Forms.Padding(5);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.okButton.Size = new System.Drawing.Size(131, 34);
            this.okButton.TabIndex = 13;
            this.okButton.Text = "Thực hiện";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // UcChangePassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtRetype);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtPassword);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcChangePassForm";
            this.Size = new System.Drawing.Size(489, 202);
            this.Load += new System.EventHandler(this.ChangePassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovButton closeButton;
        private View.Core.NovButton okButton;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private View.Core.NovLabel label4;
        private View.Core.NovTextBox txtUsername;
        private View.Core.NovTextBox txtRetype;
        private View.Core.NovTextBox txtNewPassword;
        private View.Core.NovTextBox txtPassword;
    }
}