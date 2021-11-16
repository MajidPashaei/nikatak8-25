using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ViewModels.AdminViewModel.Financial{
public class Vm_Financial {
    [Key]
    public int Id { get; set; }
    public string UserNameFi { get; set; }
    public string TelFi { get; set; }
    public string RemovalFi { get; set; }
    public string DepositFi { get; set; }
    public DateTime DateFi { get; set; }
    public string StateFi { get; set; }
    public string Language { get; set; }

}

}