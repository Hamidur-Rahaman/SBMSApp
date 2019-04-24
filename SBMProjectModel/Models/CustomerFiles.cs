using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMProjectModel.Models
{
    public class CustomerFiles
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public Customer Customer { get; set; }
    }
}
