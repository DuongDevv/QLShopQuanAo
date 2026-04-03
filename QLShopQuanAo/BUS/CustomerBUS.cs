using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.BUS
{
    public class CustomerBUS
    {
        DAL.CustomerDAL dal = new DAL.CustomerDAL();
        public System.Data.DataTable LoadCustomer()
        {
            return dal.GetAll();
        }
        public bool AddCustomer(DTO.CustomerDTO kh)
        {
            return dal.Insert(kh);
        }
        public bool UpdateCustomer(DTO.CustomerDTO kh)
        {
            return dal.Update(kh);
        }
        public bool RemoveCustomer(int id)
        {
            return dal.Delete(id);
        }
        public DataTable GetCustomerNames()
        {
            return dal.GetCustomerNames();
        }
        public DataTable GetSuppliers()
        {
            return dal.GetSuppliers();
        }

        public DataTable SearchCustomer(string name)
        {
            return dal.Search(name);
        }
        public string CheckRank(int tongDiemMoi)
        {
            if (tongDiemMoi >= 2000) return "Đen (VIP)"; 
            if (tongDiemMoi >= 500) return "Vàng";       
            if (tongDiemMoi >= 100) return "Bạc";        
            return "Mới";                                
        }
        public DTO.CustomerDTO GetCustomerByID(int id)
        {
            DataTable dt = dal.GetCustomerByID(id); 
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new DTO.CustomerDTO
                {
                    MaKH = (int)r["MaKH"],
                    TenKH = r["TenKH"].ToString(), 
                    LoaiThanhVien = r["LoaiThanhVien"] == DBNull.Value ? "Mới" : r["LoaiThanhVien"].ToString(),
                    DiemTichLuy = Convert.ToInt32(r["DiemTichLuy"] == DBNull.Value ? 0 : Convert.ToInt32(r["DiemTichLuy"])),
                    TongChiTieu = r["TongChiTieu"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TongChiTieu"])
                };
            }
            return null;
        }
    }
}
