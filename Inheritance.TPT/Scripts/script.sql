/****** Object:  Table [dbo].[IndividualParties]    Script Date: 5/29/2019 4:37:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndividualParties](
	[Id] [bigint] NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_IndividualParties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LegalParties]    Script Date: 5/29/2019 4:37:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LegalParties](
	[Id] [bigint] NOT NULL,
	[CeoName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LegalParties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parties]    Script Date: 5/29/2019 4:37:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parties](
	[Id] [bigint] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Parties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IndividualParties]  WITH CHECK ADD  CONSTRAINT [FK_IndividualParties_Parties] FOREIGN KEY([Id])
REFERENCES [dbo].[Parties] ([Id])
GO
ALTER TABLE [dbo].[IndividualParties] CHECK CONSTRAINT [FK_IndividualParties_Parties]
GO
ALTER TABLE [dbo].[LegalParties]  WITH CHECK ADD  CONSTRAINT [FK_LegalParties_Parties] FOREIGN KEY([Id])
REFERENCES [dbo].[Parties] ([Id])
GO
ALTER TABLE [dbo].[LegalParties] CHECK CONSTRAINT [FK_LegalParties_Parties]
GO
