using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace ViewModels.AdminViewModel.Originality {
    public class Vm_Originality {
        [Key]
        public int Id { get; set; }
        public int IdProductOri { get; set; }
        public string NumberProductOri { get; set; }
        public DateTime DateCreateOri { get; set; }
        public string HologramCodeOri { get; set; }
        public string Language { get; set; }
        public string nameproduct { get; set; }
        public string img { get; set; }
      
        
        
        
        
    }

}