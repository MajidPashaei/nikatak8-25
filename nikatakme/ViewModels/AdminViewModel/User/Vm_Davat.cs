using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace ViewModels.AdminViewModel.User
{
    public class Vm_Davat
    {
        [Key]
        public int Id { get; set; }
        public string UasrName { get; set; }
        public string InviteBy { get; set; }
        public bool Status { get; set; }
    }
}