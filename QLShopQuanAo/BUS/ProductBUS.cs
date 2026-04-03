using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.BUS
{
    public class ProductBUS
    {
        DAL.ProductDAL dal = new DAL.ProductDAL();
        public System.Data.DataTable LoadProduct()
        {
            return dal.GetAll();
        }
        public bool AddProduct(DTO.ProductDTO sp)
        {
            return dal.Insert(sp);
        }
        public bool UpdateProduct(DTO.ProductDTO sp)
        {
            return dal.Update(sp);
        }
        public DataTable GetCategories()
        {
            return dal.GetCategories();
        }
        public DataTable LoadProductActive()
        {
            return dal.GetActiveProducts();
        }

        public DataTable Search(string name, int maLoai)
        {
            return dal.SearchProduct(name, maLoai);
        }
        public bool ChangeStatus(int id, string status)
        {
            return dal.UpdateStatus(id, status);
        }
        public DataTable SearchActiveProduct(string name, int maLoai)
        {
            return dal.SearchActiveProduct(name, maLoai);
        }
    }
}
