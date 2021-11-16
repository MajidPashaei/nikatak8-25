using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;

namespace DataLayer.AdminEntities.Request {
    public class Tbl_Request {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Type_Request { get; set; }
        public string Bill_Id { get; set; }
        public string Pay_Id { get; set; }
        public int Amount { get; set; }
        public string Titel_Request { get; set; }
        public DateTime Date_Request { get; set; }
    }
}