using System;
using System.Data;

namespace QLShopQuanAo.DAL
{
    public class ReportDAL
    {
        public string GetLowStockCount()
        {
            DataTable dt = DataHelper.GetDataTable("SELECT COUNT(*) FROM SanPham WHERE SoLuongTon < 5");
            return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "0";
        }

        public string GetNewCustomerToday()
        {
            DataTable dt = DataHelper.GetDataTable("SELECT COUNT(*) FROM KhachHang WHERE CAST(NgayDK AS DATE) = CAST(GETDATE() AS DATE)");
            return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "0";
        }

        public string GetOrderToday()
        {
            DataTable dt = DataHelper.GetDataTable("SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)");
            return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "0";
        }

        public DataTable GetTopSelling()
        {
            return DataHelper.GetDataTable(@"SELECT TOP 5 s.TenSP AS 'Tên Sản Phẩm', SUM(ct.SoLuong) AS 'Đã bán' 
                                   FROM ChiTietHoaDon ct 
                                   JOIN SanPham s ON ct.MaSP = s.MaSP 
                                   GROUP BY s.TenSP 
                                   ORDER BY SUM(ct.SoLuong) DESC");
        }

        public string GetRevenueToday()
        {
            DataTable dt = DataHelper.GetDataTable("SELECT SUM(TongTien) FROM HoaDon WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)");
            object rev = dt.Rows[0][0];
            return rev != DBNull.Value ? Convert.ToDecimal(rev).ToString("#,###,###,##0") + " đ" : "0 đ";
        }

        public DataTable GetCategoryRevenue()
        {
            string sql = @"SELECT l.TenLoaiSP, SUM(ct.SoLuong * ct.DonGia) as DoanhThu 
                   FROM LoaiSP l 
                   JOIN SanPham s ON l.MaLoai = s.MaLoai 
                   JOIN ChiTietHoaDon ct ON s.MaSP = ct.MaSP 
                   GROUP BY l.TenLoaiSP";
            return DataHelper.GetDataTable(sql);
        }

        public DataTable GetTotalRevenue()
        {
            string sql = @"SELECT h.MaHD as [Mã Hóa Đơn], FORMAT(h.NgayLap, 'dd/MM/yyy HH:mm' ) as [Ngày Lập], 
                          n.TenNV as [Nhân Viên], k.TenKH as [Khách Hàng], 
                          h.TongTien as [Tổng Tiền]
                   FROM HoaDon h
                   JOIN NhanVien n ON h.MaNV = n.MaNV
                   JOIN KhachHang k ON h.MaKH = k.MaKH
                   ORDER BY h.NgayLap DESC";

            return DataHelper.GetDataTable(sql);
        }
    }
}
