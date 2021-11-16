using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.Voip
{
    public class Tbl_VoipUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NameFamily { get; set; }
        public string CM_Code { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Post { get; set; }
        public string Email { get; set; }
        public string CM_Img { get; set; }
        public string CM_Img2 { get; set; }
        public string Address { get; set; } 
        public string Lng { get; set; } 
        public string Lat { get; set; } 
    }
}