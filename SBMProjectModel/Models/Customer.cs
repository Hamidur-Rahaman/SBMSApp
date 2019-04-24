using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SBMProjectModel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string LoyaltyPoint { get; set; }
        public ICollection<Sales> Saleses { get; set; } 
        public virtual List<CustomerFiles> CustomerFileses { get; set; } 
        [NotMapped]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }

}
