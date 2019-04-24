using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SBMProjectModel.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        public ICollection<Purchase> Purchases { get; set; } 
        public virtual List<SupplierFiles> supplierFileses  { get; set; }
        [NotMapped]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }
}
