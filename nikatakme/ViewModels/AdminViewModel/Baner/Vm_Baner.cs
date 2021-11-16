using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Baner {
    public class Vm_Baner {
        public int Id { get; set; }
        public string TitleSlid { get; set; }
        public int CategoryIdSlid { get; set; }
        public int CategoryProductIdSlid { get; set; }
        public string TypeSlid { get; set; }
        public string ImageMainSlid { get; set; }
        public string Language { get; set; }
        public IFormFile img { get; set; }
        public string nameproduct { get; set; }

    }

}