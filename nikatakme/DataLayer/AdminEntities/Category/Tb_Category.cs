using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.Category {
    public class Tb_Category {
        [Key]
        public int Id { get; set; }
        public string NameCat { get; set; }
        public int FatherIdCat { get; set; }
        public string Language { get; set; }

    }

}