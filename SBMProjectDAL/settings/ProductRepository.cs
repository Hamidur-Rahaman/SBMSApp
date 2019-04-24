using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectModel.DatabaseContext;
using SBMProjectModel.Models;

namespace SBMProjectDAL.settings
{
    public class ProductRepository
    {
        SBMDbContext _db = new SBMDbContext();
        public bool SaveProduct(Product product)
        {
            bool isSave = false;
            _db.Products.Add(product);
            int save = _db.SaveChanges();
            if (save > 0)
            {
                isSave = true;
            }
            else
            {
                isSave = false;
            }
            return isSave;
        }
        public bool UpdateProduct(Product product)
        {
            bool isSave = false;
            _db.Entry(product).State = EntityState.Modified;
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

        public List<Product> GetProduct()
        {
            List<Product> productList = new List<Product>();
            productList = _db.Products.ToList();
            return productList;
        }

        public bool DeleteProduct(int id)
        {
            bool isDelete = false;
            if (id > 0)
            {
                Product product = _db.Products.Where(x => x.Id == id).FirstOrDefault();
                _db.Products.Remove(product);
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
        public Product GeProductById(int id)
        {
            Product product = _db.Products.Where(c => c.Id == id).FirstOrDefault();
            return product;
        }
    }
}
