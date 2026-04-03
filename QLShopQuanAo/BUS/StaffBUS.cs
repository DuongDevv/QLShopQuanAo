using System.Data;
using QLShopQuanAo.DTO;
using QLShopQuanAo.DAL;

namespace QLShopQuanAo.BUS
{
    public class StaffBUS
    {
        StaffDAL dal = new StaffDAL();

        public DataTable LoadStaff()
        {
            return dal.GetAll();
        }

        public bool AddStaff(StaffDTO nv)
        {
            return dal.InsertAndGetID(nv);
        }

        public bool UpdateStaff(StaffDTO nv)
        {
            return dal.Update(nv);
        }

        public bool RemoveStaff(int id)
        {
            return dal.Delete(id);
        }

        public DataTable Search(string name, string pos)
        {
            return dal.SearchStaff(name, pos);
        }
        public DataRow GetInformationAccount(int id)
        {
           return dal.GetStaffInfo(id);
        }

        public StaffDTO CheckLogin(string user, string pass)
        {
            return dal.CheckLogin(user, pass);
        }
       
    }
}