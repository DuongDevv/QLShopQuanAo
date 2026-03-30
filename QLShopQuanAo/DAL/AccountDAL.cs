using QLShopQuanAo.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QLShopQuanAo.DAL
{
    public class AccountDAL
    {
        // Hàm thêm tài khoản mới
        public bool InsertAccount(AccountDTO acc)
        {
            string sql = "INSERT INTO TaiKhoan (TenTK, MatKhau, MaNV, PhanQuyen) VALUES (@user, @pass, @manv, @quyen)";
            SqlParameter[] pr = {
                new SqlParameter("@user", acc.TenTK),
                new SqlParameter("@pass", acc.MatKhau),
                new SqlParameter("@manv", acc.MaNV),
                new SqlParameter("@quyen", acc.PhanQuyen)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }

        // Hàm kiểm tra trùng tên đăng nhập
        public bool IsExist(string tenTK)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTK = @user";
            SqlParameter[] pr = { new SqlParameter("@user", tenTK) };
            int count = (int)DataHelper.ExecuteScalar(sql, pr);
            return count > 0;
        }

        // Chuyển hàm Login từ StaffDAL sang đây
        public bool CheckLogin(string user, string pass)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTK = @user AND MatKhau = @pass";
            SqlParameter[] pr = {
                new SqlParameter("@user", user),
                new SqlParameter("@pass", pass)
            };
            int count = (int)DataHelper.ExecuteScalar(sql, pr);
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
        public DataTable GetAccountByMaNV(int maNV)
        {
            string sql = "SELECT TenTK, MatKhau FROM TaiKhoan WHERE MaNV = @id";
            SqlParameter[] pr = { new SqlParameter("@id", maNV) };
            return DataHelper.GetDataTable(sql, pr);
        }
    }
}