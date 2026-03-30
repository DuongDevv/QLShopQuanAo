using System;
using System.Data;
using System.Data.SqlClient;
using QLShopQuanAo.DTO;

namespace QLShopQuanAo.DAL
{
    public class StaffDAL
    {
        public DataTable GetAll()
        {
            string sql = "SELECT MaNV AS 'Mã NV', TenNV AS 'Tên NV', GioiTinh AS 'Giới Tính', NgaySinh AS 'Ngày Sinh', SDT AS 'SĐT', Email, ChucVu AS 'Chức Vụ', TrangThai as 'Trạng Thái', HinhAnh as 'Hình Ảnh' FROM NhanVien";
            return DataHelper.GetDataTable(sql);
        }

        public int InsertAndGetID(StaffDTO nv)
        {
            string sql = "INSERT INTO NhanVien (TenNV, GioiTinh, NgaySinh, SDT, Email, ChucVu, HinhAnh) VALUES (@Ten, @Gioi, @Ngay, @SDT, @Email, @CV, @Hinh);SELECT SCOPE_IDENTITY();";
            SqlParameter[] pr = {
                new SqlParameter("@Ten", nv.TenNV),
                new SqlParameter("@Gioi", nv.GioiTinh),
                new SqlParameter("@Ngay", nv.NgaySinh),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@Email", nv.Email),
                new SqlParameter("@CV", nv.ChucVu),
                new SqlParameter("@Hinh", nv.HinhAnh)
            };
            object res = DataHelper.ExecuteScalar(sql, pr);
            return (res != null) ? Convert.ToInt32(res) : 0;
        }

        public bool Update(StaffDTO nv)
        {
            string sql = "UPDATE NhanVien SET TenNV=@Ten, GioiTinh=@Gioi, NgaySinh=@Ngay, SDT=@SDT, Email=@Email, ChucVu=@CV, HinhAnh=@Hinh WHERE MaNV=@Ma";
            SqlParameter[] pr = {
                new SqlParameter("@Ma", nv.MaNV),
                new SqlParameter("@Ten", nv.TenNV),
                new SqlParameter("@Gioi", nv.GioiTinh),
                new SqlParameter("@Ngay", nv.NgaySinh),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@Email", nv.Email),
                new SqlParameter("@CV", nv.ChucVu),
                new SqlParameter("@Hinh", nv.HinhAnh)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNV = @id";
            SqlParameter[] pr = { new SqlParameter("@id", id) };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }

        // Hàm tìm kiếm nhân viên
        public DataTable SearchStaff(string name, string pos)
        {
            string sql = "SELECT nv.MaNV AS 'Mã NV', nv.TenNV AS 'Tên NV', nv.GioiTinh AS 'Giới Tính', nv.NgaySinh AS 'Ngày Sinh', nv.SDT AS 'SĐT', nv.Email, nv.ChucVu AS 'Chức Vụ', nv.TrangThai as 'Trạng Thái', nv.HinhAnh, tk.TenTk as 'Tên TK', tk.MatKhau as 'Mật khẩu' FROM NhanVien nv JOIN TaiKhoan tk WHERE TenNV LIKE @Ten";
            if (pos != "Tất cả" && !string.IsNullOrEmpty(pos))
            {
                sql += " AND ChucVu = @ChucVu";
            }
            SqlParameter[] pr = {
        new SqlParameter("@Ten", "%" + name + "%"),
        new SqlParameter("@ChucVu", pos)
    };
            return DataHelper.GetDataTable(sql, pr);
        }

        // Hàm lấy thông tin 1 nhân viên để hiện ở trang Tài Khoản
        public DataRow GetStaffInfo(int id)
        {
            string sql = "SELECT nv.MaNV, nv.TenNV, nv.ChucVu, nv.HinhAnh, tk.TenTK, tk.MatKhau FROM NhanVien nv JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV WHERE nv.MaNV = @id";
            SqlParameter[] pr = { new SqlParameter("@id", id) };
            DataTable dt = DataHelper.GetDataTable(sql, pr);
            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }
    }
}