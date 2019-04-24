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
    public class CategoryRepository
    {
        SBMDbContext _db = new SBMDbContext();
        public bool SaveCategory(Category category)
        {
            bool isSave = false;
            _db.Categories.Add(category);
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
        public bool UpdateCategory(Category category)
        {
            bool isSave = false;
            _db.Entry(category).State = EntityState.Modified;
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

        public List<Category> GetCategory()
        {
            List<Category> cList = new List<Category>();
            cList = _db.Categories.ToList();
            return cList;
        }

        public bool DeleteCategory(int id)
        {
            bool isDelete = false;
            if (id > 0)
            {
                var category = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
                _db.Categories.Remove(category);
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
