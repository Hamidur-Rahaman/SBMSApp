using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectDAL.settings
{
    public class PurchaseRepository
    {
        SBMDbContext _db = new SBMDbContext();
        public bool SavePurchase(Purchase purchase)
        {
            _db.Purchases.Add(purchase);
            var isAdded = _db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Purchase> GetPurchaseInfo()
        {
            List<Purchase> purchaseList = new List<Purchase>();
            purchaseList = _db.Purchases.ToList();
            return purchaseList;
        }

        public bool DeletePurchaseInfo(int id)
        {
            bool isDelete = false;
            if (id > 0)
            {
                Purchase purchase = _db.Purchases.Where(x => x.Id == id).FirstOrDefault();
                _db.Purchases.Remove(purchase);
                int add = _db.SaveChanges();
                if (add > 0)
                {
                    isDelete = true;
                }
                else
                {
                    isDelete = false;
                }
            }
            else
            {
                isDelete = false;
            }

            return isDelete;
        }
    }
}
