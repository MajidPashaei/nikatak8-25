using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace ViewModels.AdminViewModel.Order {
    public class Vm_Order {
      [Key]
        public int Id { get; set; }
        public int Id_user { get; set; }
        public DateTime Date_Order { get; set; }
         public string Pay { get; set; }
        public string State { get; set; }
        public int Total { get; set; }
        public string datesave { get; set; }
          public string UserName { get; set; }
        public string phone { get; set; }
        
        
        
        
        


    }

}