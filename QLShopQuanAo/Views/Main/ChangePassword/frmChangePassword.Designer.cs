namespace QLShopQuanAo.Views.Main.ChangePassword
{
    partial class frmChangePassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.btnCancelUpdatePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu hiện tại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập lại mật khẩu:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(197, 38);
            this.txtCurrentPassword.Multiline = true;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(171, 22);
            this.txtCurrentPassword.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(195, 179);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(171, 22);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(197, 107);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(171, 22);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnUpdatePassword.Location = new System.Drawing.Point(97, 241);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(90, 41);
            this.btnUpdatePassword.TabIndex = 6;
            this.btnUpdatePassword.Text = "Cập nhật";
            this.btnUpdatePassword.UseVisualStyleBackColor = false;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnCancelUpdatePassword
            // 
            this.btnCancelUpdatePassword.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancelUpdatePassword.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelUpdatePassword.Location = new System.Drawing.Point(230, 241);
            this.btnCancelUpdatePassword.Name = "btnCancelUpdatePassword";
            this.btnCancelUpdatePassword.Size = new System.Drawing.Size(90, 41);
            this.btnCancelUpdatePassword.TabIndex = 7;
            this.btnCancelUpdatePassword.Text = "Hủy";
            this.btnCancelUpdatePassword.UseVisualStyleBackColor = false;
            this.btnCancelUpdatePassword.Click += new System.EventHandler(this.btnCancelUpdatePassword_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 354);
            this.Controls.Add(this.btnCancelUpdatePassword);
            this.Controls.Add(this.btnUpdatePassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.Button btnCancelUpdatePassword;
    }
}