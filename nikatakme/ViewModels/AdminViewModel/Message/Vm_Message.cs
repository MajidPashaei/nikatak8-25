using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Message {
    public class Vm_Message {
        [Key]
        public int Id { get; set; }
        public string SenderMess { get; set; }
        public string ResiverMess { get; set; }
        public string DateMess { get; set; }
        public string SubjectMess { get; set; }
        public string TextMess { get; set; }
        public bool StateMess { get; set; }
        public string Language { get; set; }
        public IFormFile emailAttach { get; set; }
        public string pathfile { get; set; }
        public IFormFile file { get; set; }
        public string namesender { get; set; }
        

    }

}