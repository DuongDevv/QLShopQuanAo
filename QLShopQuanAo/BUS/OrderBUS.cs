using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.BUS
{
    public class OrderBUS
    {
        DAL.OrderDAL orderDAL = new DAL.OrderDAL();
        public int ThanhToan(DTO.OrderDTO hd, List<DTO.OrderDetailDTO> details)
        {
            if (details == null || details.Count == 0) return -1;
            if (hd.TongTien <= 0) return -2;

            return orderDAL.ProcessPayment(hd, details);
        }
    }
}
