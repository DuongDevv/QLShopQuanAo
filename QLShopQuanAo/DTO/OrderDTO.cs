using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.DTO
{
    public class OrderDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public decimal TongTien { get; set; }
    }
}
