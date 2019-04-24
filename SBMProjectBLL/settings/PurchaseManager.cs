using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.settings;
using SBMProjectModel.Models;

namespace SBMProjectBLL.settings
{
    public class PurchaseManager
    {
        PurchaseRepository purchaseRepository=new PurchaseRepository();
        public bool SavePurchase(Purchase purchase)
        {
            return purchaseRepository.SavePurchase(purchase);
        }

        public List<Purchase> GetPurchaseInfo()
        {
            return purchaseRepository.GetPurchaseInfo();
        }

        public bool DeletePurchaseInfo(int id)
        {
            return purchaseRepository.DeletePurchaseInfo(id);
        }
    }
}
