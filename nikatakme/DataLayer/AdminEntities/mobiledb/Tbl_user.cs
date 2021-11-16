using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.AdminEntities.mobiledb
{
    public class Tbl_User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CodeNational { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string CodeInvite { get; set; }
        public string Token { get; set; }
    }
}