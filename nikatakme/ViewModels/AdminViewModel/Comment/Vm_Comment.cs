using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModel.Comment {
    public class Vm_Comment {
        [Key]
        public int Id { get; set; }
        public string User_Id { get; set; }
        public int blog_id { get; set; }
        public int product_id { get; set; }
        public string Comment { get; set; }
        public DateTime DateComment { get; set; }
        public bool State { get; set; }
        public string Language { get; set; }
        public string username { get; set; }
        public string dateshamsi { get; set; }
        public string image { get; set; }

    }

}