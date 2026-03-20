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
            return DataHelper.GetDataTable("SELECT MaKH AS 'Mã KH', TenKH AS 'Tên KH', GioiTinh AS 'Giới Tính', SDT AS 'SĐT', Email, DiaChi AS 'Địa Chỉ', NgayDK AS 'Ngày Đăng Ký' FROM KhachHang");
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
    }
}