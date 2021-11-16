using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.sajam {
    public class Vm_Getprofile{
        [Key]
        public int Id { get; set; }
        public string identifier { get; set; }
        public string token { get; set; }

    }
}