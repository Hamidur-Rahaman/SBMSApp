using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMProjectModel.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public double GrandTotal { get; set; }
        public double Paid { get; set; }
        public double Due { get; set; }
        public Customer Customer { get; set; }
        public ICollection<SalesDetails> SalesDetailses { get; set; }
    }
}
