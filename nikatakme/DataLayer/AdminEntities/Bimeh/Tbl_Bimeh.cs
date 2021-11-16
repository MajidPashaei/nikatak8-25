using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
namespace DataLayer.AdminEntities.Bimeh
{
    public class Tbl_Bimeh
    {
        [Key]
        public int Id { get; set; }
        public string CartMashin1 { get; set; }

        public string CartMashin2 { get; set; }

        public string BimehNameh { get; set; }

        public string GhovahiNameh1 { get; set; }
        
        public string GhovahiNameh2 { get; set; }
        
        
    }
}