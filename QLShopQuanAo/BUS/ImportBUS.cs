using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopQuanAo.BUS
{
    public class ImportBUS
    {
        DAL.ImportDAL dal = new DAL.ImportDAL();
        public bool NhapHang(DTO.ImportDTO ip)
        {
            return dal.InsertImport(ip); 
        }
    }
}
