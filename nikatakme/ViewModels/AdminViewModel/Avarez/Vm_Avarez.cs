using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Avarez
{
    public class Vm_Avarez
    {
        [Key]
        public int Id { get; set; }
        public int amount { get; set; }
        public string bill_id { get; set; }
        public string pay_id { get; set; }
        public string Token { get; set; }
        public string reference { get; set; }       
    }
}