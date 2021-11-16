using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModel.Voip
{
    public class Vm_VoipNumber
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string CodeOstan { get; set; }
        public string Ostan { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string SelectVoip { get; set; }
        public string Rezerve { get; set; }
        public DateTime DateRezerve { get; set; }
        public string Date { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; } 
        public int NumId { get; set; } 
        public string ChannelNum { get; set; } 
        public string InternalNum { get; set; } 
    }
}