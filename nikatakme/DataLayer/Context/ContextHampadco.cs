using DataLayer.AdminEntities.Address;
using DataLayer.AdminEntities.Admin;
using DataLayer.AdminEntities.Agency;
using DataLayer.AdminEntities.Baner;
using DataLayer.AdminEntities.Blog;
using DataLayer.AdminEntities.Category;
using DataLayer.AdminEntities.Comment;
using DataLayer.AdminEntities.Experts;
using DataLayer.AdminEntities.Financial;
using DataLayer.AdminEntities.Gallery;
using DataLayer.AdminEntities.Logo;
using DataLayer.AdminEntities.Message;
using DataLayer.AdminEntities.Order;
using DataLayer.AdminEntities.Originality;
using DataLayer.AdminEntities.Product;
using DataLayer.AdminEntities.Richat;
using DataLayer.AdminEntities.Slider;
using DataLayer.AdminEntities.SocialNetwork;
using DataLayer.AdminEntities.Teaser;
using DataLayer.AdminEntities.User;
using DataLayer.AdminEntities.inforep;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DataLayer.AdminEntities.wallet;
using DataLayer.AdminEntities.Contact;
using DataLayer.AdminEntities.Request;
using DataLayer.AdminEntities.Hesab;
using DataLayer.AdminEntities.Membership;
using DataLayer.AdminEntities.Bimeh;
using DataLayer.AdminEntities.TokenValue;
using DataLayer.AdminEntities.PayBills;
using DataLayer.AdminEntities.mobiledb;
using DataLayer.AdminEntities.Voip;
using DataLayer.AdminEntities.Job;
using DataLayer.AdminEntities.KasabeYar;

namespace DataLayer.Context
{
    public class ContextHampadco : DbContext
    {
        public ContextHampadco(DbContextOptions<ContextHampadco> options) : base(options)
        {
        }
        public DbSet<Tb_Address> Tbl_Adress { get; set; }
        public DbSet<Tb_Agency> Tbl_Agencie { get; set; }
        public DbSet<Tb_Blog> Tbl_Blog { get; set; }
        public DbSet<Tb_Comment> Tbl_Comments { get; set; }
        public DbSet<Tb_Category> tbl_category { get; set; }
        public DbSet<Tb_Experts> Tbl_Experts { get; set; }
        public DbSet<Tb_Financial> Tbl_Financial { get; set; }
        public DbSet<Tb_Gallery> Tbl_Gallery { get; set; }
        public DbSet<Tb_ImageGallery> tb_ImageGalleries { get; set; }
        public DbSet<Tb_Logo> Tbl_Logo { get; set; }
        public DbSet<Tb_Message> Tbl_Message { get; set; }
        public DbSet<Tb_Order> Tbl_Order { get; set; }
        public DbSet<Tb_Factor> Tbl_Factors { get; set; }
        public DbSet<Tb_Originality> Tbl_Originality { get; set; }
        public DbSet<Tb_Product> Tbl_Product { get; set; }
        public DbSet<Tb_Slider> Tbl_Slider { get; set; }
        public DbSet<Tb_Baner> Tbl_Baner { get; set; }
        public DbSet<Tbl_Richat> Tbl_Richats { get; set; }
        public DbSet<Tb_SocialNetwork> Tbl_SocialNetwork { get; set; }
        public DbSet<Tb_Teaser> Tbl_Teaser { get; set; }
        public DbSet<Tb_User> Tbl_User { get; set; }
        public DbSet<Tbl_KasabeYarUser> Tbl_KasabeYarUsers { get; set; }
        public DbSet<Tb_UserPersenel> Tbl_UserPersenel { get; set; }
        public DbSet<Tb_GalleryProduct> tb_GalleryProducts { get; set; }
        public DbSet<Tbl_info> Tbl_infos { get; set; }
        public DbSet<Tbl_infoPersenel> Tbl_infoPersenels { get; set; }
        public DbSet<Tbl_inforep> Tbl_Inforeps { get; set; }
        public DbSet<Tbl_pay> Tbl_pays { get; set; } 
        public DbSet<Tbl_Contact> Tbl_Contacts { get; set; } 
        public DbSet<Tbl_Request> Tbl_Requests { get; set; } 
        public DbSet<Tbl_Hesab> Tbl_Hesabs { get; set; } 
        public DbSet<Tbl_Membership> Tbl_Memberships { get; set; } 
        public DbSet<Tbl_Bimeh> Tbl_Bimehs { get; set; } 
        public DbSet<Tb_TokenValue> Tbl_TokenValues { get; set; }
        public DbSet<Tb_TokenPayGabzValue> Tbl_TokenPayGabzValues { get; set; }
        public DbSet<Tb_PayBill> Tbl_PayBills { get; set; }
        public DbSet<Tbl_Mypay> Tbl_Mypays { get; set; }
        public DbSet<Tbl_User> Tbl_Users { get; set; }
        public DbSet<Tbl_Davat> Tbl_Davats { get; set; }
        public DbSet<Tbl_VoipNumber> Tbl_VoipNumbers { get; set; }
        public DbSet<Tbl_VoipOrder> Tbl_VoipOrders { get; set; }
        public DbSet<Tbl_VoipUser> Tbl_VoipUsers { get; set; }
        public DbSet<Tbl_JobUser> Tbl_JobUsers { get; set; }
        public DbSet<Tbl_JobPay> Tbl_JobPays { get; set; }
    }
    public class ToDoContextFactory : IDesignTimeDbContextFactory<ContextHampadco>
    {
        public ContextHampadco CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ContextHampadco>();
            builder.UseSqlServer("Data Source=.;initial Catalog=taxijoc1_nika;integrated Security=SSPI;MultipleActiveResultSets=true");
            //  builder.UseSqlServer("Data Source=193.141.64.76,2019;initial Catalog=hampadco;USER ID=hampadco;PASSWORD=12345@iran;MultipleActiveResultSets=true");
            return new ContextHampadco(builder.Options);
        }
    }

}