using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.Contact
{
    public class Tbl_Contact
    {
           [Key]
           public int Id { get; set; }
           public string Email { get; set; }
           public string Phone { get; set; }
           public string Title { get; set; }
           public string Text { get; set; }

    }
}