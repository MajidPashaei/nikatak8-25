using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ViewModels.AdminViewModel.Gallery{
public class Vm_ImageGallery {
    [Key]
    public int Id { get; set; }
    public int IdGallery { get; set; }
    public string ImagePath { get; set; }
    public string Language { get; set; }

}

}