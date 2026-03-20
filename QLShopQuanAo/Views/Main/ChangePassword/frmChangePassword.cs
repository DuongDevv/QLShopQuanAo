using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo.Views.Main.ChangePassword
{
    public partial class frmChangePassword : Form
    {
        public int MaNV_HienTai { get; set; }
        string connectionString = @"Data Source=DESKTOP-10UJ2O8\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True";
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(current))
            {
                MessageBox.Show("Vui lòng nhập lại Password hiện tại!","Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(confirm) || string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Vui lòng nhập 'Mật khẩu mới' và 'Xác nhận' lại mật khẩu!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp!"); return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM TaiKhoan WHERE MaNV = @id AND MatKhau = @old";
                SqlCommand cmdCheck = new SqlCommand(checkSql, conn);
                cmdCheck.Parameters.AddWithValue("@id", MaNV_HienTai);
                cmdCheck.Parameters.AddWithValue("@old", current);

                int count = (int)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    string updateSql = "UPDATE TaiKhoan SET MatKhau = @new WHERE MaNV = @id";
                    SqlCommand cmdUpdate = new SqlCommand(updateSql, conn);
                    cmdUpdate.Parameters.AddWithValue("@new", newPass);
                    cmdUpdate.Parameters.AddWithValue("@id", MaNV_HienTai);

                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không chính xác!");
                }
            }
        }

        private void btnCancelUpdatePassword_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
