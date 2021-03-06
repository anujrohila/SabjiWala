USE [OrderManagment]
GO
/****** Object:  Table [dbo].[TblAddressMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblAddressMaster](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](50) NULL,
	[CustomerID] [int] NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblAddressMaster] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblAdminLoginMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblAdminLoginMaster](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[DisplayName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[EmailID] [varchar](50) NULL,
	[AdminProfile] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblAdminLoginMaster] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblBillMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBillMaster](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[AddressID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblBillMaster] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblCategoryMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblCategoryMaster](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[CategoryImage] [varchar](50) NULL,
	[LanguageID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblCategoryMaster] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblCustomerCreditMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCustomerCreditMaster](
	[CustomerCreditID] [int] IDENTITY(1,1) NOT NULL,
	[FinalAmount] [int] NULL,
	[OrderAmount] [int] NULL,
	[CreditAmount] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblCustomerCreditMaster] PRIMARY KEY CLUSTERED 
(
	[CustomerCreditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblCustomerDeviceMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblCustomerDeviceMaster](
	[CustomerDeviceID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[DeviceTypeID] [int] NULL,
	[DeviceToken] [varchar](50) NULL,
	[DeviceKey] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblDeviceMaster] PRIMARY KEY CLUSTERED 
(
	[CustomerDeviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblCustomerMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblCustomerMaster](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[UserID] [int] NULL,
	[DisplayName] [varchar](10) NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[LanguageID] [int] NULL,
	[ConformationCode] [int] NULL,
	[CustomerDeviceID] [int] NULL,
	[CustomerStatusID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblCustomerMaster] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblCustomerPaymentDetailMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblCustomerPaymentDetailMaster](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[CustomerID] [int] NULL,
	[CreditDateTime] [datetime] NULL,
	[Amount] [float] NULL,
	[ReceivedPersonName] [varchar](50) NULL,
	[EmployeeID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblCustomerCreditAmountMaster] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblCustomerStatusMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblCustomerStatusMaster](
	[CustomerStatusID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerStatus] [varchar](50) NULL,
	[StatusDescription] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblCustomerStatusMaster] PRIMARY KEY CLUSTERED 
(
	[CustomerStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblDeviceTypeMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblDeviceTypeMaster](
	[DeviceTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceName] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblDeviceTypeMaster] PRIMARY KEY CLUSTERED 
(
	[DeviceTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblEmployeeMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblEmployeeMaster](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](50) NULL,
	[EmployeeTypeID] [int] NULL,
	[Address] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblEmployeeMaster] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblEmployeeTypeMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblEmployeeTypeMaster](
	[EmployeeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeType] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblEmployeeTypeMaster] PRIMARY KEY CLUSTERED 
(
	[EmployeeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblLanguageMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblLanguageMaster](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblLanguageMaster] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblOrderItemDetailMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderItemDetailMaster](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [float] NULL,
	[Price] [float] NULL,
	[Discount] [float] NULL,
	[TotalAmount] [float] NULL,
	[ProductStatusID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblOrderItemIdMaster] PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderMaster](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[AddressID] [int] NULL,
	[OrderStatusID] [int] NULL,
	[OrderDateTime] [datetime] NULL,
	[EmployeeID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblOrderMaster] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderStatusMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblOrderStatusMaster](
	[OrderStatusID] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatus] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblOrderStatusMaster] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblProductMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblProductMaster](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryID] [int] NULL,
	[CategoryID] [int] NULL,
	[ProductName] [varchar](50) NULL,
	[ProductImage] [varchar](50) NULL,
	[ProductPrice] [float] NULL,
	[ProductDiscount] [float] NULL,
	[LanguageID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblProductMaster] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblProductStatusMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblProductStatusMaster](
	[ProductStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ProductStatus] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblStatusMaster] PRIMARY KEY CLUSTERED 
(
	[ProductStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblSubCategoryMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblSubCategoryMaster](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [varchar](50) NULL,
	[SubCategoryImage] [varchar](50) NULL,
	[CategoryID] [int] NULL,
	[LanguageID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblSubCategoryMaster] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblSupplierDeviceMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblSupplierDeviceMaster](
	[SupplierDeviceID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[DeviceTypeID] [int] NULL,
	[DeviceToken] [varchar](50) NULL,
	[DeviceKey] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblSupplierDeviceMaster] PRIMARY KEY CLUSTERED 
(
	[SupplierDeviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblSupplierMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblSupplierMaster](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[UserID] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[OrganizationName] [varchar](50) NULL,
	[LanguageID] [int] NULL,
	[EmailID] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[SupplierDeviceID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblSupplierMaster] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblTerm&ConditionMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblTerm&ConditionMaster](
	[ConditionID] [int] IDENTITY(1,1) NOT NULL,
	[ConditionSubject] [varchar](50) NULL,
	[ConditionDetail] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblTeam&ConditionMaster] PRIMARY KEY CLUSTERED 
(
	[ConditionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblTypeMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblTypeMaster](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
 CONSTRAINT [PK_TblTypeMaster] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblUserLoginMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblUserLoginMaster](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[TypeID] [int] NULL,
	[ConformationCode] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblUserLoginMaster] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblUserLogMaster]    Script Date: 12-04-2015 10:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserLogMaster](
	[UserLogID] [int] IDENTITY(1,1) NOT NULL,
	[IPAddress] [int] NULL,
	[LoginTimeDate] [datetime] NULL,
	[LogoutTimeDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TblUserLogMaster] PRIMARY KEY CLUSTERED 
(
	[UserLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TblAddressMaster] ON 

INSERT [dbo].[TblAddressMaster] ([AddressID], [Address], [CustomerID], [Longitude], [Latitude], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'A-4/76 shubham residency', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblAddressMaster] ([AddressID], [Address], [CustomerID], [Longitude], [Latitude], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'Akash Anklev ,VIP Road ,Surat', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblAddressMaster] ([AddressID], [Address], [CustomerID], [Longitude], [Latitude], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (3, N'Krishna Soc.,Vrachha Road, SURAT', 1006, NULL, NULL, NULL, NULL, NULL, CAST(N'2015-04-08 16:50:10.750' AS DateTime), NULL, NULL)
INSERT [dbo].[TblAddressMaster] ([AddressID], [Address], [CustomerID], [Longitude], [Latitude], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (8, N'A-78 Janki Villa,Simada Naka,Surat', 1006, NULL, NULL, NULL, CAST(N'2015-04-08 17:17:54.917' AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblAddressMaster] OFF
SET IDENTITY_INSERT [dbo].[TblAdminLoginMaster] ON 

INSERT [dbo].[TblAdminLoginMaster] ([AdminID], [AdminName], [Password], [DisplayName], [Address], [MobileNo], [EmailID], [AdminProfile], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'8155877', N'janki123', N'Janvi', N'A-4/404 Shubham residency', N'9876732478', N'lotus.j7@gmail.com', N'20150323082626.png', NULL, NULL, 8155877, CAST(N'2015-03-23 08:26:26.103' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblAdminLoginMaster] OFF
SET IDENTITY_INSERT [dbo].[TblCategoryMaster] ON 

INSERT [dbo].[TblCategoryMaster] ([CategoryID], [CategoryName], [CategoryImage], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'Fruit', N'20150407140505.jpg', NULL, 8155877, CAST(N'2015-03-11 14:18:51.917' AS DateTime), 8155877, CAST(N'2015-04-07 14:05:05.237' AS DateTime), NULL, 1)
INSERT [dbo].[TblCategoryMaster] ([CategoryID], [CategoryName], [CategoryImage], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'Vegetable', N'20150407140424.jpg', NULL, 8155877, CAST(N'2015-03-11 14:20:39.923' AS DateTime), 8155877, CAST(N'2015-04-07 14:04:24.497' AS DateTime), NULL, 1)
INSERT [dbo].[TblCategoryMaster] ([CategoryID], [CategoryName], [CategoryImage], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (5, N'Fast Food', N'20150407140552.jpg', NULL, 8155877, CAST(N'2015-03-12 14:05:32.097' AS DateTime), 8155877, CAST(N'2015-04-07 14:05:52.820' AS DateTime), NULL, 1)
INSERT [dbo].[TblCategoryMaster] ([CategoryID], [CategoryName], [CategoryImage], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (6, N'Grocery&Stable', N'20150313153639.jpg', NULL, 8155877, CAST(N'2015-03-13 15:36:39.627' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblCategoryMaster] OFF
SET IDENTITY_INSERT [dbo].[TblCustomerMaster] ON 

INSERT [dbo].[TblCustomerMaster] ([CustomerID], [CustomerName], [Password], [UserID], [DisplayName], [FirstName], [MiddleName], [LastName], [EmailId], [LanguageID], [ConformationCode], [CustomerDeviceID], [CustomerStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'8764763662', N'ravipatel', 8, N'Ravi Patel', N'Patel', N'RaviKumar', N'Dayabhai', N'ravi@gmail.com', 2, NULL, NULL, NULL, 8155877, CAST(N'2015-03-11 17:13:38.117' AS DateTime), 8155877, CAST(N'2015-03-23 08:25:01.360' AS DateTime), NULL, 1)
INSERT [dbo].[TblCustomerMaster] ([CustomerID], [CustomerName], [Password], [UserID], [DisplayName], [FirstName], [MiddleName], [LastName], [EmailId], [LanguageID], [ConformationCode], [CustomerDeviceID], [CustomerStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'8893898882', N'jjkk123', 1016, N'nidhiPatel', N'patel', N'nidhi', N'hasubhai', N'nidhi@gmail.com', 2, NULL, NULL, NULL, 8155877, CAST(N'2015-03-23 09:45:49.277' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblCustomerMaster] ([CustomerID], [CustomerName], [Password], [UserID], [DisplayName], [FirstName], [MiddleName], [LastName], [EmailId], [LanguageID], [ConformationCode], [CustomerDeviceID], [CustomerStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1002, N'988787875', N'RaviPatel', NULL, N'Ravina', N'patel', N'ravikumar', N'Dayabhai', N'ravikumar909@gmail.com', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblCustomerMaster] ([CustomerID], [CustomerName], [Password], [UserID], [DisplayName], [FirstName], [MiddleName], [LastName], [EmailId], [LanguageID], [ConformationCode], [CustomerDeviceID], [CustomerStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1005, N'988787875', N'ravi', NULL, N'Ravina', N'patel', N'asdfgg', N'sdfg', N'dzsxfgcgv', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblCustomerMaster] ([CustomerID], [CustomerName], [Password], [UserID], [DisplayName], [FirstName], [MiddleName], [LastName], [EmailId], [LanguageID], [ConformationCode], [CustomerDeviceID], [CustomerStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1006, N'9867775664', N'janvi123', 2014, N'JanviPatel', N'khunt', N'janvi', N'kurjibhai', N'janvi12@gmail.com', NULL, NULL, NULL, NULL, NULL, CAST(N'2015-04-03 14:06:53.977' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblCustomerMaster] ([CustomerID], [CustomerName], [Password], [UserID], [DisplayName], [FirstName], [MiddleName], [LastName], [EmailId], [LanguageID], [ConformationCode], [CustomerDeviceID], [CustomerStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1007, N'9874746420', N'ravu123', 2016, N'Ravina', N'patel', N'ravii', N'dayabhaiii', N'ravi123@gmail.com', NULL, NULL, NULL, NULL, NULL, CAST(N'2015-04-03 14:26:35.897' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblCustomerMaster] OFF
SET IDENTITY_INSERT [dbo].[TblEmployeeMaster] ON 

INSERT [dbo].[TblEmployeeMaster] ([EmployeeID], [EmployeeName], [EmployeeTypeID], [Address], [FirstName], [MiddleName], [LastName], [EmailId], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (3, N'4568999925', 1, N'gghfgh', N'patel', N'Kajal', N'mavjibhai', N'kajal@gmail.com', 8155877, CAST(N'2015-03-11 17:19:13.020' AS DateTime), 8155877, CAST(N'2015-03-14 17:09:10.903' AS DateTime), NULL, 1)
INSERT [dbo].[TblEmployeeMaster] ([EmployeeID], [EmployeeName], [EmployeeTypeID], [Address], [FirstName], [MiddleName], [LastName], [EmailId], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (4, N'7627765656', 2, N'fgfhgfgh', N'patel', N'ravi', N'dayabhai', N'ravi@gmail.com', 8155877, CAST(N'2015-03-12 00:49:30.430' AS DateTime), 8155877, CAST(N'2015-03-15 11:44:10.750' AS DateTime), NULL, 1)
INSERT [dbo].[TblEmployeeMaster] ([EmployeeID], [EmployeeName], [EmployeeTypeID], [Address], [FirstName], [MiddleName], [LastName], [EmailId], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (7, N'8726762625', 2, N'hghjghj', N'hghgh', N'ghjghj', N'ghjgjh', N'kajal12@gmail.com', 8155877, CAST(N'2015-03-12 01:35:38.427' AS DateTime), 8155877, CAST(N'2015-03-15 23:40:18.657' AS DateTime), NULL, 1)
INSERT [dbo].[TblEmployeeMaster] ([EmployeeID], [EmployeeName], [EmployeeTypeID], [Address], [FirstName], [MiddleName], [LastName], [EmailId], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1010, N'9839840000', 1, N'A-4 setu residency', N'patel', N'nidhi', N'Hasubhai', N'nidhi99@gmail.com', 8155877, CAST(N'2015-03-23 09:47:26.737' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblEmployeeMaster] OFF
SET IDENTITY_INSERT [dbo].[TblEmployeeTypeMaster] ON 

INSERT [dbo].[TblEmployeeTypeMaster] ([EmployeeTypeID], [EmployeeType], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'Ravi', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblEmployeeTypeMaster] ([EmployeeTypeID], [EmployeeType], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'Sunny', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblEmployeeTypeMaster] ([EmployeeTypeID], [EmployeeType], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (3, N'Kajal', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblEmployeeTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[TblLanguageMaster] ON 

INSERT [dbo].[TblLanguageMaster] ([LanguageID], [Language], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'Gujarati', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblLanguageMaster] ([LanguageID], [Language], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'English', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblLanguageMaster] ([LanguageID], [Language], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (3, N'Hindi', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblLanguageMaster] OFF
SET IDENTITY_INSERT [dbo].[TblOrderItemDetailMaster] ON 

INSERT [dbo].[TblOrderItemDetailMaster] ([OrderItemID], [OrderID], [ProductID], [Quantity], [Price], [Discount], [TotalAmount], [ProductStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (17, 4, 1, 2, 30, 0, 60, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblOrderItemDetailMaster] ([OrderItemID], [OrderID], [ProductID], [Quantity], [Price], [Discount], [TotalAmount], [ProductStatusID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (19, 4, 5, 5, 10, 0, 50, 2, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblOrderItemDetailMaster] OFF
SET IDENTITY_INSERT [dbo].[TblOrderMaster] ON 

INSERT [dbo].[TblOrderMaster] ([OrderID], [CustomerID], [AddressID], [OrderStatusID], [OrderDateTime], [EmployeeID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (4, 1, 1, 1, CAST(N'2015-03-21 00:00:00.000' AS DateTime), 3, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblOrderMaster] OFF
SET IDENTITY_INSERT [dbo].[TblOrderStatusMaster] ON 

INSERT [dbo].[TblOrderStatusMaster] ([OrderStatusID], [OrderStatus], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'Panding', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblOrderStatusMaster] ([OrderStatusID], [OrderStatus], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'Deliver', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblOrderStatusMaster] ([OrderStatusID], [OrderStatus], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (3, N'process', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblOrderStatusMaster] OFF
SET IDENTITY_INSERT [dbo].[TblProductMaster] ON 

INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, 2, 1, N'Banana', N'20150403145727.jpg', 54, 0, NULL, 8155877, CAST(N'2015-03-11 14:23:45.243' AS DateTime), 8155877, CAST(N'2015-04-03 16:32:47.293' AS DateTime), NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (5, 12, 2, N'Coriander', N'20150403145710.jpg', 40, 0, NULL, 8155877, CAST(N'2015-03-12 15:11:19.797' AS DateTime), 8155877, CAST(N'2015-04-03 16:32:36.123' AS DateTime), NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (6, 14, 2, N'Brinjal', N'20150403145757.jpg', 40, 0, NULL, 8155877, CAST(N'2015-04-03 14:57:57.220' AS DateTime), 8155877, CAST(N'2015-04-03 16:32:57.073' AS DateTime), NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (7, 2, 1, N'Apple', N'20150403163129.jpg', 100, 0, NULL, 8155877, CAST(N'2015-04-03 16:31:29.657' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (8, 15, 2, N'Red cabbage', N'20150403163224.jpg', 50, 2, NULL, 8155877, CAST(N'2015-04-03 16:32:24.023' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (9, 14, 2, N'Onion', N'20150403163339.jpg', 50, 0, NULL, 8155877, CAST(N'2015-04-03 16:33:39.143' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (10, 16, 1, N'Dragan Fruit', N'20150403163419.jpg', 100, 0, NULL, 8155877, CAST(N'2015-04-03 16:34:19.530' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (11, 2, 1, N'Mask melon', N'20150403163512.jpg', 60, 2, NULL, 8155877, CAST(N'2015-04-03 16:35:12.753' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (12, 15, 2, N'Potato', N'20150403163554.jpg', 35, 2, NULL, 8155877, CAST(N'2015-04-03 16:35:54.130' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblProductMaster] ([ProductID], [SubCategoryID], [CategoryID], [ProductName], [ProductImage], [ProductPrice], [ProductDiscount], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (13, 2, 1, N'Mango', N'20150403163655.jpg', 120, 0, NULL, 8155877, CAST(N'2015-04-03 16:36:55.900' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblProductMaster] OFF
SET IDENTITY_INSERT [dbo].[TblProductStatusMaster] ON 

INSERT [dbo].[TblProductStatusMaster] ([ProductStatusID], [ProductStatus], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'Available', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblProductStatusMaster] ([ProductStatusID], [ProductStatus], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'Not Available', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblProductStatusMaster] OFF
SET IDENTITY_INSERT [dbo].[TblSubCategoryMaster] ON 

INSERT [dbo].[TblSubCategoryMaster] ([SubCategoryID], [SubCategoryName], [SubCategoryImage], [CategoryID], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'common fruit', N'20150403144255.jpg', 1, NULL, 8155877, CAST(N'2015-03-11 14:22:53.427' AS DateTime), 8155877, CAST(N'2015-04-03 14:42:55.857' AS DateTime), NULL, 1)
INSERT [dbo].[TblSubCategoryMaster] ([SubCategoryID], [SubCategoryName], [SubCategoryImage], [CategoryID], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (12, N'Leafy Vegetable', N'20150403144328.jpg', 2, NULL, 8155877, CAST(N'2015-03-12 01:03:27.877' AS DateTime), 8155877, CAST(N'2015-04-03 14:43:28.743' AS DateTime), NULL, 1)
INSERT [dbo].[TblSubCategoryMaster] ([SubCategoryID], [SubCategoryName], [SubCategoryImage], [CategoryID], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (14, N'common vegetable', N'20150403145339.jpg', 2, NULL, 8155877, CAST(N'2015-04-03 14:53:39.153' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblSubCategoryMaster] ([SubCategoryID], [SubCategoryName], [SubCategoryImage], [CategoryID], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (15, N'Exotic Vegetable', N'20150403145454.jpg', 2, NULL, 8155877, CAST(N'2015-04-03 14:54:54.480' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblSubCategoryMaster] ([SubCategoryID], [SubCategoryName], [SubCategoryImage], [CategoryID], [LanguageID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (16, N'Exotic Fruit', N'20150403145543.jpeg', 1, NULL, 8155877, CAST(N'2015-04-03 14:55:43.163' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblSubCategoryMaster] OFF
SET IDENTITY_INSERT [dbo].[TblSupplierMaster] ON 

INSERT [dbo].[TblSupplierMaster] ([SupplierID], [SupplierName], [Password], [UserID], [FirstName], [MiddleName], [LastName], [OrganizationName], [LanguageID], [EmailID], [Address], [Longitude], [Latitude], [SupplierDeviceID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2, N'9887765654', N'janki', 7, N'Khunt', N'janvi', N'kurjibhai', N'janki Infotech', 2, N'janki@gmail.com', N'hhaggertt', NULL, NULL, NULL, 8155877, CAST(N'2015-03-11 17:11:33.637' AS DateTime), 8155877, CAST(N'2015-03-11 17:12:08.560' AS DateTime), NULL, NULL)
INSERT [dbo].[TblSupplierMaster] ([SupplierID], [SupplierName], [Password], [UserID], [FirstName], [MiddleName], [LastName], [OrganizationName], [LanguageID], [EmailID], [Address], [Longitude], [Latitude], [SupplierDeviceID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (3, N'6276876478', N'ravikhumar', 11, N'patel', N'ravikumar', N'dayabhai', N'hgjghj', 2, N'janki121@gmail.com', N'dfggvddfgh', NULL, NULL, NULL, 8155877, CAST(N'2015-03-12 16:09:43.783' AS DateTime), 8155877, CAST(N'2015-03-23 08:23:55.750' AS DateTime), NULL, 1)
INSERT [dbo].[TblSupplierMaster] ([SupplierID], [SupplierName], [Password], [UserID], [FirstName], [MiddleName], [LastName], [OrganizationName], [LanguageID], [EmailID], [Address], [Longitude], [Latitude], [SupplierDeviceID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (4, N'5678909855', N'kajal123', 12, N'patel', N'kajal', N'mavjibhai', N'kajallllll', 2, N'kajal24@gmail.com', N'gfghfghfg', NULL, NULL, NULL, 8155877, CAST(N'2015-03-14 11:24:00.237' AS DateTime), 8155877, CAST(N'2015-03-23 08:24:23.210' AS DateTime), NULL, 1)
INSERT [dbo].[TblSupplierMaster] ([SupplierID], [SupplierName], [Password], [UserID], [FirstName], [MiddleName], [LastName], [OrganizationName], [LanguageID], [EmailID], [Address], [Longitude], [Latitude], [SupplierDeviceID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (5, N'9858884933', N'jkjk', 1014, N'patel', N'nidhi', N'hasmukbhai', N'nidhi shopss', 1, N'nidhi@gmail.com', N'A-2 setu residency', NULL, NULL, NULL, 8155877, CAST(N'2015-03-23 08:30:55.937' AS DateTime), 8155877, CAST(N'2015-03-23 08:35:19.283' AS DateTime), NULL, 1)
INSERT [dbo].[TblSupplierMaster] ([SupplierID], [SupplierName], [Password], [UserID], [FirstName], [MiddleName], [LastName], [OrganizationName], [LanguageID], [EmailID], [Address], [Longitude], [Latitude], [SupplierDeviceID], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (6, N'9288749332', N'kjkj999', 1017, N'nbkbfb,mbm', N'     vvf  ', N'ssdfsfdsfd', N'sdsssfdsfdsfdsf', 2, N'ddsjfds@dj.com', N'sdifuhfdhfhdfh ughgf hdhdfh hfdfdhfhdh ghfdhj jhjd', NULL, NULL, NULL, 8155877, CAST(N'2015-03-23 11:55:36.687' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblSupplierMaster] OFF
SET IDENTITY_INSERT [dbo].[TblTypeMaster] ON 

INSERT [dbo].[TblTypeMaster] ([TypeID], [TypeName]) VALUES (1, N'Suppiler')
INSERT [dbo].[TblTypeMaster] ([TypeID], [TypeName]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[TblTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[TblUserLoginMaster] ON 

INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1, N'janki', N'janki', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (5, N'2345678888', N'gggg', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (6, N'8678676767', N'asdffdd', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (7, N'9887765654', N'janki', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (8, N'8764763662', N'Ravi', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (9, N'1234567890', N'asd', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (10, N'8155877', N'janki123', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (11, N'8738748732', N'khunt', 1, NULL, 8155877, CAST(N'2015-03-12 16:08:47.537' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (12, N'5678909855', N'kajal', 1, NULL, 8155877, CAST(N'2015-03-14 11:23:12.757' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (13, N'7627848777', N'jajja', 2, NULL, 8155877, CAST(N'2015-03-15 23:54:51.383' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (14, N'7287837787', N'sddd', 2, NULL, 8155877, CAST(N'2015-03-15 23:55:04.540' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1013, N'9875300033', N'jkjkjk', 1, NULL, 8155877, CAST(N'2015-03-23 08:29:49.463' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1014, N'9858884933', N'jkjk', 1, NULL, 8155877, CAST(N'2015-03-23 08:30:06.163' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1015, N'9238787722', N'kjkjk', 2, NULL, 8155877, CAST(N'2015-03-23 08:36:03.927' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1016, N'8893898882', N'jjkk123', 2, NULL, 8155877, CAST(N'2015-03-23 09:45:11.057' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (1017, N'9288749332', N'kjkj999', 1, NULL, 8155877, CAST(N'2015-03-23 11:53:55.520' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2013, N'9887476535', N'janu123', NULL, NULL, NULL, CAST(N'2015-04-03 14:00:00.770' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2014, N'9867775664', N'janvi123', NULL, NULL, NULL, CAST(N'2015-04-03 14:05:10.217' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2015, N'9877666532', N'kaju123', NULL, NULL, NULL, CAST(N'2015-04-03 14:17:03.937' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TblUserLoginMaster] ([UserID], [UserName], [Password], [TypeID], [ConformationCode], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime], [IsDeleted], [IsActive]) VALUES (2016, N'9874746420', N'ravu123', NULL, NULL, NULL, CAST(N'2015-04-03 14:25:45.927' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TblUserLoginMaster] OFF
ALTER TABLE [dbo].[TblOrderItemDetailMaster]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderItemDetailMaster_TblOrderMaster] FOREIGN KEY([OrderID])
REFERENCES [dbo].[TblOrderMaster] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblOrderItemDetailMaster] CHECK CONSTRAINT [FK_TblOrderItemDetailMaster_TblOrderMaster]
GO
ALTER TABLE [dbo].[TblSubCategoryMaster]  WITH CHECK ADD  CONSTRAINT [FK_TblSubCategoryMaster_TblCategoryMaster] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[TblCategoryMaster] ([CategoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSubCategoryMaster] CHECK CONSTRAINT [FK_TblSubCategoryMaster_TblCategoryMaster]
GO
ALTER TABLE [dbo].[TblSupplierMaster]  WITH CHECK ADD  CONSTRAINT [FK_TblSupplierMaster_TblLanguageMaster] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[TblLanguageMaster] ([LanguageID])
GO
ALTER TABLE [dbo].[TblSupplierMaster] CHECK CONSTRAINT [FK_TblSupplierMaster_TblLanguageMaster]
GO
