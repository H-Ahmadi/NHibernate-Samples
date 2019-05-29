/****** Object:  Table [dbo].[InventoryTransactions]    Script Date: 5/29/2019 3:15:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventoryTransactions](
	[Id] [bigint] NOT NULL,
	[OperationPeriodId] [bigint] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InventoryTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[OperationPeriodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[RealEstates]    Script Date: 5/29/2019 3:16:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RealEstates](
	[Id] [bigint] NOT NULL,
	[OwnerName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RealEstates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

