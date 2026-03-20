using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.DTO
{
    public class ImportDTO
    {
        public int MaPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNV { get; set; }
        public int MaNCC { get; set; }
        public decimal TongTien { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
