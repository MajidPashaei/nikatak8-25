using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModel.Voip
{
    public class Vm_VoipOrder
    {
        [Key]
        public int Id { get; set; }
        public int UserName { get; set; }
        public int Id_User { get; set; }
        public int Id_Number { get; set; }
    }
}