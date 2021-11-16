using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.Membership
{
    public class Vm_Membership
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}