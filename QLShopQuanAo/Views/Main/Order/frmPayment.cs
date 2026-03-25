using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo.Views.Main.Order
{
    public partial class frmPayment : Form
    {
        BUS.OrderBUS oBUS = new BUS.OrderBUS();
        public string TenNV_Nhan { get; set; }
        public int MaNV_DangNhap { get; set; }
        public int MaKH_Nhan { get; set; }
        public string TenKH_Nhan { get; set; }
        public decimal TongTien_Nhan { get; set; }  
        public int MaNV_Nhan { get; set; }
        public DataTable GioHang_Nhan { get; set; }
        public frmPayment()
        {
            InitializeComponent();
        }


        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtIDCustomerPay.Text = MaKH_Nhan.ToString();
            txtNameCustomerPay.Text = TenKH_Nhan;
            lblCustomerTotalAmountPay.Text = TongTien_Nhan.ToString("N0") + " VNĐ";

            txtCustomerAmountTendered.Focus();
        }

        private void txtCustomerAmountTendered_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtCustomerAmountTendered.Text, out decimal khachTra))
                {
                    decimal tienThua = khachTra - TongTien_Nhan;
                    lblCustomerChange.Text = tienThua.ToString("N0") + " VNĐ";
                    if (tienThua < 0 || txtCustomerAmountTendered.Text=="")
                    {
                        lblCustomerChange.ForeColor = Color.Red;
                        btnPay.Enabled = false;
                    }
                    else
                    {
                        lblCustomerChange.ForeColor = Color.Green;
                        btnPay.Enabled = true;
                    }
                }
                else 
                {
                    lblCustomerChange.Text = "0 VNĐ";
                    lblCustomerChange.ForeColor = Color.Black;
                }
            }
            catch { }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerAmountTendered.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền khách trả!"); return;
            }

            // 2. Đóng gói dữ liệu
            DTO.OrderDTO hd = new DTO.OrderDTO
            {
                NgayLap = DateTime.Now,
                MaNV = this.MaNV_Nhan, // Dùng biến Nhan từ frmMain sang
                MaKH = this.MaKH_Nhan,
                TongTien = this.TongTien_Nhan
            };

            List<DTO.OrderDetailDTO> details = new List<DTO.OrderDetailDTO>();
            foreach (DataRow r in GioHang_Nhan.Rows)
            {
                details.Add(new DTO.OrderDetailDTO
                {
                    MaSP = Convert.ToInt32(r["MaSP"]),
                    SoLuong = Convert.ToInt32(r["SoLuong"]),
                    DonGia = Convert.ToDecimal(r["DonGia"])
                });
            }

            int maHD_Moi = oBUS.ThanhToan(hd, details);

            if (maHD_Moi > 0)
            {
                MessageBox.Show("Thanh toán thành công!");

                frmInvoice f = new frmInvoice();
                f.MaHD = maHD_Moi.ToString();
                f.MaNV = this.MaNV_Nhan.ToString();
                f.TenNV = this.TenNV_Nhan;
                f.NgayLap = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                f.MaKH = this.MaKH_Nhan.ToString();
                f.TenKH = this.TenKH_Nhan;
                f.TongTien = this.TongTien_Nhan.ToString("N0");
                f.ChiTietGioHang = this.GioHang_Nhan;

                f.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống hoặc không đủ hàng tồn kho!");
            }                                                                                                                                               

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
