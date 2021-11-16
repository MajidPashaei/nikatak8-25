using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.Agency {
    public class Tb_Agency {
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

    }

}