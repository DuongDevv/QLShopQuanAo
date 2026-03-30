using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.DTO
{
    public class AccountDTO
    {
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public int MaNV { get; set; }
        public string PhanQuyen { get; set; }

        public AccountDTO() { }
        public AccountDTO(string tenTK, string matKhau, int maNV, string phanQuyen)
        {
            TenTK = tenTK;
            MatKhau = matKhau;
            MaNV = maNV;
            PhanQuyen = phanQuyen;
        }
    }
}
