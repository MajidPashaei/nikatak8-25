using System.Security.AccessControl;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ViewModels.AdminViewModel.Gallery{
public class Vm_Gallery {
    [Key]
    public int Id { get; set; }
    public string TitleGal { get; set; }
    public string pathImage { get; set; }
    public string Language { get; set; }
    public List<IFormFile> upload_imgs { get; set; }
    public IFormFile img { get; set; }

}

}