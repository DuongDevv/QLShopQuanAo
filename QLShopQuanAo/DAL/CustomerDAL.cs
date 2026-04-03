using QLShopQuanAo.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLShopQuanAo.DAL
{
    public class CustomerDAL
    {

        public DataTable GetAll()
        {
            return DataHelper.GetDataTable("SELECT MaKH AS 'Mã KH', TenKH AS 'Tên KH', GioiTinh AS 'Giới Tính', SDT AS 'SĐT', Email, DiaChi AS 'Địa Chỉ', NgayDK AS 'Ngày Đăng Ký', DiemTichLuy AS 'Điểm Tích Lũy', LoaiThanhVien AS 'Loại Thành Viên' FROM KhachHang");
        }

        public DataTable GetSuppliers()
        {
            return DataHelper.GetDataTable("SELECT MaNCC, TenNCC, DiaChi FROM NhaCungCap");
        }
        public bool Insert(CustomerDTO kh)
        {
            string sql = "INSERT INTO KhachHang (TenKH, GioiTinh, SDT, Email, DiaChi, NgayDK) VALUES (@Ten, @Gioi, @SDT, @Email, @Dia, @Ngay)";
            SqlParameter[] pr = {
                new SqlParameter("@Ten", kh.TenKH), new SqlParameter("@Gioi", kh.GioiTinh),
                new SqlParameter("@SDT", kh.SDT), new SqlParameter("@Email", kh.Email),
                new SqlParameter("@Dia", kh.DiaChi), new SqlParameter("@Ngay", kh.NgayDK)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }

        public bool Update(CustomerDTO kh)
        {
            string sql = "UPDATE KhachHang SET TenKH=@Ten, GioiTinh=@Gioi, SDT=@SDT, Email=@Email, DiaChi=@Dia, NgayDK=@Ngay WHERE MaKH=@Ma";
            SqlParameter[] pr = {
                new SqlParameter("@Ma", kh.MaKH), 
                new SqlParameter("@Ten", kh.TenKH),
                new SqlParameter("@Gioi", kh.GioiTinh), 
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@Email", kh.Email), 
                new SqlParameter("@Dia", kh.DiaChi),
                new SqlParameter("@Ngay", kh.NgayDK)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }
        public bool Delete(int id)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = @id";
            SqlParameter[] pr = { new SqlParameter("@id", id) };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }
        public DataTable GetCustomerNames()
        {
            return DataHelper.GetDataTable("SELECT MaKH, TenKH FROM KhachHang");
        }
        public DataTable Search(string name)
        {
            string sql = "SELECT MaKH AS 'Mã KH', TenKH AS 'Tên KH', GioiTinh AS 'Giới Tính', SDT AS 'SĐT', Email, DiaChi AS 'Địa Chỉ', NgayDK AS 'Ngày Đăng Ký' FROM KhachHang WHERE TenKH LIKE @Ten";
            SqlParameter[] pr = { new SqlParameter("@Ten", "%" + name + "%") };
            return DataHelper.GetDataTable(sql, pr);
        }
        public bool UpdateLoyalty(int maKH, decimal soTienThem, int diemThem, string hangMoi)
        {
            string sql = "UPDATE KhachHang SET TongChiTieu = TongChiTieu + @tien, " +
                         "DiemTichLuy = DiemTichLuy + @diem, LoaiThanhVien = @hang WHERE MaKH = @id";
            SqlParameter[] pr = {
                new SqlParameter("@tien", soTienThem),
                new SqlParameter("@diem", diemThem),
                new SqlParameter("@hang", hangMoi),
                new SqlParameter("@id", maKH)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }
        public DataTable GetCustomerByID(int id)
        {
            string sql = "SELECT MaKH, TenKH, GioiTinh, SDT, Email, DiaChi, NgayDK, TongChiTieu, DiemTichLuy, LoaiThanhVien " +
                         "FROM KhachHang WHERE MaKH = @id";
            SqlParameter[] pr = { new SqlParameter("@id", id) };
            return DataHelper.GetDataTable(sql, pr);
        }

        public bool UpdateCustomerScore(int maKH, decimal tongTienHienTai)
        {
            int diemCongThem = (int)(tongTienHienTai / 100000);

            string sql = @"UPDATE KhachHang 
                   SET DiemTichLuy = ISNULL(DiemTichLuy, 0) + @DiemCong,
                       LoaiThanhVien = CASE 
                            WHEN (ISNULL(DiemTichLuy, 0) + @DiemCong) >= 2000 THEN N'Đen (VIP)'
                            WHEN (ISNULL(DiemTichLuy, 0) + @DiemCong) >= 500 THEN N'Vàng'
                            WHEN (ISNULL(DiemTichLuy, 0) + @DiemCong) >= 200 THEN N'Bạc'
                            ELSE N'Mới'
                       END
                   WHERE MaKH = @MaKH";

            SqlParameter[] pars = {
        new SqlParameter("@DiemCong", diemCongThem),
        new SqlParameter("@MaKH", maKH)
    };
            return DataHelper.ExecuteNonQuery(sql, pars) > 0;
}
    }
}