using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
namespace ViewModels.AdminViewModel.Order
{
    public class Vm_Factor
    {
        [Key]
        public int Id { get; set; }
        public int Id_Order { get; set; }
        public int Product_Id { get; set; }
        public string product_Name { get; set; }
        public int Product_Count { get; set; }
        public int product_Price { get; set; }
        public int Total_sum { get; set; }
        public string Pay { get; set; }
        public string State { get; set; }
    }
}