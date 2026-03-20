using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.DTO
{
    public class ProductDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int MaLoai { get; set; }
        public string DVT { get; set; }
        public int SoLuongTon { get; set; }
        public decimal GiaBan { get; set; }
        public string HinhAnh { get; set; }
        public string TrangThai { get; set; }
    }
}
