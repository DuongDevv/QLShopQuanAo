using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.DAL
{
    public class OrderDetailDAL
    {
        //Hàm lưu chi tiết hóa đơn (Lưu từng món hàng một)áds
        public static bool InsertOrderDetail(int maHD, int maSP, int soLuong, decimal donGia)
        {
            string  sql = "INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, DonGia) VALUES(@mahd, @masp, @sl, @dg)";
            SqlParameter[] pars = {
                new SqlParameter("@mahd", maHD),
                new SqlParameter("@masp", maSP),
                new SqlParameter("@sl", soLuong),
                new SqlParameter("@dg", donGia)
            };
            
            return DataHelper.ExecuteNonQuery(sql, pars) > 0;
        }

        //Hàm lấy danh sách chi tiết (Dùng để hiển thị lên Form Hóa Đơn hoặc In)
        public static DataTable GetListByOrderID(int maHD)
        {
            string sql = @"SELECT sp.TenSP, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) as ThanhTien 
                           FROM ChiTietHoaDon ct 
                           JOIN SanPham sp ON ct.MaSP = sp.MaSP 
                           WHERE ct.MaHD = @mahd";
            
            SqlParameter[] pars = { new SqlParameter("@mahd", maHD) };
            return DataHelper.GetDataTable(sql, pars);
        }
    }
}