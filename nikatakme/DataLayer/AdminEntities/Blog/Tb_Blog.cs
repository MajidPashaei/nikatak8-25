using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.Blog {
    public class Tb_Blog {
        [Key]
        public int Id { get; set; }
        public string TitleBLo { get; set; }
        public int IdCtegoryBlo { get; set; }
        public string SummaryBlo { get; set; }
        public string ImageMainBlo { get; set; }
        public string FullTextBlo { get; set; }
        public string KeywordsBlo { get; set; }
        public string Language { get; set; }

    }

}