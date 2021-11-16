using System.ComponentModel.DataAnnotations;
namespace DataLayer.AdminEntities.Membership
{
    public class Tbl_Membership
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}