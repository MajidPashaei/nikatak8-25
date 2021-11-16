using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.Voip
{
    public class Tbl_VoipOrder
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Id_User { get; set; }
        public int Id_Number { get; set; }
    }
}