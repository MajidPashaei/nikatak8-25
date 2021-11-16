using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.AdminEntities.Gallery {
    public class Tb_Gallery {
        [Key]
        public int Id { get; set; }
        public string TitleGal { get; set; }
        public string pathImage { get; set; }
        public string Language { get; set; }

    }

}