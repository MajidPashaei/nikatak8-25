using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.AdminEntities.Job
{
    public class Tbl_JobUser
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
        public DateTime DateTime { get; set; }
        public DateTime Tavalood { get; set; }
        public string Img_CartMeli { get; set; }
        public string Img_MadrakTahsili { get; set; }
        public string Img_PayanKH { get; set; }
        public string Img_Shenasname { get; set; }
    }
}