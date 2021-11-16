using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.mobiledb
{
    public class Tbl_Davat
    {
        [Key]
        public int Id { get; set; }
        public string UasrName { get; set; }
        public string InviteBy { get; set; }
        public bool Status { get; set; }
    }
}