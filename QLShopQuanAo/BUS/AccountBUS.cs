using QLShopQuanAo.DAL;
using QLShopQuanAo.DTO;
using System.Data;

namespace QLShopQuanAo.BUS
{
    public class AccountBUS
    {
        AccountDAL dal = new AccountDAL();

        public string CreateAccount(AccountDTO acc)
        {
            if (string.IsNullOrWhiteSpace(acc.TenTK) || string.IsNullOrWhiteSpace(acc.MatKhau))
                return "Tài khoản và mật khẩu không được để trống!";

            if (dal.IsExist(acc.TenTK))
                return "Tên tài khoản này đã tồn tại!";

            if (dal.InsertAccount(acc))
                return "OK";

            return "Lỗi hệ thống khi tạo tài khoản!";
        }

        public bool Login(string user, string pass)
        {
            return dal.CheckLogin(user, pass);
        }

        public bool CheckLogin(string user, string pass)
        {
            return dal.CheckLogin(user, pass);
        }

        public StaffDTO GetAccountInfo(string tenTK)
        {
            return dal.GetInfo(tenTK);
        }
        public DataTable GetAccountDetails(int maNV)
        {
            return dal.GetAccountByMaNV(maNV);
        }
    }
}