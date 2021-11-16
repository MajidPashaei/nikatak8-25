using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.sajam
{
    public class Vm_provinces 
    {
        [Key]
        public int Id { get; set; }
        
        public string token { get; set; }
           public string country_id { get; set; }
             
       
        
     
}
}