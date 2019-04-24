using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMProjectModel.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public Sales Sales { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public double TotalPrice { get; set; }
        

    }
}
