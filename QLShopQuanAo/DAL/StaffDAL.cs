using System;
using System.Data;
using System.Data.SqlClient;
using QLShopQuanAo.DTO;

namespace QLShopQuanAo.DAL
{
    public class StaffDAL
    {
        public bool CheckLogin(string user, string pass)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTK = @user AND MatKhau = @pass";
            SqlParameter[] pars = {
            new SqlParameter("@user", user),
            new SqlParameter("@pass", pass)
        };
            int count = (int)DataHelper.ExecuteScalar(sql, pars);
            return count > 0;
        }

        public StaffDTO GetInfo(string tenTK)
        {
            string sql = @"SELECT t.MaNV, n.TenNV, n.ChucVu 
               FROM TaiKhoan t 
               JOIN NhanVien n ON t.MaNV = n.MaNV 
               WHERE t.TenTK = @user";
            SqlParameter[] pars = { new SqlParameter("@user", tenTK) };
            DataTable dt = DataHelper.GetDataTable(sql, pars);

            if (dt.Rows.Count > 0)
            {
                return new StaffDTO
                {
                    MaNV = Convert.ToInt32(dt.Rows[0]["MaNV"]),
                    ChucVu = dt.Rows[0]["ChucVu"].ToString(),
                    TenNV = dt.Rows[0]["TenNV"].ToString()
                };
            }
            return null;
        }

        public DataTable GetAll()
        {
            string sql = "SELECT MaNV AS 'Mã NV', TenNV AS 'Tên NV', GioiTinh AS 'Giới Tính', NgaySinh AS 'Ngày Sinh', SDT AS 'SĐT', Email, ChucVu AS 'Chức Vụ', TrangThai as 'Trạng Thái', HinhAnh as 'Hình Ảnh' FROM NhanVien";
            return DataHelper.GetDataTable(sql);
        }

        public bool Insert(StaffDTO nv)
        {
            string sql = "INSERT INTO NhanVien (TenNV, GioiTinh, NgaySinh, SDT, Email, ChucVu, HinhAnh) VALUES (@Ten, @Gioi, @Ngay, @SDT, @Email, @CV, @Hinh)";
            SqlParameter[] pr = {
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
            string sql = "SELECT MaNV AS 'Mã NV', TenNV AS 'Tên NV', GioiTinh AS 'Giới Tính', NgaySinh AS 'Ngày Sinh', SDT AS 'SĐT', Email, ChucVu AS 'Chức Vụ', TrangThai as 'Trạng Thái', HinhAnh FROM NhanVien WHERE TenNV LIKE @Ten";
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