using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModel.Job
{
    public class Vm_JobPay
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CodeMeli { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Rand { get; set; }
        public DateTime DateTime { get; set; }
        public string time { get; set; }
        public bool statuspay { get; set; }
        public bool statususe { get; set; }
    }
}