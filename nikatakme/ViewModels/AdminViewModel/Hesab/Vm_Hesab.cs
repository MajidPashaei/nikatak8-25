using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Hesab
{
    public class Vm_Hesab
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Bank { get; set; }
        public string Hesab { get; set; }
        public string Shaba { get; set; }
        public int Shobe { get; set; }
    }
}