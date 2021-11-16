using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class frdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_GalleryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_GalleryProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ImageGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGallery = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ImageGalleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Adress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstAddress = table.Column<string>(nullable: true),
                    SecondAddress = table.Column<string>(nullable: true),
                    LocationAd = table.Column<string>(nullable: true),
                    Tel1Ad = table.Column<string>(nullable: true),
                    Tel2Ad = table.Column<string>(nullable: true),
                    Officetel1Ad = table.Column<string>(nullable: true),
                    Officetel2Ad = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Agencie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageAg = table.Column<string>(nullable: true),
                    NameAg = table.Column<string>(nullable: true),
                    NamePersenAg = table.Column<string>(nullable: true),
                    TelAg = table.Column<string>(nullable: true),
                    OfficetelAg = table.Column<string>(nullable: true),
                    LocationAg = table.Column<string>(nullable: true),
                    DescreptionAg = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Agencie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Baner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleSlid = table.Column<string>(nullable: true),
                    CategoryIdSlid = table.Column<int>(nullable: false),
                    CategoryProductIdSlid = table.Column<int>(nullable: false),
                    TypeSlid = table.Column<string>(nullable: true),
                    ImageMainSlid = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Baner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Bimehs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartMashin1 = table.Column<string>(nullable: true),
                    CartMashin2 = table.Column<string>(nullable: true),
                    BimehNameh = table.Column<string>(nullable: true),
                    GhovahiNameh1 = table.Column<string>(nullable: true),
                    GhovahiNameh2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Bimehs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Blog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleBLo = table.Column<string>(nullable: true),
                    IdCtegoryBlo = table.Column<int>(nullable: false),
                    SummaryBlo = table.Column<string>(nullable: true),
                    ImageMainBlo = table.Column<string>(nullable: true),
                    FullTextBlo = table.Column<string>(nullable: true),
                    KeywordsBlo = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCat = table.Column<string>(nullable: true),
                    FatherIdCat = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<string>(nullable: true),
                    blog_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DateComment = table.Column<DateTime>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Davats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UasrName = table.Column<string>(nullable: true),
                    InviteBy = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Davats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Experts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEx = table.Column<string>(nullable: true),
                    ImageEx = table.Column<string>(nullable: true),
                    TelEx = table.Column<string>(nullable: true),
                    OfficeTelEx = table.Column<string>(nullable: true),
                    LocationEx = table.Column<string>(nullable: true),
                    AboutEx = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Factors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Order = table.Column<int>(nullable: false),
                    Product_Id = table.Column<int>(nullable: false),
                    product_Name = table.Column<string>(nullable: true),
                    Product_Count = table.Column<int>(nullable: false),
                    product_Price = table.Column<int>(nullable: false),
                    Total_sum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Factors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Financial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameFi = table.Column<string>(nullable: true),
                    TelFi = table.Column<string>(nullable: true),
                    RemovalFi = table.Column<string>(nullable: true),
                    DepositFi = table.Column<string>(nullable: true),
                    DateFi = table.Column<DateTime>(nullable: false),
                    StateFi = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Financial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleGal = table.Column<string>(nullable: true),
                    pathImage = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Gallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Hesabs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Hesab = table.Column<string>(nullable: true),
                    Shaba = table.Column<string>(nullable: true),
                    Shobe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Hesabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_infoPersenels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameId = table.Column<string>(nullable: true),
                    Nameper = table.Column<string>(nullable: true),
                    Familyper = table.Column<string>(nullable: true),
                    Fathernameper = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Nameen = table.Column<string>(nullable: true),
                    Familyen = table.Column<string>(nullable: true),
                    Fathernameen = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Yers = table.Column<string>(nullable: true),
                    Mont = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    maritalstatus = table.Column<string>(nullable: true),
                    Bankname = table.Column<string>(nullable: true),
                    Bankcode = table.Column<string>(nullable: true),
                    Branchname = table.Column<string>(nullable: true),
                    Accounttype = table.Column<string>(nullable: true),
                    cardnumber = table.Column<string>(nullable: true),
                    Shabanumber = table.Column<string>(nullable: true),
                    accountnumber = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    PostalcodeBank = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PhoneHome = table.Column<string>(nullable: true),
                    PhonelocationN = table.Column<string>(nullable: true),
                    PhoneNikatak = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Postalcode = table.Column<string>(nullable: true),
                    homeaddress = table.Column<string>(nullable: true),
                    Locationaddress = table.Column<string>(nullable: true),
                    DiplomDate = table.Column<string>(nullable: true),
                    DiplomLocation = table.Column<string>(nullable: true),
                    KardaniDate = table.Column<string>(nullable: true),
                    KardaniLocation = table.Column<string>(nullable: true),
                    KarshenasiDate = table.Column<string>(nullable: true),
                    KarshenasiLocation = table.Column<string>(nullable: true),
                    ArshadDate = table.Column<string>(nullable: true),
                    ArshadLocation = table.Column<string>(nullable: true),
                    DoktoraDate = table.Column<string>(nullable: true),
                    DoktoraLocation = table.Column<string>(nullable: true),
                    photos = table.Column<string>(nullable: true),
                    Nationalcard = table.Column<string>(nullable: true),
                    Nationalcardback = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Shaba = table.Column<string>(nullable: true),
                    Degreeeducation = table.Column<string>(nullable: true),
                    PostalcodeDoc = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    Badbackground = table.Column<string>(nullable: true),
                    Receipt = table.Column<string>(nullable: true),
                    Companyname = table.Column<string>(nullable: true),
                    start = table.Column<string>(nullable: true),
                    End = table.Column<string>(nullable: true),
                    Typeactivity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_infoPersenels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Inforeps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    part = table.Column<string>(nullable: true),
                    cod = table.Column<string>(nullable: true),
                    codshow = table.Column<bool>(nullable: false),
                    Clerk = table.Column<string>(nullable: true),
                    Clerkshow = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Phoneshow = table.Column<bool>(nullable: false),
                    PhoneHome = table.Column<string>(nullable: true),
                    PhoneHomeshow = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Addressshow = table.Column<bool>(nullable: false),
                    Postalcode = table.Column<string>(nullable: true),
                    Postalcodeshow = table.Column<bool>(nullable: false),
                    Locationaddress = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    photos = table.Column<string>(nullable: true),
                    photosshow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Inforeps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_infos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameId = table.Column<string>(nullable: true),
                    Nameper = table.Column<string>(nullable: true),
                    Familyper = table.Column<string>(nullable: true),
                    Fathernameper = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Nameen = table.Column<string>(nullable: true),
                    Familyen = table.Column<string>(nullable: true),
                    Fathernameen = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Yers = table.Column<string>(nullable: true),
                    Mont = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    maritalstatus = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    Bankname = table.Column<string>(nullable: true),
                    Bankcode = table.Column<string>(nullable: true),
                    Branchname = table.Column<string>(nullable: true),
                    Accounttype = table.Column<string>(nullable: true),
                    cardnumber = table.Column<string>(nullable: true),
                    Shabanumber = table.Column<string>(nullable: true),
                    accountnumber = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    PostalcodeBank = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PhoneHome = table.Column<string>(nullable: true),
                    PhonelocationN = table.Column<string>(nullable: true),
                    PhoneNikatak = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Postalcode = table.Column<string>(nullable: true),
                    homeaddress = table.Column<string>(nullable: true),
                    Locationaddress = table.Column<string>(nullable: true),
                    DiplomDate = table.Column<string>(nullable: true),
                    DiplomLocation = table.Column<string>(nullable: true),
                    KardaniDate = table.Column<string>(nullable: true),
                    KardaniLocation = table.Column<string>(nullable: true),
                    KarshenasiDate = table.Column<string>(nullable: true),
                    KarshenasiLocation = table.Column<string>(nullable: true),
                    ArshadDate = table.Column<string>(nullable: true),
                    ArshadLocation = table.Column<string>(nullable: true),
                    DoktoraDate = table.Column<string>(nullable: true),
                    DoktoraLocation = table.Column<string>(nullable: true),
                    photos = table.Column<string>(nullable: true),
                    Nationalcard = table.Column<string>(nullable: true),
                    Nationalcardback = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    Shaba = table.Column<string>(nullable: true),
                    Degreeeducation = table.Column<string>(nullable: true),
                    PostalcodeDoc = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    Badbackground = table.Column<string>(nullable: true),
                    Receipt = table.Column<string>(nullable: true),
                    Companyname = table.Column<string>(nullable: true),
                    start = table.Column<string>(nullable: true),
                    End = table.Column<string>(nullable: true),
                    Typeactivity = table.Column<string>(nullable: true),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_JobPays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    CodeMeli = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Rand = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    statuspay = table.Column<bool>(nullable: false),
                    statususe = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_JobPays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_JobUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    CodeMeli = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Telphone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Ostan = table.Column<string>(nullable: true),
                    Rand = table.Column<string>(nullable: true),
                    Tahsilat = table.Column<string>(nullable: true),
                    Reshte = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Tavalood = table.Column<DateTime>(nullable: false),
                    Img_CartMeli = table.Column<string>(nullable: true),
                    Img_MadrakTahsili = table.Column<string>(nullable: true),
                    Img_PayanKH = table.Column<string>(nullable: true),
                    Img_Shenasname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_JobUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_KasabeYarUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    CodeMeli = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserAdmin = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CodePosti = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_KasabeYarUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Logo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleLogo = table.Column<string>(nullable: true),
                    ImageLogo = table.Column<string>(nullable: true),
                    FavIcon = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Logo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderMess = table.Column<string>(nullable: true),
                    ResiverMess = table.Column<string>(nullable: true),
                    DateMess = table.Column<DateTime>(nullable: false),
                    SubjectMess = table.Column<string>(nullable: true),
                    TextMess = table.Column<string>(nullable: true),
                    StateMess = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    pathfile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mypays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Pay = table.Column<int>(nullable: false),
                    Harvest = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mypays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_user = table.Column<int>(nullable: false),
                    Date_Order = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Originality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductOri = table.Column<int>(nullable: false),
                    NumberProductOri = table.Column<string>(nullable: true),
                    DateCreateOri = table.Column<DateTime>(nullable: false),
                    HologramCodeOri = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Originality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PayBills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    BillId = table.Column<string>(nullable: true),
                    PayId = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    ShenaseMarja = table.Column<string>(nullable: true),
                    PeygiriId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PayBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_pays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Pay = table.Column<int>(nullable: false),
                    Harvest = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleProductPro = table.Column<string>(nullable: true),
                    ImageMainPro = table.Column<string>(nullable: true),
                    CategoryIdPro = table.Column<string>(nullable: true),
                    PricePro = table.Column<string>(nullable: true),
                    OfferPro = table.Column<string>(nullable: true),
                    SizePro = table.Column<string>(nullable: true),
                    ColorPro = table.Column<string>(nullable: true),
                    BrandPro = table.Column<string>(nullable: true),
                    TypeCarPro = table.Column<string>(nullable: true),
                    MaterialPro = table.Column<string>(nullable: true),
                    TotalPro = table.Column<string>(nullable: true),
                    DescreptionPro = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Type_Request = table.Column<string>(nullable: true),
                    Bill_Id = table.Column<string>(nullable: true),
                    Pay_Id = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Titel_Request = table.Column<string>(nullable: true),
                    Date_Request = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Richats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScriptChat = table.Column<string>(nullable: true),
                    zarinpal = table.Column<string>(nullable: true),
                    enemad = table.Column<string>(nullable: true),
                    sms = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    paternsms = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Richats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Slider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleSlid = table.Column<string>(nullable: true),
                    CategoryIdSlid = table.Column<int>(nullable: false),
                    CategoryProductIdSlid = table.Column<int>(nullable: false),
                    TypeSlid = table.Column<string>(nullable: true),
                    ImageMainSlid = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SocialNetwork",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instagram = table.Column<string>(nullable: true),
                    Telegram = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Whatsapp = table.Column<string>(nullable: true),
                    Aparat = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SocialNetwork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Teaser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleTeaser = table.Column<string>(nullable: true),
                    CategoryIdTeaser = table.Column<string>(nullable: true),
                    VideoPathTeaser = table.Column<string>(nullable: true),
                    LinkVideoTeaser = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Teaser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_TokenPayGabzValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: true),
                    Refresh = table.Column<string>(nullable: true),
                    LifeTime = table.Column<DateTime>(nullable: false),
                    Scopes = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TokenPayGabzValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_TokenValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: true),
                    Refresh = table.Column<string>(nullable: true),
                    LifeTime = table.Column<DateTime>(nullable: false),
                    Scopes = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TokenValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameUs = table.Column<string>(nullable: true),
                    EmailUS = table.Column<string>(nullable: true),
                    PhoneUs = table.Column<string>(nullable: true),
                    PasswordUs = table.Column<string>(nullable: true),
                    AddressUs = table.Column<string>(nullable: true),
                    ProfileImageUs = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    NameFamily = table.Column<string>(nullable: true),
                    CodeMeli = table.Column<string>(nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserPersenel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameUs = table.Column<string>(nullable: true),
                    EmailUS = table.Column<string>(nullable: true),
                    PhoneUs = table.Column<string>(nullable: true),
                    PasswordUs = table.Column<string>(nullable: true),
                    AddressUs = table.Column<string>(nullable: true),
                    ProfileImageUs = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    NameFamily = table.Column<string>(nullable: true),
                    CodeMeli = table.Column<string>(nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserPersenel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    CodeNational = table.Column<string>(nullable: true),
                    Gmail = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CodeInvite = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_VoipNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Ostan = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Rezerve = table.Column<string>(nullable: true),
                    DateRezerve = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_VoipNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_VoipOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Id_User = table.Column<int>(nullable: false),
                    Id_Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_VoipOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_VoipUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    NameFamily = table.Column<string>(nullable: true),
                    CM_Code = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CM_Img = table.Column<string>(nullable: true),
                    CM_Img2 = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_VoipUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_GalleryProducts");

            migrationBuilder.DropTable(
                name: "tb_ImageGalleries");

            migrationBuilder.DropTable(
                name: "Tbl_Adress");

            migrationBuilder.DropTable(
                name: "Tbl_Agencie");

            migrationBuilder.DropTable(
                name: "Tbl_Baner");

            migrationBuilder.DropTable(
                name: "Tbl_Bimehs");

            migrationBuilder.DropTable(
                name: "Tbl_Blog");

            migrationBuilder.DropTable(
                name: "tbl_category");

            migrationBuilder.DropTable(
                name: "Tbl_Comments");

            migrationBuilder.DropTable(
                name: "Tbl_Contacts");

            migrationBuilder.DropTable(
                name: "Tbl_Davats");

            migrationBuilder.DropTable(
                name: "Tbl_Experts");

            migrationBuilder.DropTable(
                name: "Tbl_Factors");

            migrationBuilder.DropTable(
                name: "Tbl_Financial");

            migrationBuilder.DropTable(
                name: "Tbl_Gallery");

            migrationBuilder.DropTable(
                name: "Tbl_Hesabs");

            migrationBuilder.DropTable(
                name: "Tbl_infoPersenels");

            migrationBuilder.DropTable(
                name: "Tbl_Inforeps");

            migrationBuilder.DropTable(
                name: "Tbl_infos");

            migrationBuilder.DropTable(
                name: "Tbl_JobPays");

            migrationBuilder.DropTable(
                name: "Tbl_JobUsers");

            migrationBuilder.DropTable(
                name: "Tbl_KasabeYarUsers");

            migrationBuilder.DropTable(
                name: "Tbl_Logo");

            migrationBuilder.DropTable(
                name: "Tbl_Memberships");

            migrationBuilder.DropTable(
                name: "Tbl_Message");

            migrationBuilder.DropTable(
                name: "Tbl_Mypays");

            migrationBuilder.DropTable(
                name: "Tbl_Order");

            migrationBuilder.DropTable(
                name: "Tbl_Originality");

            migrationBuilder.DropTable(
                name: "Tbl_PayBills");

            migrationBuilder.DropTable(
                name: "Tbl_pays");

            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_Requests");

            migrationBuilder.DropTable(
                name: "Tbl_Richats");

            migrationBuilder.DropTable(
                name: "Tbl_Slider");

            migrationBuilder.DropTable(
                name: "Tbl_SocialNetwork");

            migrationBuilder.DropTable(
                name: "Tbl_Teaser");

            migrationBuilder.DropTable(
                name: "Tbl_TokenPayGabzValues");

            migrationBuilder.DropTable(
                name: "Tbl_TokenValues");

            migrationBuilder.DropTable(
                name: "Tbl_User");

            migrationBuilder.DropTable(
                name: "Tbl_UserPersenel");

            migrationBuilder.DropTable(
                name: "Tbl_Users");

            migrationBuilder.DropTable(
                name: "Tbl_VoipNumbers");

            migrationBuilder.DropTable(
                name: "Tbl_VoipOrders");

            migrationBuilder.DropTable(
                name: "Tbl_VoipUsers");
        }
    }
}
