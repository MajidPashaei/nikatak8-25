using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModel.Voip
{
    public class Vm_Factor
    {
        [Key]
        public int Id { get; set; }
        public string Amount_Total { get; set; }
        // ------------------------------ tel
        public int Id_Tel { get; set; }
        public string Number_Tel { get; set; }
        public string Title_Tel { get; set; }
        public string Type_Tel { get; set; }
        public string Ostan_Tel { get; set; }
        public string Amount_Tel { get; set; }
        public string Date_Tel { get; set; }
        public string Amount_ArAf_Tel { get; set; }
        public string Total_Amount_Tel { get; set; }
        // ------------------------------ set
        public string Title_Set { get; set; }
        public string Type_Set { get; set; }
        public string Amount_Set { get; set; }
        public string Date_Set { get; set; }
        // ------------------------------ admin
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone_Admin { get; set; }
        public string Ostan_City { get; set; }
        // ------------------------------ client
        public string NameFamily { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public string OstanCity { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Post { get; set; }
        public string CodeMeli { get; set; }
        public string Address { get; set; }

        public int Order_Id { get; set; }
        public string ta1 { get; set; }
        public string ta2 { get; set; }
    }
}
 
/*  
Amount_Total
// ------------------------------ tel
Number_Tel
Title_Tel
Type_Tel
Ostan_Tel
Amount_Tel
Date_Tel
// ------------------------------ set
Title_Set
Type_Set
Amount_Set
Date_Set
// ------------------------------ admin
UserName
Name = HttpContext.Session.GetString("name");
Phone_Admin
Ostan_City
// ------------------------------ client
NameFamily
Ostan
City
Mobile
Phone
post 
*/