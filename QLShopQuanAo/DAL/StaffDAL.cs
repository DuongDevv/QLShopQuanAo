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
            string sql = "SELECT MaNV AS 'Mã NV', TenNV AS 'Tên NV', GioiTinh AS 'Giới Tính', NgaySinh AS 'Ngày Sinh', SDT AS 'SĐT', Email, ChucVu AS 'Chức Vụ', TrangThai as 'Trạng Thái', HinhAnh as 'Hình Ảnh', TenTK as 'Tên TK', MatKhau as 'Mật khẩu' FROM NhanVien";
            return DataHelper.GetDataTable(sql);
        }

        public bool InsertAndGetID(StaffDTO nv)
        {
            string sql = "INSERT INTO NhanVien (TenNV, GioiTinh, NgaySinh, SDT, Email, ChucVu, HinhAnh, TenTK, MatKhau) VALUES (@Ten, @Gioi, @Ngay, @SDT, @Email, @CV, @Hinh, @TK, @MK);SELECT SCOPE_IDENTITY();";
            SqlParameter[] pr = {
                new SqlParameter("@Ten", nv.TenNV),
                new SqlParameter("@Gioi", nv.GioiTinh),
                new SqlParameter("@Ngay", nv.NgaySinh),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@Email", nv.Email),
                new SqlParameter("@CV", nv.ChucVu),
                new SqlParameter("@Hinh", nv.HinhAnh),
                new SqlParameter("@TK",nv.TenTK),
                new SqlParameter("@MK",nv.MatKhau)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) >0 ;
        }

        public StaffDTO CheckLogin(string user, string pass)
        {
            string sql = "SELECT * FROM NhanVien WHERE TenTK = @user AND MatKhau = @pass";
            SqlParameter[] pr = { new SqlParameter("@user", user), new SqlParameter("@pass", pass) };
            DataTable dt = DataHelper.GetDataTable(sql, pr);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new StaffDTO
                {
                    MaNV = (int)r["MaNV"],
                    TenNV = r["TenNV"].ToString(),
                    TenTK = r["TenTK"].ToString(),
                    MatKhau = r["MatKhau"].ToString(),
                    ChucVu = r["ChucVu"].ToString()
                };
            }
            return null;
        }

        public bool Update(StaffDTO nv)
        {
            string sql = "UPDATE NhanVien SET TenNV=@Ten, GioiTinh=@Gioi, NgaySinh=@Ngay, SDT=@SDT, Email=@Email, ChucVu=@CV, HinhAnh=@Hinh, TenTK=@TK, MatKhau=@MK WHERE MaNV=@Ma";
            SqlParameter[] pr = {
                new SqlParameter("@Ma", nv.MaNV),
                new SqlParameter("@Ten", nv.TenNV),
                new SqlParameter("@Gioi", nv.GioiTinh),
                new SqlParameter("@Ngay", nv.NgaySinh),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@Email", nv.Email),
                new SqlParameter("@CV", nv.ChucVu),
                new SqlParameter("@Hinh", nv.HinhAnh),
                new SqlParameter("@TK", nv.TenTK),
                new SqlParameter("@MK", nv.MatKhau)
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
            string sql = "SELECT MaNV AS 'Mã NV', TenNV AS 'Tên NV', GioiTinh AS 'Giới Tính', NgaySinh AS 'Ngày Sinh', SDT AS 'SĐT', Email, ChucVu AS 'Chức Vụ', TrangThai as 'Trạng Thái', HinhAnh, TenTk as 'Tên TK', MatKhau as 'Mật khẩu' FROM NhanVien WHERE TenNV LIKE @Ten";
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
            string sql = "SELECT MaNV, TenNV, ChucVu, HinhAnh, TenTK, MatKhau FROM NhanVien WHERE MaNV = @id";
            SqlParameter[] pr = { new SqlParameter("@id", id) };
            DataTable dt = DataHelper.GetDataTable(sql, pr);
            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }
    }
}