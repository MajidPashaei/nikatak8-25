using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Blog {
    public class Vm_Blog {
        [Key]
        public int Id { get; set; }
        public string TitleBLo { get; set; }
        public int IdCtegoryBlo { get; set; }
        public string SummaryBlo { get; set; }
        public string ImageMainBlo { get; set; }
        public string FullTextBlo { get; set; }
        public string KeywordsBlo { get; set; }
        public string Language { get; set; }
        public IFormFile file { get; set; }
        public string catname { get; set; }

    }

}