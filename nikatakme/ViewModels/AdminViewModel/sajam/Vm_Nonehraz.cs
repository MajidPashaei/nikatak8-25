using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.sajam
{
    public class Vm_Nonehraz
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; } 
        public string password { get; set; }
        public string token { get; set; }
        
     
}
}