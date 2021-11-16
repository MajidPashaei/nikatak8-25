using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Sepordeh
{
    public class Vm_ShowSummary
    {
        [Key]
        public int deposit_number { get; set; }
        public string order { get; set; } 
        public string from_date { get; set; }
        public string to_date { get; set; }
     	
}
}