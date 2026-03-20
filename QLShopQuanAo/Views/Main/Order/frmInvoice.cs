using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QLShopQuanAo.Views.Main.Order
{
    public partial class frmInvoice : Form
    {
        //Biến để lưu ảnh
        Bitmap memoryImage;

        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string NgayLap { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string TongTien { get; set; }
        public DataTable ChiTietGioHang { get; set; }
        public frmInvoice()
        {
            InitializeComponent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            lblInvoiceID.Text = MaHD;
            lblStaffID.Text = MaNV;
            lblNameStaff.Text = TenNV;
            lblDate.Text = NgayLap;
            lblCustomerID.Text = MaKH;
            lblCustomerName.Text = TenKH;
            lblTotalAmount.Text = TongTien + " VNĐ";
            

            if (ChiTietGioHang != null)
            {
                dgvInvoiceDetails.DataSource = ChiTietGioHang;
            }
            if (dgvInvoiceDetails.Columns.Contains("DonGia"))
            {
                dgvInvoiceDetails.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvInvoiceDetails.Columns.Contains("ThanhTien"))
            {
                dgvInvoiceDetails.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang kết nối máy in...", "Thông báo");
            btnPrint.Visible = false; 

            CaptureScreen();

            //Khởi tạo đối tượng in (PrintDocument)
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            //Hiện hộp thoại chọn máy in (PrintDialog)
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = pd;

            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print(); 
            }
            
            btnPrint.Visible = true;  // In xong hiện nút lại
        }

        private void CaptureScreen()
        {
            memoryImage = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(memoryImage, new Rectangle(0, 0, this.Width, this.Height));
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}




