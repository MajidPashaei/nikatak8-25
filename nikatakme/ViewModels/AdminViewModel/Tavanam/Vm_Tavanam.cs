using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModel.Tavanam
{
    public class Vm_Tavanam
    {
        [Key]
        public int Id { get; set; }
        public string national_code { get; set; }
        public string mobile { get; set; }
        public string factor_id { get; set; }
        public string factor_id2 { get; set; }
        public string pay_id { get; set; }
        public string otp { get; set; }
        
    }
}