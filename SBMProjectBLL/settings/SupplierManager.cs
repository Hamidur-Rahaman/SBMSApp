using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.settings;
using SBMProjectModel.Models;

namespace SBMProjectBLL.settings
{
    public class SupplierManager
    {
        SupplierRepository _cuRepository = new SupplierRepository();
        public bool SaveSupplier(Supplier obj)
        {
            bool isSave = false;
            isSave = _cuRepository.SaveSupplier(obj);
            return isSave;
        }
        public bool UpdateSupplier(Supplier obj)
        {
            bool isSave = false;
            isSave = _cuRepository.UpdateSupplier(obj);
            return isSave;
        }
        public bool DeleteSupplier(int id)
        {
            bool isSave = false;
            isSave = _cuRepository.DeleteSupplier(id);
            return isSave;
        }
        public List<Supplier> GetSupplier()
        {
            var list = new List<Supplier>();
            list = _cuRepository.GetSupplier();
            return list;
        }
    }
}
