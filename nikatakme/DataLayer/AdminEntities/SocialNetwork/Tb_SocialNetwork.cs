using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace DataLayer.AdminEntities.SocialNetwork {
    public class Tb_SocialNetwork {
        [Key]
        public int Id { get; set; }
        public string Instagram { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public string Aparat { get; set; }
        public string Youtube { get; set; }
        public string Language { get; set; }

    }

}