using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModel.Address {
    public class Vm_Address {
        [Key]
        public int Id { get; set; }
        public string FirstAddress { get; set; }
        public string SecondAddress { get; set; }
        public string LocationAd { get; set; }
        public string Tel1Ad { get; set; }
        public string Tel2Ad { get; set; }
        public string Officetel1Ad { get; set; }
        public string Officetel2Ad { get; set; }
        public string Language { get; set; }

    }

}