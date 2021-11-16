using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.AdminEntities.Hesab {
    public class Tbl_Hesab
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Bank { get; set; }
        public string Hesab { get; set; }
        public string Shaba { get; set; }
        public int Shobe { get; set; }
    }
}