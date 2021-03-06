USE [BDCompany]
GO
/****** Object:  Table [dbo].[Shopping]    Script Date: 17/08/2021 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Amount] [float] NULL,
	[IdentificatorOfMoney] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/08/2021 17:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Names] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Shopping] ON 

INSERT [dbo].[Shopping] ([Id], [UserId], [Amount], [IdentificatorOfMoney]) VALUES (1, 1, 2.0779220779220777, N'Dolar')
INSERT [dbo].[Shopping] ([Id], [UserId], [Amount], [IdentificatorOfMoney]) VALUES (2, 1, 11.220779220779221, N'Real')
INSERT [dbo].[Shopping] ([Id], [UserId], [Amount], [IdentificatorOfMoney]) VALUES (3, 1, 2.0779220779220777, N'Dolar')
SET IDENTITY_INSERT [dbo].[Shopping] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Names], [LastName], [Email]) VALUES (1, N'Anthony Jesus ', N'Portilla Cano', N'anthony-nek22@hotmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Shopping]  WITH CHECK ADD  CONSTRAINT [FK_Users_Shopping] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Shopping] CHECK CONSTRAINT [FK_Users_Shopping]
GO
