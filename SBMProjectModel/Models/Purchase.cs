﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMProjectModel.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNo { get; set; }
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<PurchaseDetails> PurchaseDetailses { get; set; } 
    }
}
