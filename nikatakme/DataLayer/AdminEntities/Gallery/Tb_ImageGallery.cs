using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.AdminEntities.Gallery {
    public class Tb_ImageGallery {
        [Key]
        public int Id { get; set; }
        public int IdGallery { get; set; }
        public string ImagePath { get; set; }
        public string Language { get; set; }

    }

}