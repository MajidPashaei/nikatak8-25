using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Gabz
{
    public class Vm_Gabz
    {
        [Key]
        public int Id { get; set; }
        public string Water { get; set; }
        public string Electricity { get; set; }
        public string Gaz { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Violation { get; set; }
        public List<string> G_E { get; set; }
        public List<string> G_G { get; set; }
        public List<string> G_W { get; set; }
        public List<string> G_V { get; set; }
        public List<string> G_P { get; set; }
        public List<string> G_M { get; set; }
        public string mobile_number { get; set; }
        public int amount { get; set; }
        public string pan { get; set; }
        public string pin { get; set; }
        public string cvv2 { get; set; }
        public string exp_date { get; set; }
        public string payment_service_id { get; set; }
        public string customer_number { get; set; }
        public string deposit_number { get; set; }
        public string bill_id { get; set; }
        public string pay_id { get; set; }
        public string Token { get; set; }  
        public string Titel { get; set; }
        public string bill_id2 { get; set; }
        public string pay_id2 { get; set; }
        public int amount2 { get; set; }
        public string parameter { get; set; }
        public string type { get; set; }
    }
}