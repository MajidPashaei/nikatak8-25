using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.wallet
{
    public class Tbl_Mypay
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Pay { get; set; }
        public int Harvest { get; set; }
        public DateTime DateTime { get; set; }
        public bool status { get; set; }
        public int RequestId { get; set; }
    }
}