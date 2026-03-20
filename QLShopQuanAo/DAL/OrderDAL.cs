using QLShopQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLShopQuanAo.DAL
{
    public class OrderDAL
    {
        string strConn = @"Data Source=DESKTOP-10UJ2O8\SQLEXPRESS;Initial Catalog=QLShopQuanAo;Integrated Security=True";

        public int ProcessPayment(OrderDTO hd, List<OrderDetailDTO> details)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // Bắt đầu giao dịch
                try
                {
                    // 1. Thêm Hóa Đơn và lấy mã HD vừa tạo
                    string sqlHD = "INSERT INTO HoaDon(NgayLap, MaNV, MaKH, TongTien) VALUES(@ngay, @manv, @makh, @tong); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@ngay", hd.NgayLap);
                    cmdHD.Parameters.AddWithValue("@manv", hd.MaNV);
                    cmdHD.Parameters.AddWithValue("@makh", hd.MaKH);
                    cmdHD.Parameters.AddWithValue("@tong", hd.TongTien);
                    int maHDVuaTao = Convert.ToInt32(cmdHD.ExecuteScalar());

                    // 2. Thêm Chi Tiết và Trừ Kho
                    foreach (var item in details)
                    {
                        // Thêm chi tiết
                        string sqlCT = "INSERT INTO ChiTietHoaDon(MaHD, MaSP, SoLuong, DonGia) VALUES(@mahd, @masp, @sl, @gia)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@mahd", maHDVuaTao);
                        cmdCT.Parameters.AddWithValue("@masp", item.MaSP);
                        cmdCT.Parameters.AddWithValue("@sl", item.SoLuong);
                        cmdCT.Parameters.AddWithValue("@gia", item.DonGia);
                        cmdCT.ExecuteNonQuery();

                        // Trừ kho
                        string sqlUp = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @sl WHERE MaSP = @masp";
                        SqlCommand cmdUp = new SqlCommand(sqlUp, conn, trans);
                        cmdUp.Parameters.AddWithValue("@sl", item.SoLuong);
                        cmdUp.Parameters.AddWithValue("@masp", item.MaSP);
                        cmdUp.ExecuteNonQuery();
                    }

                    trans.Commit(); // Hoàn tất thành DataHelper.
                    return maHDVuaTao;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Console.WriteLine("Lỗi thanh toán: " + ex.Message);
                    return -1;
                }
            }
        }
    }
}