using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Job
{
    public class Vm_JobUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CodeMeli { get; set; }
        public string FatherName { get; set; }
        public string Telphone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Post { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Ostan { get; set; }
        public string Rand { get; set; }
        public string Tahsilat { get; set; }
        public string Reshte { get; set; }
        public string tavalood { get; set; }
        public DateTime Tavalood { get; set; }
        public DateTime DateTime { get; set; }
        public string time { get; set; }
        public IFormFile img_cartmeli { get; set; }
        public string Img_CartMeli { get; set; }
        public IFormFile img_madraktahsili { get; set; }
        public string Img_MadrakTahsili { get; set; }
        public IFormFile img_payankh { get; set; }
        public string Img_PayanKH { get; set; }
        public IFormFile img_shenasname { get; set; }
        public string Img_Shenasname { get; set; }
        public IFormFile img_aks { get; set; }
        public string Img_Aks { get; set; }
    }
}