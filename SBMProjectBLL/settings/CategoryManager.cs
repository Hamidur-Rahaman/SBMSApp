using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.settings;
using SBMProjectModel.Models;

namespace SBMProjectBLL.settings
{
    public class CategoryManager
    {
    CategoryRepository _cgRepository = new CategoryRepository();

        public bool SaveCategory(Category category)
        {
            return _cgRepository.SaveCategory(category);
        }

        public bool UpdateCategory(Category category)
        {
            return _cgRepository.UpdateCategory(category);
        }
        public List<Category> GetCategory()
        {
            return _cgRepository.GetCategory();
        }

        public bool DeleteCategory(int id)
        {
            return _cgRepository.DeleteCategory(id);
        }
    }
}
