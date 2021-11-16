using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using faraboom.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using ViewModels.AdminViewModel.Originality;
using DataLayer.AdminEntities.Comment;
using Microsoft.AspNetCore.Hosting;

namespace faraboom.Controllers
{
       public class CommentController : BaseController
    {
       ////////////////////////////////////////////////////type db
       public CommentController(ContextHampadco _db, IWebHostEnvironment env):base(_db,env)
        {
            
        }

        //////////////////////////////////////////////////////////
        [HttpPost]    
        public bool addBlog(string comment,int id)
        {
          if (User.Identity.IsAuthenticated)
          {
              Tb_Comment com =new Tb_Comment()
              {
                  User_Id=User.Identity.GetId(),
                  blog_id=id,
                  Comment=comment,
                  State=false,
                  DateComment=DateTime.Today,
                   Language=ln


              };
              db.Tbl_Comments.Add(com);
              db.SaveChanges();
              return true;

              
          }else
          return false;


        }


        [HttpPost]    
        public bool addproduct(string comment,int id)
        {
          if (User.Identity.IsAuthenticated)
          {
              Tb_Comment com =new Tb_Comment()
              {
                  User_Id=User.Identity.GetId(),
                  product_id=id,
                  Comment=comment,
                  State=false,
                  DateComment=DateTime.Today,
                  Language=ln


              };
              db.Tbl_Comments.Add(com);
              db.SaveChanges();
              return true;

              
          }else
          return false;


        }
       
    }
}
