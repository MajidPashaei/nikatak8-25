using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace DataLayer.AdminEntities.Message {
    public class Tb_Message {
        [Key]
        public int Id { get; set; }
        public string SenderMess { get; set; }
        public string ResiverMess { get; set; }
        public DateTime DateMess { get; set; }
        public string SubjectMess { get; set; }
        public string TextMess { get; set; }
        public bool StateMess { get; set; }
        public string Language { get; set; }
        public string pathfile { get; set; }

    }

}