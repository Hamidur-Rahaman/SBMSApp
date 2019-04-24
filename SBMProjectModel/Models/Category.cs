using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMProjectModel.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } 
    }
}
