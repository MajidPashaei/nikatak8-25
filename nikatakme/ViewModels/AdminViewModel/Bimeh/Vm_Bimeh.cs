using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Bimeh
{
    public class Vm_Bimeh
    {
        [Key]
        public int Id { get; set; }
    
        public string CartMashin1 { get; set; }
        public IFormFile FCartMashin1 { get; set; }

        public string CartMashin2 { get; set; }
        public IFormFile FCartMashin2 { get; set; }

        public string BimehNameh { get; set; }
        public IFormFile FBimehNameh { get; set; }

        public string GhovahiNameh1 { get; set; }
        public IFormFile FGhovahiNameh1 { get; set; }
        
        public string GhovahiNameh2 { get; set; }
        public IFormFile FGhovahiNameh2 { get; set; }
        
        
    }
}