using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Voip
{
    public class Vm_VoipUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NameFamily { get; set; }
        public string CM_Code { get; set; }
        public string Sh_Number { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Post { get; set; }
        public string Email { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public IFormFile CAImg { get; set; }
        public string CM_Img { get; set; }
        public IFormFile CAImg2 { get; set; }
        public string CM_Img2 { get; set; }
        public IFormFile ShImg { get; set; }
        public string Sh_Img { get; set; } 
        public IFormFile PKHImg { get; set; }
        public string PKH_Img { get; set; }    
        public string Address { get; set; } 
        public string Lng { get; set; } 
        public string Lat { get; set; } 
    }
}