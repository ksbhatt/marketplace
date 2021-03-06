USE [master]
GO
/****** Object:  Database [Sample 1]    Script Date: 10/04/2021 12:34:38 PM ******/
CREATE DATABASE [Sample 1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sample 1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\Sample 1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sample 1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\Sample 1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Sample 1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sample 1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sample 1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sample 1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sample 1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sample 1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sample 1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sample 1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sample 1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sample 1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sample 1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sample 1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sample 1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sample 1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sample 1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sample 1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sample 1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sample 1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sample 1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sample 1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sample 1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sample 1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sample 1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sample 1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sample 1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Sample 1] SET  MULTI_USER 
GO
ALTER DATABASE [Sample 1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sample 1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sample 1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sample 1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sample 1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sample 1] SET QUERY_STORE = OFF
GO
USE [Sample 1]
GO
/****** Object:  Table [dbo].[contact_us]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact_us](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[EmailID] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](50) NULL,
	[Comments] [nvarchar](200) NULL,
 CONSTRAINT [PK_contact_us] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Countrycode] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Downloads]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Downloads](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[Seller] [int] NOT NULL,
	[Downloader] [int] NOT NULL,
	[IsSellerHasAllowedDownload] [bit] NOT NULL,
	[AttachmentPath] [nvarchar](max) NULL,
	[IsAttachmentDownloaded] [bit] NOT NULL,
	[AttachmentDownloadedDate] [datetime] NULL,
	[IsPaid] [bit] NOT NULL,
	[PurchasedPrice] [decimal](18, 0) NULL,
	[NoteTitle] [nvarchar](100) NOT NULL,
	[NoteCategory] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[Email] [nvarchar](50) NOT NULL,
	[SellType] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Downloads] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoteCategories]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoteCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_NoteCategories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoteTypes]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoteTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_NoteTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReferenceData]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
	[DataValue] [nvarchar](100) NOT NULL,
	[RefCategory] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ReferenceData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotes]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SellerID] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[ActionedBy] [int] NULL,
	[AdminRemarks] [nvarchar](max) NULL,
	[PublishedDate] [datetime] NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Category] [int] NOT NULL,
	[NoteType] [int] NULL,
	[NumberOfPages] [int] NULL,
	[Description] [nvarchar](50) NOT NULL,
	[UniversityName] [nvarchar](200) NULL,
	[Country] [nvarchar](50) NULL,
	[Course] [nvarchar](100) NULL,
	[CourseCode] [nvarchar](100) NULL,
	[Professor] [nvarchar](100) NULL,
	[IsPaid] [bit] NOT NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayPicture] [nvarchar](max) NULL,
	[NotePreview] [nvarchar](max) NULL,
	[DisplayNote] [nvarchar](max) NULL,
	[AttachmentSize] [nvarchar](50) NULL,
	[NoOfDownloads] [int] NULL,
 CONSTRAINT [PK_SellerNotes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotesAttachments]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotesAttachments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SellerNotesAttachments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotesReportedIssues]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotesReportedIssues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[ReportedByID] [int] NOT NULL,
	[AgainstDownloadID] [int] NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModofiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_SellerNotesReportedIssues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotesReviews]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotesReviews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[ReviewedByID] [int] NOT NULL,
	[AgainstDownloadsID] [int] NOT NULL,
	[Ratings] [decimal](18, 0) NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SellerNotesReviews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfigurations]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfigurations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupportEmailAddress] [nvarchar](100) NOT NULL,
	[SupportPhoneNumber] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[FacebookURL] [nvarchar](50) NULL,
	[TwitterURL] [nvarchar](50) NULL,
	[LinkedInURL] [nvarchar](50) NULL,
 CONSTRAINT [PK_SystemConfigurations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmailID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RememberMe] [bit] NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DOB] [date] NULL,
	[Gender] [int] NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[AddressLine1] [nvarchar](100) NOT NULL,
	[AddressLine2] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Zipcode] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[University] [nvarchar](100) NULL,
	[College] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[CountryCode] [nvarchar](50) NULL,
	[SecondaryEmailAddress] [nvarchar](50) NULL,
	[ProfilePicture] [nvarchar](500) NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/04/2021 12:34:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailID] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](24) NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[ResetPasswordCode] [nvarchar](100) NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[CountryCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[contact_us] ON 

INSERT [dbo].[contact_us] ([ID], [Name], [EmailID], [Subject], [Comments]) VALUES (1017, N'Khyati Patel', N'khyatipatel@gmail.com', N'Not able to buy', N'I am not able to buy the book')
SET IDENTITY_INSERT [dbo].[contact_us] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([ID], [Name], [Countrycode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, N'India', N'1', CAST(N'2020-02-10T00:00:00.000' AS DateTime), N'1', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Countries] ([ID], [Name], [Countrycode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (9, N'America', N'2', CAST(N'2020-02-10T00:00:00.000' AS DateTime), N'1', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Downloads] ON 

INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Email], [SellType], [Number]) VALUES (18, 84, 1020, 1021, 1, N'kanan.pdf', 1, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1, CAST(180 AS Decimal(18, 0)), N'Demo Title', N'IT', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, N'khyati@gmail.com', N'free', 1)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Email], [SellType], [Number]) VALUES (19, 85, 1021, 1022, 0, N'kanan.pdf', 0, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 0, CAST(120 AS Decimal(18, 0)), N'Demo Title 2 ', N'Computer', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, N'rahul@gmail.com', N'paid', 2)
SET IDENTITY_INSERT [dbo].[Downloads] OFF
GO
SET IDENTITY_INSERT [dbo].[NoteCategories] ON 

INSERT [dbo].[NoteCategories] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (12, N'IT', N'IT Desctiption demo', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'1020', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, 1)
INSERT [dbo].[NoteCategories] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (13, N'Computer', N'Computer Description', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'1021', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, 1)
INSERT [dbo].[NoteCategories] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (14, N'Science', N'Science Description Demo', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'1022', CAST(N'2020-11-03T00:00:00.000' AS DateTime), 1022, 1)
INSERT [dbo].[NoteCategories] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (15, N'History', N'History Description Demo', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'1023', CAST(N'2020-11-01T00:00:00.000' AS DateTime), 1023, 1)
INSERT [dbo].[NoteCategories] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (16, N'Account', N'Account Description', CAST(N'2020-12-03T00:00:00.000' AS DateTime), N'1024', CAST(N'2020-12-03T00:00:00.000' AS DateTime), 1024, 1)
SET IDENTITY_INSERT [dbo].[NoteCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[NoteTypes] ON 

INSERT [dbo].[NoteTypes] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, N'val1', N'val1 type description demo', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'1020', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, 1)
INSERT [dbo].[NoteTypes] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (9, N'val2', N'val2 type description demo ', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'1021', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, 1)
INSERT [dbo].[NoteTypes] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (10, N'val3', N'val3 type description demo', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'1022', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1022, 1)
INSERT [dbo].[NoteTypes] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (11, N'val4', N'val4 type description', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'1023', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1023, 1)
INSERT [dbo].[NoteTypes] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (12, N'val5', N'val5 tpe description demo', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'1024', CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1024, 1)
SET IDENTITY_INSERT [dbo].[NoteTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[SellerNotes] ON 

INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (79, 1020, 1, 1024, N'5 User marked this note as inappropriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Human Body', 12, 8, 24, N'Lorem ipsum is simply dummy text', N'GTU', N'India', N'Medical', N'002', N'Proff', 1, CAST(180.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, 1, N'1.jpg', NULL, N'kanan.pdf', N'103kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (82, 1021, 0, 1025, N'5 User marked to be inappopriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Accounting', 13, 9, 24, N'Demo Text Description', N'Nirma', N'India', N'Accounts', N'003', N'Prof,', 1, CAST(120.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1023, 1, N'2.jpg', NULL, N'kanan.pdf', N'201kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (83, 1020, 1, 1024, N'5 User marked this note as inappropriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Human Body', 12, 8, 24, N'Lorem ipsum is simply dummy text', N'GTU', N'India', N'Medical', N'002', N'Proff', 1, CAST(180.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, 1, N'1.jpg', NULL, N'kanan.pdf', N'103kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (84, 1021, 0, 1025, N'5 User marked to be inappopriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Accounting', 13, 9, 24, N'Demo Text Description', N'Nirma', N'India', N'Accounts', N'003', N'Prof,', 1, CAST(120.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1023, 1, N'2.jpg', NULL, N'kanan.pdf', N'201kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (85, 1020, 1, 1024, N'5 User marked this note as inappropriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Human Body', 12, 8, 24, N'Lorem ipsum is simply dummy text', N'GTU', N'India', N'Medical', N'002', N'Proff', 1, CAST(180.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, 1, N'1.jpg', NULL, N'kanan.pdf', N'103kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (86, 1021, 0, 1025, N'5 User marked to be inappopriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Accounting', 13, 9, 24, N'Demo Text Description', N'Nirma', N'India', N'Accounts', N'003', N'Prof,', 1, CAST(120.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1023, 1, N'2.jpg', NULL, N'kanan.pdf', N'201kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (87, 1020, 2, 1024, N'5 User marked this note as inappropriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Human Body', 12, 8, 24, N'Lorem ipsum is simply dummy text', N'GTU', N'India', N'Medical', N'002', N'Proff', 1, CAST(180.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, 1, N'1.jpg', NULL, N'kanan.pdf', N'103kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (88, 1021, 0, 1025, N'5 User marked to be inappopriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Accounting', 13, 9, 24, N'Demo Text Description', N'Nirma', N'India', N'Accounts', N'003', N'Prof,', 1, CAST(120.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1023, 1, N'2.jpg', NULL, N'kanan.pdf', N'201kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (89, 1020, 1, 1024, N'5 User marked this note as inappropriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Human Body', 12, 8, 24, N'Lorem ipsum is simply dummy text', N'GTU', N'India', N'Medical', N'002', N'Proff', 1, CAST(180.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1020, 1, N'1.jpg', NULL, N'kanan.pdf', N'103kb', 20)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [DisplayPicture], [NotePreview], [DisplayNote], [AttachmentSize], [NoOfDownloads]) VALUES (90, 1021, 2, 1025, N'5 User marked to be inappopriate', CAST(N'2020-11-03T00:00:00.000' AS DateTime), N'Accounting', 13, 9, 24, N'Demo Text Description', N'Nirma', N'India', N'Accounts', N'003', N'Prof,', 1, CAST(120.00 AS Decimal(18, 2)), CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1021, CAST(N'2020-10-03T00:00:00.000' AS DateTime), 1023, 1, N'2.jpg', NULL, N'kanan.pdf', N'201kb', 20)
SET IDENTITY_INSERT [dbo].[SellerNotes] OFF
GO
SET IDENTITY_INSERT [dbo].[SellerNotesReportedIssues] ON 

INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModofiedDate], [ModifiedBy]) VALUES (36, 84, 1020, 18, N'Not good', CAST(N'2020-10-04T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-04T00:00:00.000' AS DateTime), 1020)
INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModofiedDate], [ModifiedBy]) VALUES (37, 85, 1021, 19, N'Not good', CAST(N'2020-10-04T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-04T00:00:00.000' AS DateTime), 1020)
INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModofiedDate], [ModifiedBy]) VALUES (39, 86, 1021, 19, N'Not good', CAST(N'2020-10-04T00:00:00.000' AS DateTime), 1020, CAST(N'2020-10-04T00:00:00.000' AS DateTime), 1020)
SET IDENTITY_INSERT [dbo].[SellerNotesReportedIssues] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemConfigurations] ON 

INSERT [dbo].[SystemConfigurations] ([ID], [SupportEmailAddress], [SupportPhoneNumber], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [EmailAddress], [FacebookURL], [TwitterURL], [LinkedInURL]) VALUES (5, N'notesmarketplace@gmail.com', N'7777777777', CAST(N'2020-09-02T00:00:00.000' AS DateTime), 1020, CAST(N'2020-09-02T00:00:00.000' AS DateTime), 1020, 1, N'marketplace@gmail.com', N'facebook.com', N'twitter.com', N'linkedin.com')
SET IDENTITY_INSERT [dbo].[SystemConfigurations] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [PhoneNumber], [AddressLine1], [AddressLine2], [City], [State], [Zipcode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [CountryCode], [SecondaryEmailAddress], [ProfilePicture]) VALUES (65, 1020, CAST(N'1999-08-02' AS Date), 1, N'9999999999', N'Hill', N'Drive', N'Bhavnagar', N'Gujarat', N'364001', N'India', N'GTU', N'GEC', CAST(N'2020-10-09T00:00:00.000' AS DateTime), 1, CAST(N'2020-10-09T00:00:00.000' AS DateTime), 1, N'2', N'khyati@gmail.com', N'customer-1.jpg')
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [PhoneNumber], [AddressLine1], [AddressLine2], [City], [State], [Zipcode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [CountryCode], [SecondaryEmailAddress], [ProfilePicture]) VALUES (66, 1021, CAST(N'1998-03-01' AS Date), 1, N'8888888888', N'Area Name', N'Secondary Address Line 2 Demo', N'Ahmedaabas', N'Gujarat', N'364002', N'India', N'Nirma', N'Nirma', CAST(N'2020-11-03T00:00:00.000' AS DateTime), 1, CAST(N'2020-11-03T00:00:00.000' AS DateTime), 1, N'2', N'rahuls@gmail.com', N'customer-1.jpg')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'user', N'all access', CAST(N'2021-04-10T00:00:00.000' AS DateTime), 1, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[UserRoles] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'admin', N'dashboard access', CAST(N'2021-04-10T00:00:00.000' AS DateTime), 1, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [ResetPasswordCode], [PhoneNo], [CountryCode]) VALUES (1020, 1, N'Khyati', N'Patel', N'khyatipatel@gmail.com', N'khyati', 1, CAST(N'2020-10-09T00:00:00.000' AS DateTime), 1, CAST(N'2020-10-09T00:00:00.000' AS DateTime), 1, 1, N'98', N'9898989898', N'1')
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [ResetPasswordCode], [PhoneNo], [CountryCode]) VALUES (1021, 1, N'Rahul', N'Shah', N'rahulshah@gmail.com', N'rahul', 1, CAST(N'2020-10-11T00:00:00.000' AS DateTime), 1, CAST(N'2020-10-11T00:00:00.000' AS DateTime), 1, 1, N'89', N'9999999999', N'2')
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [ResetPasswordCode], [PhoneNo], [CountryCode]) VALUES (1022, 1, N'Suman', N'Trivedi', N'suman@gmail.com', N'suman', 1, CAST(N'2020-10-11T00:00:00.000' AS DateTime), 1, CAST(N'2020-10-11T00:00:00.000' AS DateTime), 1, 1, N'95', N'8888888888', N'2')
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [ResetPasswordCode], [PhoneNo], [CountryCode]) VALUES (1023, 1, N'Raj', N'Malhotra', N'rahul@gmail.com', N'raj', 1, CAST(N'2020-10-12T00:00:00.000' AS DateTime), 1, CAST(N'2020-10-12T00:00:00.000' AS DateTime), 1, 1, N'65', N'6666666666', N'2')
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [ResetPasswordCode], [PhoneNo], [CountryCode]) VALUES (1024, 1, N'Niya', N'Patel', N'niya@gmail.com', N'niya', 1, CAST(N'2020-10-13T00:00:00.000' AS DateTime), 1, CAST(N'2020-10-13T00:00:00.000' AS DateTime), 1, 1, N'54', N'5555555555', N'2')
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [ResetPasswordCode], [PhoneNo], [CountryCode]) VALUES (1025, 2, N'Admin', N'Surname', N'admin@gmail.com', N'admin', 1, CAST(N'2020-10-13T00:00:00.000' AS DateTime), 1, CAST(N'2020-10-13T00:00:00.000' AS DateTime), 1, 1, N'41', N'2222222222', N'2')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [DF_Countries_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[NoteCategories] ADD  CONSTRAINT [DF_NoteCategories_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[NoteTypes] ADD  CONSTRAINT [DF_NoteTypes_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ReferenceData] ADD  CONSTRAINT [DF_ReferenceData_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SellerNotes] ADD  CONSTRAINT [DF_SellerNotes_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SellerNotesAttachments] ADD  CONSTRAINT [DF_SellerNotesAttachments_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SellerNotesReviews] ADD  CONSTRAINT [DF_SellerNotesReviews_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SystemConfigurations] ADD  CONSTRAINT [DF_SystemConfigurations_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsEmailVerified]  DEFAULT ((0)) FOR [IsEmailVerified]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_SellerNotes]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Users] FOREIGN KEY([Seller])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Users]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Users1] FOREIGN KEY([Downloader])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Users1]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_NoteCategories] FOREIGN KEY([Category])
REFERENCES [dbo].[NoteCategories] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_NoteCategories]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_NoteTypes] FOREIGN KEY([NoteType])
REFERENCES [dbo].[NoteTypes] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_NoteTypes]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_Users] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_Users]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_Users1] FOREIGN KEY([ActionedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_Users1]
GO
ALTER TABLE [dbo].[SellerNotesAttachments]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesAttachments_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesAttachments] CHECK CONSTRAINT [FK_SellerNotesAttachments_SellerNotes]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_Downloads] FOREIGN KEY([AgainstDownloadID])
REFERENCES [dbo].[Downloads] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_Downloads]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_SellerNotes]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_Users] FOREIGN KEY([ReportedByID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_Users]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_Downloads] FOREIGN KEY([AgainstDownloadsID])
REFERENCES [dbo].[Downloads] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_Downloads]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_SellerNotes]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_Users] FOREIGN KEY([ReviewedByID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_Users]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_Users1] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_Users1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[UserRoles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRoles]
GO
USE [master]
GO
ALTER DATABASE [Sample 1] SET  READ_WRITE 
GO
