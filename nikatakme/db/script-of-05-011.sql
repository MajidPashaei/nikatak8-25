USE [master]
GO
/****** Object:  Database [nikatek_db]    Script Date: 8/2/2021 10:47:54 AM ******/
CREATE DATABASE [nikatek_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'nikatek_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\nikatek_db.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'nikatek_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\nikatek_db_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [nikatek_db] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [nikatek_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [nikatek_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [nikatek_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [nikatek_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [nikatek_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [nikatek_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [nikatek_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [nikatek_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [nikatek_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [nikatek_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [nikatek_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [nikatek_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [nikatek_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [nikatek_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [nikatek_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [nikatek_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [nikatek_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [nikatek_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [nikatek_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [nikatek_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [nikatek_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [nikatek_db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [nikatek_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [nikatek_db] SET RECOVERY FULL 
GO
ALTER DATABASE [nikatek_db] SET  MULTI_USER 
GO
ALTER DATABASE [nikatek_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [nikatek_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [nikatek_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [nikatek_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [nikatek_db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'nikatek_db', N'ON'
GO
USE [nikatek_db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_GalleryProducts]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_GalleryProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduct] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_GalleryProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_ImageGalleries]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ImageGalleries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdGallery] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_ImageGalleries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tb_Pays]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Pays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Pay] [nvarchar](max) NULL,
	[DatePay] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tb_Pays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Adress]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Adress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstAddress] [nvarchar](max) NULL,
	[SecondAddress] [nvarchar](max) NULL,
	[LocationAd] [nvarchar](max) NULL,
	[Tel1Ad] [nvarchar](max) NULL,
	[Tel2Ad] [nvarchar](max) NULL,
	[Officetel1Ad] [nvarchar](max) NULL,
	[Officetel2Ad] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Agencie]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Agencie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageAg] [nvarchar](max) NULL,
	[NameAg] [nvarchar](max) NULL,
	[NamePersenAg] [nvarchar](max) NULL,
	[TelAg] [nvarchar](max) NULL,
	[OfficetelAg] [nvarchar](max) NULL,
	[LocationAg] [nvarchar](max) NULL,
	[DescreptionAg] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Agencie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Baner]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Baner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleSlid] [nvarchar](max) NULL,
	[CategoryIdSlid] [int] NOT NULL,
	[CategoryProductIdSlid] [int] NOT NULL,
	[TypeSlid] [nvarchar](max) NULL,
	[ImageMainSlid] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Baner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Bimehs]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Bimehs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartMashin1] [nvarchar](max) NULL,
	[CartMashin2] [nvarchar](max) NULL,
	[BimehNameh] [nvarchar](max) NULL,
	[GhovahiNameh1] [nvarchar](max) NULL,
	[GhovahiNameh2] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Bimehs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleBLo] [nvarchar](max) NULL,
	[IdCtegoryBlo] [int] NOT NULL,
	[SummaryBlo] [nvarchar](max) NULL,
	[ImageMainBlo] [nvarchar](max) NULL,
	[FullTextBlo] [nvarchar](max) NULL,
	[KeywordsBlo] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameCat] [nvarchar](max) NULL,
	[FatherIdCat] [int] NOT NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Comments]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [nvarchar](max) NULL,
	[blog_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[DateComment] [datetime2](7) NOT NULL,
	[State] [bit] NOT NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Contacts]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Experts]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Experts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameEx] [nvarchar](max) NULL,
	[ImageEx] [nvarchar](max) NULL,
	[TelEx] [nvarchar](max) NULL,
	[OfficeTelEx] [nvarchar](max) NULL,
	[LocationEx] [nvarchar](max) NULL,
	[AboutEx] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Experts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Factors]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Factors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Order] [int] NOT NULL,
	[Product_Id] [int] NOT NULL,
	[product_Name] [nvarchar](max) NULL,
	[Product_Count] [int] NOT NULL,
	[product_Price] [int] NOT NULL,
	[Total_sum] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Factors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Financial]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Financial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserNameFi] [nvarchar](max) NULL,
	[TelFi] [nvarchar](max) NULL,
	[RemovalFi] [nvarchar](max) NULL,
	[DepositFi] [nvarchar](max) NULL,
	[DateFi] [datetime2](7) NOT NULL,
	[StateFi] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Financial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Gallery]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Gallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleGal] [nvarchar](max) NULL,
	[pathImage] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Gallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Hesabs]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Hesabs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Bank] [nvarchar](max) NULL,
	[Hesab] [nvarchar](max) NULL,
	[Shaba] [nvarchar](max) NULL,
	[Shobe] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Hesabs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_infoPersenels]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_infoPersenels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserNameId] [nvarchar](max) NULL,
	[Nameper] [nvarchar](max) NULL,
	[Familyper] [nvarchar](max) NULL,
	[Fathernameper] [nvarchar](max) NULL,
	[NationalCode] [nvarchar](max) NULL,
	[Nameen] [nvarchar](max) NULL,
	[Familyen] [nvarchar](max) NULL,
	[Fathernameen] [nvarchar](max) NULL,
	[Place] [nvarchar](max) NULL,
	[Serial] [nvarchar](max) NULL,
	[Religion] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Yers] [nvarchar](max) NULL,
	[Mont] [nvarchar](max) NULL,
	[Day] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[maritalstatus] [nvarchar](max) NULL,
	[Bankname] [nvarchar](max) NULL,
	[Bankcode] [nvarchar](max) NULL,
	[Branchname] [nvarchar](max) NULL,
	[Accounttype] [nvarchar](max) NULL,
	[cardnumber] [nvarchar](max) NULL,
	[Shabanumber] [nvarchar](max) NULL,
	[accountnumber] [nvarchar](max) NULL,
	[AccountName] [nvarchar](max) NULL,
	[PostalcodeBank] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PhoneHome] [nvarchar](max) NULL,
	[PhonelocationN] [nvarchar](max) NULL,
	[PhoneNikatak] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Postalcode] [nvarchar](max) NULL,
	[homeaddress] [nvarchar](max) NULL,
	[Locationaddress] [nvarchar](max) NULL,
	[DiplomDate] [nvarchar](max) NULL,
	[DiplomLocation] [nvarchar](max) NULL,
	[KardaniDate] [nvarchar](max) NULL,
	[KardaniLocation] [nvarchar](max) NULL,
	[KarshenasiDate] [nvarchar](max) NULL,
	[KarshenasiLocation] [nvarchar](max) NULL,
	[ArshadDate] [nvarchar](max) NULL,
	[ArshadLocation] [nvarchar](max) NULL,
	[DoktoraDate] [nvarchar](max) NULL,
	[DoktoraLocation] [nvarchar](max) NULL,
	[photos] [nvarchar](max) NULL,
	[Nationalcard] [nvarchar](max) NULL,
	[Nationalcardback] [nvarchar](max) NULL,
	[Certificate] [nvarchar](max) NULL,
	[Shaba] [nvarchar](max) NULL,
	[Degreeeducation] [nvarchar](max) NULL,
	[PostalcodeDoc] [nvarchar](max) NULL,
	[Document] [nvarchar](max) NULL,
	[Badbackground] [nvarchar](max) NULL,
	[Receipt] [nvarchar](max) NULL,
	[Companyname] [nvarchar](max) NULL,
	[start] [nvarchar](max) NULL,
	[End] [nvarchar](max) NULL,
	[Typeactivity] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_infoPersenels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Inforeps]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Inforeps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[part] [nvarchar](max) NULL,
	[cod] [nvarchar](max) NULL,
	[Clerk] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PhoneHome] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Postalcode] [nvarchar](max) NULL,
	[Locationaddress] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[photos] [nvarchar](max) NULL,
	[Addressshow] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[Clerkshow] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[PhoneHomeshow] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[Phoneshow] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[Postalcodeshow] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[codshow] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
	[photosshow] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
 CONSTRAINT [PK_Tbl_Inforeps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_infos]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_infos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nameper] [nvarchar](max) NULL,
	[Familyper] [nvarchar](max) NULL,
	[Fathernameper] [nvarchar](max) NULL,
	[NationalCode] [nvarchar](max) NULL,
	[Nameen] [nvarchar](max) NULL,
	[Familyen] [nvarchar](max) NULL,
	[Fathernameen] [nvarchar](max) NULL,
	[Place] [nvarchar](max) NULL,
	[Serial] [nvarchar](max) NULL,
	[Religion] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[maritalstatus] [nvarchar](max) NULL,
	[Bankname] [nvarchar](max) NULL,
	[Bankcode] [nvarchar](max) NULL,
	[Branchname] [nvarchar](max) NULL,
	[Accounttype] [nvarchar](max) NULL,
	[cardnumber] [nvarchar](max) NULL,
	[Shabanumber] [nvarchar](max) NULL,
	[accountnumber] [nvarchar](max) NULL,
	[AccountName] [nvarchar](max) NULL,
	[PostalcodeBank] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PhoneHome] [nvarchar](max) NULL,
	[PhonelocationN] [nvarchar](max) NULL,
	[PhoneNikatak] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Postalcode] [nvarchar](max) NULL,
	[homeaddress] [nvarchar](max) NULL,
	[Locationaddress] [nvarchar](max) NULL,
	[DiplomDate] [nvarchar](max) NULL,
	[DiplomLocation] [nvarchar](max) NULL,
	[KardaniDate] [nvarchar](max) NULL,
	[KardaniLocation] [nvarchar](max) NULL,
	[KarshenasiDate] [nvarchar](max) NULL,
	[KarshenasiLocation] [nvarchar](max) NULL,
	[ArshadDate] [nvarchar](max) NULL,
	[ArshadLocation] [nvarchar](max) NULL,
	[DoktoraDate] [nvarchar](max) NULL,
	[DoktoraLocation] [nvarchar](max) NULL,
	[photos] [nvarchar](max) NULL,
	[Nationalcard] [nvarchar](max) NULL,
	[Nationalcardback] [nvarchar](max) NULL,
	[Certificate] [nvarchar](max) NULL,
	[Shaba] [nvarchar](max) NULL,
	[Degreeeducation] [nvarchar](max) NULL,
	[PostalcodeDoc] [nvarchar](max) NULL,
	[Document] [nvarchar](max) NULL,
	[Badbackground] [nvarchar](max) NULL,
	[Receipt] [nvarchar](max) NULL,
	[Companyname] [nvarchar](max) NULL,
	[start] [nvarchar](max) NULL,
	[End] [nvarchar](max) NULL,
	[Typeactivity] [nvarchar](max) NULL,
	[Day] [nvarchar](max) NULL,
	[Mont] [nvarchar](max) NULL,
	[Yers] [nvarchar](max) NULL,
	[UserNameId] [nvarchar](max) NULL,
	[code] [nvarchar](max) NULL,
	[DateRegister] [datetime2](7) NOT NULL DEFAULT ('0001-01-01T00:00:00.0000000'),
 CONSTRAINT [PK_Tbl_infos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Logo]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Logo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleLogo] [nvarchar](max) NULL,
	[ImageLogo] [nvarchar](max) NULL,
	[FavIcon] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Logo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Memberships]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Memberships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Family] [nvarchar](max) NULL,
	[NationalCode] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Memberships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Message]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderMess] [nvarchar](max) NULL,
	[ResiverMess] [nvarchar](max) NULL,
	[DateMess] [datetime2](7) NOT NULL,
	[SubjectMess] [nvarchar](max) NULL,
	[TextMess] [nvarchar](max) NULL,
	[StateMess] [bit] NOT NULL,
	[Language] [nvarchar](max) NULL,
	[pathfile] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Mypays]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Mypays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Pay] [int] NOT NULL,
	[Harvest] [int] NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[status] [bit] NOT NULL,
	[RequestId] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Mypays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Order]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NOT NULL,
	[Date_Order] [datetime2](7) NOT NULL,
	[Pay] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Originality]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Originality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProductOri] [int] NOT NULL,
	[NumberProductOri] [nvarchar](max) NULL,
	[DateCreateOri] [datetime2](7) NOT NULL,
	[HologramCodeOri] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Originality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_PayBills]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_PayBills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[BillId] [nvarchar](max) NULL,
	[PayId] [nvarchar](max) NULL,
	[User] [nvarchar](max) NULL,
	[Amount] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
	[Time] [nvarchar](max) NULL,
	[ShenaseMarja] [nvarchar](max) NULL,
	[PeygiriId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[MyProperty] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_PayBills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_pays]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_pays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pay] [int] NOT NULL,
	[Harvest] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[DateTime] [datetime2](7) NOT NULL DEFAULT ('0001-01-01T00:00:00.0000000'),
	[RequestId] [int] NOT NULL DEFAULT ((0)),
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_pays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Product]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleProductPro] [nvarchar](max) NULL,
	[ImageMainPro] [nvarchar](max) NULL,
	[CategoryIdPro] [nvarchar](max) NULL,
	[PricePro] [nvarchar](max) NULL,
	[OfferPro] [nvarchar](max) NULL,
	[SizePro] [nvarchar](max) NULL,
	[ColorPro] [nvarchar](max) NULL,
	[BrandPro] [nvarchar](max) NULL,
	[TypeCarPro] [nvarchar](max) NULL,
	[MaterialPro] [nvarchar](max) NULL,
	[TotalPro] [nvarchar](max) NULL,
	[DescreptionPro] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Requests]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type_Request] [nvarchar](max) NULL,
	[Amount] [int] NOT NULL,
	[Titel_Request] [nvarchar](max) NULL,
	[Date_Request] [datetime2](7) NOT NULL,
	[Bill_Id] [nvarchar](max) NULL,
	[Pay_Id] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Richats]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Richats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScriptChat] [nvarchar](max) NULL,
	[zarinpal] [nvarchar](max) NULL,
	[enemad] [nvarchar](max) NULL,
	[sms] [nvarchar](max) NULL,
	[website] [nvarchar](max) NULL,
	[paternsms] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Richats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Slider]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Slider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleSlid] [nvarchar](max) NULL,
	[CategoryIdSlid] [int] NOT NULL,
	[CategoryProductIdSlid] [int] NOT NULL,
	[TypeSlid] [nvarchar](max) NULL,
	[ImageMainSlid] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Slider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_SocialNetwork]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_SocialNetwork](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Instagram] [nvarchar](max) NULL,
	[Telegram] [nvarchar](max) NULL,
	[Facebook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[Whatsapp] [nvarchar](max) NULL,
	[Aparat] [nvarchar](max) NULL,
	[Youtube] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_SocialNetwork] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Teaser]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Teaser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TitleTeaser] [nvarchar](max) NULL,
	[CategoryIdTeaser] [nvarchar](max) NULL,
	[VideoPathTeaser] [nvarchar](max) NULL,
	[LinkVideoTeaser] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Teaser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_TokenPayGabzValues]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TokenPayGabzValues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](max) NULL,
	[Refresh] [nvarchar](max) NULL,
	[LifeTime] [datetime2](7) NOT NULL,
	[Scopes] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_TokenPayGabzValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_TokenValues]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TokenValues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](max) NULL,
	[Refresh] [nvarchar](max) NULL,
	[LifeTime] [datetime2](7) NOT NULL,
	[Scopes] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_TokenValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserNameUs] [nvarchar](max) NULL,
	[EmailUS] [nvarchar](max) NULL,
	[PhoneUs] [nvarchar](max) NULL,
	[PasswordUs] [nvarchar](max) NULL,
	[AddressUs] [nvarchar](max) NULL,
	[ProfileImageUs] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
	[NameFamily] [nvarchar](max) NULL,
	[CodeMeli] [nvarchar](max) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_UserPersenel]    Script Date: 8/2/2021 10:47:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_UserPersenel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserNameUs] [nvarchar](max) NULL,
	[EmailUS] [nvarchar](max) NULL,
	[PhoneUs] [nvarchar](max) NULL,
	[PasswordUs] [nvarchar](max) NULL,
	[AddressUs] [nvarchar](max) NULL,
	[ProfileImageUs] [nvarchar](max) NULL,
	[Language] [nvarchar](max) NULL,
	[NameFamily] [nvarchar](max) NULL,
	[CodeMeli] [nvarchar](max) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_UserPersenel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201008172122_firsr', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201011134135_tbl_cat', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201012075047_adadsss', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201018095537_gallerproduct', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201019071104_add', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201019082954_adds', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201021195927_sjk', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201021201102_sjkfg', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201021204328_sjkfgsd', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201028095544_filemsg', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201108180309_comment', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201109112656_richat', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201109113727_richatd', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201110131106_7star', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201110131702_sevenstarrr', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201110133148_sevenstarr', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201116205854_fact', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201118090103_gavicon', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201118144904_zar', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201118150625_zars', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201122073322_db990902', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201222123804_usersssss', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201222124806_userssssss', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201227143441_asd123', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201227152216_asdasd5445', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201230062646_nika', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201230062840_state', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201230072204_us', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201230153812_dfgf', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210103131530_first', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210103133803_database', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210103142836_asdfsdfdsf', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210114113210_adsasd', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210114140637_uservvvf', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210116073624_sdada', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210116073835_asdasdasd', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210119132532_aassddd', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210120072513_sssaasa', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210404153035_db', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210406061433_new56', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210415121848_frtb', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210415132945_serr', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210419100218_ccddcc', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210419102556_key', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210419104406_newa', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210419105528_new85', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210419105858_new86', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210420073920_Re', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210420081415_rere', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210420143159_bpi', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210422061921_datetime', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210422062557_datetime2', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210509062500_tbh', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210509065257_tbhh', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210509065648_tbhkk', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210517071025_p', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210606114252_mSH', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210612144138_khj', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210708081937_date', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210712151420_fghk', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210712151803_dvbng', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210719071654_gghhggh', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210719104328_sdsdsdsd', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210719164608_tblmypay', N'3.1.8')
SET IDENTITY_INSERT [dbo].[tb_ImageGalleries] ON 

INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (1, 1, N'db3799e3-c835-4885-80ef-5e62517722f1.jpg', N'fa')
INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (2, 1, N'4a6b8386-a835-4d80-9c5e-1ac6565f32d7.jpg', N'fa')
INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (3, 1, N'e615c3c0-c94b-424c-a7ea-adc4e57f874f.jpg', N'fa')
INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (4, 1, N'63d7febe-8d03-4105-94e8-edafe00af56c.jpg', N'fa')
INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (5, 1, N'86369181-0c36-4f16-82d2-716306878cc6.jpg', N'fa')
INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (6, 1, N'f0e166be-cfbd-4e4d-9e44-910852d9b659.jpg', N'fa')
INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (7, 1, N'd0f38076-5a9a-4086-b0a9-f8823baf724a.jpg', N'fa')
INSERT [dbo].[tb_ImageGalleries] ([Id], [IdGallery], [ImagePath], [Language]) VALUES (8, 1, N'b6ebeb48-214b-4e2e-ad6d-44064cc265ee.jpg', N'fa')
SET IDENTITY_INSERT [dbo].[tb_ImageGalleries] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Adress] ON 

INSERT [dbo].[Tbl_Adress] ([Id], [FirstAddress], [SecondAddress], [LocationAd], [Tel1Ad], [Tel2Ad], [Officetel1Ad], [Officetel2Ad], [Language]) VALUES (1, N'تهران، بلوار میرداماد میدان مادر خیابان وزیری پور پلاک2 واحد 7 ', NULL, N'35.75421465300695,51.44574453469759', N'09220648677', N'09220648677', N'02191316789', NULL, N'fa')
SET IDENTITY_INSERT [dbo].[Tbl_Adress] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (1, N'اطلاعیه شماره یک نیکا تک', 12, N'قابل توجه نمایندگان ثبت نام شده تا 8 دی ماه 99 ارسال پیام از طریق واتساب به شماره 09220648677 جهت هماهنگی حضور در شرکت نهایت تا 13 دی ماه میباشد.', N'ec28b0f3-767e-4e67-b849-7c049914475a.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-justify">اطلاعیه شماره یک نیکا تک</p><p class="ql-align-justify">قابل توجه نمایندگان ثبت نام شده تا 8 دی ماه 99 ارسال پیام از طریق واتساب به شماره 09220648677 جهت هماهنگی حضور در شرکت نهایت تا 13 دی ماه میباشد. حضور کلیه نمایندگان مستقر در استانها و شهرستانها که تا مورخه هشتم دی ماه سال جاری درخواست نمایندگی ویا ثبت نام نموده اند می رساند. جهت انعقاد قرارداد از مورخه 13 دی ماه تا 30 دی ماه از طریق واتساب پیام ارسال نموده تا جهت هماهنگی برای مراجعه حضوری به همراه اصل مدارک ذیل به آدرس شرکت مندرج در سایت شرکت مراجعه فرمایند . بدیهی است در صورت عدم هماهنگی قبلی و تنظیم زمان حضور در موعد مقرر در مرحله نخست مجوز فعالیت بمدت۶ماه لغو ودرصورت تکرار باعث لغو خاتمه همکاری می باشد . این اطلاعیه به منزله ابلاغ قانونی جهت ثبت نام کنندگان تا هشتم دی ماه است . در هنگام مراجعه اصل مدارک ذیل وخود نماینده الزامی میباشد: اصل شناسنامه و کارت ملی . اصل مدرک تحصیلی عکس 3*4 به تعداد 4 قطعه اصل کلیه مدارک به همراه رسید پرداخت وجه به حساب شرکت با سپاس مدیریت حقوقی وامور قراردادها تاریخ 99.1.09</p><p class="ql-align-center"><a href="https://nikatak.ir/home/maplogin" target="_blank" class="ql-size-large" style="background-color: rgb(0, 102, 204); color: rgb(255, 255, 255);">برای ثبت نام کلیک کنید</a></p></div><div class="ql-clipboard" contenteditable="true" tabindex="-1"></div><div class="ql-tooltip ql-editing ql-flip ql-hidden" data-mode="link" style="left: 388.859px; top: 107.899px;"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL" placeholder="https://quilljs.com"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (2, N'اطلاعیه شماره دو نیکا تک', 12, N'اطلاعیه شماره دو نیکا تک فراخوان دعوت به همکاری 9 تا 19 دی ماه 99 شرکت نیکا تک پیشرو در ارائه خدمات الکترونیکی به مناسبت دهه بصیرت از 9 دی تا 19 دی نسبت به پذیرش و اعطای نمایندگی در سراسر ایران اسلامی برای خدمات هوشمند یکپارچه نیکاتک اقدام می نماید', N'52b28a9a-75cb-4d1f-90e5-a7f5f72a523d.jpg', N'<div  style="text-align: center;background-color:rgb(143, 159, 255)"> <img src="https://nikatak.ir/site/Images/logo2.png" alt=""></div>
    <div style="">
    <h4 style="text-align: center;">سلام دوست عزیز به جمع بزرگ نیکاتک خوش آمدید</h4>
    <h4 style="text-align: center;">قرارداد به پیوست خدمت شما ارسال شد لطفا قرار داد را کامل نموده و آن را برای ما پست کنید</h4>
    <h4 style="text-align: center;"> لطفا برای دانلود قرار داد روی لینک زیر  کلیک کنید</h4>
    <div style="text-align: center;">
        <a href="https://drive.google.com/file/d/1HoK73qWxRieGkS1p7Rjg57OhN5Y1rk9L/view?usp=sharing"  >
            <h4>لینک دانلود</h4>
            
        </a>
    </div>
    <h4 style="text-align: center;"> شماره تماس همراه : : 09220648677</h4>
    <h4 style="text-align: center;"> شماره تماس ثابت اول : : 02191316789 </h4>
    
  </div> 
  <div style="text-align: center;">
    <a href="http://nikatak.ir/"  >
        <h4>وب سایت نیکاتک</h4>
        
    </a>
</div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (3, N'خوش آمدگویی نیکاتک', 12, N'ضمن عرض سلام و وقت بخیر  خدمت تمام دوستان عزیز 

نیکاتک ورود شما به جامعه نیکاتک را خیر مقدم عرض می نماید', N'975b9596-2826-4e61-b3a1-9a43456f2a99.png', N'<div  style="text-align: center;background-color:rgb(143, 159, 255)"> <img src="https://nikatak.ir/site/Images/logo2.png" alt=""></div>
    <div style="text-align: center;">
    <h4 style="text-align: center;">سلام دوست عزیز به جمع بزرگ نیکاتک خوش آمدید</h4>
    <h4 style="text-align: center;">نام کاربری شما :user</h4>
    <h4 style="text-align: center;"> رمز عبور شما : pass</h4>
    <h4 style="text-align: center;"> برای تایید ایمیل روی لینک زیر کلیک کنید</h4>
    <div style="text-align: center;">
        <a href="https://nikatak.ir/login/verify"  >
           لینک تایید ایمیل 
            
        </a>
    </div>
    <h4 style="text-align: center;"> شماره تماس همراه : : 09220648677</h4>
    <h4 style="text-align: center;"> شماره تماس ثابت اول : : 02191316789 </h4>
    
  </div> 
  <div style="text-align: center;">
    <a href="http://nikatak.ir/"  >
        <h4>وب سایت نیکاتک</h4>
        
    </a>
</div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (4, N'اینترنت TD-LTE، نسل جدید اینترنت ثابت بی سیم', 6, N'اینترنت TD-LTE جدیدترین و آخرین نسل از اینترنت ثابت بی سیم است که به نسبت سایر فناوری های اینترنت ثابت مانند ADSL و WIMAX دارای سرعت بالاتری می باشد. این فناوری به جز سرعت بالا، مزیت های فراوان دیگری نیز برای کاربران خود به همراه می آورد و باعث می شود که تجربه ی شیرین تری از کار با اینترنت داشته باشند.', N'1e1956dd-616e-4651-8e28-6692abd74efb.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">اینترنت TD-LTE جدیدترین و آخرین نسل از اینترنت ثابت بی سیم است که به نسبت سایر فناوری های اینترنت ثابت مانند ADSL و WIMAX دارای سرعت بالاتری می باشد. این فناوری به جز سرعت بالا، مزیت های فراوان دیگری نیز برای کاربران خود به همراه می آورد و باعث می شود که تجربه ی شیرین تری از کار با اینترنت داشته باشند.</p><p class="ql-align-right">برای مثال از دیگر مزیت های اینترنت TD-LTE، می توان به قابلیت جا به جایی آسان، عدم نیاز به خط تلفن، نداشتن مشکل نویز خط تلفن، نبود مشکلات محدودیت ظرفیت مرکز مخابراتی و نصب و راه اندازی در کم تر از 48 ساعت اشاره کرد.</p><p class="ql-align-right">حال این سوال مطرح می شود که ما چگونه می توانیم از فناوری TD-LTE استفاده کنیم؟</p><p class="ql-align-right">ابتدا باید یکی از شرکت های ارائه دهنده این سرویس را انتخاب کنید، بعد از آن به یک سیم کارت و یک مودم برای راه اندازی اینترنت TD-LTE خود نیاز دارید. البته باید بدانید که سیم کارت های مناسب برای فناوری TD-LTE با سیم کارت های معمولی متفاوت بوده و فقط می توانند داده ها را ارسال و دریافت نمایند.</p><p class="ql-align-right">مودم های این سرویس نیز، منحصر به خود این فناوری می باشند و نمی توان برای راه اندازی آن ها از مودم های WIMAX و یا ADSL استفاده نمود. بعد از آن که مودم و سیم کارت خود را دریافت کردید، حال می توانید به راحتی با کمک کابل و یا از طریق وای فای به مودم خود متصل شوید و از اینترنت پر سرعت خود نهایت لذت را ببرید.</p><p class="ql-align-right">TD-LTE نیز مانند سایر فناوری های اینترنت، بسته های اینترنتی دارند و هر بسته متناسب با نیاز شما حجم و سرعت متفاوتی دارد.</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (5, N' نیکا تک راهکاری سریع و مدرن برای بهرمندی از خدمات تلفن گویا', 6, N'ما با فراهم سازی زیرساخت قدرتمند مرکز تلفن اَبری بر پایه وُیپ(VOIP) و ارائه خطوط اینترنتی اختصاصی، با بهرمندی از چندین سال تجربه در این زمینه پا به عرصه نهادیم تا خدماتی در خور با هزینه بسیار پایین به کاربران و مشتریان گرامی ارائه نماییم. ', N'732a5569-1eec-4aa7-8d18-9c0b5c335931.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">ما با فراهم سازی زیرساخت قدرتمند مرکز تلفن اَبری بر پایه وُیپ(VOIP) و ارائه خطوط اینترنتی اختصاصی، با بهرمندی از چندین سال تجربه در این زمینه پا به عرصه نهادیم تا خدماتی در خور با هزینه بسیار پایین به کاربران و مشتریان گرامی ارائه نماییم.</p><p class="ql-align-right">نیکا تک ، راهکار آنلاین و سریع برای رسیدن به یک مرکز تلفن پایدار، ساده و کم هزینه می باشد.</p><p class="ql-align-right">ما فعالیت خود را با راه اندازی Call Center آغاز نمودیم ولی با توجه به پیشرفت تکنولوژی و چالش های پیش رو برای شرکت ها، استارت آپ ها و تمامی بنگاه های اقتصادی، اقدام به راه اندازی مرکز تلفن با تکنولوژی اَبری نمودیم، که بهره وری بسیار بالاتر و هزینه بسیار پایین تری نسبت به مرکز تماس های قدیمی دارد.</p><p class="ql-align-right">نیکا تک مفتخر است به اولین ارائه دهنده خدمات وُیپ(VOIP) بر پایه پردازش اَبری(Cloud Hosted PBX) در ایران عزیزمان با پایداری بالا و هزینه بسیار پایین.</p><p class="ql-align-right">در تلاشیم تا با همت مضاعف، روز به روز به امکانات و کیفیت خدمات خود بیافزاییم تا بتوانیم به طیف گسترده تری از کاربران گرامی خدمت رسانی نماییم.</p><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (6, N'مزایای سیم‌کارت‌ مختص مودم‌های ثابت (TD-LTE):', 6, N'پوشش گسترده در مراکز استان‌ها ( مشاهده مناطق پوشش اینترنت ثابت )

سرعت بالاتر در مقایسه با سایر سرویس‌ها', N'db348bf2-52bd-4785-9207-7f486b194996.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">پوشش گسترده در مراکز استان‌ها ( مشاهده مناطق پوشش اینترنت ثابت )</p><p class="ql-align-right">سرعت بالاتر در مقایسه با سایر سرویس‌ها</p><p class="ql-align-right">امکان استفاده از بسته‌هایی با حجم بالا و تنوع زیاد</p><p class="ql-align-right">امکان استفاده از سیم‌کارت‌ها در کلیه مودم‌های TD-LTE (با قابلیت پشتیبانی از باند فرکانسی ۳۵۰۰ مگاهرتز)</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (7, N'نیکا ‌پیامک یک سامانه اینترنتی برای ارسال پیامک', 6, N'نیکا ‌پیامک یک سامانه اینترنتی برای ارسال، دریافت و مدیریت پیامک‌ها به صورت انبوه است. ما به دنبال آن بودیم که یک سامانه کامل اما در عین حال ساده را در اختیار کسب و کارها قرار دهیم. سامانه‌ای که از', N'61351a96-5de6-4559-8a6c-2da55cbc96ab.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">نیکا ‌پیامک یک سامانه اینترنتی برای ارسال، دریافت و مدیریت پیامک‌ها به صورت انبوه است. ما به دنبال آن بودیم که یک سامانه کامل اما در عین حال ساده را در اختیار کسب و کارها قرار دهیم. سامانه‌ای که از پشتیبانی با کیفیت، زیرساخت قدرتمند و آموزش اصولی برخوردار باشد.</p><p class="ql-align-right">ادرس سایت : <a href="http://nikasms.ir" target="_blank"> http://nikasms.ir</a></p><h6 class="ql-align-right"><br></h6><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (8, N' سرویس تلفن های ثابت اینترنتی گویا نیکا تک ', 6, N'امروزه دسترسی به اینترنت سریع و قابل اعتماد یکی از ملزومات اساسی هر مجموعه کسب وکار است.
سرویس پهنای باند پل ارتباطی شما با اینترنت در سطح تجاری است و به شما کمک می کند تا از امکانات بهتر و مطمئن تری جهت ارسال و دریافت اطلاعات، نسبت به...', N'3e69dfee-4003-429f-ba4e-196e3954df83.jpg', NULL, N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (9, N'مزایای سیم‌کارت‌ مختص مودم‌های ثابت (TD-LTE):', 6, N'سرویس IP-VPN این امکان را به سازمان‌ها می‌دهد که سایت‌ها و مراکز مختلف زیرمجموعه‌ی خود را با نیازهای متفاوت، وابسته به موقعیت محلی هر مرکز در سراسر کشور به یکدیگر متصل نماید. ', N'e7ad542f-09e4-43de-a3a8-89e4c5002209.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">سرویس IP-VPN این امکان را به سازمان‌ها می‌دهد که سایت‌ها و مراکز مختلف زیرمجموعه‌ی خود را با نیازهای متفاوت، وابسته به موقعیت محلی هر مرکز در سراسر کشور به یکدیگر متصل نماید.</p><p class="ql-align-right">این امر می‌تواند برقراری ارتباطات مشترک را آسان نموده و همه‌ی سرویس‌های موردنیاز را در داخل یک شبکه اختصاصی مجتمع، تأمین نماید. همچنین این سرویس دسترسی کاربر را به نرم‌افزارها و کاربردهای «ابری» در سراسر کشور یا در سطوح شهری و استانی برقرار می‌نماید.</p><p class="ql-align-right">وجود شبکه گسترده ثابت و موبایل در کل کشور ایجاد شبکه یکپارچه بین نقاط را برای سازمان‌ها و شرکت‌ها در اکثر شهرهای کشور را ممکن می‌کند.</p><p class="ql-align-right">علاوه بر آنکه بسته به نیاز مشتریان امکان ارائه سرویس‌های دارای افزونگی (Redundancy) فراهم می‌باشد.</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (10, N' خدماتی است با امکانات سخت‌افزاری اختصاصی و قابل گسترش ', 6, N'خدماتی است با امکانات سخت‌افزاری اختصاصی و قابل گسترش بر روی مجموعه‌ای از سرورهای پرتوان که امکان گسترش منابع سخت‌افزاری را برای مشترک فراهم نموده و همچنین با بهره‌گیری از کنترل پنل امکان مدیریت سرور را از راه دور تامین می‌نماید. ', N'72bd011b-b4b2-4061-87b8-bc3a6d2b57b2.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">دریافت سرور اختصاصی</p><p class="ql-align-right"><br></p><p class="ql-align-right">خدماتی است با امکانات سخت‌افزاری اختصاصی و قابل گسترش بر روی مجموعه‌ای از سرورهای پرتوان که امکان گسترش منابع سخت‌افزاری را برای مشترک فراهم نموده و همچنین با بهره‌گیری از کنترل پنل امکان مدیریت سرور را از راه دور تامین می‌نماید.</p><p class="ql-align-right">سرور خصوصی اختصاصی (Virtual Private Server) بیشتر امکانات یک سرور واقعی را داراست اما حدود سخت افزاری آن بوسیله نرم افزارهای مخصوص به صورت اختصاصی تعیین شده است.</p><p class="ql-align-right">سرور خصوصی اختصاصی مناسب برای کسانی می‌باشد که به یک سرور اختصاصی (Dedicated Server) جهت وب سایت یا وب سایت های خود نیازمند می‌باشند، اما توان یا توجیه اقتصادی اجاره یک سرور اختصاصی کامل را ندارند.</p><p class="ql-align-right">در اين سرويس هر يك از سرورهای اختصاصی كاملا مانند يك سرور فيزيكی شبكه مشاهده مي شوند.</p><p class="ql-align-right">همچنين يک سرور اختصاصی نسبت به يک سرور اختصاصی معادل خود در منابع سخت افزاري به علت استفاده از سخت افزار بهتر در سرور مادر و دسترسی به منابع اضافی در سخت افزار اشتراکی، داراي کارايی بهتر و بالاتری می باشد.</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (11, N' اینترنت پرسرعت ADSL', 6, N'حجم سرویس های 3-6- ۱۲ ماه به صورت ضریبی از حجم یک ماهه طبق جداول فوق که به صورت یک جا در سرویس مشترکین اعمال خواهد شد. ', N'dff7f35c-a0fa-46e0-ba02-b5da2556fe6b.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">اینترنت پرسرعت ADSL</p><p class="ql-align-right">حجم سرویس های 3-6- ۱۲ ماه به صورت ضریبی از حجم یک ماهه طبق جداول فوق که به صورت یک جا در سرویس مشترکین اعمال خواهد شد.</p><p class="ql-align-right">خرید سرویس های شش و دوازده ماهه (بجز سرویس های برنزی کم حجم)، به ترتیب شامل ۵ و ۱۰ درصد تخفیف خواهد بود. * به آستانه مصرف هر یک ازسرویس ها ۵ درصد ترافیک بیش تر برای ایجاد حاشیه اطمینان محاسبات مصرف کاربران افزوده شده است.</p><p class="ql-align-right">آستانه مصرف منصفانه که به اختصار FUP نامیده می شود عبارت است از حداکثر میزان ترافیکی که مشترک می تواند در یک دوره و با همان سرعتی که سرویس را خریداری کرده، استفاده کند.</p><p class="ql-align-right">منظور از ترافیک داخلی، هر ترافیک با میزبانی داخلی است یعنی سایت ها و اپلیکیشن هایی که سرور آن در داخل کشور می باشد و نام آنها در این لیست درج شده است.</p><p class="ql-align-right">ترافیک پیام‌رسان ‌های داخلی مورد تایید سازمان تنظیم مقررات و ارتباطات رادیویی، طبق مصوبه ۲۶۵ بصورت یک سوم بها محاسبه می‌شود.</p><p class="ql-align-right">منظور از ترافیک بین الملل، هر ترافیک با میزبانی خارجی است یعنی سایت ها و اپلیکیشن هایی که سرور آن در خارج از کشور می باشد مانند اینستاگرام، تلگرام، گوگل و ....</p><p class="ql-align-right">مصرف هر گیگ از ترافیک بین الملل ۲ برابر مصرف هر گیگ از ترافیک داخلی محاسبه می شود.</p><p class="ql-align-right">در تمامی سرویس ها، FUP یکجا به مشترک داده می شود و مدیریت مصرف بنا بر میل مشترک در یک دوره می باشد.</p><p class="ql-align-right">سرعت سرویس ها برای ۹۵ درصد مواقع تضمین می شود و ممکن است در ۵ درصد مواقع کاهش یابد.</p><p class="ql-align-right">مبلغ مالیات ارزش افزوده به سرویس ها اضافه خواهد شد.</p><p class="ql-align-right">هزینه‌ی راه‌اندازی و نصب این سرویس‌ها ۱۵,۰۰۰ تومان است.</p><p class="ql-align-right">هزینه دایری و تخلیه خطوط مشترکین ۱۲,۰۰۰ تومان است که در هنگام ثبت نام دریافت خواهد شد.</p><p class="ql-align-right">هزینه ی ایاب و ذهاب جهت نصب و راه اندازی و رفع خرابی ۲۵.۰۰۰ تومان می باشد.</p><p class="ql-align-right">برای کسب اطلاعات بیشتر مصوبه ۲۶۶ سازمان تنظیم مقررات را مطالعه فرمائید.</p><p class="ql-align-right">جزئیات پارامترهای موافقت نامه سطح خدمات آسیاتک، مطابق ضوابط مصوبه ۱۷۷ سازمان تنظیم مقررات به پیوست قرارداد مشترکین میباشد.</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (12, N'خدمات دیتا سنتر ', 6, N'انتقال سایتهای اینترنتی ایرانی به داخل کشور از سال 1387 به صورت جدی در دستور کار مدیران سازمانها و شرکتهای مهم از جمله وزارتخانه ها، سازمانهای دولتی، شرکتها و نیز مراکز حساس سیاسی، اقتصادی و ', N'b2af611b-b068-4722-b39b-b9b8feaa59ac.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">خدمات دیتا سنتر</p><p class="ql-align-right">انتقال سایتهای اینترنتی ایرانی به داخل کشور از سال 1387 به صورت جدی در دستور کار مدیران سازمانها و شرکتهای مهم از جمله وزارتخانه ها، سازمانهای دولتی، شرکتها و نیز مراکز حساس سیاسی، اقتصادی و فرهنگی قرار گرفته است. برای کمک به تحقق این امر ملی، شرکت لایزر به عنوان شرکتی پیشتاز در عرصه IT کشور و دارنده رتبه یک شورایعالی انفورماتیک و گواهینامه های ISO 9001 و(ISO 27001(ISMS، با هدف ارتقاء امنیت (IT Security) و پایداری خدمات (Business Continuity) در حوزه فنآوری اطلاعات اقدام به راه اندازی دیتاسنتر با استاندارد جهانی نموده است .</p><p class="ql-align-right">شرکت لایزر با استفاده از ظرفیت ایجاد شده در حال حاضر آمادگی ارائه کلیه خدمات مربوط به دیتاسنتر از جمله ارایه سرور اختصاصی (Dedicated Server) ،میزبانی سرور (Co-Location)، سرور اختصاصي مجازي (Virtual Private Server) و ميزباني صفحات وب (Web-Hosting) به شرکتها و سازمانهای علاقمند را دارد. از ویژگی های دیتاسنتر لایزر می توان به ارتباط از طریق فیبرنوری با شرکت ارتباطات زیرساخت ایران، شرکت مخابرات ایران و شبکه دیتا سنتر اسیاتک اشاره کرد، که این امر پایداری سرویسهای این شرکت را به میزان قابل توجهی افزایش داده است. در ذیل به اصلی ترین ویژگی های دیتاسنتر لایزر اشاره می شود:</p><p class="ql-align-right">بر اساس آخرین استانداردهای جهانی (از جمله CISCO SAFE).</p><p class="ql-align-right">امنیت اطلاعاتی (IT Security).</p><p class="ql-align-right">پایداری خدمات (Business Continuity).</p><p class="ql-align-right">سیستم مونیتورینگ پیشرفته (Network Operation Center) NOC.</p><p class="ql-align-right">سیستم پشتیبانی پس از فروش بصورت 24 ساعته(24/7 Tech Support).</p><p class="ql-align-right">استفاده از آخرین تکنولوژی در طراحی دیتاسنتر.</p><p class="ql-align-right">موقعیت جغرافیایی مناسب.</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (13, N'اینترنت VDSL ', 6, N' یکی از مهم‌ترین خدمات قابل ارایه در برج‌ها و مجتمع‌های مسکونی خدمات (VDSL (Very high bit-rate DSL است. ', N'95576e77-cefe-4151-a595-353a5fe8651d.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">اینترنت VDSL</p><p class="ql-align-right">یکی از مهم‌ترین خدمات قابل ارایه در برج‌ها و مجتمع‌های مسکونی خدمات (VDSL (Very high bit-rate DSL است.</p><p class="ql-align-right">شرکت برای نخستین بار در کشور این خدمات را که از آن به عنوان انقلابی در ارایه خدمات اینترنت یاد می‌شود، با استفاده از پیشرفته‌ترین تجهیزات و فناوری‌ها در اختیار ساکنان برج‌ها و مجتمع‌ها قرار می‌دهد. مهم‌ترین ویژگی این خدمات، پهنای باند بسیار بیش‌تر نسبت به خدمات +ADSL2 است. در این روش مشتریان می‌توانند از سرویس‌ با سرعت‌ بالا همچون ۱۰۰Mbps بهره‌مند شوند. برای آشنایی با این فناوری مطالعه نوشتار زیر را به شما توصیه می‌کنیم:</p><p class="ql-align-right">خدمات VDSL) Very high bit-rate Digital Subscriber Line) روشی نوین در ارایه خدمات اینترنت پرسرعت است که سرعت ارایه خدمات بر بستر DSL را تا چندین برابر افزایش می‌دهد. در این روش، سرعت دانلود و آپلود اطلاعات تا بیش از ۱۰ برابر روش ADSL قابل افزایش است. با توجه به نزدیک بودن فاصله میان مرکز ارایه کننده و مشترک گیرنده این خدمات در برج‌ها و مجتمع‌ها، امکان ارایه این سرویس با کیفیتی ثابت برای مشتریان فراهم می‌شود.</p><p class="ql-align-right">این خدمات در هر مجتمع ابتدا از طریق یک DSLAM دریافت و سپس از طریق خطوط تلفن میان کاربران تقسیم می‌شود.</p><p class="ql-align-right">پس از آن هر مشترک با نصب یک مودم VDSL در محل خود می‌تواند از پهنای باند اختصاص داده شده بهره‌مند شود. پهنای باند بسیار بالا، نوسان اندک و کیفیت ثابت، از مهم‌ترین ویژگی‌های این روش به شمار می‌آید.</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (14, N'تست سرعت اینترنت ', 6, N' با کلیک بر روی دکمه زیر تست سرعت اینترنت خود را انجام دهید ', N'1d8864dc-0adc-44fb-acd9-fb5fe84f2e7f.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right"><strong>تست سرعت اینترنت </strong></p><p class="ql-align-right">با کلیک بر روی دکمه زیر تست سرعت اینترنت خود را انجام دتستید</p><p class="ql-align-right"><a href="https://www.speedtest.net/run" target="_blank"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAARsAAABaCAYAAACIXvJcAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAxBpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6NUYyMEM1Rjc0QUEzMTFFQkE3MTZGNzExNUI5N0ZCMTYiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NUYyMEM1RjY0QUEzMTFFQkE3MTZGNzExNUI5N0ZCMTYiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNiBXaW5kb3dzIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9IkUwNTY1RkM1MTM5RkQ3RkVEMzMyRkY2MUJDOTM0RjVDIiBzdFJlZjpkb2N1bWVudElEPSJFMDU2NUZDNTEzOUZEN0ZFRDMzMkZGNjFCQzkzNEY1QyIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PmD4JHgAADZvSURBVHja7H0JnB1Fnf+vuvsdc08ymdx3SCAQCCAB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"></a></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-editing ql-flip ql-hidden" style="left: 1135.47px; top: -5.23334px;" data-mode="link"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL" placeholder="https://quilljs.com"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (15, N'ردیاب نیکا ', 6, N' سرویس ردیابی ماهواره ای راه حل نوینی از دنیای تکنولوژی به مدیریان مشاغل مختلف مرتبط با هزینه حمل و نقل می باشد و امکانات آن چنان وسیع است که پهنه کاربرد آن بی انتهاست. ', N'e1107994-ade2-4d82-ab4e-9b5aebf31ed1.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">ردیاب نیکا</p><p class="ql-align-right">سامانه ردیابی چه کاربردهایی دارد؟</p><p class="ql-align-right">سرویس ردیابی ماهواره ای راه حل نوینی از دنیای تکنولوژی به مدیریان مشاغل مختلف مرتبط با هزینه حمل و نقل می باشد و امکانات آن چنان وسیع است که پهنه کاربرد آن بی انتهاست.</p><p class="ql-align-right">برخی از زمینه های شغلی که این سامانه در نحوه مدیریت و کاهش هزینه‌های آنها نقش غیر قابل تصوری ایفا می نماید، عبارتند از:</p><p class="ql-align-right"> شرکت های پیمانکار خدمات و نظافت شهری</p><p class="ql-align-right"> شرکت های ترانزیت انواع کالا</p><p class="ql-align-right"> توزیع کنندگان و بنکداران مواد غذایی</p><p class="ql-align-right"> واحد های حوادث آب، برق، گاز و...</p><p class="ql-align-right"> مراکز خودروهای کرایه ای</p><p class="ql-align-right"> پیمانکاران صنعت حمل و نقل</p><p class="ql-align-right"> شرکت های تعاونی حمل و نقل مسافر</p><p class="ql-align-right"> مراکز تاکسی سرویس، وانت تلفنی و پیک موتوری</p><p class="ql-align-right"> آتش نشانی ها و مراکز آمبولانس</p><p class="ql-align-right"> مراکز دارای خودروهای ماموریتی</p><p class="ql-align-right"> شرکت های حمل فراورده های نفتی و پتروشیمی</p><p class="ql-align-right"> مراکز توزیع و خرید عمده لوازم یدکی</p><p class="ql-align-right"> کارخانجات دارای سرویس حمل و نقل مواد اولیه و محصولات تولیدی</p><p class="ql-align-right"> سازمان ها و مراکز دارای سرویس حمل و نقل پرسنل</p><p class="ql-align-right"> سازمان ها و شرکت های دارای پرسنل سیار(ماور، بازاریاب و...)</p><p class="ql-align-right"> همچنین خودروهای شخصی به عنوان وسیله ای جهت امنیت می توانند از این وسیله استفاده كنند</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (16, N'مشاوره رتبه بندی اعتبار ایران', 15, N'مشاوره رتبه بندی اعتبار ایران', N'b5be58ca-2a13-43fa-83be-377fad4faa78.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (17, N'بیمه ما', 15, N'بیمه ما', N'6839effa-a6a7-44dc-9078-f39684c83ab5.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (18, N'پست جمهوری اسلامی ایران', 15, N'پست جمهوری اسلامی ایران', N'44e91ebf-e4f4-4c3f-82b0-965cc2826b30.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (19, N'سازمان فناوری و اطلاعات ایران', 15, N'سازمان فناوری و اطلاعات ایران', N'f27fbe05-9d01-4691-8ef3-fbd60fd46dd4.jpg', NULL, N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (20, N'سامانه جامع سجام', 15, N'سامانه جامع سجام', N'42b6809e-38de-4050-9a55-0bc3ed5a2375.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (21, N'شرکت فرابوم', 15, N'شرکت فرابوم', N'ca4c303f-75b6-433f-862c-8ee08e927843.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (22, N'شرکت فرابوم', 15, N'شرکت فرابوم', N'eb2abf47-fee5-4047-81e7-fc962c2df0ea.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (23, N'امداد خودرو ایران', 15, N'امداد خودرو ایران', N'f1a9383a-65ab-4948-b2b0-a2c1e09d6c4b.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (24, N'شرکت لایزر', 15, N'شرکت لایزر', N'26bd1696-c7bb-4c2d-a975-e23abb5afabb.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (25, N'بیمه سرمد', 15, N'بیمه سرمد', N'5c07f39c-b5f5-409e-81fb-d3e61ea6a1cd.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'بیمه سرمد', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (26, N'پرداخت کارت شاپرک', 15, N'پرداخت کارت شاپرک', N'030e8c02-0e66-4a72-ac26-8eda60739e5e.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (27, N'راشید', 15, N'راشید', N'fd028052-5ee6-4f5b-a971-189e160bbcd4.jpg', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (28, N'سوالات متداول', 17, N'در حال بروز رسانی این بخش هستیم ', N'eb32e683-6e42-4579-b64d-7e4b6372f8c2.png', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right"><strong style="background-color: rgb(230, 0, 0); color: rgb(255, 255, 0);">در حال بروز رسانی این بخش هستیم </strong></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (29, N'درباره ما', 19, N'ضمن عرض سلام و وقت بخیر خدمت تمام دوستان عزیز نیکاتک ورود شما به جامعه نیکاتک را خیر مقدم عرض می نماید', N'b5c1f061-4b79-40bf-95fd-7c97e735ceac.png', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><h5 class="ql-align-center">خوش آمدگویی نیکاتک</h5><p class="ql-align-center">ضمن عرض سلام و وقت بخیر خدمت تمام دوستان عزیز نیکاتک ورود شما به جامعه نیکاتک را خیر مقدم عرض می نماید</p><p class="ql-align-center"><span style="background-color: rgb(0, 0, 0);"><img src="https://nikatak.ir/site/Images/logo2.png"></span></p><h4 class="ql-align-center">سلام دوست عزیز به جمع بزرگ نیکاتک خوش آمدید</h4><h4 class="ql-align-center">قرارداد به پیوست خدمت شما ارسال شد لطفا قرار داد را کامل نموده و آن را برای ما پست کنید</h4><h4 class="ql-align-center">لطفا برای دانلود قرار داد روی لینک زیر کلیک کنید</h4><h4 class="ql-align-center"><a href="https://drive.google.com/file/d/1HoK73qWxRieGkS1p7Rjg57OhN5Y1rk9L/view?usp=sharing" target="_blank">لینک دانلود</a></h4><h4 class="ql-align-center">شماره تماس همراه : : 09220648677</h4><h4 class="ql-align-center">شماره تماس ثابت اول : : 02191316789</h4><h4 class="ql-align-center"><a href="http://nikatak.ir/" target="_blank">وب سایت نیکاتک</a></h4><p><br></p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'نیکاتک', N'fa')
INSERT [dbo].[Tbl_Blog] ([Id], [TitleBLo], [IdCtegoryBlo], [SummaryBlo], [ImageMainBlo], [FullTextBlo], [KeywordsBlo], [Language]) VALUES (30, N'مزایده و مناقصه', 20, N'تست', N'121aea35-e18a-4a4f-9d98-4a19d593a594.jpg', NULL, N'نیکاتک', N'fa')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
SET IDENTITY_INSERT [dbo].[tbl_category] ON 

INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (1, N'معرفی', -2, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (2, N'معرفی مدیران', 1, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (3, N'معرفی نمایندگان', 1, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (5, N'خدمات', -2, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (6, N'خدمات ما', 5, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (11, N'اطلاعیه ها ', -2, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (12, N'اطلاعیه های جدید ', 11, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (14, N'سازمان ها', -2, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (15, N'سازمانها و مراکز طرف قرارداد ', 14, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (16, N'سوالات', -2, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (17, N'سوالات متداول', 16, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (18, N'درباره', -2, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (19, N'درباره ما', 18, N'fa')
INSERT [dbo].[tbl_category] ([Id], [NameCat], [FatherIdCat], [Language]) VALUES (20, N'مزایده و مناقصه', -2, N'fa')
SET IDENTITY_INSERT [dbo].[tbl_category] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Contacts] ON 

INSERT [dbo].[Tbl_Contacts] ([Id], [Email], [Phone], [Title], [Text]) VALUES (1, N'gerge@gmail.com', N'09336192158', N'test', N'huy7hhhuh')
INSERT [dbo].[Tbl_Contacts] ([Id], [Email], [Phone], [Title], [Text]) VALUES (2, N'gerge@gmail.com', N'09336192158', N'test', N'4jhuh')
SET IDENTITY_INSERT [dbo].[Tbl_Contacts] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Experts] ON 

INSERT [dbo].[Tbl_Experts] ([Id], [NameEx], [ImageEx], [TelEx], [OfficeTelEx], [LocationEx], [AboutEx], [Language], [address]) VALUES (1, N'حسن محمدی', N'f8fa79fb-3ba6-4e56-9493-b4101db35dcf.jpg', N'09647995321', N'04432598765', N'37.71721439387317,45.010755425037075', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">تستتستتستتستتستتستتستتستتستتستتستتست</p><p class="ql-align-right">تست</p><p class="ql-align-right">تستتستتست</p><p class="ql-align-right">تستتست</p><p class="ql-align-right">تستتستتستتست</p><p class="ql-align-right">تستتستتست</p><p class="ql-align-right">تستتست</p><p class="ql-align-right">تستتست</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'fa', N'تهران')
SET IDENTITY_INSERT [dbo].[Tbl_Experts] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Gallery] ON 

INSERT [dbo].[Tbl_Gallery] ([Id], [TitleGal], [pathImage], [Language]) VALUES (1, N'nikatek', N'9535fe97-e88c-4b8d-b437-f6c37efa6e65.jpg', N'fa')
SET IDENTITY_INSERT [dbo].[Tbl_Gallery] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Hesabs] ON 

INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (9, N'nikatak1234', N'انصارkjh', N'1587', N'IR12345678912233333', 123562)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (10, N'nikatak1234', N'159', N'1587', N'IR12345678912233333/', 123562)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (11, N'nikatak1234', N'انصارkjh', N'1587', N'IR310660000000203305445009', 12356)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (12, N'nikatak1234', N'انصارkjh', N'1587', N'IR310660000000203305445009', 12356)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (13, N'nikatak1234', N'jh', N'45', N'565', 0)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (14, N'nikatak1234', N'jh', N'45', N'565', 0)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (15, N'nikatak1234', N'jh', N'45', N'565', 0)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (16, N'nikatak1234', N'dsacs', N'414', N'45285253', 5636)
INSERT [dbo].[Tbl_Hesabs] ([Id], [UserName], [Bank], [Hesab], [Shaba], [Shobe]) VALUES (17, N'nikatak1234', N'انصارkjh', N'123', N'IR310660000000203305445009', 12356)
SET IDENTITY_INSERT [dbo].[Tbl_Hesabs] OFF
SET IDENTITY_INSERT [dbo].[Tbl_infoPersenels] ON 

INSERT [dbo].[Tbl_infoPersenels] ([Id], [UserNameId], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Yers], [Mont], [Day], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity]) VALUES (3, N'karim', N'کریم', N'نعمتی', N'رحمان', N'2840600359', N'karim', N'nemati', N'rahman', N'سلماس', N'464654654', N'مسیحی', N'karimnemati@gmail.com', N'1385', N'اردیبهشت', N'16', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'09375884461', N'0443658745', NULL, NULL, N'  ,ارومیه ,اشنویه ,بوکان ,پیرانشهر ,تکاب ,چالدران ,خوی ,سردشت ,سلماس ,شاهین‌دژ ,ماکو ,مهاباد ,میاندوآب ,نقده', NULL, N'44444', N'سلماس سلماس', N'سلماس خ امام55555555555', N'kl;', N'kl;;k;', N'jlkj', N'jjlkj', N'5445jlkj', N'jkljl', N'jkljkl', N'lkjlk', N'kjlj', N'lkjl', N'0ce5d494-b8e9-4037-a920-4515172e7220.jpg', N'0c9fc648-f00d-4f49-b77e-78bd01eb993d.png', N'4d89ec20-bac1-4d05-bb98-5d01ce4722b2.png', N'd76684b4-5865-4bb4-b96d-e27245f53a18.png', N'c597dcb5-589f-44de-ac74-e9d8cac60f49.png', N'f146c89e-7ab1-4a1c-ae1b-a868edfc1856.png', N'718d8981-d85d-47ec-ba39-0e1852e17136.jpg', N'27fef6a4-3494-4559-bbf7-ab7a5f6a9641.jpg', N'8ad4a8ee-15c2-415c-aab7-fb0c7c2084f3.jpg', N'5b8feac0-a664-4868-853f-e19cf1fd5929.jpg', N'همپادکو', N'99/01/02', N'99/02/03', N'99/05/06')
INSERT [dbo].[Tbl_infoPersenels] ([Id], [UserNameId], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Yers], [Mont], [Day], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity]) VALUES (4, N'karimali', NULL, NULL, NULL, N'284045632585', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'  ,ارومیه ,اشنویه ,بوکان ,پیرانشهر ,تکاب ,چالدران ,خوی ,سردشت ,سلماس ,شاهین‌دژ ,ماکو ,مهاباد ,میاندوآب ,نقده', N'سلماس ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_infoPersenels] ([Id], [UserNameId], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Yers], [Mont], [Day], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity]) VALUES (5, N'rahim', NULL, NULL, NULL, N'2851868012', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'  ,ارومیه ,اشنویه ,بوکان ,پیرانشهر ,تکاب ,چالدران ,خوی ,سردشت ,سلماس ,شاهین‌دژ ,ماکو ,مهاباد ,میاندوآب ,نقده', N'شاهین‌دژ ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_infoPersenels] ([Id], [UserNameId], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Yers], [Mont], [Day], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity]) VALUES (6, N'admin', NULL, NULL, NULL, N'2851868012', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'  ,اسلام‌شهر ,پاکدشت ,تهران ,دماوند ,رباط‌کریم ,ری ,ساوجبلاغ ,شمیرانات ,شهریار ,فیروزکوه ,کرج ,نظرآباد ,ورامین', N'فیروزکوه ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_infoPersenels] ([Id], [UserNameId], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Yers], [Mont], [Day], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity]) VALUES (7, N'44444444444', NULL, NULL, NULL, N'44444444444', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'  ,آبادان ,امیدیه ,اندیمشک ,اهواز ,ایذه ,باغ‌ملک ,بندر ماهشهر ,بهبهان ,خرمشهر ,دزفول ,دشت آزادگان ,رامشیر ,رامهرمز ,شادگان ,شوش ,شوشتر ,گتوند ,لالی ,مسجد سلیمان,هندیجان ', N'شوش ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_infoPersenels] ([Id], [UserNameId], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Yers], [Mont], [Day], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity]) VALUES (8, N'hampadصص', NULL, NULL, NULL, N'28518680100', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'  ,اردبیل ,بیله‌سوار ,پارس‌آباد ,خلخال ,کوثر ,گِرمی ,مِشگین‌شهر ,نَمین ,نیر', N'خلخال ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tbl_infoPersenels] ([Id], [UserNameId], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Yers], [Mont], [Day], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity]) VALUES (9, N'MAJID', NULL, NULL, NULL, N'1720188403', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'  ,ابهر ,ایجرود ,خدابنده ,خرمدره ,زنجان ,طارم ,ماه‌نشان', N'ابهر ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tbl_infoPersenels] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Inforeps] ON 

INSERT [dbo].[Tbl_Inforeps] ([Id], [State], [City], [part], [cod], [Clerk], [Phone], [PhoneHome], [Address], [Postalcode], [Locationaddress], [Description], [photos], [Addressshow], [Clerkshow], [PhoneHomeshow], [Phoneshow], [Postalcodeshow], [codshow], [photosshow]) VALUES (12, N'آذربایجان غربی', N'  ارومیه ', N'شکریازی', N'77', N'الهیه', N'09214351340', N'04435256830', N'شمیران نو', N'5884362', N'35.85798446282902,51.37062477982141', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">مهندس نرمافزار </p></div><div class="ql-clipboard" contenteditable="true" tabindex="-1"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'156e1878-ba03-4833-afdd-9865b5934e37.jfif', 0, 1, 0, 1, 0, 1, 0)
INSERT [dbo].[Tbl_Inforeps] ([Id], [State], [City], [part], [cod], [Clerk], [Phone], [PhoneHome], [Address], [Postalcode], [Locationaddress], [Description], [photos], [Addressshow], [Clerkshow], [PhoneHomeshow], [Phoneshow], [Postalcodeshow], [codshow], [photosshow]) VALUES (13, N'آذربایجان غربی', N'سلماس ', N'مرکزی', N'53', N'پاشایی', N'09039074700', N'556677', N'سلماس', N'8765478756', N'38.20427428311822,44.764957609164426', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p>منم</p></div><div class="ql-clipboard" contenteditable="true" tabindex="-1"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'b1f98025-dd10-4d7e-9588-efd894fe0a6f.jpg', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Tbl_Inforeps] ([Id], [State], [City], [part], [cod], [Clerk], [Phone], [PhoneHome], [Address], [Postalcode], [Locationaddress], [Description], [photos], [Addressshow], [Clerkshow], [PhoneHomeshow], [Phoneshow], [Postalcodeshow], [codshow], [photosshow]) VALUES (14, N'کرمان', N'شهر بابک ', N'مرکزی', N'56', N'البی', N'09039074700', N'04435256830', N'شمیران نو', N'6578', N'38.487056845997884,44.954901578784295', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p>لبایالیابا</p></div><div class="ql-clipboard" contenteditable="true" tabindex="-1"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'a19edd1d-bfdd-49f0-8057-e8bd0649207f.jpg', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Tbl_Inforeps] ([Id], [State], [City], [part], [cod], [Clerk], [Phone], [PhoneHome], [Address], [Postalcode], [Locationaddress], [Description], [photos], [Addressshow], [Clerkshow], [PhoneHomeshow], [Phoneshow], [Postalcodeshow], [codshow], [photosshow]) VALUES (15, N'اردبیل', N'  اردبیل ', N'شکریازی', N'213صضثق', N'12ثص', N'0000', N'ضصیبث', N'صضثق', N'ثقشقس', N'38.551703483473176,44.95581736415063', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p>90op</p></div><div class="ql-clipboard" contenteditable="true" tabindex="-1"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'ceea134e-5682-4453-8a08-be1d238ad8c6.jpg', 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Tbl_Inforeps] ([Id], [State], [City], [part], [cod], [Clerk], [Phone], [PhoneHome], [Address], [Postalcode], [Locationaddress], [Description], [photos], [Addressshow], [Clerkshow], [PhoneHomeshow], [Phoneshow], [Postalcodeshow], [codshow], [photosshow]) VALUES (16, N'آذربایجان غربی', N'  ارومیه ', N'مرکزی', N'53', N'پاشایی', N'09039074700', N'044000000000', N'سلماس', N'8765478756', N'38.561013479606636,44.974859397355836', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p>azsdfghjk</p></div><div class="ql-clipboard" contenteditable="true" tabindex="-1"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'32498233-2cf4-404e-ba14-2a5095b814bb.jfif', 1, 1, 0, 1, 0, 1, 0)
INSERT [dbo].[Tbl_Inforeps] ([Id], [State], [City], [part], [cod], [Clerk], [Phone], [PhoneHome], [Address], [Postalcode], [Locationaddress], [Description], [photos], [Addressshow], [Clerkshow], [PhoneHomeshow], [Phoneshow], [Postalcodeshow], [codshow], [photosshow]) VALUES (17, N'آذربایجان شرقی', N'آذرشهر ', N'retgfh', N'456', N'الهیه', N'09039074700', N'fgh', N'sad', N'aqdsf', N'38.55271032972973,44.9705842905199', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p>wqefdg</p></div><div class="ql-clipboard" contenteditable="true" tabindex="-1"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'fecacc9d-2f1c-45ed-8236-16dda1862f85.jfif', 1, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Inforeps] OFF
SET IDENTITY_INSERT [dbo].[Tbl_infos] ON 

INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId], [code], [DateRegister]) VALUES (48, N'مجیدپاشایی', NULL, NULL, N'4744', NULL, NULL, NULL, NULL, NULL, NULL, N'tak1.ghasemi@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'dv s', NULL, CAST(N'2021-07-08 08:40:23.6622088' AS DateTime2))
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId], [code], [DateRegister]) VALUES (49, N'محسن پاشایی', NULL, NULL, N'1720188408', NULL, NULL, NULL, NULL, NULL, NULL, N'cpt.moh3en@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'روز', N'ماه', N'سال', N'nikatak1234', NULL, CAST(N'2021-07-08 08:40:23.6622088' AS DateTime2))
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId], [code], [DateRegister]) VALUES (50, N'مجید مجیدی', NULL, NULL, N'2851868011', NULL, NULL, NULL, NULL, NULL, NULL, N'tak1.ghasemi@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'روز', N'ماه', N'سال', N'bimekosar', NULL, CAST(N'2021-07-08 08:40:23.6622088' AS DateTime2))
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId], [code], [DateRegister]) VALUES (51, N'رحیم', N'قاسمی', NULL, N'2850711128', NULL, NULL, NULL, NULL, NULL, NULL, N'khjjxhdsb@lmcvlk.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'09149501938', N'04435698779', NULL, NULL, N'تهران', N'تهران ', N'000011', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1c38f536-f6bf-4c3b-95fc-aa4d9b1dad39.png', NULL, N'e09d4e0a-908c-4384-8128-9921e8d4dfaa.png', NULL, N'e498a330-1b5e-454a-8011-8795691b359f.png', NULL, N'80995505-c7c6-43ed-a9b0-2bc7a4800584.png', NULL, NULL, NULL, NULL, NULL, N'Request', NULL, NULL, NULL, NULL, N'NYETB', CAST(N'2021-07-08 08:40:23.6622088' AS DateTime2))
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId], [code], [DateRegister]) VALUES (53, N'سیب', N'یبیب', NULL, N'2790650306', NULL, NULL, NULL, NULL, NULL, NULL, N'jhjg@ghvhjg.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'09149501938', N'04435698779', NULL, NULL, N'کردستان', N'کامیاران ', N'000011', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'f9a2b007-5d0a-498b-883b-f1afc03119ef.png', NULL, N'fe33cbdd-c2e7-48a9-883d-7502f58bc7a3.png', NULL, N'27ecd8a1-c69f-46c1-8bc2-20430d25c46b.png', NULL, N'f779ef1f-951c-49f9-b1ed-6cf68000908a.png', NULL, NULL, NULL, NULL, NULL, N'Request', NULL, NULL, NULL, NULL, N'7TB65', CAST(N'2021-07-08 10:33:38.5725391' AS DateTime2))
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId], [code], [DateRegister]) VALUES (55, N'g', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Request', NULL, NULL, NULL, NULL, NULL, CAST(N'2021-03-21 08:40:23.6622088' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Tbl_infos] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Message] ON 

INSERT [dbo].[Tbl_Message] ([Id], [SenderMess], [ResiverMess], [DateMess], [SubjectMess], [TextMess], [StateMess], [Language], [pathfile]) VALUES (12, N'karim', N'admin', CAST(N'2021-02-08 00:00:00.0000000' AS DateTime2), N'cxbvcxzbvcb', N'bzvcbxcvbxzvcbxvc', 1, N'fa', N'850a552c-edea-4b89-86d0-6f8bfedd3026.png')
SET IDENTITY_INSERT [dbo].[Tbl_Message] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Mypays] ON 

INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (6, N'test', 200000, 1000, CAST(N'2021-04-24 12:30:45.7037064' AS DateTime2), 1, 1)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (7, N'Admin', 150, 0, CAST(N'2021-07-25 09:45:03.4684352' AS DateTime2), 1, 4179)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (8, N'Admin', 150, 0, CAST(N'2021-07-25 11:14:55.0901623' AS DateTime2), 1, 4180)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (9, N'Admin', 150, 0, CAST(N'2021-07-25 11:16:37.4532626' AS DateTime2), 1, 4181)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (10, N'Admin', 2400, 0, CAST(N'2021-07-25 11:18:54.5288011' AS DateTime2), 1, 4182)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (11, N'Admin', 2400, 0, CAST(N'2021-07-25 11:19:45.7218357' AS DateTime2), 1, 4183)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (12, N'Admin', 2400, 0, CAST(N'2021-07-25 11:20:02.9071635' AS DateTime2), 1, 4184)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (13, N'Admin', 150, 0, CAST(N'2021-07-25 11:22:38.2347455' AS DateTime2), 1, 4185)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (14, N'Admin', 150, 0, CAST(N'2021-07-25 11:23:06.9778903' AS DateTime2), 1, 4186)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (15, N'Admin', 150, 0, CAST(N'2021-07-25 11:23:30.3190043' AS DateTime2), 1, 4187)
INSERT [dbo].[Tbl_Mypays] ([Id], [UserName], [Pay], [Harvest], [DateTime], [status], [RequestId]) VALUES (16, N'Admin', 600, 0, CAST(N'2021-07-25 11:26:17.7933723' AS DateTime2), 1, 4188)
SET IDENTITY_INSERT [dbo].[Tbl_Mypays] OFF
SET IDENTITY_INSERT [dbo].[Tbl_PayBills] ON 

INSERT [dbo].[Tbl_PayBills] ([Id], [Type], [BillId], [PayId], [User], [Amount], [Date], [Time], [ShenaseMarja], [PeygiriId], [Name], [MyProperty]) VALUES (1, N'تلفن ثابت تلفناذربایجانغربى', N'773931444149', N'7900362', N'Admin', N'79000', N'1400/4/28', N'193826', N'221938254650', N'304650', NULL, 0)
SET IDENTITY_INSERT [dbo].[Tbl_PayBills] OFF
SET IDENTITY_INSERT [dbo].[Tbl_pays] ON 

INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1101, 100000, 0, 1, CAST(N'2021-04-24 12:30:45.7037064' AS DateTime2), 0, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1104, 0, 600, 1, CAST(N'2021-04-26 06:25:37.7504374' AS DateTime2), 1124, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1105, 180, 0, 1, CAST(N'2021-04-26 06:25:37.7684384' AS DateTime2), 1124, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1106, 0, 600, 1, CAST(N'2021-04-26 06:28:13.3975250' AS DateTime2), 1125, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1107, 180, 0, 1, CAST(N'2021-04-26 06:28:13.4275267' AS DateTime2), 1125, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1108, 0, 200, 1, CAST(N'2021-04-26 06:42:31.9626784' AS DateTime2), 1126, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1109, 60, 0, 1, CAST(N'2021-04-26 06:42:31.9996806' AS DateTime2), 1126, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1110, 0, 200, 1, CAST(N'2021-04-26 06:56:22.3443471' AS DateTime2), 1127, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1111, 60, 0, 1, CAST(N'2021-04-26 06:56:22.3493474' AS DateTime2), 1127, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1112, 0, 600, 1, CAST(N'2021-04-26 07:21:26.5346740' AS DateTime2), 1128, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1113, 180, 0, 1, CAST(N'2021-04-26 07:21:26.5596755' AS DateTime2), 1128, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1114, 0, 600, 1, CAST(N'2021-04-26 07:21:33.8100902' AS DateTime2), 1129, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1115, 180, 0, 1, CAST(N'2021-04-26 07:21:33.8130903' AS DateTime2), 1129, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1116, 0, 600, 1, CAST(N'2021-04-26 07:33:50.8536407' AS DateTime2), 1130, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1117, 180, 0, 1, CAST(N'2021-04-26 07:33:50.8706417' AS DateTime2), 1130, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1118, 0, 600, 1, CAST(N'2021-04-26 07:38:13.0076603' AS DateTime2), 1131, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1119, 180, 0, 1, CAST(N'2021-04-26 07:38:13.0656636' AS DateTime2), 1131, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1120, 0, 600, 1, CAST(N'2021-04-26 07:39:09.4398009' AS DateTime2), 1132, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1121, 180, 0, 1, CAST(N'2021-04-26 07:39:09.4608021' AS DateTime2), 1132, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1122, 0, 600, 1, CAST(N'2021-04-26 07:39:20.5954390' AS DateTime2), 1133, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1123, 180, 0, 1, CAST(N'2021-04-26 07:39:20.6044395' AS DateTime2), 1133, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1124, 0, 600, 1, CAST(N'2021-04-26 07:46:00.4929448' AS DateTime2), 1134, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1125, 180, 0, 1, CAST(N'2021-04-26 07:46:00.5319470' AS DateTime2), 1134, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1126, 0, 600, 1, CAST(N'2021-04-26 07:49:09.4551524' AS DateTime2), 1135, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1127, 180, 0, 1, CAST(N'2021-04-26 07:49:09.4721533' AS DateTime2), 1135, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1128, 0, 200, 1, CAST(N'2021-04-26 07:50:53.1898939' AS DateTime2), 1136, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1129, 60, 0, 1, CAST(N'2021-04-26 07:50:53.2528975' AS DateTime2), 1136, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1130, 0, 200, 1, CAST(N'2021-04-26 07:52:24.8638430' AS DateTime2), 1137, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1131, 60, 0, 1, CAST(N'2021-04-26 07:52:24.8958449' AS DateTime2), 1137, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1132, 0, 75, 1, CAST(N'2021-04-26 07:52:49.9582784' AS DateTime2), 1138, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1133, 22, 0, 1, CAST(N'2021-04-26 07:52:49.9872800' AS DateTime2), 1138, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1134, 0, 200, 1, CAST(N'2021-04-26 07:55:30.3142703' AS DateTime2), 1139, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1135, 60, 0, 1, CAST(N'2021-04-26 07:55:30.3482722' AS DateTime2), 1139, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1136, 0, 200, 1, CAST(N'2021-04-26 08:09:14.2864326' AS DateTime2), 1140, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1137, 60, 0, 1, CAST(N'2021-04-26 08:09:14.3134342' AS DateTime2), 1140, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1138, 0, 200, 1, CAST(N'2021-04-26 08:10:02.2547864' AS DateTime2), 1141, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1139, 60, 0, 1, CAST(N'2021-04-26 08:10:02.2797878' AS DateTime2), 1141, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1140, 0, 200, 1, CAST(N'2021-04-26 08:10:57.5448850' AS DateTime2), 1142, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1141, 60, 0, 1, CAST(N'2021-04-26 08:10:57.5528855' AS DateTime2), 1142, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1142, 0, 200, 1, CAST(N'2021-04-26 08:25:11.7955564' AS DateTime2), 1143, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1143, 60, 0, 1, CAST(N'2021-04-26 08:25:11.8155575' AS DateTime2), 1143, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1144, 0, 200, 1, CAST(N'2021-04-26 08:28:48.4846709' AS DateTime2), 1144, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1145, 60, 0, 1, CAST(N'2021-04-26 08:28:48.5226731' AS DateTime2), 1144, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1146, 0, 200, 1, CAST(N'2021-04-26 08:31:55.0994960' AS DateTime2), 1145, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1147, 60, 0, 1, CAST(N'2021-04-26 08:31:55.1234974' AS DateTime2), 1145, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1148, 0, 600, 1, CAST(N'2021-04-26 08:33:41.7036501' AS DateTime2), 1146, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1149, 180, 0, 1, CAST(N'2021-04-26 08:33:41.7086503' AS DateTime2), 1146, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1150, 0, 600, 1, CAST(N'2021-04-26 08:34:13.7734448' AS DateTime2), 1147, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1151, 180, 0, 1, CAST(N'2021-04-26 08:34:13.7794451' AS DateTime2), 1147, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1152, 0, 600, 1, CAST(N'2021-04-26 08:35:22.4187358' AS DateTime2), 1148, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1153, 180, 0, 1, CAST(N'2021-04-26 08:35:22.4487375' AS DateTime2), 1148, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1154, 0, 600, 1, CAST(N'2021-04-26 08:36:47.8392668' AS DateTime2), 1149, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1155, 180, 0, 1, CAST(N'2021-04-26 08:36:47.8592679' AS DateTime2), 1149, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1156, 0, 75, 1, CAST(N'2021-04-26 08:40:17.2754430' AS DateTime2), 1150, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1157, 22, 0, 1, CAST(N'2021-04-26 08:40:17.2974442' AS DateTime2), 1150, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1158, 0, 600, 1, CAST(N'2021-04-26 08:42:00.8360085' AS DateTime2), 1151, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1159, 180, 0, 1, CAST(N'2021-04-26 08:42:00.8410088' AS DateTime2), 1151, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1160, 0, 75, 1, CAST(N'2021-04-26 08:43:36.3159193' AS DateTime2), 1152, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1161, 22, 0, 1, CAST(N'2021-04-26 08:43:36.3369205' AS DateTime2), 1152, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1162, 0, 600, 1, CAST(N'2021-04-26 08:43:55.1699977' AS DateTime2), 1153, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1163, 180, 0, 1, CAST(N'2021-04-26 08:43:55.1909989' AS DateTime2), 1153, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1164, 0, 600, 1, CAST(N'2021-04-26 08:46:18.9324663' AS DateTime2), 1154, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1165, 180, 0, 1, CAST(N'2021-04-26 08:46:18.9524674' AS DateTime2), 1154, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1166, 0, 600, 1, CAST(N'2021-04-26 09:09:40.5763100' AS DateTime2), 1155, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1167, 180, 0, 1, CAST(N'2021-04-26 09:09:40.5793102' AS DateTime2), 1155, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1168, 0, 600, 1, CAST(N'2021-04-26 09:13:52.4567167' AS DateTime2), 1156, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1169, 180, 0, 1, CAST(N'2021-04-26 09:13:52.4747178' AS DateTime2), 1156, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1170, 0, 600, 1, CAST(N'2021-04-26 09:14:07.4621568' AS DateTime2), 1157, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1171, 180, 0, 1, CAST(N'2021-04-26 09:14:07.4671571' AS DateTime2), 1157, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1172, 0, 200, 1, CAST(N'2021-05-03 07:43:10.4904203' AS DateTime2), 1158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1173, 60, 0, 1, CAST(N'2021-05-03 07:43:10.5444234' AS DateTime2), 1158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1174, 0, 200, 1, CAST(N'2021-05-03 07:43:36.0742067' AS DateTime2), 1159, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1175, 60, 0, 1, CAST(N'2021-05-03 07:43:36.0772068' AS DateTime2), 1159, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1176, 0, 200, 1, CAST(N'2021-05-03 07:43:44.8417081' AS DateTime2), 1160, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1177, 60, 0, 1, CAST(N'2021-05-03 07:43:44.8447083' AS DateTime2), 1160, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1178, 0, 200, 1, CAST(N'2021-05-03 07:44:01.3976551' AS DateTime2), 1161, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1179, 60, 0, 1, CAST(N'2021-05-03 07:44:01.4006553' AS DateTime2), 1161, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1180, 0, 600, 1, CAST(N'2021-05-03 08:09:42.9871575' AS DateTime2), 1162, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1181, 180, 0, 1, CAST(N'2021-05-03 08:09:42.9931579' AS DateTime2), 1162, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1182, 0, 600, 1, CAST(N'2021-05-03 08:10:05.8874833' AS DateTime2), 1163, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1183, 180, 0, 1, CAST(N'2021-05-03 08:10:05.9154850' AS DateTime2), 1163, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1184, 0, 600, 1, CAST(N'2021-05-03 08:15:31.4657418' AS DateTime2), 1164, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1185, 180, 0, 1, CAST(N'2021-05-03 08:15:31.4697421' AS DateTime2), 1164, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1186, 0, 600, 1, CAST(N'2021-05-03 08:15:58.0321656' AS DateTime2), 1165, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1187, 180, 0, 1, CAST(N'2021-05-03 08:15:58.0401660' AS DateTime2), 1165, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1188, 0, 600, 1, CAST(N'2021-05-03 08:16:04.2905235' AS DateTime2), 1166, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1189, 180, 0, 1, CAST(N'2021-05-03 08:16:04.3115247' AS DateTime2), 1166, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1190, 0, 600, 1, CAST(N'2021-05-03 08:16:47.2109838' AS DateTime2), 1167, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1191, 180, 0, 1, CAST(N'2021-05-03 08:16:47.2129839' AS DateTime2), 1167, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1192, 0, 600, 1, CAST(N'2021-05-03 08:17:05.4520778' AS DateTime2), 1168, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1193, 180, 0, 1, CAST(N'2021-05-03 08:17:05.4580781' AS DateTime2), 1168, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1194, 0, 600, 1, CAST(N'2021-05-03 08:17:18.8358130' AS DateTime2), 1169, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1195, 180, 0, 1, CAST(N'2021-05-03 08:17:18.8398132' AS DateTime2), 1169, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1196, 0, 600, 1, CAST(N'2021-05-03 08:17:35.6302084' AS DateTime2), 1170, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1197, 180, 0, 1, CAST(N'2021-05-03 08:17:35.6322085' AS DateTime2), 1170, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1198, 0, 600, 1, CAST(N'2021-05-03 08:17:51.4633938' AS DateTime2), 1171, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1199, 180, 0, 1, CAST(N'2021-05-03 08:17:51.4663939' AS DateTime2), 1171, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1200, 0, 600, 1, CAST(N'2021-05-03 08:18:55.7045250' AS DateTime2), 1172, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1201, 180, 0, 1, CAST(N'2021-05-03 08:18:55.7255262' AS DateTime2), 1172, N'test')
GO
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1202, 0, 600, 1, CAST(N'2021-05-03 08:19:37.9604037' AS DateTime2), 1173, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1203, 180, 0, 1, CAST(N'2021-05-03 08:19:38.0444085' AS DateTime2), 1173, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1204, 0, 600, 1, CAST(N'2021-05-03 08:19:50.7558206' AS DateTime2), 1174, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1205, 180, 0, 1, CAST(N'2021-05-03 08:19:50.7718215' AS DateTime2), 1174, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1206, 0, 600, 1, CAST(N'2021-05-03 08:20:39.2882176' AS DateTime2), 1175, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1207, 180, 0, 1, CAST(N'2021-05-03 08:20:39.2922179' AS DateTime2), 1175, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1208, 0, 600, 1, CAST(N'2021-05-03 08:22:21.4377052' AS DateTime2), 1176, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1209, 180, 0, 1, CAST(N'2021-05-03 08:22:21.4407054' AS DateTime2), 1176, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1210, 0, 600, 1, CAST(N'2021-05-03 08:22:38.2522006' AS DateTime2), 1177, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1211, 180, 0, 1, CAST(N'2021-05-03 08:22:38.2572009' AS DateTime2), 1177, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1212, 0, 600, 1, CAST(N'2021-05-03 08:24:10.9194349' AS DateTime2), 1178, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1213, 180, 0, 1, CAST(N'2021-05-03 08:24:10.9394360' AS DateTime2), 1178, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1214, 0, 600, 1, CAST(N'2021-05-03 08:24:25.9142925' AS DateTime2), 1179, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1215, 180, 0, 1, CAST(N'2021-05-03 08:24:25.9392939' AS DateTime2), 1179, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1216, 0, 600, 1, CAST(N'2021-05-03 08:24:58.1941388' AS DateTime2), 1180, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1217, 180, 0, 1, CAST(N'2021-05-03 08:24:58.2011392' AS DateTime2), 1180, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1218, 0, 600, 1, CAST(N'2021-05-03 08:25:37.8101286' AS DateTime2), 1181, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1219, 180, 0, 1, CAST(N'2021-05-03 08:25:37.8331299' AS DateTime2), 1181, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1220, 0, 200, 1, CAST(N'2021-05-03 08:26:20.1729771' AS DateTime2), 1182, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1221, 60, 0, 1, CAST(N'2021-05-03 08:26:20.1969785' AS DateTime2), 1182, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1222, 0, 200, 1, CAST(N'2021-05-03 08:26:21.6850636' AS DateTime2), 1183, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1223, 60, 0, 1, CAST(N'2021-05-03 08:26:21.6880638' AS DateTime2), 1183, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1224, 0, 600, 1, CAST(N'2021-05-03 08:27:10.8148737' AS DateTime2), 1184, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1225, 180, 0, 1, CAST(N'2021-05-03 08:27:10.8198740' AS DateTime2), 1184, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1226, 0, 600, 1, CAST(N'2021-05-03 08:29:09.9591854' AS DateTime2), 1186, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1227, 0, 600, 1, CAST(N'2021-05-03 08:29:09.9741863' AS DateTime2), 1186, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1228, 180, 0, 1, CAST(N'2021-05-03 08:29:09.9801866' AS DateTime2), 1186, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1229, 180, 0, 1, CAST(N'2021-05-03 08:29:09.9891872' AS DateTime2), 1186, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1230, 0, 600, 1, CAST(N'2021-05-03 08:36:49.1844470' AS DateTime2), 1187, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1231, 180, 0, 1, CAST(N'2021-05-03 08:36:49.3524566' AS DateTime2), 1187, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1232, 0, 600, 1, CAST(N'2021-05-03 08:36:52.8476565' AS DateTime2), 1188, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1233, 180, 0, 1, CAST(N'2021-05-03 08:36:52.8536569' AS DateTime2), 1188, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1234, 0, 600, 1, CAST(N'2021-05-03 08:37:05.4245223' AS DateTime2), 1189, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1235, 180, 0, 1, CAST(N'2021-05-03 08:37:05.4285225' AS DateTime2), 1189, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1236, 0, 600, 1, CAST(N'2021-05-03 08:37:52.6534688' AS DateTime2), 1190, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1237, 180, 0, 1, CAST(N'2021-05-03 08:37:52.7234728' AS DateTime2), 1190, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1238, 0, 600, 1, CAST(N'2021-05-03 08:37:53.8245358' AS DateTime2), 1191, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1239, 180, 0, 1, CAST(N'2021-05-03 08:37:53.8295361' AS DateTime2), 1191, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1240, 0, 600, 1, CAST(N'2021-05-03 08:38:03.1752473' AS DateTime2), 1192, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1241, 180, 0, 1, CAST(N'2021-05-03 08:38:03.1802475' AS DateTime2), 1192, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1242, 0, 600, 1, CAST(N'2021-05-03 08:40:41.6784855' AS DateTime2), 1193, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1243, 180, 0, 1, CAST(N'2021-05-03 08:40:41.6844858' AS DateTime2), 1193, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1244, 0, 600, 1, CAST(N'2021-05-03 08:41:50.8365170' AS DateTime2), 1194, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1245, 180, 0, 1, CAST(N'2021-05-03 08:41:50.8915201' AS DateTime2), 1194, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1246, 0, 200, 1, CAST(N'2021-05-03 08:51:30.4042122' AS DateTime2), 1195, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1247, 60, 0, 1, CAST(N'2021-05-03 08:51:30.4232133' AS DateTime2), 1195, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1248, 0, 200, 1, CAST(N'2021-05-03 08:51:38.6076814' AS DateTime2), 1196, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1249, 60, 0, 1, CAST(N'2021-05-03 08:51:38.6106816' AS DateTime2), 1196, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1250, 0, 200, 1, CAST(N'2021-05-03 08:52:03.1170833' AS DateTime2), 1197, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1251, 60, 0, 1, CAST(N'2021-05-03 08:52:03.1190834' AS DateTime2), 1197, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1252, 0, 200, 1, CAST(N'2021-05-03 08:52:04.7131746' AS DateTime2), 1198, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1253, 60, 0, 1, CAST(N'2021-05-03 08:52:04.7351758' AS DateTime2), 1198, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1254, 0, 600, 1, CAST(N'2021-05-03 08:53:21.0039420' AS DateTime2), 1199, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1255, 180, 0, 1, CAST(N'2021-05-03 08:53:21.0219431' AS DateTime2), 1199, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1256, 0, 600, 1, CAST(N'2021-05-03 08:53:29.8114458' AS DateTime2), 1200, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1257, 180, 0, 1, CAST(N'2021-05-03 08:53:29.8144460' AS DateTime2), 1200, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1258, 0, 200, 1, CAST(N'2021-05-03 08:55:51.1432274' AS DateTime2), 1201, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1259, 60, 0, 1, CAST(N'2021-05-03 08:55:51.1662288' AS DateTime2), 1201, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1260, 0, 600, 1, CAST(N'2021-05-03 12:11:07.6036557' AS DateTime2), 1202, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1261, 180, 0, 1, CAST(N'2021-05-03 12:11:07.6396577' AS DateTime2), 1202, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1369, 50000, 0, 1, CAST(N'2021-05-08 05:46:37.3363665' AS DateTime2), 0, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1370, 1000000, 0, 1, CAST(N'2021-05-08 07:57:14.3647456' AS DateTime2), 0, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1371, 0, 200, 1, CAST(N'2021-05-08 07:59:06.4575730' AS DateTime2), 1251, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1372, 60, 0, 1, CAST(N'2021-05-08 07:59:06.4728530' AS DateTime2), 1251, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1373, 0, 600, 1, CAST(N'2021-05-08 08:23:48.2159629' AS DateTime2), 1253, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1374, 180, 0, 1, CAST(N'2021-05-08 08:23:48.3797037' AS DateTime2), 1253, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1375, 0, 600, 1, CAST(N'2021-05-08 08:23:48.5160716' AS DateTime2), 1253, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1376, 180, 0, 1, CAST(N'2021-05-08 08:23:48.5227666' AS DateTime2), 1253, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1377, 0, 12000, 1, CAST(N'2021-05-08 09:38:44.8990685' AS DateTime2), 1254, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1378, 3600, 0, 1, CAST(N'2021-05-08 09:38:44.9600071' AS DateTime2), 1254, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1379, 0, 12000, 1, CAST(N'2021-05-08 10:23:34.4141649' AS DateTime2), 1255, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1380, 3600, 0, 1, CAST(N'2021-05-08 10:23:34.4353203' AS DateTime2), 1255, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1381, 0, 12000, 1, CAST(N'2021-05-08 10:23:34.6393440' AS DateTime2), 1256, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1382, 3600, 0, 1, CAST(N'2021-05-08 10:23:34.6411766' AS DateTime2), 1256, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1383, 0, 12000, 1, CAST(N'2021-05-08 10:24:46.7492138' AS DateTime2), 1257, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1384, 3600, 0, 1, CAST(N'2021-05-08 10:24:46.7578185' AS DateTime2), 1257, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1385, 0, 12000, 1, CAST(N'2021-05-08 10:25:22.8788293' AS DateTime2), 1258, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1386, 3600, 0, 1, CAST(N'2021-05-08 10:25:22.9143283' AS DateTime2), 1258, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1387, 0, 12000, 1, CAST(N'2021-05-08 10:26:11.1838791' AS DateTime2), 1259, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1388, 3600, 0, 1, CAST(N'2021-05-08 10:26:11.1903306' AS DateTime2), 1259, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1389, 0, 12000, 1, CAST(N'2021-05-08 10:41:19.0980742' AS DateTime2), 1260, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1390, 3600, 0, 1, CAST(N'2021-05-08 10:41:19.1159734' AS DateTime2), 1260, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1391, 0, 12000, 1, CAST(N'2021-05-08 10:42:25.2393549' AS DateTime2), 1261, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1392, 3600, 0, 1, CAST(N'2021-05-08 10:42:25.2438806' AS DateTime2), 1261, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1393, 0, 12000, 1, CAST(N'2021-05-08 10:45:11.6169512' AS DateTime2), 1262, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1394, 3600, 0, 1, CAST(N'2021-05-08 10:45:11.6226604' AS DateTime2), 1262, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1395, 0, 600, 1, CAST(N'2021-05-08 11:52:35.3925656' AS DateTime2), 1263, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1396, 180, 0, 1, CAST(N'2021-05-08 11:52:35.4276668' AS DateTime2), 1263, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1397, 0, 600, 1, CAST(N'2021-05-08 11:52:36.2406797' AS DateTime2), 1264, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1398, 180, 0, 1, CAST(N'2021-05-08 11:52:36.2431798' AS DateTime2), 1264, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1399, 0, 600, 1, CAST(N'2021-05-08 11:52:48.6006967' AS DateTime2), 1265, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1400, 180, 0, 1, CAST(N'2021-05-08 11:52:48.6041837' AS DateTime2), 1265, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1401, 0, 600, 1, CAST(N'2021-05-08 11:57:42.5465383' AS DateTime2), 1267, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1402, 180, 0, 1, CAST(N'2021-05-08 11:57:42.5527620' AS DateTime2), 1267, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1403, 0, 600, 1, CAST(N'2021-05-08 11:57:42.5553216' AS DateTime2), 1267, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1404, 180, 0, 1, CAST(N'2021-05-08 11:57:42.5639612' AS DateTime2), 1267, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1405, 0, 12000, 1, CAST(N'2021-05-08 11:58:53.4368693' AS DateTime2), 1268, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1406, 45000, 0, 1, CAST(N'2021-05-08 11:58:53.4432341' AS DateTime2), 1, N'admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1407, 0, 200, 1, CAST(N'2021-05-08 12:16:49.5597623' AS DateTime2), 1269, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1408, 60, 0, 1, CAST(N'2021-05-08 12:16:49.5819843' AS DateTime2), 1269, N'nikatak1234')
GO
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1409, 0, 600, 1, CAST(N'2021-05-08 12:32:48.7668194' AS DateTime2), 1270, N'a')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1410, 180, 0, 1, CAST(N'2021-05-08 12:32:48.7896161' AS DateTime2), 1270, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1411, 0, 600, 1, CAST(N'2021-05-08 12:44:14.3933875' AS DateTime2), 1271, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1412, 180, 0, 1, CAST(N'2021-05-08 12:44:14.3986822' AS DateTime2), 1271, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1413, 0, 600, 1, CAST(N'2021-05-08 12:44:19.8962013' AS DateTime2), 1272, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1414, 180, 0, 1, CAST(N'2021-05-08 12:44:19.9002984' AS DateTime2), 1272, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1415, 0, 600, 1, CAST(N'2021-05-08 13:23:19.3583003' AS DateTime2), 1273, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1416, 180, 0, 1, CAST(N'2021-05-08 13:23:19.3823615' AS DateTime2), 1273, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1417, 0, 200, 1, CAST(N'2021-05-09 06:31:19.2288401' AS DateTime2), 1274, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1418, 60, 0, 1, CAST(N'2021-05-09 06:31:19.2574389' AS DateTime2), 1274, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1419, 0, 200, 1, CAST(N'2021-05-09 06:31:43.1188836' AS DateTime2), 1275, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1420, 60, 0, 1, CAST(N'2021-05-09 06:31:43.1370841' AS DateTime2), 1275, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1421, 0, 200, 1, CAST(N'2021-05-09 06:38:24.6849798' AS DateTime2), 1276, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1422, 60, 0, 1, CAST(N'2021-05-09 06:38:24.7463159' AS DateTime2), 1276, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1423, 0, 200, 1, CAST(N'2021-05-09 06:39:41.0986766' AS DateTime2), 1277, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1424, 60, 0, 1, CAST(N'2021-05-09 06:39:41.1206678' AS DateTime2), 1277, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1425, 0, 200, 1, CAST(N'2021-05-09 06:42:01.4659587' AS DateTime2), 1278, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1426, 60, 0, 1, CAST(N'2021-05-09 06:42:01.4709614' AS DateTime2), 1278, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1427, 0, 600, 1, CAST(N'2021-05-09 06:42:24.0868562' AS DateTime2), 1279, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1428, 180, 0, 1, CAST(N'2021-05-09 06:42:24.1142287' AS DateTime2), 1279, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1429, 0, 200, 1, CAST(N'2021-05-09 06:43:05.5641509' AS DateTime2), 1280, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1430, 60, 0, 1, CAST(N'2021-05-09 06:43:05.5674487' AS DateTime2), 1280, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1431, 0, 600, 1, CAST(N'2021-05-09 07:11:08.8183148' AS DateTime2), 1281, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1432, 180, 0, 1, CAST(N'2021-05-09 07:11:08.8374910' AS DateTime2), 1281, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1433, 0, 600, 1, CAST(N'2021-05-09 07:12:57.4362268' AS DateTime2), 1282, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1434, 180, 0, 1, CAST(N'2021-05-09 07:12:57.4409086' AS DateTime2), 1282, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1435, 0, 600, 1, CAST(N'2021-05-09 07:18:04.5347381' AS DateTime2), 1283, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1436, 180, 0, 1, CAST(N'2021-05-09 07:18:04.5575188' AS DateTime2), 1283, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1437, 0, 550, 1, CAST(N'2021-05-09 07:21:19.3229965' AS DateTime2), 1284, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1438, 165, 0, 1, CAST(N'2021-05-09 07:21:19.3405109' AS DateTime2), 1284, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1439, 0, 550, 1, CAST(N'2021-05-09 07:42:52.2123323' AS DateTime2), 1285, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1440, 165, 0, 1, CAST(N'2021-05-09 07:42:52.2320788' AS DateTime2), 1285, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1441, 0, 12000, 1, CAST(N'2021-05-09 07:46:28.1501459' AS DateTime2), 1286, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (1442, 3600, 0, 1, CAST(N'2021-05-09 07:46:28.1557263' AS DateTime2), 1286, N'nikatak1234')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2172, 0, 600, 1, CAST(N'2021-05-11 13:59:24.1521880' AS DateTime2), 2158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2173, 180, 0, 1, CAST(N'2021-05-11 13:59:24.3101970' AS DateTime2), 2158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2174, 0, 600, 1, CAST(N'2021-05-11 13:59:55.2998571' AS DateTime2), 2159, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2175, 180, 0, 1, CAST(N'2021-05-11 13:59:55.3308588' AS DateTime2), 2159, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2176, 0, 600, 1, CAST(N'2021-05-11 14:11:37.3898501' AS DateTime2), 2160, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2177, 180, 0, 1, CAST(N'2021-05-11 14:11:37.4278522' AS DateTime2), 2160, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2178, 0, 600, 1, CAST(N'2021-05-11 14:11:58.6693407' AS DateTime2), 2161, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2179, 180, 0, 1, CAST(N'2021-05-11 14:11:58.6853416' AS DateTime2), 2161, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2180, 0, 600, 1, CAST(N'2021-05-11 14:20:18.2474973' AS DateTime2), 2162, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2181, 180, 0, 1, CAST(N'2021-05-11 14:20:18.2604980' AS DateTime2), 2162, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2182, 0, 600, 1, CAST(N'2021-05-11 14:20:55.6007905' AS DateTime2), 2163, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2183, 180, 0, 1, CAST(N'2021-05-11 14:20:55.6277921' AS DateTime2), 2163, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2184, 0, 600, 1, CAST(N'2021-05-11 14:40:02.2701603' AS DateTime2), 2164, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2185, 180, 0, 1, CAST(N'2021-05-11 14:40:02.3121627' AS DateTime2), 2164, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2186, 0, 600, 1, CAST(N'2021-05-11 14:41:59.2419368' AS DateTime2), 2165, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2187, 180, 0, 1, CAST(N'2021-05-11 14:41:59.2599378' AS DateTime2), 2165, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2188, 0, 600, 1, CAST(N'2021-05-11 14:43:14.7662656' AS DateTime2), 2166, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2189, 180, 0, 1, CAST(N'2021-05-11 14:43:14.7862667' AS DateTime2), 2166, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2190, 0, 600, 1, CAST(N'2021-05-11 14:44:59.5093556' AS DateTime2), 2167, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2191, 180, 0, 1, CAST(N'2021-05-11 14:44:59.5303568' AS DateTime2), 2167, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2192, 0, 600, 1, CAST(N'2021-05-11 14:47:35.5497847' AS DateTime2), 2168, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (2193, 180, 0, 1, CAST(N'2021-05-11 14:47:35.5677858' AS DateTime2), 2168, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (3172, 0, 600, 1, CAST(N'2021-05-12 07:46:12.9266986' AS DateTime2), 3158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (3173, 180, 0, 1, CAST(N'2021-05-12 07:46:12.9567003' AS DateTime2), 3158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4172, 0, 200, 1, CAST(N'2021-05-12 08:20:52.0805846' AS DateTime2), 4158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4173, 60, 0, 1, CAST(N'2021-05-12 08:20:52.1275873' AS DateTime2), 4158, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4174, 0, 600, 1, CAST(N'2021-05-12 08:33:22.1982096' AS DateTime2), 4159, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4175, 180, 0, 1, CAST(N'2021-05-12 08:33:22.2162106' AS DateTime2), 4159, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4176, 0, 600, 1, CAST(N'2021-05-12 08:36:24.2318286' AS DateTime2), 4160, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4177, 180, 0, 1, CAST(N'2021-05-12 08:36:24.2658306' AS DateTime2), 4160, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4178, 0, 600, 1, CAST(N'2021-05-12 08:42:59.9686939' AS DateTime2), 4161, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4179, 180, 0, 1, CAST(N'2021-05-12 08:43:00.0046960' AS DateTime2), 4161, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4180, 0, 600, 1, CAST(N'2021-05-12 08:43:34.6806335' AS DateTime2), 4162, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4181, 180, 0, 1, CAST(N'2021-05-12 08:43:34.7086351' AS DateTime2), 4162, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4182, 0, 600, 1, CAST(N'2021-05-12 08:45:17.0773391' AS DateTime2), 4163, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4183, 180, 0, 1, CAST(N'2021-05-12 08:45:17.0803393' AS DateTime2), 4163, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4184, 0, 600, 1, CAST(N'2021-05-12 08:45:53.0559892' AS DateTime2), 4164, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4185, 180, 0, 1, CAST(N'2021-05-12 08:45:53.0599894' AS DateTime2), 4164, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4186, 0, 600, 1, CAST(N'2021-05-12 08:48:00.3372558' AS DateTime2), 4165, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4187, 180, 0, 1, CAST(N'2021-05-12 08:48:00.3502565' AS DateTime2), 4165, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4188, 0, 600, 1, CAST(N'2021-05-12 08:48:23.5287144' AS DateTime2), 4166, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4189, 180, 0, 1, CAST(N'2021-05-12 08:48:23.5327146' AS DateTime2), 4166, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4190, 0, 600, 1, CAST(N'2021-05-12 08:48:45.6800573' AS DateTime2), 4167, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4191, 180, 0, 1, CAST(N'2021-05-12 08:48:45.7110590' AS DateTime2), 4167, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4192, 0, 600, 1, CAST(N'2021-05-12 08:49:36.6013075' AS DateTime2), 4168, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4193, 180, 0, 1, CAST(N'2021-05-12 08:49:36.6053077' AS DateTime2), 4168, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4194, 0, 600, 1, CAST(N'2021-05-12 08:50:59.3180858' AS DateTime2), 4169, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4195, 180, 0, 1, CAST(N'2021-05-12 08:50:59.3230860' AS DateTime2), 4169, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4196, 0, 600, 1, CAST(N'2021-05-12 10:54:01.7181454' AS DateTime2), 4170, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4197, 180, 0, 1, CAST(N'2021-05-12 10:54:01.7221456' AS DateTime2), 4170, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4198, 0, 600, 1, CAST(N'2021-05-12 11:08:28.4674326' AS DateTime2), 4171, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4199, 180, 0, 1, CAST(N'2021-05-12 11:08:28.4714329' AS DateTime2), 4171, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4200, 0, 600, 1, CAST(N'2021-05-12 11:24:39.9653887' AS DateTime2), 4172, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4201, 180, 0, 1, CAST(N'2021-05-12 11:24:40.0213919' AS DateTime2), 4172, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4202, 0, 600, 1, CAST(N'2021-05-12 11:26:21.5700007' AS DateTime2), 4173, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4203, 180, 0, 1, CAST(N'2021-05-12 11:26:21.6260039' AS DateTime2), 4173, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4204, 0, 600, 1, CAST(N'2021-05-12 11:26:49.8846202' AS DateTime2), 4174, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4205, 180, 0, 1, CAST(N'2021-05-12 11:26:49.9276227' AS DateTime2), 4174, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4206, 0, 600, 1, CAST(N'2021-05-12 11:27:36.8353057' AS DateTime2), 4175, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4207, 180, 0, 1, CAST(N'2021-05-12 11:27:36.8913089' AS DateTime2), 4175, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4208, 0, 600, 1, CAST(N'2021-05-12 11:28:07.5883431' AS DateTime2), 4176, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4209, 180, 0, 1, CAST(N'2021-05-12 11:28:07.6053441' AS DateTime2), 4176, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4210, 200, 0, 0, CAST(N'2021-05-29 15:31:37.9439362' AS DateTime2), 0, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4211, 200, 0, 0, CAST(N'2021-05-29 15:31:38.1923028' AS DateTime2), 0, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4212, 1000, 0, 0, CAST(N'2021-05-29 15:39:25.1279891' AS DateTime2), 0, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4213, 1000, 0, 0, CAST(N'2021-05-29 15:41:33.5955144' AS DateTime2), 0, N'test')
GO
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4214, 2000000, 0, 0, CAST(N'2021-05-29 15:42:13.3446728' AS DateTime2), 0, N'test')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4215, 10000, 0, 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4216, 0, 700, 1, CAST(N'2021-07-19 15:08:52.1384765' AS DateTime2), 4177, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4217, 420, 0, 1, CAST(N'2021-07-19 15:08:52.2057183' AS DateTime2), 4177, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4218, 0, 7900, 1, CAST(N'2021-07-19 15:08:56.1976289' AS DateTime2), 4178, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4219, 4740, 0, 1, CAST(N'2021-07-19 15:08:56.2010432' AS DateTime2), 4178, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4220, 0, 500, 1, CAST(N'2021-07-25 09:45:03.4045656' AS DateTime2), 4179, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4221, 0, 500, 1, CAST(N'2021-07-25 11:14:55.0574790' AS DateTime2), 4180, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4222, 0, 500, 1, CAST(N'2021-07-25 11:16:37.4497596' AS DateTime2), 4181, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4223, 0, 8000, 1, CAST(N'2021-07-25 11:18:54.5238328' AS DateTime2), 4182, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4224, 0, 8000, 1, CAST(N'2021-07-25 11:19:45.7170424' AS DateTime2), 4183, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4225, 0, 8000, 1, CAST(N'2021-07-25 11:20:02.9054754' AS DateTime2), 4184, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4226, 0, 500, 1, CAST(N'2021-07-25 11:22:38.2131908' AS DateTime2), 4185, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4227, 0, 500, 1, CAST(N'2021-07-25 11:23:06.9719300' AS DateTime2), 4186, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4228, 0, 500, 1, CAST(N'2021-07-25 11:23:30.2923200' AS DateTime2), 4187, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4229, 0, 2000, 1, CAST(N'2021-07-25 11:26:17.7729339' AS DateTime2), 4188, N'Admin')
INSERT [dbo].[Tbl_pays] ([Id], [Pay], [Harvest], [status], [DateTime], [RequestId], [UserName]) VALUES (4230, 2000000, 0, 0, CAST(N'2021-07-25 11:43:04.2088799' AS DateTime2), 0, N'Admin')
SET IDENTITY_INSERT [dbo].[Tbl_pays] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Requests] ON 

INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (114, N'استعلام', 2000, N'آب', CAST(N'2021-04-22 08:58:57.4506383' AS DateTime2), N'3126163691013', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (115, N'استعلام', 2000, N'آب', CAST(N'2021-04-22 09:00:01.5967118' AS DateTime2), N'3126163691013', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (116, N'استعلام', 2000, N'آب', CAST(N'2021-04-22 09:04:13.5721240' AS DateTime2), N'3126163691013', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (117, N'استعلام', 2000, N'برق', CAST(N'2021-04-22 09:04:57.3926304' AS DateTime2), N'1146209701322', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (118, N'استعلام', 2000, N'برق', CAST(N'2021-04-22 10:20:41.8008787' AS DateTime2), N'1146209701322', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (119, N'پرداخت', 750, N'برق', CAST(N'2021-04-22 10:20:54.5386073' AS DateTime2), N'1146209701322', N' 80200276', N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (120, N'استعلام', 2000, N'آب', CAST(N'2021-04-22 13:07:22.7824496' AS DateTime2), N'3126163691013', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (121, N'استعلام', 2000, N'برق', CAST(N'2021-04-22 13:10:06.0584111' AS DateTime2), N'1146209701322', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (122, N'استعلام', 2000, N'گاز', CAST(N'2021-04-22 13:10:16.0789843' AS DateTime2), N'22093331420', NULL, N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (123, N'پرداخت', 750, N'گاز', CAST(N'2021-04-22 13:10:26.1045577' AS DateTime2), N'93331408032', N'59602405', N'karim')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (124, N'استعلام', 2000, N'آب', CAST(N'2021-04-24 08:48:15.3684779' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (125, N'مکان محور', 2000, N'دریافت آدرس', CAST(N'2021-04-24 09:41:16.6709384' AS DateTime2), N'5881774899', N'5881774899', N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1124, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-04-26 06:25:37.2864109' AS DateTime2), N'', N'', N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1125, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-04-26 06:28:13.0885073' AS DateTime2), N'', N'', N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1126, N'سپرده', 200, N'دریافت اطلاعات  نام مشتری', CAST(N'2021-04-26 06:42:31.6746620' AS DateTime2), N'', N'', N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1127, N'استعلام', 200, N'آب', CAST(N'2021-04-26 06:56:22.3173456' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1128, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-04-26 07:21:26.3626642' AS DateTime2), N'', N'', N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1129, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-04-26 07:21:33.7960894' AS DateTime2), N'', N'', N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1130, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 07:33:50.8026378' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1131, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 07:38:12.7006428' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1132, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 07:39:09.4077991' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1133, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 07:39:20.5734377' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1134, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 07:46:00.2759324' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1135, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 07:49:09.2751421' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1136, N'استعلام', 200, N'برق', CAST(N'2021-04-26 07:50:52.9438798' AS DateTime2), N'1146209701322', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1137, N'استعلام', 200, N'آب', CAST(N'2021-04-26 07:52:24.6138287' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1138, N'پرداخت', 75, N'آب', CAST(N'2021-04-26 07:52:49.9302768' AS DateTime2), N'3126163691013', N'120790605', N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1139, N'استعلام', 200, N'آب', CAST(N'2021-04-26 07:55:30.0852572' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1140, N'استعلام', 200, N'آب', CAST(N'2021-04-26 08:09:14.0704203' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1141, N'استعلام', 200, N'آب', CAST(N'2021-04-26 08:10:02.2387855' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1142, N'استعلام', 200, N'آب', CAST(N'2021-04-26 08:10:57.5268840' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1143, N'استعلام', 200, N'آب', CAST(N'2021-04-26 08:25:10.5104829' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1144, N'استعلام', 200, N'آب', CAST(N'2021-04-26 08:28:48.2496575' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1145, N'استعلام', 200, N'برق', CAST(N'2021-04-26 08:31:54.8684828' AS DateTime2), N'1146209701322', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1146, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 08:33:41.6836489' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1147, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 08:34:13.7064409' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1148, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 08:35:22.1557208' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1149, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 08:36:47.5932527' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1150, N'پرداخت', 75, NULL, CAST(N'2021-04-26 08:40:17.0274288' AS DateTime2), NULL, NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1151, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 08:42:00.8000064' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1152, N'پرداخت', 75, NULL, CAST(N'2021-04-26 08:43:36.0599047' AS DateTime2), NULL, NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1153, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 08:43:55.0879930' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1154, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 08:46:17.7623993' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1155, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 09:09:40.5003056' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1156, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 09:13:52.4287151' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1157, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-04-26 09:14:07.4381555' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1158, N'استعلام', 200, N'تلفن همراه', CAST(N'2021-05-03 07:43:09.4943634' AS DateTime2), N'09141888830', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1159, N'استعلام', 200, N'تلفن ثابت', CAST(N'2021-05-03 07:43:36.0592058' AS DateTime2), N'04435256830', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1160, N'استعلام', 200, N'تلفن ثابت', CAST(N'2021-05-03 07:43:44.8217070' AS DateTime2), N'04435241211', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1161, N'استعلام', 200, N'آب', CAST(N'2021-05-03 07:44:01.3846543' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1162, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:09:42.9691565' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1163, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:10:05.8754827' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1164, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:15:31.4307398' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1165, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:15:58.0141645' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1166, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:16:04.2735225' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1167, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:16:47.1989831' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1168, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:17:05.4330767' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1169, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:17:18.8208121' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1170, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:17:35.6002067' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1171, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:17:51.4573934' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1172, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:18:55.6595224' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1173, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:19:37.9294020' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1174, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:19:50.7468201' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1175, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:20:39.2502155' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1176, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:22:21.4197042' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1177, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:22:38.2341995' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1178, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:24:09.6663632' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1179, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:24:25.8642897' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1180, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:24:58.1631370' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1181, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:25:37.7811270' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1182, N'استعلام', 200, N'برق', CAST(N'2021-05-03 08:26:20.1539761' AS DateTime2), N'1146209701322', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1183, N'استعلام', 200, N'برق', CAST(N'2021-05-03 08:26:21.6670626' AS DateTime2), N'1146209701322', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1184, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:27:10.7998728' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1185, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:29:09.7581739' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1186, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:29:09.7581739' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1187, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:36:48.9494336' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1188, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:36:52.7896532' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1189, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:37:05.3905203' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1190, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:37:52.6284674' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1191, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:37:53.7365307' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1192, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:38:03.1492458' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1193, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:40:41.6434835' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1194, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:41:50.7855140' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1195, N'استعلام', 200, N'تلفن همراه', CAST(N'2021-05-03 08:51:30.1511977' AS DateTime2), N'09129727276', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1196, N'استعلام', 200, N'تلفن همراه', CAST(N'2021-05-03 08:51:38.5906804' AS DateTime2), N'09123580087', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1197, N'استعلام', 200, N'تلفن ثابت', CAST(N'2021-05-03 08:52:03.0980822' AS DateTime2), N'04435228343', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1198, N'استعلام', 200, N'تلفن ثابت', CAST(N'2021-05-03 08:52:04.6851730' AS DateTime2), N'04435228343', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1199, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:53:20.8099309' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1200, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 08:53:29.7704434' AS DateTime2), N'85823818', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1201, N'استعلام', 200, N'آب', CAST(N'2021-05-03 08:55:50.9402158' AS DateTime2), N'3126163691013', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1202, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-03 12:11:07.4046443' AS DateTime2), N'81569052', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1250, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-08 04:54:58.6576620' AS DateTime2), N'81569052', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1251, N'استعلام', 200, N'آب', CAST(N'2021-05-08 07:59:06.3814875' AS DateTime2), N'3126163691013', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1252, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-08 08:23:46.4951259' AS DateTime2), N'81569052', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1253, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-08 08:23:47.7876004' AS DateTime2), N'81569052', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1254, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 09:38:44.3430779' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1255, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:23:33.9644051' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1256, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:23:34.6227528' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1257, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:24:46.6196632' AS DateTime2), NULL, NULL, N'nikatak1234')
GO
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1258, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:25:22.8222418' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1259, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:26:11.1580572' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1260, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:41:18.8988007' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1261, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:42:25.2035953' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1262, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 10:45:11.5615235' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1263, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-05-08 11:52:34.8981566' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1264, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-05-08 11:52:36.1915113' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1265, N'سپرده', 600, N'تبدیل شماره سپرده به شبا', CAST(N'2021-05-08 11:52:48.5679351' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1266, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-05-08 11:57:42.5086266' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1267, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-05-08 11:57:42.5086492' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1268, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-08 11:58:53.3912585' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1269, N'استعلام', 200, N'آب', CAST(N'2021-05-08 12:16:49.2514774' AS DateTime2), N'3126163691013', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1270, N'سپرده', 600, N'تبدیل شماره سپرده به شبا', CAST(N'2021-05-08 12:32:48.5779397' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1271, N'سپرده', 600, N'تبدیل شماره سپرده به شبا', CAST(N'2021-05-08 12:44:14.3702135' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1272, N'سپرده', 600, N'تبدیل شماره شبا به سپرده', CAST(N'2021-05-08 12:44:19.8856121' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1273, N'خدمات بانکی', 600, N'تبدیل شماره سپرده به شبا', CAST(N'2021-05-08 13:23:18.9869326' AS DateTime2), N'', N'', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1274, N'استعلام', 200, N'آب', CAST(N'2021-05-09 06:31:18.7544329' AS DateTime2), N'3126163691013', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1275, N'استعلام', 200, N'آب', CAST(N'2021-05-09 06:31:43.0761471' AS DateTime2), N'3126163691013', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1276, N'استعلام', 200, N'آب', CAST(N'2021-05-09 06:38:24.2747989' AS DateTime2), N'3126163691013', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1277, N'استعلام', 200, N'آب', CAST(N'2021-05-09 06:39:41.0587853' AS DateTime2), N'3126163691013', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1278, N'استعلام', 200, N'تلفن همراه', CAST(N'2021-05-09 06:42:01.4113754' AS DateTime2), N'09123580087', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1279, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-09 06:42:24.0329026' AS DateTime2), N'81569052', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1280, N'استعلام', 200, N'آب', CAST(N'2021-05-09 06:43:05.5535383' AS DateTime2), N'3126163691013', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1281, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-09 07:11:08.5536389' AS DateTime2), N'81569052', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1282, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-09 07:12:57.4157574' AS DateTime2), N'81569052', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1283, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-09 07:18:04.4187399' AS DateTime2), N'81569052', NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1284, N'عمومی', 550, N'تطبیق کدملی و شماره تلفن همراه', CAST(N'2021-05-09 07:21:19.1307738' AS DateTime2), N'2851868012', N'09149501938', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1285, N'سامانه شاهکار', 550, N'تطبیق کدملی و شماره تلفن همراه', CAST(N'2021-05-09 07:42:51.9325928' AS DateTime2), N'2851868012', N'09054113328', N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (1286, N'اعتبارسنجی', 12000, N'دریافت فاکتور', CAST(N'2021-05-09 07:46:28.1067652' AS DateTime2), NULL, NULL, N'nikatak1234')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2158, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 13:59:22.4740920' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2159, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 13:59:55.1558488' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2160, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:11:30.7384696' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2161, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:11:58.6423392' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2162, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:20:18.1904940' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2163, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:20:55.5557880' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2164, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:40:02.0571482' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2165, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:41:59.1959341' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2166, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:43:14.7312636' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2167, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:44:59.2003379' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (2168, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-11 14:47:35.5167829' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (3158, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 07:46:12.1386535' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4158, N'استعلام', 200, N'برق', CAST(N'2021-05-12 08:20:51.4345476' AS DateTime2), N'1119849901320', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4159, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:33:21.9921978' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4160, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:36:24.0368175' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4161, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:42:59.7206797' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4162, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:43:34.6436314' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4163, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:45:17.0563379' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4164, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:45:53.0339879' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4165, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:48:00.3082541' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4166, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:48:23.4857119' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4167, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:48:45.6290543' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4168, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:49:36.5533048' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4169, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 08:50:59.2880840' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4170, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 10:54:01.7001444' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4171, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 11:08:28.4054291' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4172, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 11:24:39.7263750' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4173, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 11:26:21.0579715' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4174, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 11:26:49.8126161' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4175, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 11:27:36.7833027' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4176, N'استعلام', 600, N'خلافی خودرو و موتور', CAST(N'2021-05-12 11:28:07.5713422' AS DateTime2), N'90068863', NULL, N'test')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4177, N'پرداخت قبض', 700, N'تلفن ثابت', CAST(N'2021-07-19 15:08:46.6765586' AS DateTime2), N'773931444149', N'7900362', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4178, N'پرداخت قبض', 7900, N'تلفن ثابت', CAST(N'2021-07-19 15:08:53.0423674' AS DateTime2), N'773931444149', N'7900362', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4179, N'استعلام', 500, N'استعلام شماره کارت', CAST(N'2021-07-25 09:44:40.4471194' AS DateTime2), N'6273811127106752', N'استعلام شماره کارت', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4180, N'استعلام', 500, N'تبدیل شماره کارت به شبا', CAST(N'2021-07-25 11:14:54.8698320' AS DateTime2), N'6273811127106752', N'تبدیل شماره کارت به شبا', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4181, N'استعلام', 500, N'تبدیل شماره شبا', CAST(N'2021-07-25 11:16:37.4290937' AS DateTime2), N'788639788', N'تبدیل شماره شبا', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4182, N'استعلام', 8000, N'استعلام  چک برگشتی', CAST(N'2021-07-25 11:18:54.4794865' AS DateTime2), N'2851766147', N'استعلام  چک برگشتی', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4183, N'استعلام', 8000, N'استعلام  تسهیلات', CAST(N'2021-07-25 11:19:45.6941562' AS DateTime2), N'2851766147', N'استعلام  تسهیلات', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4184, N'استعلام', 8000, N'استعلام  تسهیلات', CAST(N'2021-07-25 11:20:02.8913480' AS DateTime2), N'2851766147', N'استعلام  تسهیلات', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4185, N'استعلام', 500, N'استعلام خلافی خودرو', CAST(N'2021-07-25 11:22:36.9117257' AS DateTime2), N'101409864', N'استعلام خلافی خودرو', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4186, N'استعلام', 500, N'استعلام خلافی خودرو', CAST(N'2021-07-25 11:23:06.9391372' AS DateTime2), N'101409864', N'استعلام خلافی خودرو', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4187, N'استعلام', 500, N'استعلام نمره منفی گواهینامه', CAST(N'2021-07-25 11:23:30.2811211' AS DateTime2), N'9901347510', N'استعلام نمره منفی گواهینامه', N'Admin')
INSERT [dbo].[Tbl_Requests] ([Id], [Type_Request], [Amount], [Titel_Request], [Date_Request], [Bill_Id], [Pay_Id], [UserName]) VALUES (4188, N'احراز هویت', 2000, N'احراز هویت', CAST(N'2021-07-25 11:26:16.4256778' AS DateTime2), N'2851766147', N'احراز هویت', N'Admin')
SET IDENTITY_INSERT [dbo].[Tbl_Requests] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Slider] ON 

INSERT [dbo].[Tbl_Slider] ([Id], [TitleSlid], [CategoryIdSlid], [CategoryProductIdSlid], [TypeSlid], [ImageMainSlid], [Language]) VALUES (1, NULL, 0, 1, NULL, N'f311037d-f466-4e99-b041-0afdca7eb874.jpg', N'fa')
INSERT [dbo].[Tbl_Slider] ([Id], [TitleSlid], [CategoryIdSlid], [CategoryProductIdSlid], [TypeSlid], [ImageMainSlid], [Language]) VALUES (2, NULL, 0, 2, NULL, N'e692ee5f-d67b-438a-b045-8e53e0666478.jpg', N'fa')
INSERT [dbo].[Tbl_Slider] ([Id], [TitleSlid], [CategoryIdSlid], [CategoryProductIdSlid], [TypeSlid], [ImageMainSlid], [Language]) VALUES (3, NULL, 0, 3, NULL, N'cf67b52d-b3bf-453a-9c38-0d6e6a98b4ca.png', N'fa')
SET IDENTITY_INSERT [dbo].[Tbl_Slider] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Teaser] ON 

INSERT [dbo].[Tbl_Teaser] ([Id], [TitleTeaser], [CategoryIdTeaser], [VideoPathTeaser], [LinkVideoTeaser], [Language]) VALUES (1, N'سلام', NULL, NULL, N'8aacb7d9-a5ea-4eb6-975d-6aecd37dce50.wmv', N'fa')
INSERT [dbo].[Tbl_Teaser] ([Id], [TitleTeaser], [CategoryIdTeaser], [VideoPathTeaser], [LinkVideoTeaser], [Language]) VALUES (2, N'salam', NULL, NULL, N'e6a4d9a4-5d79-4292-b75e-3c898bf20771.mp4', N'fa')
SET IDENTITY_INSERT [dbo].[Tbl_Teaser] OFF
SET IDENTITY_INSERT [dbo].[Tbl_TokenPayGabzValues] ON 

INSERT [dbo].[Tbl_TokenPayGabzValues] ([Id], [Token], [Refresh], [LifeTime], [Scopes], [Name]) VALUES (1, N'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJtb250aGx5Q2FsbExpbWl0YXRpb24iOjEwMDAsIm1heEFtb3VudFBlclRyYW5zYWN0aW9uIjoxMDAwMDAwMCwidG9rZW5JZCI6ImFTN212WlNGZ1pTVmNxSG96Y2V2cUc0dWpqY1BDblVvIiwiY2xpZW50SWQiOiJuaWthdGFrNTI1MCIsImRlcG9zaXRzIjpbIjAyMDM2MjYyODAwMDYiXSwibGlmZVRpbWUiOjg2NDAwMDAwMCwiYmFuayI6IjA2MiIsInR5cGUiOiJDT0RFIiwiY3JlYXRpb25EYXRlIjoiMTQwMDA1MTAxODI2MzQiLCJ1c2VySWQiOiIyODUxMzI0MzU3Iiwic2NvcGVzIjpbIm9hazpiaWxsLWFjY291bnQ6ZXhlY3V0ZSJdLCJyYW5kb21VVUlEIjoieVRZeWVWc01CVDliODhIQyIsImlhdCI6MTYyNzgyNjE5NCwiZXhwIjoxNjI4NjkwMTk0fQ.ZXZ_KzgSRIoS6vZu-400CcDsJG12I5KA5g-IqbUf_gmnSLVbmu_UDvbDq8UIUEdtmDRUQk4s_q9YCod65pYayl2exuYKa_da73eFj2pjGQy4sKzzR42O6OUFT5X99ygiKf0D-tsyA0Sh1-sp9280pH_aUtNwvMiGlvGwRFNZVXAONnRX9G9kNLsP3BBin3fItrZ5nQnnP3xVJcQ4xEy0kLc-TC9SZVsQ9T5VK_yro6zBBubNxaE8j8qMUVANUvtqodXNSaYmvH7lPCxeyxls8D1nX_uInU2ZcfTa4V2z2XBEwza_zX4KgMeQNGaxkxSGmUk66Mdo62kfwvLs0mpUZg', N'nbq5LXFWbjTQ7VexX8u92kl3fdFVu7VuJi2f8IGhqKSRF6t50FqCWDKd32Qvi1pvX1dl1GBsKchk5l3i6U9Phy9iz6EctRmxohTsIL7XY82difIQ2vyFQlA2dXPXjrTz2O5K9uaBoe8FBsmc1ULAh7iIWUoDj7TUyfn4txhgIhnOKqTRP69PzvdTYwQ0jWCPcD6RqPEs3x59fl8DNiLkvLcWSkYcs6w4J6stpcgXO1SQl4qI71clAABzScD3awjT', CAST(N'2021-08-09 00:00:00.0000000' AS DateTime2), N'oak:bill-account:execute', NULL)
SET IDENTITY_INSERT [dbo].[Tbl_TokenPayGabzValues] OFF
SET IDENTITY_INSERT [dbo].[Tbl_TokenValues] ON 

INSERT [dbo].[Tbl_TokenValues] ([Id], [Token], [Refresh], [LifeTime], [Scopes], [Name]) VALUES (1, N'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbklkIjoiYjk4YWYwNWUtNGFkZC00YWY1LWI0ZGItMDRiMzY5YjVmNmRkIiwicmVmcmVzaFRva2VuIjoiRFRzZE9TaEZYaGlSZ3NqZGxDNm8wd3p0RHFHdFNuOWlyTTJRb1I4Z2dPM1RqVTc2Rm1LOE01ZVVkMUI2WWlUaGFqT0VtV0Jhc2toVEZIUVdHMHU3Y2tpa3oxbGhSTTBpUGVRWExPNHUzUERpMFVRWjJBa3RPa3NqeFlUdlhxcjFtblFYc2ZLUXNFejZNbUdPeFpZVUN1M1dsenMzQnBQTTBDcms3UlFWOWl6a1laNTJUV3hJOVRqY2FTNTNpbndpN2tHdHpxeUVKdWZqVm1HN3hMelNGYUlzRnRIZVdCbG4yNkV3d3FMNGt0bGpiZGNLcnBsS1BkSmZ3eEkwak1pTyIsImNyZWF0aW9uRGF0ZSI6IjE0MDAwNDI5MTYxMjQ0IiwibGlmZVRpbWUiOjg2NDAwMDAwMCwiY2xpZW50SWQiOiJuaWthdGFrNTI1MCIsInVzZXJJZCI6IjI4NTE4NjgwMTIiLCJhY3RpdmUiOnRydWUsInNjb3BlcyI6WyJiaWxsaW5nOmRyaXZpbmctb2ZmZW5zZS1pbnF1aXJ5OmdldCIsImJpbGxpbmc6Y2MtbmVnYXRpdmUtc2NvcmU6Z2V0IiwiYmlsbGluZzpjYy1pbnF1aXJ5LWRldGFpbDpnZXQiLCJiaWxsaW5nOmNjLWlucXVpcnk6Z2V0IiwiYmlsbGluZzpyZWdpc3RyYXRpb25zOmRlbGV0ZSIsImJpbGxpbmc6cmVnaXN0cmF0aW9uczpwdXQiLCJiaWxsaW5nOnJlZ2lzdHJhdGlvbnM6Z2V0IiwiYmlsbGluZzpyZWdpc3RyYXRpb25zOnBvc3QiLCJmYWNpbGl0eTpjYXJkLXRvLWRlcG9zaXQ6Z2V0IiwiZmFjaWxpdHk6Y2MtZGVwb3NpdC1pYmFuOmdldCIsImZhY2lsaXR5OmNjLWJhbmstaW5mbzpnZXQiLCJmYWNpbGl0eTpjYXJkLXRvLWliYW46Z2V0IiwiYm9vbXJhbmc6d2FnZXM6Z2V0IiwiYm9vbXJhbmc6dG9rZW5zOmdldCIsImJvb21yYW5nOnRva2VuOmRlbGV0ZSIsImJvb21yYW5nOnNtcy12ZXJpZnk6ZXhlY3V0ZSIsImJvb21yYW5nOnNtcy1zZW5kOmV4ZWN1dGUiLCJjcmVkaXQ6bG9hbi1pbmZvOmdldCIsImNhcmQ6aW5mb3JtYXRpb246Z2V0IiwiY2FyZDpsaXN0OmdldCJdLCJ0eXBlIjoiQ0xJRU5ULUNSRURFTlRJQUwiLCJiYW5rIjoiMDYyIiwiaWF0IjoxNjI2NzgxMzY0LCJleHAiOjE2Mjc2NDUzNjR9.lhs6mwY7KbKKx-7CAr6oeR49Y5a0hdRJUlWtYAAxTNY9bLFTIEAFs5rapvPeX6SmX3Amtmu15SxhsAKAxLd_871O15NC5V3Z1AMGT9g8zozwTDRlmIQ-9UGxeR5_p9RVzt-7VOOtyfKAQTkGeGaG-BgSMQl66S8GZdxtJmNcKHj8sf86-1KwJ8RpDoU_1VPKqPdT_5LWxFD-ug7R2bVf_8HybF6_vt1h-ll7iU9CGumRZqb-HJMUAk73C-8rdQhQHKoUWCjeP-2tmQ3Al1nKP1zPxUTQGQxEbZXWuJnm3kyXeLpLoSyvRA5oF7Cj4RGcqqFJeKpnuzaacyA1hGLI7A', N'DTsdOShFXhiRgsjdlC6o0wztDqGtSn9irM2QoR8ggO3TjU76FmK8M5eUd1B6YiThajOEmWBaskhTFHQWG0u7ckikz1lhRM0iPeQXLO4u3PDi0UQZ2AktOksjxYTvXqr1mnQXsfKQsEz6MmGOxZYUCu3Wlzs3BpPM0Crk7RQV9izkYZ52TWxI9TjcaS53inwi7kGtzqyEJufjVmG7xLzSFaIsFtHeWBln26EwwqL4ktljbdcKrplKPdJfwxI0jMiO', CAST(N'2021-07-29 00:00:00.0000000' AS DateTime2), N'billing:driving-offense-inquiry:get,billing:cc-negative-score:get,billing:cc-inquiry-detail:get,billing:cc-inquiry:get,billing:registrations:delete,billing:registrations:put,billing:registrations:get,billing:registrations:post,facility:card-to-deposit:get,facility:cc-deposit-iban:get,facility:cc-bank-info:get,facility:card-to-iban:get,boomrang:wages:get,boomrang:tokens:get,boomrang:token:delete,boomrang:sms-verify:execute,boomrang:sms-send:execute,credit:loan-info:get,card:information:get,card:list:get', NULL)
SET IDENTITY_INSERT [dbo].[Tbl_TokenValues] OFF
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (1, N'info@nikatak.ir', NULL, NULL, N'nikatak5250', NULL, NULL, NULL, N'سعید عطائی', NULL, 1)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (3, N'admin5250', N'p.nikatak@yahoo.com', N'09129727276', N'123456789', N'تهران میدان مادر', N'dfecbc55-4a2a-4236-9964-040a396f1337.png', NULL, N'هرمز عطائی', N'2851324357', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (10, N'karim', N'karim.nemati17@gmail.com', N'09374771121', N'123456', N'سلماس', N'65e22abd-e68f-44ed-92d5-0c7df0f1b9ef.jpg', NULL, N'کریم نعمتی', N'2840400324', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (11, N'test', N'tak1.ghasemi@gmail.com', N'9149501938', N'123456', N'tehran', N'91525523-f636-4881-aa02-e3cd659bc43a.png', NULL, N'', N'2851868012', 1)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (12, N'mohammad', N'user@gmail.com', N'09336192158', N'123', N'salmas', N'8cd02766-c415-422d-99ca-a4ade1c213e8.jpg', NULL, N'محمدحافظ نیا', N'284125125', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (14, N'mohammad', N'gasemi.ahad2020@gemail.com', N'09336192158', N'123', N'سلماس', N'18d3103e-7875-41e8-bc38-6dfcc363b3b2.png', NULL, N'محمدحافظ نیا', N'2840420562', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (15, N't', N'tak1.ghasemi@gmail.com', N'5555', N't', N't', N'd28dc718-025a-4a87-b7c7-593e648bbb27.png', NULL, N'ewwreerwqre', N'2851868012', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (16, N'kjjj', N'tak1.ghasemi@gmail.com', N'09149501938', N'123', N'سلماس روستا سیلاب', N'19448f6e-72ee-46b0-bd23-7be0760b1654.png', NULL, N'مجیدپاشایی', N'4744', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (17, N'tuyio', N'tak1.ghasemi@gmail.com', N'09149501938', N'123', N'سلماس روستا سیلاب', N'2c1e0be2-3e4c-401e-98fe-c20d8662bcc6.jpg', NULL, N'مجیددلایی میلان', N'۲۸۸۹۸۴۰۷۱۰', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (18, N'p[l', N'tak1.ghasemi@gmail.com', N'09149501938', N'123', N'سلماس روستا سیلاب', N'c8620211-6d5e-4cb7-bc64-277fa906fca2.jpg', NULL, N'رحیم پاشایی', N'4744', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (19, N'nika4404', N'tak1.ghasemi@gmail.com', N'09149501938', N'5555', N'پلدشت خیابان آزادی جنب بیمه ایران', N'bfeb0591-51d9-4335-bca4-ea48f45d1707.jpg', NULL, N'مجیددلایی میلان', N'۲۸۰۳۲۷۲۸۰۶', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (20, N'jnvbjfn', N'tak1.ghasemi@gmail.com', N'09149501938', N'987', N'سلماس روستا سیلاب', N'80b865d2-bcc8-4af7-961d-bcb6ede51fc7.jpg', NULL, N'مجیددلایی میلان', N'۲۸۸۹۸۴۰۷۱۰', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (21, N'zfgzfgs', N'tak1.ghasemi@gmail.com', N'09149501938', N'963', N'سلماس روستا سیلاب', N'56521d11-0d6f-4e60-8f39-a25aff758feb.jpg', NULL, N'مجیددلایی میلان', N'۲۸۸۹۸۴۰۷۱۰', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (22, N'dv s', N'tak1.ghasemi@gmail.com', N'09149501938', N'123', N'سلماس روستا سیلاب', N'565aa14d-d519-43dd-9deb-c25a80fd4b68.jpg', NULL, N'مجیدپاشایی', N'4744', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (23, N'nikatak1234', N'cpt.moh3en@gmail.com', N'09227241678', N'1234', N'سلماس', N'ab77b3cc-a9c7-46af-bb22-2d852210f357.png', NULL, N'محسن پاشایی', N'1720188408', 1)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (25, N'Admin', N'info@nikatak.ir', NULL, N'nikatak5250', N'tehran', NULL, NULL, N'مدیریت', N'2851868012', 1)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (27, N'nikatak123', N'aaa@gmail.com', N'0393', N'123', N'sls', NULL, NULL, N'test', N'147', 1)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (28, N'bimekosar', N'tak1.ghasemi@gmail.com', N'09149501938', N'bime5250', N'تهران', N'1f870b0a-2191-45a2-aa4e-6b54cfe69193.png', NULL, N'مجید مجیدی', N'2851868011', 0)
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
SET IDENTITY_INSERT [dbo].[Tbl_UserPersenel] ON 

INSERT [dbo].[Tbl_UserPersenel] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (3, N'karim', N'karim.nemati17@gmail.com', N'09375887791', N'123456', N'سلماس', N'38fef371-2d21-4221-a0ce-26a14eeea06a.jpg', NULL, N'کریم', N'2840600359', 0)
INSERT [dbo].[Tbl_UserPersenel] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (4, N'karimali', N'karim.nemati17@gmail.com', N'0255545454', N'123456', N'سلماس', N'cb4f562f-96ed-43b5-aa1b-0b1fff7bb8ff.jpg', NULL, N'کریم', N'284045632585', 0)
INSERT [dbo].[Tbl_UserPersenel] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (5, N'rahim', N'tak1.ghasemi@gmail.com', N'09149501938', N'12345', N']lvhk', N'fd91962d-a3bd-4d85-8240-e5de6dde78dd.png', NULL, N'رحیم  قاسمی', N'2851868012', 0)
INSERT [dbo].[Tbl_UserPersenel] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (6, N'admin', N'tak1.ghasemi@gmail.com', N'09149501937', N'123', N'سلماس', N'710fe0ae-4931-410d-bc03-f4754c5ce1d1.png', NULL, N'احد', N'2851868012', 0)
INSERT [dbo].[Tbl_UserPersenel] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (7, N'44444444444', N'tak1.ghasemi@gmail.com', N'44444444444', N'4444', N'ایران سلماس', N'8b0cfe33-a703-4adb-a723-ef1c3551d497.png', NULL, N'رحیم  قاسمی', N'44444444444', 0)
INSERT [dbo].[Tbl_UserPersenel] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (8, N'hampadصص', N'tak1.hasemi@gmail.com', N'09149501930', N'44', N'ایران سلماس', N'969cb62a-b6e4-4dd6-88e2-ba602aac076d.png', NULL, N'رحیم  قاسمی', N'28518680100', 0)
INSERT [dbo].[Tbl_UserPersenel] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (9, N'MAJID', N'tak2.ghasemi@gmail.com', N'09214351340', N'123', N'خوی', N'a6031e28-3b79-41d0-92bf-d1db9525e9ae.png', NULL, N'مجید ', N'1720188403', 0)
SET IDENTITY_INSERT [dbo].[Tbl_UserPersenel] OFF
ALTER TABLE [dbo].[Tbl_Comments] ADD  DEFAULT ((0)) FOR [blog_id]
GO
ALTER TABLE [dbo].[Tbl_Comments] ADD  DEFAULT ((0)) FOR [product_id]
GO
ALTER TABLE [dbo].[Tbl_Comments] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateComment]
GO
ALTER TABLE [dbo].[Tbl_Order] ADD  DEFAULT ((0)) FOR [Id_user]
GO
ALTER TABLE [dbo].[Tbl_Order] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Date_Order]
GO
USE [master]
GO
ALTER DATABASE [nikatek_db] SET  READ_WRITE 
GO
