using QLShopQuanAo.BUS;
using QLShopQuanAo.DTO;
using QLShopQuanAo.Views.Main;
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

namespace QLShopQuanAo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string acc = txtAccountName.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(acc))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccountName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            BUS.StaffBUS staffBUS = new BUS.StaffBUS();
            try
            {
                if (staffBUS.CheckLogin(acc, pass))
                {
                    // Nếu đúng, lấy toàn bộ thông tin (MaNV, ChucVu...)
                    DTO.StaffDTO info = staffBUS.GetInfo(acc);

                    if (info != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmMain f = new frmMain();
                        f.MaNV_DangNhap = info.MaNV;
                        f.ChucVu_DangNhap = info.ChucVu; // Truyền chức vụ sang để phân quyền
                        f.TenNV_DangNhap = info.TenNV;

                        this.Hide();
                        f.ShowDialog();

                        txtPassword.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hệ thống: " + ex.Message);
            }
        }


        //Phân quyền giữ Nhân viên và Quản lí
            


    }
}
