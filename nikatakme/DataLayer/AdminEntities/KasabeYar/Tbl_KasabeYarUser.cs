using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace DataLayer.AdminEntities.KasabeYar 
{
    public class Tbl_KasabeYarUser 
    {
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CodeMeli { get; set; } 
        public string UserName { get; set; }
        public string UserAdmin { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CodePosti { get; set; } 
        public string Address { get; set; }
        public string Image { get; set; }
        public bool state { get; set; }
    }
}