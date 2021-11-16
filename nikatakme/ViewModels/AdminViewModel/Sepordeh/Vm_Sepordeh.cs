using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Sepordeh
{
    public class Vm_Sepordeh
    {
        [Key]
        public int Id { get; set; }
        public string national_code { get; set; }
        public string account { get; set; }
        public string Sheba { get; set; }
        ////////////////////////////////////////////
        public string customer_number { get; set; }
        public string dossier_number { get; set; }
        public string amount { get; set; }
        public string deposit_number { get; set; }
        public string Shaba { get; set; }
    }
}