using System.Data;
using QLShopQuanAo.DTO;
using QLShopQuanAo.DAL;

namespace QLShopQuanAo.BUS
{
    public class StaffBUS
    {
        StaffDAL dal = new StaffDAL();

        public bool CheckLogin(string user, string pass)
        {
            return dal.CheckLogin(user, pass);
        }

        public StaffDTO GetInfo(string tenTK)
        {
            return dal.GetInfo(tenTK);
        }

        public DataTable LoadStaff()
        {
            return dal.GetAll();
        }

        public bool AddStaff(StaffDTO nv)
        {
            return dal.Insert(nv);
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
    }
}