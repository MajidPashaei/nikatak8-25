USE [master]
GO
/****** Object:  Database [nikatek_db]    Script Date: 01/04/2021 11:10:02 ق.ظ ******/
CREATE DATABASE [nikatek_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'nikatek_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\nikatek_db.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'nikatek_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\nikatek_db_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/04/2021 11:10:04 ق.ظ ******/
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
/****** Object:  Table [dbo].[tb_GalleryProducts]    Script Date: 01/04/2021 11:10:04 ق.ظ ******/
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
/****** Object:  Table [dbo].[tb_ImageGalleries]    Script Date: 01/04/2021 11:10:04 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Adress]    Script Date: 01/04/2021 11:10:04 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Agencie]    Script Date: 01/04/2021 11:10:04 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Baner]    Script Date: 01/04/2021 11:10:04 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[tbl_category]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Comments]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Experts]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Factors]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Financial]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Gallery]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_infos]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
 CONSTRAINT [PK_Tbl_infos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Logo]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Message]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Order]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Originality]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Product]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Richats]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Slider]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_SocialNetwork]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_Teaser]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 01/04/2021 11:10:05 ق.ظ ******/
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
SET IDENTITY_INSERT [dbo].[tbl_category] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Experts] ON 

INSERT [dbo].[Tbl_Experts] ([Id], [NameEx], [ImageEx], [TelEx], [OfficeTelEx], [LocationEx], [AboutEx], [Language], [address]) VALUES (1, N'حسن محمدی', N'f8fa79fb-3ba6-4e56-9493-b4101db35dcf.jpg', N'09647995321', N'04432598765', N'37.71721439387317,45.010755425037075', N'<div class="ql-editor ql-blank" data-gramm="false" contenteditable="true"><p class="ql-align-right">تستتستتستتستتستتستتستتستتستتستتستتست</p><p class="ql-align-right">تست</p><p class="ql-align-right">تستتستتست</p><p class="ql-align-right">تستتست</p><p class="ql-align-right">تستتستتستتست</p><p class="ql-align-right">تستتستتست</p><p class="ql-align-right">تستتست</p><p class="ql-align-right">تستتست</p></div><div class="ql-clipboard" tabindex="-1" contenteditable="true"></div><div class="ql-tooltip ql-hidden"><a class="ql-preview" target="_blank" href="about:blank"></a><input type="text" data-formula="e=mc^2" data-link="https://quilljs.com" data-video="Embed URL"><a class="ql-action"></a><a class="ql-remove"></a></div>', N'fa', N'تهران')
SET IDENTITY_INSERT [dbo].[Tbl_Experts] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Gallery] ON 

INSERT [dbo].[Tbl_Gallery] ([Id], [TitleGal], [pathImage], [Language]) VALUES (1, N'nikatek', N'9535fe97-e88c-4b8d-b437-f6c37efa6e65.jpg', N'fa')
SET IDENTITY_INSERT [dbo].[Tbl_Gallery] OFF
SET IDENTITY_INSERT [dbo].[Tbl_infos] ON 

INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (9, N'کریم', N'نعمتی', NULL, NULL, NULL, N'Nemati', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'04435236987', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'karim')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'saber')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'hampad')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'nikatak')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (13, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sajadrezaei1997')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'mahmoud abdolazizzadhe
')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Gerash')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (16, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Narges.mgh
')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (17, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'zahra1362')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'morteza. haji')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (19, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'mahsa. z')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Mahmudzm52')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (21, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Leilashadab')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (22, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'jafar karimpoor')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (23, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Siamak.alizadeh')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Reza30')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (25, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Sara30')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (26, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2889840719')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (27, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Hamed')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (28, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'nikatakraha')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (29, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'p197351h')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (30, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'rahimdalaiemilan')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (31, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'mohammad')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (32, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'vahed5793')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (33, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'karim')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (34, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Rezagholami05')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (35, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Rana20')
INSERT [dbo].[Tbl_infos] ([Id], [Nameper], [Familyper], [Fathernameper], [NationalCode], [Nameen], [Familyen], [Fathernameen], [Place], [Serial], [Religion], [Email], [Gender], [maritalstatus], [Bankname], [Bankcode], [Branchname], [Accounttype], [cardnumber], [Shabanumber], [accountnumber], [AccountName], [PostalcodeBank], [Address], [Phone], [PhoneHome], [PhonelocationN], [PhoneNikatak], [State], [City], [Postalcode], [homeaddress], [Locationaddress], [DiplomDate], [DiplomLocation], [KardaniDate], [KardaniLocation], [KarshenasiDate], [KarshenasiLocation], [ArshadDate], [ArshadLocation], [DoktoraDate], [DoktoraLocation], [photos], [Nationalcard], [Nationalcardback], [Certificate], [Shaba], [Degreeeducation], [PostalcodeDoc], [Document], [Badbackground], [Receipt], [Companyname], [start], [End], [Typeactivity], [Day], [Mont], [Yers], [UserNameId]) VALUES (36, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'yusof')
SET IDENTITY_INSERT [dbo].[Tbl_infos] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Slider] ON 

INSERT [dbo].[Tbl_Slider] ([Id], [TitleSlid], [CategoryIdSlid], [CategoryProductIdSlid], [TypeSlid], [ImageMainSlid], [Language]) VALUES (1, NULL, 0, 1, NULL, N'f311037d-f466-4e99-b041-0afdca7eb874.jpg', N'fa')
INSERT [dbo].[Tbl_Slider] ([Id], [TitleSlid], [CategoryIdSlid], [CategoryProductIdSlid], [TypeSlid], [ImageMainSlid], [Language]) VALUES (2, NULL, 0, 2, NULL, N'e692ee5f-d67b-438a-b045-8e53e0666478.jpg', N'fa')
INSERT [dbo].[Tbl_Slider] ([Id], [TitleSlid], [CategoryIdSlid], [CategoryProductIdSlid], [TypeSlid], [ImageMainSlid], [Language]) VALUES (3, NULL, 0, 3, NULL, N'cf67b52d-b3bf-453a-9c38-0d6e6a98b4ca.png', N'fa')
SET IDENTITY_INSERT [dbo].[Tbl_Slider] OFF
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (1, N'info@nikatak.ir', NULL, NULL, N'nikatak5250', NULL, NULL, NULL, N'سعید عطایی', NULL, 1)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (2, N'admin', NULL, N'09920648677', N'nikatak5250', N'تهران', N'a624dd41-b43b-4910-a9fc-b00f01bbcbb8.png', N'fa', N'سعید عطایی', NULL, 1)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (3, NULL, N'p.nikatak@yahoo.com', N'09129727276', N'123456789', N'تهران میدان مادر', N'dfecbc55-4a2a-4236-9964-040a396f1337.png', NULL, N'هرمز عطائی', N'2851324357', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (4, NULL, N'sabrpryzad@gmail.com', N'۰۹۱۴۹۷۵۶۵۹۳', N'3542saber', N'آذربایجان غربی نقده', N'edbdc110-abe3-43a3-990e-c7942e6e1e64.jpg', NULL, N'صابر پری زاد', N'۲۹۰۹۶۸۷۴۰۶', 0)
INSERT [dbo].[Tbl_User] ([Id], [UserNameUs], [EmailUS], [PhoneUs], [PasswordUs], [AddressUs], [ProfileImageUs], [Language], [NameFamily], [CodeMeli], [state]) VALUES (10, N'karim', N'karim.nemati17@gmail.com', N'09374771121', N'123456', N'سلماس', N'65e22abd-e68f-44ed-92d5-0c7df0f1b9ef.jpg', NULL, N'کریم نعمتی', N'2840400324', 0)
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
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
