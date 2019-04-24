using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.common;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectDAL.settings
{
    public class SupplierRepository
    {
        SBMDbContext _db = new SBMDbContext();
        private SqlFactory _sqlFactory = new SqlFactory();
        private DataTable _dt;
        public bool SaveSupplier(Supplier obj)
        {
            bool isSave = false;
            _db.Suppliers.Add(obj);
            int add = _db.SaveChanges();
            if (add > 0)
            {
                isSave = true;
            }
            else
            {
                isSave = false;
            }
            return isSave;

        }
        public bool UpdateSupplier(Supplier supplier)
        {
            bool isSave = false;
            _db.Entry(supplier).State = EntityState.Modified;
            int add = _db.SaveChanges();
            if (add > 0)
            {
                isSave = true;
            }
            else
            {
                isSave = false;
            }
            return isSave;
        }
        public bool DeleteSupplier(int id)
        {
            bool isDelete = false;
            if (id>0)
            {
                var supplier = _db.Suppliers.Where(x => x.Id == id).FirstOrDefault();
                _db.Suppliers.Remove(supplier);
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
        public List<Supplier> GetSupplier()
        {
            var list = _db.Suppliers.ToList();
            return list;
        }
    }
}
