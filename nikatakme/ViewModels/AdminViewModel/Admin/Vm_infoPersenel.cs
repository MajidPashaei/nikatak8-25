using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Admin {
    public class Vm_infoPersenel {
        [Key]
        public int Id { get; set; }
        public string UserNameId { get; set; }
        /////////// Vm_document
        public string photos { get; set; }
        public IFormFile Fphotos { get; set; }
        public string Nationalcard { get; set; }
        public IFormFile FNationalcard { get; set; }
        public string Nationalcardback { get; set; }
        public IFormFile FNationalcardback { get; set; }
        public string Certificate { get; set; }
        public IFormFile FCertificate { get; set; }
        public string Shaba { get; set; }
        public IFormFile FShaba { get; set; }
        public string Degreeeducation { get; set; }
        public IFormFile FDegreeeducation { get; set; }
        public string PostalcodeDoc { get; set; }
        public IFormFile FPostalcodeDoc { get; set; }
        public string Document { get; set; }
        public IFormFile FDocument { get; set; }
        public string Badbackground { get; set; }
        public IFormFile FBadbackground { get; set; }
        public string Receipt { get; set; }
        public IFormFile FReceipt { get; set; }
        ///////////end Vm_document

        /////////info personal
        public string Nameper { get; set; }
        public string Familyper { get; set; }
        public string Fathernameper { get; set; }
        public string NationalCode { get; set; }
        public string Nameen { get; set; }
        public string Familyen { get; set; }
        public string Fathernameen { get; set; }
        public string Place { get; set; }
        public string Serial { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string Yers { get; set; }
        public string Mont { get; set; }
        public string Day { get; set; }
        public string Gender { get; set; }
        public string maritalstatus { get; set; }

        ///////////end info personal

        //////////Vm_info_account
        public string Bankname { get; set; }
        public string Bankcode { get; set; }
        public string Branchname { get; set; }
        public string Accounttype { get; set; }
        public string cardnumber { get; set; }
        public string Shabanumber { get; set; }
        public string accountnumber { get; set; }
        public string AccountName { get; set; }
        public string PostalcodeBank { get; set; }
        public string Address { get; set; }

        /////////////end Vm_info_account

        //////////Vm_Contact
        public string Phone { get; set; }
        public string PhoneHome { get; set; }
        public string PhonelocationN { get; set; }
        public string PhoneNikatak { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Postalcode { get; set; }
        public string homeaddress { get; set; }
        public string Locationaddress { get; set; }
        ////////// end Vm_Contact

        ///////////Vm_Level

   
        public string DiplomDate { get; set; }
        public string DiplomLocation { get; set; }
        public string KardaniDate { get; set; }
        public string KardaniLocation { get; set; }
        public string KarshenasiDate { get; set; }
        public string KarshenasiLocation { get; set; }
        public string ArshadDate { get; set; }
        public string ArshadLocation { get; set; }
        public string DoktoraDate { get; set; }
        public string DoktoraLocation { get; set; }

        ////////////end Vm_Level

        ////////////Vm_info_records
        public string Companyname { get; set; }
        public string start { get; set; }
        public string End { get; set; }
        public string Typeactivity { get; set; }
        //////////// end Vm_info_records

    }
}