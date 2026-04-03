using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using QLShopQuanAo.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

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
            string sql = @"SELECT s.MaSP AS 'Mã SP', s.TenSP AS 'Tên SP', 
                                  ct.KichCo AS 'Kích cỡ', ct.MauSac AS 'Màu sắc', 
                                  ct.GiaBan AS 'Đơn giá', ct.SoLuongTon AS 'Số lượng' 
                           FROM SanPham s 
                           INNER JOIN ChiTietSanPham ct ON s.MaSP = ct.MaSP 
                           WHERE s.TrangThai = N'Đang kinh doanh'";
            return DataHelper.GetDataTable(sql);
        }

        public DataTable GetAll()
        {
            string sql = @"SELECT s.MaSP AS [Mã SP], s.TenSP AS [Tên SP], l.TenLoaiSP AS [Loại SP], 
                          ct.SoLuongTon AS [Số lượng], s.DVT, ct.GiaBan AS [Đơn giá], 
                          s.TrangThai, s.HinhAnh, ct.KichCo AS [Kích cỡ], ct.MauSac AS [Màu sắc],
                          ct.MaChiTiet
                   FROM SanPham s 
                   INNER JOIN ChiTietSanPham ct ON s.MaSP = ct.MaSP
                   INNER JOIN LoaiSP l ON s.MaLoai = l.MaLoai";
            return DataHelper.GetDataTable(sql);
        }

        public bool Insert(ProductDTO sp)
        {
            string sql = "INSERT INTO SanPham (TenSP, MaLoai, DVT, TrangThai, HinhAnh) VALUES (@Ten, @MaL, @DVT, @TT, @Hinh)";
            SqlParameter[] pr = {
                new SqlParameter("@Ten", sp.TenSP),
                new SqlParameter("@MaL", sp.MaLoai),
                new SqlParameter("@DVT", sp.DVT),
                new SqlParameter("@TT", sp.TrangThai),
                new SqlParameter("@Hinh", sp.HinhAnh ?? (object)DBNull.Value)
             };
             return DataHelper.ExecuteNonQuery(sql, pr) > 0;
        }

        public bool Update(ProductDTO sp)
        {
            string sqlSP = "UPDATE SanPham SET TenSP=@Ten, MaLoai=@MaL, DVT=@DVT, HinhAnh=@Hinh WHERE MaSP=@Ma";
            SqlParameter[] prSP = {
        new SqlParameter("@Ma", sp.MaSP),
        new SqlParameter("@Ten", sp.TenSP),
        new SqlParameter("@MaL", sp.MaLoai),
        new SqlParameter("@DVT", sp.DVT),
        new SqlParameter("@Hinh", sp.HinhAnh ?? (object)DBNull.Value)
            };

            string sqlCT = "UPDATE ChiTietSanPham SET KichCo=@Size, MauSac=@Mau, SoLuongTon=@SL, GiaBan=@Gia WHERE MaChiTiet=@MaCT";
            SqlParameter[] prCT = {
        new SqlParameter("@MaCT", sp.MaChiTiet),
        new SqlParameter("@Size", sp.KichCo),
        new SqlParameter("@Mau", sp.MauSac),
        new SqlParameter("@SL", sp.SoLuongTon),
        new SqlParameter("@Gia", sp.GiaBan)
            };
            return DataHelper.ExecuteNonQuery(sqlSP, prSP) > 0 && DataHelper.ExecuteNonQuery(sqlCT, prCT) > 0;
        }
        public DataTable SearchActiveProduct(string name, int maLoai)
        {
            string sql = "SELECT * FROM SanPham WHERE TrangThai = N'Đang kinh doanh' " +
                         "AND TenSP LIKE N'%' + @name + '%'";
            if (maLoai != 0)
            {
                sql += " AND MaLoai = @maLoai";
            }

            SqlParameter[] pars = {
                 new SqlParameter("@name", name),
                 new SqlParameter("@maLoai", maLoai)
            };
            return DataHelper.GetDataTable(sql, pars);
        }

        public DataTable SearchProduct(string name, int maLoai)
        {
            string sql = @"SELECT s.MaSP AS 'Mã SP', s.TenSP AS 'Tên SP', l.TenLoaiSP AS 'Loại SP', 
                                  ct.SoLuongTon AS 'Số lượng', s.DVT, ct.GiaBan AS 'Đơn giá', 
                                  s.TrangThai, s.HinhAnh, ct.KichCo, ct.MauSac 
                           FROM SanPham s 
                           INNER JOIN LoaiSP l ON s.MaLoai = l.MaLoai 
                           INNER JOIN ChiTietSanPham ct ON s.MaSP = ct.MaSP 
                           WHERE s.TenSP LIKE @Ten";

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

        public bool UpdateStock(int maSP, int soLuongNhap)
        {
            // David: SQL cộng dồn cực kỳ quan trọng
            string sql = "UPDATE SanPham SET SoLuongTon = SoLuongTon + @SL WHERE MaSP = @ID";
            SqlParameter[] pars = {
        new SqlParameter("@SL", soLuongNhap),
        new SqlParameter("@ID", maSP)
    };
            return DataHelper.ExecuteNonQuery(sql, pars) > 0;
        }
    }
}