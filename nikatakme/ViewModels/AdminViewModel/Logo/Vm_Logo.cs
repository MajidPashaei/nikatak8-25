using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace ViewModels.AdminViewModel.Logo{
public class Vm_Logo {
    [Key]
    public int Id { get; set; }
    public string TitleLogo { get; set; }
    public IFormFile ImageLogo { get; set; }
    public string ImageLogost { get; set; }
    public string FavIcon { get; set; }  
     public IFormFile fav { get; set; }
    public string Language { get; set; }

}

}