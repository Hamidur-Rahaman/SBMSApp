using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.settings;
using SBMProjectModel.Models;

namespace SBMProjectBLL.settings
{
    public class SalesManager
    {
        SalesRepository salesRepository=new SalesRepository();
        public bool SaveSales(Sales sales)
        {
            return salesRepository.SaveSales(sales);
        }

        public List<Sales> GetSalesInfo()
        {
            return salesRepository.GetSalesInfo();
        }
    }
}
