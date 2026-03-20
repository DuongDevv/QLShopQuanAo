using System.Data;
using System.Data.SqlClient;
using QLShopQuanAo.DTO;

namespace QLShopQuanAo.DAL
{
    public class ProductDAL
    {
        public DataTable GetCategories()
        {
            return DataHelper.GetDataTable("SELECT MaLoai, TenLoaiSP FROM LoaiSP");
        }

        public DataTable GetActiveProducts()
        {
             return DataHelper.GetDataTable("SELECT MaSP AS 'Mã SP', TenSP AS 'Tên SP', GiaBan AS 'Đơn giá', SoLuongTon AS 'Số lượng' FROM SanPham WHERE TrangThai = N'Đang kinh doanh'");

        }
        public DataTable GetAll()
        {
            string sql = @"SELECT s.MaSP AS 'Mã SP', s.TenSP AS 'Tên SP', l.TenLoaiSP AS 'Loại SP', 
                           s.SoLuongTon AS 'Số lượng', s.DVT, s.GiaBan AS 'Đơn giá', s.TrangThai, s.HinhAnh
                           FROM SanPham s INNER JOIN LoaiSP l ON s.MaLoai = l.MaLoai";
            return DataHelper.GetDataTable(sql);
        }

        public bool Insert(ProductDTO sp)
        {
            string sql = "INSERT INTO SanPham (TenSP, MaLoai, DVT, SoLuongTon, GiaBan, HinhAnh, TrangThai) VALUES (@Ten, @MaL, @DVT, @SL, @Gia, @Hinh, @TT)";
            SqlParameter[] pr = {
                new SqlParameter("@Ten", sp.TenSP), new SqlParameter("@MaL", sp.MaLoai),
                new SqlParameter("@DVT", sp.DVT), new SqlParameter("@SL", sp.SoLuongTon),
                new SqlParameter("@Gia", sp.GiaBan), new SqlParameter("@Hinh", sp.HinhAnh),
                new SqlParameter("@TT", sp.TrangThai)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }

        public bool Update(ProductDTO sp)
        {
            string sql = "UPDATE SanPham SET TenSP=@Ten, MaLoai=@MaL, DVT=@DVT, SoLuongTon=@SL, GiaBan=@Gia, HinhAnh=@Hinh WHERE MaSP=@Ma";
            SqlParameter[] pr = {
                new SqlParameter("@Ma", sp.MaSP), 
                new SqlParameter("@Ten", sp.TenSP),
                new SqlParameter("@MaL", sp.MaLoai), 
                new SqlParameter("@DVT", sp.DVT),
                new SqlParameter("@SL", sp.SoLuongTon), 
                new SqlParameter("@Gia", sp.GiaBan),
                new SqlParameter("@Hinh", sp.HinhAnh)
            };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }

        // Hàm tìm kiếm sản phẩm
        public DataTable SearchProduct(string name, int maLoai)
        {
            string sql = @"SELECT s.MaSP AS 'Mã SP', s.TenSP AS 'Tên SP', l.TenLoaiSP AS 'Loại SP', s.SoLuongTon AS 'Số lượng', s.DVT, s.GiaBan AS 'Đơn giá', s.TrangThai, s.HinhAnh 
                   FROM SanPham s INNER JOIN LoaiSP l ON s.MaLoai = l.MaLoai WHERE s.TenSP LIKE @Ten";
            if (maLoai > 0) sql += " AND s.MaLoai = @MaLoai";
            SqlParameter[] pr = {
        new SqlParameter("@Ten", "%" + name + "%"),
        new SqlParameter("@MaLoai", maLoai)
            };
            return DataHelper.GetDataTable(sql, pr);
        }

        public bool UpdateStatus(int id, string status)
        {
            string sql = "UPDATE SanPham SET TrangThai = @Status WHERE MaSP = @Ma";
            SqlParameter[] pr = {
        new SqlParameter("@Status", status),
        new SqlParameter("@Ma", id)
    };
            return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }
        public DataTable SearchActiveProduct(string name, int maLoai)
        {
            string sql = @"SELECT MaSP AS 'Mã SP', TenSP AS 'Tên SP', GiaBan AS 'Đơn giá', SoLuongTon AS 'Số lượng'
                   FROM SanPham 
                   WHERE TenSP LIKE @Ten AND TrangThai = N'Đang kinh doanh'";

            if (maLoai > 0)
                sql += " AND MaLoai = @MaLoai";

            SqlParameter[] pr = {
        new SqlParameter("@Ten", "%" + name + "%"),
        new SqlParameter("@MaLoai", maLoai)
            };

            return DataHelper.GetDataTable(sql, pr);
        }
    }
}