using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace DataLayer.AdminEntities.Baner {
    public class Tb_Baner {
        [Key]
        public int Id { get; set; }
        public string TitleSlid { get; set; }
        public int CategoryIdSlid { get; set; }
        public int CategoryProductIdSlid { get; set; }
        public string TypeSlid { get; set; }
        public string ImageMainSlid { get; set; }
        public string Language { get; set; }

    }

}