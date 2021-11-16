using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.Voip
{
    public class Tbl_VoipNumber
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Ostan { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Rezerve { get; set; }
        public DateTime DateRezerve { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; } 
    }
}