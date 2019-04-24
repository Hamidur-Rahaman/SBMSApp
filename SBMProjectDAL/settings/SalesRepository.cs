using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectDAL.settings
{
    public class SalesRepository
    {
        SBMDbContext _db = new SBMDbContext();
        public bool SaveSales(Sales sales)
        {
            _db.Sales.Add(sales);
            var isAdded = _db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Sales> GetSalesInfo()
        {
            List<Sales> salesList = new List<Sales>();
            salesList = _db.Sales.ToList();
            return salesList;
        }
    }
}
