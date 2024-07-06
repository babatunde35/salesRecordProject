using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesRecord.Data
{
    public class SalesInformation : BaseEntity
    {
        public  int  UserId { get; set; }
        public string? ItemName { get; set; }
        public Decimal Amount { get; set; }
    }
}

