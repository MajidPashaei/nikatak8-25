using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace faraboom.Models
{
    public  class CheckOutRedirectInfoModel 
    {
        public string RefId { get; set; }
        public string ResCode { get; set; }
        public long SaleOrderId { get; set; }
        public long SaleReferenceId { get; set; }
        public string MobileNo { get; set; }
    }
}
