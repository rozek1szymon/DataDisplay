USE [SR_Test]
GO
/****** Object:  Table [dbo].[AcceptingPeople]    Script Date: 4/29/2019 2:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcceptingPeople](
	[ACP_ID] [int] IDENTITY(1,1) NOT NULL,
	[ACP_Category] [nvarchar](max) NOT NULL,
	[ACP_Login] [nvarchar](max) NOT NULL,
	[ACP_Limit] [decimal](18, 2) NOT NULL,
	[ACP_SubstituteLogin] [nvarchar](max) NULL,
	[ACP_SubstituteLimit] [decimal](18, 2) NULL,
 CONSTRAINT [PK_AcceptingPeople] PRIMARY KEY CLUSTERED 
(
	[ACP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/29/2019 2:49:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ORG_ID] [int] IDENTITY(1,1) NOT NULL,
	[ORG_Name] [nvarchar](max) NOT NULL,
	[ORG_Login] [nvarchar](max) NOT NULL,
	[ORG_ManagerID] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ORG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AcceptingPeople] ON 

INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (1, N'Gastronomia', N'konrad1', CAST(700.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (2, N'Gastronomia', N'mateusz1', CAST(700.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (3, N'Gastronomia', N'Maciek2', CAST(700.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (4, N'Gastronomia', N'wojtek1', CAST(700.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (5, N'Wyjscia', N'konrad1', CAST(1000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (6, N'Wyjscia', N'mateusz1', CAST(1000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (7, N'Wyjscia', N'Maciek2', CAST(1000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (8, N'Wyjscia', N'wojtek1', CAST(1000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (9, N'Gastronomia', N'kacper1', CAST(2000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (10, N'Gastronomia', N'kuba1', CAST(2000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (11, N'Gastronomia', N'eryka1', CAST(2000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (12, N'Wyjscia', N'kacper1', CAST(2500.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (13, N'Wyjscia', N'kuba1', CAST(2500.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (14, N'Wyjscia', N'eryka1', CAST(2500.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (15, N'Sprzet', N'kacper1', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (16, N'Sprzet', N'kuba1', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (17, N'Sprzet', N'eryka1', CAST(3000.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (18, N'Gastronomia', N'patryk1', CAST(3000.00 AS Decimal(18, 2)), N'Jan1', CAST(2300.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (19, N'Wyjscia', N'patryk1', CAST(5000.00 AS Decimal(18, 2)), N'Jan1', CAST(3000.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (20, N'Sprzet', N'patryk1', CAST(5000.00 AS Decimal(18, 2)), N'Jan1', CAST(3500.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (21, N'Oprogramowanie', N'patryk1', CAST(7000.00 AS Decimal(18, 2)), N'Jan1', CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (22, N'Gastronomia', N'simon1', CAST(1000000.00 AS Decimal(18, 2)), N'maciek1', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (23, N'Wyjscia', N'simon1', CAST(1000000.00 AS Decimal(18, 2)), N'maciek1', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (24, N'Sprzet', N'simon1', CAST(1000000.00 AS Decimal(18, 2)), N'maciek1', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (25, N'Oprogramowanie', N'simon1', CAST(1000000.00 AS Decimal(18, 2)), N'maciek1', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[AcceptingPeople] ([ACP_ID], [ACP_Category], [ACP_Login], [ACP_Limit], [ACP_SubstituteLogin], [ACP_SubstituteLimit]) VALUES (26, N'Wyjscia', N'patryk1', CAST(5000.00 AS Decimal(18, 2)), N'marcin1', CAST(3100.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[AcceptingPeople] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (4, N'Szymon', N'simon1', NULL)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (5, N'Maciek', N'maciek1', 4)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (6, N'Patryk', N'patryk1', 4)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (7, N'Kacper', N'kacper1', 6)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (8, N'Kuba', N'kuba1', 6)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (9, N'Eryka', N'eryka1', 6)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (10, N'Konrad', N'konrad1', 7)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (11, N'Mateusz', N'mateusz1', 7)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (12, N'Maciek', N'Maciek2', 8)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (13, N'Wojtek', N'wojtek1', 9)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (14, N'Pracownik', N'pracownik1', 10)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (15, N'Pracownik', N'pracownik2', 10)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (16, N'Pracownik', N'pracownik3', 11)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (17, N'Pracownik', N'pracownik4', 11)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (18, N'Pracownik', N'pracownik5', 12)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (19, N'Pracownik', N'pracownik6', 12)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (20, N'Pracownik', N'pracownik7', 12)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (21, N'Pracownik', N'pracownik8', 12)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (22, N'Pracownik', N'pracownik9', 13)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (23, N'Pracownik', N'pracownik10', 13)
INSERT [dbo].[Employees] ([ORG_ID], [ORG_Name], [ORG_Login], [ORG_ManagerID]) VALUES (24, N'Pracownik', N'pracownik11', 13)

SET IDENTITY_INSERT [dbo].[Employees] OFF
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees_ORG_ManagerID] FOREIGN KEY([ORG_ManagerID])
REFERENCES [dbo].[Employees] ([ORG_ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees_ORG_ManagerID]
GO
