using QLShopQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.DAL
{
    public class ImportDAL
    {
        public bool InsertImport(ImportDTO ip)
        {
            using (SqlConnection conn = new SqlConnection(DataHelper.strConn))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlPN = "INSERT INTO PhieuNhap (NgayNhap, MaNV, MaNCC, TongTienNhap) VALUES (GETDATE(), @maNV, @maNCC, @tong); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdPN = new SqlCommand(sqlPN, conn, trans);
                    cmdPN.Parameters.AddWithValue("@maNV", ip.MaNV);
                    cmdPN.Parameters.AddWithValue("@maNCC", ip.MaNCC);
                    cmdPN.Parameters.AddWithValue("@tong", ip.TongTien);
                    int maPN = Convert.ToInt32(cmdPN.ExecuteScalar());

                    string sqlCT = "INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap) VALUES (@maPN, @maSP, @sl, @gia)";
                    SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@maPN", maPN);
                    cmdCT.Parameters.AddWithValue("@maSP", ip.MaSP);
                    cmdCT.Parameters.AddWithValue("@sl", ip.SoLuong);
                    cmdCT.Parameters.AddWithValue("@gia", ip.DonGia);
                    cmdCT.ExecuteNonQuery();

                    string sqlUp = "UPDATE SanPham SET SoLuongTon = SoLuongTon + @sl WHERE MaSP = @maSP";
                    SqlCommand cmdUp = new SqlCommand(sqlUp, conn, trans);
                    cmdUp.Parameters.AddWithValue("@sl", ip.SoLuong);
                    cmdUp.Parameters.AddWithValue("@maSP", ip.MaSP);
                    cmdUp.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex + Message)
                    return false;
                }
            }
        }
    }
}
