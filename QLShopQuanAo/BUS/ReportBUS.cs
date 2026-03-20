using System;
using System.Data;

namespace QLShopQuanAo.BUS
{
    public class ReportBUS
    {
        DAL.ReportDAL dal = new DAL.ReportDAL();
        public string LayHangSapHet()
        {
            return dal.GetLowStockCount();
        }
        public string LayKhachMoi()
        {
            return dal.GetNewCustomerToday();
        }
        public string LayDonHangMoi()
        {
            return dal.GetOrderToday();
        }
        public string LayDoanhThu()
        {
            return dal.GetRevenueToday();
        }
        public DataTable GetTopProduct()
        {
            return dal.GetTopSelling();
        }

        public DataTable LayDoanhThuTheoLoai()
        {
            return dal.GetCategoryRevenue();
        }
        public DataTable GetTotalRevenue()
        {
            return dal.GetTotalRevenue();
        }
    }
}