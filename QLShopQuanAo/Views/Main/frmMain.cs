using QLShopQuanAo.Views.Main.ChangePassword;
using QLShopQuanAo.Views.Main.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OfficeOpenXml; 
using OfficeOpenXml.Style; 
using System.IO; 
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace QLShopQuanAo.Views.Main
{
    public partial class frmMain : Form
    {
        BUS.StaffBUS nvBUS = new BUS.StaffBUS();
        BUS.CustomerBUS khBUS = new BUS.CustomerBUS();
        BUS.ProductBUS spBUS = new BUS.ProductBUS();
        BUS.ReportBUS rptBUS = new BUS.ReportBUS();
        BUS.ImportBUS ipBUS = new BUS.ImportBUS();

        public string ChucVu_DangNhap { get; set; }
        public int MaNV_DangNhap { get; set; }
        public string TenNV_DangNhap { get; set; }
        public string TenNV_Nhan { get; set; }


        DataTable cartTable = new DataTable();
        string staffImageFolder = Path.Combine(Application.StartupPath, "Images", "Staff");
        string productImageFolder = Path.Combine(Application.StartupPath, "Images", "Products");
        string currentFileName = "";

        int selectedMaNCC = -1;


        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadComboBoxLoaiSP();

            LoadDataNhanVien();

            LoadDataSanPham();

            LoadDataKhachHang();

            SetupCartTable();

            LoadDataSanPhamChoBanHang();

            LoadComboBoxKhachHang();

            LoadDataChoNhapHang();

            HienThiTenNhanVien();

            ShowPage(pnHome);

            LoadAccountInformation();

            LoadTopSellingProducts();

            RefreshDashboard();

            LoadPieChartData();

            AccessControl(this.ChucVu_DangNhap);

            timerClock.Start();
        }

        //Điều hướng
        private void ShowPage(Panel targetPanel)
        {
            pnHome.Visible = pnStaff.Visible = pnProduct.Visible =
            pnCustomer.Visible = pnOrderProduct.Visible = pnInformationProduct.Visible = pnStaffAccountInformation.Visible = false;

            targetPanel.Visible = true;
            targetPanel.Dock = DockStyle.Fill;
        }
        private void btnHome_Click(object sender, EventArgs e) => ShowPage(pnHome);
        private void btnStaff_Click(object sender, EventArgs e) => ShowPage(pnStaff);
        private void btnProduct_Click(object sender, EventArgs e) => ShowPage(pnProduct);
        private void btnCustomer_Click(object sender, EventArgs e) => ShowPage(pnCustomer);
        private void btnBill_Click(object sender, EventArgs e) => ShowPage(pnOrderProduct);
        private void btnInsertProduct_Click(object sender, EventArgs e) => ShowPage(pnInformationProduct);
        private void btnAccount_Click(object sender, EventArgs e) => ShowPage(pnStaffAccountInformation);



        // Kiểm tra định dạng Email
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Kiểm tra định dạng Số điện thoại (Việt Nam)
        private bool IsValidPhone(string phone)
        {
            string phonePattern = @"^0\d{9}$";
            return Regex.IsMatch(phone, phonePattern);
        }



        //Nút đăng xuất
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo",

                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Form frm = Application.OpenForms["frmLogin"];
                if (frm != null)
                {
                    frm.Show();
                    this.Close();
                }
            }
        }







        //TRANG NHÂN VIÊN
        private void LoadDataNhanVien()
        {
            dgvStaff.DataSource = nvBUS.LoadStaff();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtIDStaff.Clear();
            txtNameStaff.Clear();
            txtEmailStaff.Clear();
            txtPhoneNumberStaff.Clear();
            cboPositionStaff.SelectedIndex = -1;
            dtpDateStaff.Value = DateTime.Now;
            picAvatarStaff.Image?.Dispose();
            picAvatarStaff.Image = null;
            currentFileName = "";
            txtNameStaff.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DTO.StaffDTO nv = new DTO.StaffDTO
            {
                TenNV = txtNameStaff.Text.Trim(),
                GioiTinh = cboSexStaff.Text,
                NgaySinh = dtpDateStaff.Value,
                SDT = txtPhoneNumberStaff.Text.Trim(),
                Email = txtEmailStaff.Text.Trim(),
                ChucVu = cboPositionStaff.Text,
                HinhAnh = currentFileName
            };

            if (string.IsNullOrWhiteSpace(nv.TenNV))
            {
                MessageBox.Show("Vui lòng nhập Tên NV!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameStaff.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nv.Email))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailStaff.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nv.SDT))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumberStaff.Focus();
                return;
            }

            if (cboPositionStaff.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Chức vụ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPositionStaff.Focus();
                return;
            }

            if (cboSexStaff.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSexStaff.Focus();
                return;
            }

            if (!IsValidEmail(nv.Email))
            {
                MessageBox.Show("Email không đúng định dạng (Ví dụ: abc@gmail.com)!", "Lỗi định dạng");
                txtEmailStaff.Focus();
                return;
            }

            if (!IsValidPhone(nv.SDT))
            {
                MessageBox.Show("Số điện thoại phải 10 số và bắt đầu bằng số 0!", "Lỗi định dạng");
                txtPhoneNumberStaff.Focus();
                return;
            }



            if (nvBUS.AddStaff(nv))
            {
                MessageBox.Show("Thêm thành công!");
                LoadDataNhanVien();
                btnReset_Click(sender, e);
            }
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtIDStaff.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ bảng dữ liệu!", "Thông báo");
                return;
            }
            DTO.StaffDTO nv = new DTO.StaffDTO
            {
                MaNV = int.Parse(txtIDStaff.Text),
                TenNV = txtNameStaff.Text.Trim(),
                GioiTinh = cboSexStaff.Text,
                NgaySinh = dtpDateStaff.Value,
                SDT = txtPhoneNumberStaff.Text.Trim(),
                Email = txtEmailStaff.Text.Trim(),
                ChucVu = cboPositionStaff.Text,
                HinhAnh = currentFileName
            };

            if (!IsValidEmail(nv.Email))
            {
                MessageBox.Show("Email không đúng định dạng (Ví dụ: abc@gmail.com)!", "Lỗi định dạng");
                txtEmailStaff.Focus();
                return;
            }

            if (!IsValidPhone(nv.SDT))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0!", "Lỗi định dạng");
                txtPhoneNumberStaff.Focus();
                return;
            }
            if (nvBUS.UpdateStaff(nv))
            {
                MessageBox.Show("Sửa thành công!");
                LoadDataNhanVien();
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại đang được click
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                //Thêm dữ liệu đươc click vào TexBox..
                txtIDStaff.Text = row.Cells["Mã NV"].Value.ToString();
                txtNameStaff.Text = row.Cells["Tên NV"].Value.ToString();
                cboSexStaff.Text = row.Cells["Giới Tính"].Value.ToString();
                dtpDateStaff.Value = Convert.ToDateTime(row.Cells["Ngày Sinh"].Value);
                txtPhoneNumberStaff.Text = row.Cells["SĐT"].Value.ToString();
                txtEmailStaff.Text = row.Cells["Email"].Value.ToString();
                cboPositionStaff.Text = row.Cells["Chức Vụ"].Value.ToString();

                picAvatarStaff.Image?.Dispose();
                picAvatarStaff.Image = null;

                if (row.Cells["Hình Ảnh"].Value != DBNull.Value)
                {
                    string fileName = row.Cells["Hình Ảnh"].Value.ToString();
                    currentFileName = fileName;
                    string fullPath = Path.Combine(staffImageFolder, fileName);
                    if (File.Exists(fullPath))
                    {
                        byte[] imageBytes = File.ReadAllBytes(fullPath);
                        using (var ms = new MemoryStream(File.ReadAllBytes(fullPath)))
                        {
                            picAvatarStaff.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy file tại: " + fullPath);
                    }
                }
            }
        }

        private void btnRemoveStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDStaff.Text))

            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
                return;
            }

            int id = int.Parse(txtIDStaff.Text);

            if (nvBUS.RemoveStaff(id))
            {
                MessageBox.Show("Xóa thành công!");
                LoadDataNhanVien();
                btnReset_Click(sender, e);
            }

        }

        private void FilterNhanVien()
        {
            try
            {
                dgvStaff.DataSource = nvBUS.Search(txtSearchNameStaff.Text.Trim(),
                                        cboSearchPositionStaff.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc: " + ex.Message);
            }
        }
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

            FilterNhanVien();
        }

        private void cboSearchPosition_SelectedIndexChanged(object sender, EventArgs e)

        {
            FilterNhanVien();
        }

        private void btnUpLoadAvatar_Click(object sender, EventArgs e)

        {

            picAvatar_Click(sender, e);

        }

        private void picAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatarStaff.Image?.Dispose();
                    byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        picAvatarStaff.Image = Image.FromStream(ms);
                    }
                    picAvatarStaff.SizeMode = PictureBoxSizeMode.StretchImage;
                    currentFileName = Guid.NewGuid() + Path.GetExtension(ofd.FileName);
                    if (!Directory.Exists(staffImageFolder)) Directory.CreateDirectory(staffImageFolder);
                    string destPath = Path.Combine(staffImageFolder, currentFileName);
                    File.Copy(ofd.FileName, destPath, true);
                }
            }
        }

        private void btnApplyStaff_Click(object sender, EventArgs e)
        {
            FilterNhanVien();
        }

        private void btnClearStaff_Click(object sender, EventArgs e)
        {
            txtSearchNameStaff.Clear();
            LoadDataKhachHang();
        }

        private void btnUpLoadAvatarStaff_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg";
                ofd.Title = "Chọn ảnh nhân viên";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Hiện thị lên pictureBox
                        picAvatarStaff.Image?.Dispose(); //Giải phóng ảnh cũ
                        byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            picAvatarStaff.Image = Image.FromStream(ms);
                        }
                        picAvatarStaff.SizeMode = PictureBoxSizeMode.StretchImage;

                        //Tạo tên file duy nhất bằng Guid để không bao giờ bị trùng
                        currentFileName = Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);

                        //Kiểm tra và Tự động tạo thư mục nếu chưa có (Tránh lỗi không tìm thấy đường dẫn)
                        if (!Directory.Exists(staffImageFolder))
                        {
                            Directory.CreateDirectory(staffImageFolder);
                        }

                        //Copy file từ máy vào thư mục dự án 
                        string destPath = Path.Combine(staffImageFolder, currentFileName);
                        File.Copy(ofd.FileName, destPath, true);

                        MessageBox.Show("Đã tải và tạo file ảnh thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xử lý ảnh: " + ex.Message);
                    }
                }
            }
        }






        //TRANG KHÁCH HÀNG
        private void LoadDataKhachHang()
        {
            dgvCustomer.DataSource = khBUS.LoadCustomer();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DTO.CustomerDTO kh = new DTO.CustomerDTO
            {
                TenKH = txtNameCustomer.Text.Trim(),
                GioiTinh = cboSexCustomer.Text,
                SDT = txtPhoneNumberCustomer.Text.Trim(),
                Email = txtEmailCustomer.Text.Trim(),
                DiaChi = txtAddressCustomer.Text.Trim(),
                NgayDK = dtpRegistrationDateCustomer.Value
            };

            if (!IsValidEmail(txtEmailCustomer.Text))
            {

                MessageBox.Show("Email không đúng định dạng (Ví dụ: abc@gmail.com)!", "Lỗi định dạng");

                txtEmailCustomer.Focus();
                return;
            }

            if (!IsValidPhone(txtPhoneNumberCustomer.Text))
            {
                MessageBox.Show("Số điện thoại phải 10 số và bắt đầu bằng số 0!", "Lỗi định dạng");
                txtPhoneNumberCustomer.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNameCustomer.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên KH!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameCustomer.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddressCustomer.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddressCustomer.Focus();
                return;
            }

            if (cboSexCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSexCustomer.Focus();
                return;
            }

            try
            {
                if (khBUS.AddCustomer(kh)) {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK);
                    LoadDataKhachHang();
                    btnResetCustomer_Click(sender, e);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("Số điện thoại này đã được đăng ký!");
                else MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                txtIDCustomer.Text = row.Cells["Mã KH"].Value.ToString();
                txtNameCustomer.Text = row.Cells["Tên KH"].Value.ToString();
                cboSexCustomer.Text = row.Cells["Giới Tính"].Value.ToString();
                txtPhoneNumberCustomer.Text = row.Cells["SĐT"].Value.ToString();
                txtEmailCustomer.Text = row.Cells["Email"].Value.ToString();
                txtAddressCustomer.Text = row.Cells["Địa Chỉ"].Value.ToString();
                dtpRegistrationDateCustomer.Value = Convert.ToDateTime(row.Cells["Ngày Đăng Ký"].Value);
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            DTO.CustomerDTO kh = new DTO.CustomerDTO
            {
                MaKH = int.Parse(txtIDCustomer.Text),
                TenKH = txtNameCustomer.Text.Trim(),
                GioiTinh = cboSexCustomer.Text,
                SDT = txtPhoneNumberCustomer.Text.Trim(),
                Email = txtEmailCustomer.Text.Trim(),
                DiaChi = txtAddressCustomer.Text.Trim(),
                NgayDK = dtpRegistrationDateCustomer.Value
            };

            if (string.IsNullOrWhiteSpace(txtIDCustomer.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ bảng!", "Thông báo");
                return;
            }

            if (!IsValidEmail(kh.Email))
            {
                MessageBox.Show("Email sai định dạng!");
                return;
            }
            if (!IsValidPhone(kh.SDT)) {
                MessageBox.Show("SĐT phải đủ 10 số!");
                return;
            }

            try
            {
                if (khBUS.UpdateCustomer(kh))
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thành công");
                    LoadDataKhachHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }
        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDCustomer.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int id = int.Parse(txtIDCustomer.Text);

                try
                {
                    if (khBUS.RemoveCustomer(id))
                    {
                        MessageBox.Show("Đã xóa khách hàng thành công!");
                        LoadDataKhachHang();
                        btnResetCustomer_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa khách hàng này vì đã có lịch sử mua hàng! (Lỗi: " + ex.Message + ")");
                }
            }
        }

        private void btnResetCustomer_Click(object sender, EventArgs e)
        {

            txtIDCustomer.Clear();
            txtNameCustomer.Clear();
            txtPhoneNumberCustomer.Clear();
            txtEmailCustomer.Clear();
            txtAddressCustomer.Clear();
            cboSexCustomer.SelectedIndex = -1;
            dtpRegistrationDateCustomer.Value = DateTime.Now;
            txtNameCustomer.Focus();
        }

        private void FilterKhachHang()
        {
            string nameKey = txtSearchNameCustomer.Text.Trim();

            try
            {
                dgvCustomer.DataSource = khBUS.SearchCustomer(nameKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc: " + ex.Message);
            }
        }
        private void btnApplyCustomer_Click(object sender, EventArgs e)
        {
            FilterKhachHang();
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            txtSearchNameCustomer.Clear();
            FilterKhachHang();
        }









        //TRANG SẢN PHẨM
        private void LoadDataSanPham()
        {
            dgvProduct.DataSource = spBUS.LoadProduct();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];

                txtIDProduct.Text = row.Cells["Mã SP"].Value.ToString();
                txtNameProduct.Text = row.Cells["Tên SP"].Value.ToString();
                txtQuantityProduct.Text = row.Cells["Số lượng"].Value.ToString();
                txtUnitProduct.Text = row.Cells["DVT"].Value.ToString();
                txtPriceProduct.Text = row.Cells["Đơn giá"].Value.ToString();
                cboTypeProduct.Text = row.Cells["Loại SP"].Value.ToString();
                picAvatarProduct.Image?.Dispose();
                picAvatarProduct.Image = null;
                currentFileName = "";

                if (row.Cells["HinhAnh"].Value != DBNull.Value && !string.IsNullOrEmpty(row.Cells["HinhAnh"].Value.ToString()))
                {
                    string fileName = row.Cells["HinhAnh"].Value.ToString();
                    currentFileName = fileName;
                    string fullPath = Path.Combine(productImageFolder, fileName);

                    if (File.Exists(fullPath))
                    {
                        using (var ms = new MemoryStream(File.ReadAllBytes(fullPath)))
                        {
                            picAvatarProduct.Image = Image.FromStream(ms);
                        }
                        picAvatarProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDProduct.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo",
                    MessageBoxButtons.OK);
                return;
            }

            DTO.ProductDTO sp = new DTO.ProductDTO
            {
                TenSP = txtNameProduct.Text.Trim(),
                MaLoai = Convert.ToInt32(cboTypeProduct.SelectedValue),
                DVT = txtUnitProduct.Text.Trim(),
                SoLuongTon = int.Parse(txtQuantityProduct.Text),
                GiaBan = decimal.Parse(txtPriceProduct.Text),
                HinhAnh = currentFileName
            };

            try
            {
                if (spBUS.UpdateProduct(sp))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo");
                    LoadDataSanPham();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật SP: " + ex.Message); }
        }

        private void FilterSanPham()
        {
            try
            {
                int maLoai = (cboSearchTypeProduct.SelectedValue != null) ? (int)cboSearchTypeProduct.SelectedValue : 0;
                dgvProduct.DataSource = spBUS.Search(txtSearchNameProduct.Text.Trim(), maLoai);
            }
            catch (Exception) { }
        }

        private void btnDiscontinuedProduct_Click(object sender, EventArgs e)
        {
            UpdateProductStatus("Ngừng kinh doanh", "Sản phẩm đã ngừng kinh doanh!");
        }

        private void btnResumedProduct_Click(object sender, EventArgs e)
        {
            UpdateProductStatus("Đang kinh doanh", "Sản phẩm đã được mở bán lại!");
        }

        private void UpdateProductStatus(string status, string message)
        {
            if (string.IsNullOrWhiteSpace(txtIDProduct.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK);
                return;
            }
            int id = int.Parse(txtIDProduct.Text);

            if (spBUS.ChangeStatus(id, status))
            {
                MessageBox.Show(message, "Thông báo");
                LoadDataSanPham();
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại!");
            }
        }

        private void btnResetProduct_Click(object sender, EventArgs e)
        {
            txtIDProduct.Clear();
            txtNameProduct.Clear();
            txtQuantityProduct.Clear();
            txtUnitProduct.Clear();
            txtPriceProduct.Clear();
            cboTypeProduct.SelectedIndex = -1;
            picAvatarProduct.Image?.Dispose();
            picAvatarProduct.Image = null;
            currentFileName = "";
            txtNameProduct.Focus();
        }

        private void btnUploadAvatarProduct_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatarProduct.Image?.Dispose();

                    byte[] imageBytes = File.ReadAllBytes(ofd.FileName);

                    using (var ms = new MemoryStream(imageBytes))
                    {
                        picAvatarProduct.Image = Image.FromStream(ms);
                    }
                    picAvatarProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    currentFileName = Guid.NewGuid() + Path.GetExtension(ofd.FileName);

                    if (!Directory.Exists(productImageFolder)) Directory.CreateDirectory(productImageFolder);

                    string destPath = Path.Combine(productImageFolder, currentFileName);
                    File.Copy(ofd.FileName, destPath, true);

                }

            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            DTO.ProductDTO sp = new DTO.ProductDTO
            {
                TenSP = txtNameProduct.Text.Trim(),
                MaLoai = Convert.ToInt32(cboTypeProduct.SelectedValue),
                DVT = txtUnitProduct.Text.Trim(),
                SoLuongTon = string.IsNullOrEmpty(txtQuantityProduct.Text) ? 0 : int.Parse(txtQuantityProduct.Text),
                GiaBan = string.IsNullOrEmpty(txtPriceProduct.Text) ? 0 : decimal.Parse(txtPriceProduct.Text),
                HinhAnh = currentFileName,
                TrangThai = "Đang kinh doanh"
            };

            if (string.IsNullOrWhiteSpace(txtNameProduct.Text) || cboTypeProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm và chọn loại hàng!", "Thông báo");
                return;
            }

            try
            {
                if (spBUS.AddProduct(sp))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK);
                    LoadDataSanPham();
                    btnResetProduct_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        private void LoadComboBoxLoaiSP()
        {
            try
            {
                DataTable dt = spBUS.GetCategories();

                cboTypeProduct.DataSource = dt;
                cboTypeProduct.DisplayMember = "TenLoaiSP";
                cboTypeProduct.ValueMember = "MaLoai";

                DataTable dtSearch = dt.Copy();
                cboSearchTypeProduct.DataSource = dtSearch;
                cboSearchTypeProduct.DisplayMember = "TenLoaiSP";
                cboSearchTypeProduct.ValueMember = "MaLoai";
                cboSearchTypeProduct.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nạp loại SP: " + ex.Message); }
        }

        private void btnApplyProduct_Click(object sender, EventArgs e)
        {
            FilterSanPham();
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            FilterSanPham();

        }




        //TRANG ORDER SẢN PHẨM
        private void SetupCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("MaSP", typeof(int));
            cartTable.Columns.Add("TenSP", typeof(string));
            cartTable.Columns.Add("SoLuong", typeof(int));
            cartTable.Columns.Add("DonGia", typeof(decimal));
            cartTable.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");
            dgvCart.DataSource = cartTable;
            dgvCart.Columns["MaSP"].HeaderText = "Mã SP";
            dgvCart.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvCart.Columns["SoLuong"].HeaderText = "SL";
            dgvCart.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvCart.Columns["ThanhTien"].HeaderText = "Thành Tiền";
        }
        private void LoadDataSanPhamChoBanHang()
        {
            dgvProductsOrder.DataSource = spBUS.LoadProductActive();
        }

        private void TinhTongTien()
        {
            decimal tongCong = 0;
            foreach (DataRow row in cartTable.Rows)
            {
                tongCong += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTotalAmount.Text = tongCong.ToString("N0") + " VNĐ";
            lblTotalAmount.ForeColor = Color.Red;
            lblTotalAmount.Font = new Font(lblTotalAmount.Font, FontStyle.Bold);
        }

        private void FilterOrderProduct()
        {
            string nameKey = txtSearchOrderProductName.Text.Trim();
            int maLoai = 0;
            if (cboSearchOrderProductType.SelectedValue != null && cboSearchOrderProductType.SelectedValue is int)
            {
                maLoai = (int)cboSearchOrderProductType.SelectedValue;
            }

            dgvProductsOrder.DataSource = spBUS.SearchAtiveProduct(nameKey, maLoai);
        }

        private void btnApplySearchOrderProduct_Click(object sender, EventArgs e)
        {
            FilterOrderProduct();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa toàn bộ giỏ hàng?", "Hủy đơn",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cartTable.Clear();
                TinhTongTien();
            }
        }

        private void LoadComboBoxKhachHang()
        {
            cboCustomerOrder.DataSource = khBUS.GetCustomerNames();
            cboCustomerOrder.DisplayMember = "TenKH";
            cboCustomerOrder.ValueMember = "MaKH";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra điều kiện trước khi mở bảng thanh toán
            if (cboCustomerOrder.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo");
                return;
            }
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo");
                return;
            }

            Order.frmPayment fPay = new Order.frmPayment();

            fPay.MaKH_Nhan = Convert.ToInt32(cboCustomerOrder.SelectedValue);
            fPay.TenKH_Nhan = cboCustomerOrder.Text;
            fPay.MaNV_Nhan = this.MaNV_DangNhap;
            fPay.TenNV_Nhan = this.TenNV_DangNhap;
            fPay.GioHang_Nhan = this.cartTable;

            decimal tong = 0;
            foreach (DataRow r in cartTable.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            fPay.TongTien_Nhan = tong;

            if (fPay.ShowDialog() == DialogResult.OK)
            {
                cartTable.Clear();
                TinhTongTien();
                LoadDataSanPhamChoBanHang();
                cboCustomerOrder.SelectedIndex = -1;
            }
        }
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("Bạn muốn xóa món này khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cartTable.Rows.RemoveAt(e.RowIndex);
                    TinhTongTien();
                }
            }
        }

        private void btnApplySearchOrderProduct_Click_1(object sender, EventArgs e)
        {
            FilterOrderProduct();
        }

        private void btnRefreshSearchOrderProduct_Click(object sender, EventArgs e)
        {
            FilterOrderProduct();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProductsOrder.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo");
                return;
            }
            int maSP = Convert.ToInt32(dgvProductsOrder.CurrentRow.Cells["Mã SP"].Value);
            string tenSP = dgvProductsOrder.CurrentRow.Cells["Tên SP"].Value.ToString();
            decimal gia = Convert.ToDecimal(dgvProductsOrder.CurrentRow.Cells["Đơn giá"].Value);
            int soLuongMua = (int)nudQuantityOrder.Value;
            if (soLuongMua <= 0) { MessageBox.Show("Số lượng phải > 0"); return; }

            DialogResult dr = MessageBox.Show($"Thêm {soLuongMua} [{tenSP}] vào giỏ?", "Xác nhận",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                bool existed = false;
                foreach (DataRow row in cartTable.Rows)
                {
                    if ((int)row["MaSP"] == maSP)
                    {
                        row["SoLuong"] = (int)row["SoLuong"] + soLuongMua;
                        existed = true;
                        break;
                    }
                }
                if (!existed) cartTable.Rows.Add(maSP, tenSP, soLuongMua, gia);

                TinhTongTien();

                nudQuantityOrder.Value = 1;

            }
        }








        //TRANG NHẬP SẢN PHẨM
        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvProductList.Rows[e.RowIndex];
                txtImportProductID.Text = r.Cells["MaSP"].Value.ToString();
                txtImportProductName.Text = r.Cells["TenSP"].Value.ToString();
            }
        }

        private void dgvSupplierInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectedMaNCC = Convert.ToInt32(dgvSupplierInformation.Rows[e.RowIndex].Cells["MaNCC"].Value);
        }

        private void btnImportProduct_Click(object sender, EventArgs e)
        {
            if (selectedMaNCC == -1)
            {
                MessageBox.Show("Vui lòng chọn Nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtImportProductID.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtImportPrice.Text) || string.IsNullOrEmpty(txtImportQuantity.Text))
            {
                MessageBox.Show("Vui lòng nhập giá và số lượng!", "Thông báo",
                    MessageBoxButtons.OK);
                return;
            }

            DTO.ImportDTO ip = new DTO.ImportDTO
            {
                MaNV = this.MaNV_DangNhap,
                MaNCC = selectedMaNCC,
                MaSP = int.Parse(txtImportProductID.Text),
                SoLuong = int.Parse(txtImportQuantity.Text),
                DonGia = decimal.Parse(txtImportPrice.Text),
                TongTien = decimal.Parse(txtImportPrice.Text) * int.Parse(txtImportQuantity.Text)
            };

            try
            {
                if (ipBUS.NhapHang(ip))
                {
                    MessageBox.Show("Nhập kho thành công!");
                    LoadDataChoNhapHang();
                }
                else
                {
                    MessageBox.Show("Lỗi nhập hàng, vui lòng kiểm tra lại hệ thống!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập hàng: " + ex.Message);
            }
        }

        private void LoadDataChoNhapHang()
        {
            try
            {
                dgvProductList.DataSource = spBUS.LoadProduct();
                dgvSupplierInformation.DataSource = khBUS.GetSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhập hàng: " + ex.Message);
            }
        }





        //TRANG HOME
        private void HienThiTenNhanVien()
        {
            if (!string.IsNullOrEmpty(TenNV_DangNhap))
            {
                lblStaffGreeting.Text = "Xin chào, " + TenNV_DangNhap;
            }
        }

        private void LoadTopSellingProducts()
        {
            dgvTopProducts.DataSource = rptBUS.GetTopProduct();

            dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopProducts.BackgroundColor = Color.White;
            dgvTopProducts.RowHeadersVisible = false;
        }
        private void RefreshDashboard()
        {
            try
            {
                label60.Text = rptBUS.LayHangSapHet();
                label58.Text = rptBUS.LayKhachMoi();
                label57.Text = rptBUS.LayDonHangMoi();
                label55.Text = rptBUS.LayDoanhThu();
                dgvTopProducts.DataSource = rptBUS.GetTopProduct();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật Dashboard: " + ex.Message);
            }
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            label62.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void LoadPieChartData()
        {
            try
            {
                DataTable dt = rptBUS.LayDoanhThuTheoLoai();

                chartTopCategories.Series[0].Points.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    int i = chartTopCategories.Series[0].Points.AddXY(r["TenLoaiSP"], r["DoanhThu"]);

                    chartTopCategories.Series[0].Points[i].Label = "#PERCENT";
                    chartTopCategories.Series[0].Points[i].LegendText = r["TenLoaiSP"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi vẽ biểu đồ: " + ex.Message);
            }
        }

        private void ExportDataTableToExcel(DataTable dt, string fileName)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("DoanhThu");

                        //Đổ Header từ cột của DataTable
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            var cell = ws.Cells[1, i + 1];
                            cell.Value = dt.Columns[i].ColumnName;
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(Color.Green);
                            cell.Style.Font.Color.SetColor(Color.White);
                        }

                        //Đổ dữ liệu từ DataTable vào Excel (LoadFromDataTable là hàm cực nhanh của EPPlus)
                        ws.Cells["A2"].LoadFromDataTable(dt, false);
                        int rowCount = dt.Rows.Count + 1;
                        for (int i = 2; i <= rowCount; i++)
                        {
                            string cellValue = ws.Cells[i, 3].Text;

                            if (cellValue.Contains("--- TỔNG"))
                            {
                                ws.Row(i).Style.Fill.PatternType = ExcelFillStyle.Solid;
                                ws.Row(i).Style.Font.Bold = true;
                                ws.Row(i).Style.Font.Color.SetColor(Color.Blue);
                            }
                        }

                        //Định dạng cột tiền tệ cho cột cuối cùng (Tổng Tiền)
                        int lastCol = dt.Columns.Count;
                        ws.Column(lastCol).Style.Numberformat.Format = "#,##0";

                        ws.Cells.AutoFitColumns();
                        File.WriteAllBytes(sfd.FileName, pck.GetAsByteArray());

                        MessageBox.Show("Đã xuất toàn bộ báo cáo doanh thu!", "Thành công");
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dtDoanhThu = rptBUS.GetTotalRevenue();

            if (dtDoanhThu.Rows.Count > 0)
            {
                DataTable dtDaCoTong = InsertDailyTotalRevenue(dtDoanhThu);

                //Xuất ra file
                ExportDataTableToExcel(dtDaCoTong, "Bao_Cao_Tong_Hop_Doanh_Thu");
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu hóa đơn nào để xuất!");
            }
        }

        private DataTable InsertDailyTotalRevenue(DataTable dtDoanhThu)
        {
            DataTable dtResult = dtDoanhThu.Clone();
            if (dtDoanhThu.Rows.Count == 0 || dtDoanhThu == null) return dtResult;

            decimal totalSameDay = 0;
            // Lấy ngày của dòng ĐẦU TIÊN (Index 0) để làm mốc so sánh
            string today = dtDoanhThu.Rows[0]["Ngày Lập"].ToString().Substring(0, 10);

            for (int i = 0; i < dtDoanhThu.Rows.Count; i++)
            {
                // Thống nhất tên cột là "Ngày Lập"
                string dateRow = dtDoanhThu.Rows[i]["Ngày Lập"].ToString().Substring(0, 10);
                decimal amount = Convert.ToDecimal(dtDoanhThu.Rows[i]["Tổng Tiền"]);

                // Nếu phát hiện đổi sang ngày khác -> Chèn dòng tổng của ngày cũ
                if (dateRow != today)
                {
                    DataRow totalRow = dtResult.NewRow();
                    totalRow["Nhân Viên"] = "--- TỔNG NGÀY " + today + " ---";
                    totalRow["Tổng Tiền"] = totalSameDay;
                    dtResult.Rows.Add(totalRow);

                    // Reset mốc cho ngày mới
                    totalSameDay = 0;
                    today = dateRow;
                }

                dtResult.ImportRow(dtDoanhThu.Rows[i]);
                totalSameDay += amount;

                // Nếu là dòng cuối cùng của cả bảng -> Chèn nốt tổng của ngày cuối
                if (i == dtDoanhThu.Rows.Count - 1)
                {
                    DataRow totalLastRow = dtResult.NewRow();
                    totalLastRow["Nhân Viên"] = "--- TỔNG NGÀY " + today + " ---";
                    totalLastRow["Tổng Tiền"] = totalSameDay;
                    dtResult.Rows.Add(totalLastRow);
                }
            }
            return dtResult;
        }




        //TRANG TÀI KHOẢN
        private void LoadAccountInformation()
        {
            try
            {
                DataRow r = nvBUS.GetInformationAccount(MaNV_DangNhap);
                if (r != null)
                {
                    txtIDAccount.Text = r["MaNV"].ToString();
                    txtNameStaffAccount.Text = r["TenNV"].ToString();
                    txtPositionAccount.Text = r["ChucVu"].ToString();
                    txtAccountUsername.Text = r["TenTK"].ToString();
                    txtAccountPassword.Text = r["MatKhau"].ToString();

                    txtAccountPassword.UseSystemPasswordChar = true;
                    chkShowPassword.Checked = false;
                    txtAccountPassword.Refresh();


                    // Xử lý hiển thị ảnh tương tự như cũ nhưng dùng r["HinhAnh"]
                    string fileName = r["HinhAnh"].ToString();
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        string fullPath = Path.Combine(staffImageFolder, fileName);
                        if (File.Exists(fullPath))
                        {
                            using (var ms = new MemoryStream(File.ReadAllBytes(fullPath)))
                            {
                                picAvatarStaffAccount.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin tài khoản: " + ex.Message);
            }
        
        }

 

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword();
            f.MaNV_HienTai = this.MaNV_DangNhap;
            f.ShowDialog();
        }

        


        //Phân quyền giữ nhân viên và Quản lí khi đăng nhập
        private void AccessControl(string chucVu)
        {
            if(chucVu == "Nhân viên")
            {
                btnProduct.Visible = false;      
                btnImportProduct.Visible = false;
                btnCustomer.Visible = false;     
                btnStaff.Visible = false;
                btnInsertProduct.Visible = false;
                btnExportExcel.Visible = false;

            }
            else
            {
                btnProduct.Visible = true;
                btnImportProduct.Visible = true;
                btnCustomer.Visible = true;
                btnStaff.Visible = true;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked==true)
            {
                txtAccountPassword.UseSystemPasswordChar = false; 
            }
            else
            {
                txtAccountPassword.UseSystemPasswordChar = true; 
            }
            txtAccountPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}

