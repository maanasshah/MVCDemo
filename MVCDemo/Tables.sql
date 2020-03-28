USE [TestDB]
GO

/****** Object:  Table [dbo].[Transaction]    Script Date: 27/03/2020 7:48:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Payee] [nvarchar](50) NOT NULL,
	[Amount] [float] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[Memo] [nvarchar](150) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Transaction1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


------------------------------------------------------------------

USE [TestDB]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 27/03/2020 7:49:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


------------------------------------------ DATA SCRIPT ----------------------------------
