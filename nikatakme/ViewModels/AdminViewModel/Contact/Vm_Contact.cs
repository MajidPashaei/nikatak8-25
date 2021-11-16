using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModel.Contact
{
    public class Vm_Contact
    {
           public int Id { get; set; }
           public string Email { get; set; }
           public string Phone { get; set; }
           public string Title { get; set; }
           public string Text { get; set; }
    }
}