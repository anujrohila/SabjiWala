USE [master]
GO
/****** Object:  Database [SabjiWala]    Script Date: 04/22/2015 09:45:52 ******/
CREATE DATABASE [SabjiWala] ON  PRIMARY 
( NAME = N'SabjiWala', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.ANUJSQLSERVER\MSSQL\DATA\SabjiWala.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SabjiWala_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.ANUJSQLSERVER\MSSQL\DATA\SabjiWala_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SabjiWala] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SabjiWala].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SabjiWala] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SabjiWala] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SabjiWala] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SabjiWala] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SabjiWala] SET ARITHABORT OFF
GO
ALTER DATABASE [SabjiWala] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SabjiWala] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SabjiWala] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SabjiWala] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SabjiWala] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SabjiWala] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SabjiWala] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SabjiWala] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SabjiWala] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SabjiWala] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SabjiWala] SET  DISABLE_BROKER
GO
ALTER DATABASE [SabjiWala] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SabjiWala] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SabjiWala] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SabjiWala] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SabjiWala] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SabjiWala] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SabjiWala] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SabjiWala] SET  READ_WRITE
GO
ALTER DATABASE [SabjiWala] SET RECOVERY FULL
GO
ALTER DATABASE [SabjiWala] SET  MULTI_USER
GO
ALTER DATABASE [SabjiWala] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SabjiWala] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SabjiWala', N'ON'
GO
USE [SabjiWala]
GO
/****** Object:  Table [dbo].[tblSubCategory]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSubCategory](
	[SubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[SubCategoryName] [varchar](100) NOT NULL,
	[Description] [varchar](5000) NOT NULL,
	[Logo] [varchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_tblSubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblState]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblState](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblQuantityType]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuantityType](
	[QuantityTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblQuantityType] PRIMARY KEY CLUSTERED 
(
	[QuantityTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProductPrice]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductPrice](
	[PriceId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CityId] [int] NULL,
	[OldPrice] [float] NULL,
	[NewPrice] [float] NULL,
	[CreationDateTime] [datetime] NULL,
	[UpdationDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblProductPrice] PRIMARY KEY CLUSTERED 
(
	[PriceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[QuantityTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrderItems]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderItems](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_tblOrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDateTime] [datetime] NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[OrderAmount] [float] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DeliveryCharges] [float] NOT NULL,
	[OtherCharges] [float] NOT NULL,
	[CustomerMessage] [varchar](5000) NULL,
	[OverMessage] [varchar](5000) NULL,
 CONSTRAINT [PK_tblOrder] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLanguageWiseProduct]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLanguageWiseProduct](
	[RowId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[LanguageId] [int] NULL,
	[ProductName] [varchar](100) NULL,
	[Description] [varchar](5000) NULL,
 CONSTRAINT [PK_tblLanguageWiseProduct] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLanguage]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLanguage](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [varchar](50) NULL,
	[Description] [varchar](5000) NULL,
 CONSTRAINT [PK_tblLanguage] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDeliveryCharges]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDeliveryCharges](
	[DeliveryChargesId] [int] IDENTITY(1,1) NOT NULL,
	[StartAmount] [float] NOT NULL,
	[EndAmount] [float] NOT NULL,
	[Charges] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tblDeliveryCharges] PRIMARY KEY CLUSTERED 
(
	[DeliveryChargesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomerPayment]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerPayment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[Amount] [float] NOT NULL,
	[RecievedBy] [int] NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tblCustomerPayment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address] [varchar](1000) NOT NULL,
	[CityId] [int] NOT NULL,
	[EmailAddress] [varchar](100) NULL,
	[MobileNo] [nchar](10) NOT NULL,
	[Latitude] [varchar](200) NULL,
	[Longitude] [varchar](200) NULL,
	[TotalOrderAmount] [float] NOT NULL,
	[RecievedAmount] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[RegisterDeviceFrom] [int] NOT NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCity](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_tblCity] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](100) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[Description] [varchar](5000) NOT NULL,
	[Logo] [varbinary](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblArea]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblArea](
	[AreaId] [int] NOT NULL,
	[AreaName] [varchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_tblArea\] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAdvertisement]    Script Date: 04/22/2015 09:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAdvertisement](
	[AdvertisementId] [int] IDENTITY(1,1) NOT NULL,
	[AdvertisementName] [varchar](500) NULL,
	[CompanyName] [varchar](100) NULL,
	[Description] [varchar](5000) NULL,
	[Weblink] [varchar](500) NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreationDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblAdvertisement] PRIMARY KEY CLUSTERED 
(
	[AdvertisementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
