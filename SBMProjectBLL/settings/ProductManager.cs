using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.settings;
using SBMProjectModel.Models;

namespace SBMProjectBLL.settings
{
    public class ProductManager
    {
        ProductRepository _productRepository=new ProductRepository();
        public bool SaveCategory(Product product)
        {
            return _productRepository.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProduct();
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
        public Product GeProductById(int id)
        {
            return _productRepository.GeProductById(id);
        }
    }
}
