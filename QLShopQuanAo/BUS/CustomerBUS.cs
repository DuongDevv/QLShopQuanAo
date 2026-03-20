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


    }
}
