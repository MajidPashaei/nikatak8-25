using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;

namespace ViewModels.AdminViewModel.Request {
    public class Vm_Request {
        [Key]
        public int Id { get; set; }
        public string Id_User { get; set; }
        public string UserName { get; set; }
        public string Type_Request { get; set; }
        public int Amount { get; set; }
        public string Amountst { get; set; }
        public string Bill_Id { get; set; }
        public string Pay_Id { get; set; }
        public string Titel_Request { get; set; }
        public DateTime Date_Request { get; set; }
        public string Date1 { get; set; }
    }

}