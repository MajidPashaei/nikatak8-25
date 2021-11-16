using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Teaser {
    public class Vm_Teaser {
        [Key]
        public int Id { get; set; }
        public string TitleTeaser { get; set; }
        public string CategoryIdTeaser { get; set; }
        public string VideoPathTeaser { get; set; }
        public string LinkVideoTeaser { get; set; }
        public string Language { get; set; }
        public IFormFile img { get; set; }

    }

}