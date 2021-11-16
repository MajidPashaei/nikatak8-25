using System;
using System.ComponentModel.DataAnnotations;
namespace DataLayer.AdminEntities.PayBills {
    public class Tb_PayBill {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string BillId { get; set; }
        public string PayId { get; set; }
        public string User { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ShenaseMarja { get; set; }
        public string PeygiriId { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
    }
}