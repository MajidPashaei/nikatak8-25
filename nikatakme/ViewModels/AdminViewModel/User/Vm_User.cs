using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.User {
    public class Vm_User {
        [Key]
        public int Id { get; set; }
        public string UserNameUs { get; set; }
        public string EmailUS { get; set; }
        public string PhoneUs { get; set; }
        public string PasswordUs { get; set; }
        public string RePasswordUs { get; set; }
        public string AddressUs { get; set; }
        public string ProfileImageUs { get; set; }
        public string Language { get; set; }
        public string NameFamily { get; set; }
        public string CodeMeli { get; set; }
        public IFormFile NameFile { get; set; }
        public IFormFile img { get; set; }
        public bool state { get; set; }
        public string Captcha { get; set; }
        public string pay { get; set; }
        public string n { get; set; }
        public string f { get; set; }

        public string Name { get; set; }
        public string Family { get; set; }
        public string CodeNational { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public string CodeInvite { get; set; }
        public string Token { get; set; }

    }
}