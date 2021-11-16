using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Makanmehvar
{
    public class Vm_Makanmehvar
    {
        [Key]
        public int Id { get; set; }
        public string zip_code  { get; set; }
        
        
    }
}