using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Agency {
    public class Vm_Agency {
        [Key]
        public int Id { get; set; }
        public string ImageAg { get; set; }
        public string NameAg { get; set; }
        public string NamePersenAg { get; set; }
        public string TelAg { get; set; }
        public string OfficetelAg { get; set; }
        public string LocationAg { get; set; }
        public string DescreptionAg { get; set; }
        public string Language { get; set; }
        public string  Adress { get; set; }
        public IFormFile img { get; set; }

    }

}