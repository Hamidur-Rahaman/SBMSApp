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
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public double AvailableQuantity { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public ICollection<PurchaseDetails> PurchaseDetailses { get; set; }
        public ICollection<SalesDetails> SalesDetailses { get; set; }
        public virtual List<ProductFiles> ProductFileses { get; set; }
        [NotMapped]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }
}
