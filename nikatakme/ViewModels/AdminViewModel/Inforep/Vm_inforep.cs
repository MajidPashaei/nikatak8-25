using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.inforep {
    public class Vm_inforep {
        [Key]
          public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string part { get; set; }
        public string cod { get; set; }
         public bool codshow { get; set; }
        public string Clerk { get; set; }
        public bool  Clerkshow  { get; set; }
        public string Phone { get; set; }
         public bool  Phoneshow  { get; set; }
        public string PhoneHome { get; set; }
         public bool  PhoneHomeshow  { get; set; }
        public string Address { get; set; }
          public bool  Addressshow  { get; set; }
        public string Postalcode { get; set; }
        public bool  Postalcodeshow  { get; set; }
        public string Locationaddress { get; set; }
        public string Description { get; set; }
        public string photos { get; set; }
         public bool  photosshow  { get; set; }
        public IFormFile poto { get; set; }
        //////////// end Vm_info_records

    }
}