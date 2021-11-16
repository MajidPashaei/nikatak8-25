using System;
using System.ComponentModel.DataAnnotations;
namespace ViewModels.AdminViewModel.Richat
{
    public class Vm_Richat
    {
        [Key]
        public int Id { get; set; }
        public string ScriptChat { get; set; }
        
        public string zarinpal { get; set; }
        public string enemad { get; set; }
        public string sms { get; set; }
         public string website { get; set; }
        public string paternsms { get; set; }
        
    }
}







