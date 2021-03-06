USE [ARohilaDatabase]
GO
/****** Object:  Table [dbo].[tblAdvertisement]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblArea]    Script Date: 06-05-2015 14:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblArea](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [varchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_tblArea\] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 06-05-2015 14:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address] [varchar](1000) NOT NULL,
	[AreaId] [int] NOT NULL,
	[EmailAddress] [varchar](100) NULL,
	[MobileNo] [nchar](10) NOT NULL,
	[Latitude] [varchar](200) NULL,
	[Longitude] [varchar](200) NULL,
	[TotalOrderAmount] [float] NOT NULL,
	[RecievedAmount] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[RegisterDeviceId] [int] NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomerPayment]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDeliveryCharges]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDeviceType]    Script Date: 06-05-2015 14:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDeviceType](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[DeviceType] [varchar](50) NULL,
 CONSTRAINT [PK_tblDeviceType] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLanguage]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLanguageWiseProduct]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 06-05-2015 14:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLogin](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[MobileNo] [varchar](50) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[CreationDatetime] [datetime] NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RegisterDeviceId] [int] NOT NULL,
 CONSTRAINT [PK_tblLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOrderItems]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProductPrice]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblQuantityType]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblState]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSubCategory]    Script Date: 06-05-2015 14:11:43 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserType]    Script Date: 06-05-2015 14:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
 CONSTRAINT [PK_tblUserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblArea] ON 

INSERT [dbo].[tblArea] ([AreaId], [AreaName], [CityId], [StateId], [Description]) VALUES (1, N'Kadodara', 1, 1, N'This is kadodara')
SET IDENTITY_INSERT [dbo].[tblArea] OFF
SET IDENTITY_INSERT [dbo].[tblCity] ON 

INSERT [dbo].[tblCity] ([CityId], [CityName], [StateId]) VALUES (1, N'Surat', 1)
SET IDENTITY_INSERT [dbo].[tblCity] OFF
SET IDENTITY_INSERT [dbo].[tblCustomer] ON 

INSERT [dbo].[tblCustomer] ([CustomerId], [UserId], [FirstName], [LastName], [Address], [AreaId], [EmailAddress], [MobileNo], [Latitude], [Longitude], [TotalOrderAmount], [RecievedAmount], [IsActive], [IsDeleted], [CreationDateTime], [RegisterDeviceId]) VALUES (1, 1, N'Anuj', N'Rohila', N'D-10', 1, N'anuj.rohila94@gmail.com', N'9510292597', N'111111', N'111111', 0, 0, 1, 0, CAST(0x0000A52D00AA49C0 AS DateTime), NULL)
INSERT [dbo].[tblCustomer] ([CustomerId], [UserId], [FirstName], [LastName], [Address], [AreaId], [EmailAddress], [MobileNo], [Latitude], [Longitude], [TotalOrderAmount], [RecievedAmount], [IsActive], [IsDeleted], [CreationDateTime], [RegisterDeviceId]) VALUES (2, 3, N'sada', N'sada', N'', 1, N'asda', N'8510292597', N'asd', N'aasd', 0, 0, 1, 0, CAST(0x0000A48400D1F705 AS DateTime), NULL)
INSERT [dbo].[tblCustomer] ([CustomerId], [UserId], [FirstName], [LastName], [Address], [AreaId], [EmailAddress], [MobileNo], [Latitude], [Longitude], [TotalOrderAmount], [RecievedAmount], [IsActive], [IsDeleted], [CreationDateTime], [RegisterDeviceId]) VALUES (3, 4, N'dsf', N'dsf', N'dsf', 1, N'sdf', N'sdf       ', N'sdf', N'sdf', 0, 0, 1, 0, CAST(0x0000A48400D2861B AS DateTime), NULL)
INSERT [dbo].[tblCustomer] ([CustomerId], [UserId], [FirstName], [LastName], [Address], [AreaId], [EmailAddress], [MobileNo], [Latitude], [Longitude], [TotalOrderAmount], [RecievedAmount], [IsActive], [IsDeleted], [CreationDateTime], [RegisterDeviceId]) VALUES (4, 5, N'fg', N'fg', N'dfg', 1, N'dfg@gmail.com', N'972403333 ', N'fdgfdg', N'dfg', 0, 0, 1, 0, CAST(0x0000A484010C38D9 AS DateTime), NULL)
INSERT [dbo].[tblCustomer] ([CustomerId], [UserId], [FirstName], [LastName], [Address], [AreaId], [EmailAddress], [MobileNo], [Latitude], [Longitude], [TotalOrderAmount], [RecievedAmount], [IsActive], [IsDeleted], [CreationDateTime], [RegisterDeviceId]) VALUES (5, 6, N'dfs', N'dfs', N'sdf', 1, N'dsdf@gmail.com', N'dsf       ', N'dsf', N'sdf', 0, 0, 1, 0, CAST(0x0000A4840119C231 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tblCustomer] OFF
SET IDENTITY_INSERT [dbo].[tblDeviceType] ON 

INSERT [dbo].[tblDeviceType] ([DeviceId], [DeviceType]) VALUES (1, N'Web')
INSERT [dbo].[tblDeviceType] ([DeviceId], [DeviceType]) VALUES (2, N'Android')
INSERT [dbo].[tblDeviceType] ([DeviceId], [DeviceType]) VALUES (3, N'Iphone')
INSERT [dbo].[tblDeviceType] ([DeviceId], [DeviceType]) VALUES (4, N'Windows Phone')
SET IDENTITY_INSERT [dbo].[tblDeviceType] OFF
SET IDENTITY_INSERT [dbo].[tblLogin] ON 

INSERT [dbo].[tblLogin] ([UserId], [MobileNo], [UserTypeId], [CreationDatetime], [Password], [IsActive], [RegisterDeviceId]) VALUES (1, N'9510292597', 2, CAST(0x0000A12500B12790 AS DateTime), N'MTIzNDU2', 1, 2)
INSERT [dbo].[tblLogin] ([UserId], [MobileNo], [UserTypeId], [CreationDatetime], [Password], [IsActive], [RegisterDeviceId]) VALUES (2, N'8510292597', 2, CAST(0x0000A48400D1C50B AS DateTime), N'YXNkYQ==', 1, 1)
INSERT [dbo].[tblLogin] ([UserId], [MobileNo], [UserTypeId], [CreationDatetime], [Password], [IsActive], [RegisterDeviceId]) VALUES (3, N'8510292597', 2, CAST(0x0000A48400D1ED03 AS DateTime), N'YXNkYQ==', 1, 1)
INSERT [dbo].[tblLogin] ([UserId], [MobileNo], [UserTypeId], [CreationDatetime], [Password], [IsActive], [RegisterDeviceId]) VALUES (4, N'sdf', 2, CAST(0x0000A48400D28601 AS DateTime), N'c2RzZGY=', 1, 1)
INSERT [dbo].[tblLogin] ([UserId], [MobileNo], [UserTypeId], [CreationDatetime], [Password], [IsActive], [RegisterDeviceId]) VALUES (5, N'972403333', 2, CAST(0x0000A484010C388E AS DateTime), N'c2Rm', 1, 1)
INSERT [dbo].[tblLogin] ([UserId], [MobileNo], [UserTypeId], [CreationDatetime], [Password], [IsActive], [RegisterDeviceId]) VALUES (6, N'dsf', 2, CAST(0x0000A4840119C20F AS DateTime), N'ZHNm', 1, 1)
SET IDENTITY_INSERT [dbo].[tblLogin] OFF
SET IDENTITY_INSERT [dbo].[tblState] ON 

INSERT [dbo].[tblState] ([StateId], [StateName]) VALUES (1, N'Gujarat')
SET IDENTITY_INSERT [dbo].[tblState] OFF
SET IDENTITY_INSERT [dbo].[tblUserType] ON 

INSERT [dbo].[tblUserType] ([UserTypeId], [TypeName]) VALUES (1, N'Admin')
INSERT [dbo].[tblUserType] ([UserTypeId], [TypeName]) VALUES (2, N'Customer')
INSERT [dbo].[tblUserType] ([UserTypeId], [TypeName]) VALUES (3, N'Supplier')
SET IDENTITY_INSERT [dbo].[tblUserType] OFF
