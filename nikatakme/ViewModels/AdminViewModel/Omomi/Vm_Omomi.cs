using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Omomi
{
    public class Vm_Omomi
    {
        [Key]
        public int Id { get; set; }
        public string national_code { get; set; }
        public string mobile { get; set; }
        public string shobe { get; set; }
        public string tarakonesh { get; set; }
        public string shaba { get; set; }
    }
}