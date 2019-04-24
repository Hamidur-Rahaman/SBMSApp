using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectDAL.settings;
using SBMProjectModel.Models;

namespace SBMProjectBLL.settings
{
    public class CustomerManager
    {
        CustomerRepository _cuRepository = new CustomerRepository();
        public bool SaveCustomer(Customer obj)
        {
            bool isSave = false;
            isSave = _cuRepository.SaveCustomer(obj);
            return isSave;
        }
        public bool UpdateCustomer(Customer obj)
        {
            bool isSave = false;
            isSave = _cuRepository.UpdateCustomer(obj);
            return isSave;
        }
        public List<Customer> GetCustomer()
        {
            var list = new List<Customer>();
            list = _cuRepository.GetCustomer();
            return list;
        }

        public bool DeleteCustomer(int id)
        {
            return _cuRepository.DeleteCustomer(id);
        }
    }
}
