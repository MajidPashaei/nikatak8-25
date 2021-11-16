using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Experts {
    public class Vm_Experts {
        [Key]
        public int Id { get; set; }
        public string NameEx { get; set; }
        public string ImageEx { get; set; }
        public string TelEx { get; set; }
        public string OfficeTelEx { get; set; }
        public string LocationEx { get; set; }
        public string AboutEx { get; set; }
        public string  address { get; set; }

        public string Language { get; set; }
        public IFormFile img { get; set; }
    }

}