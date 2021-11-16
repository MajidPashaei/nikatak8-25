using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.sajam
{
    public class Vm_Checkprofile
    {
        [Key]
        public int Id { get; set; }
        public string mobile  { get; set; } 
        public string otp { get; set; }
        public string  identifier { get; set; }
        public string token { get; set; }
       
        
     
}
}