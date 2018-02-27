CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[Recipe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IdBook] [int] NOT NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Book] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[Recipe] CHECK CONSTRAINT [FK_Recipes_Book]
GO

--

INSERT INTO [dbo].[Book]([Name]) VALUES ('ASP.NET MVC 6')
INSERT INTO [dbo].[Book]([Name]) VALUES ('EF 7')

INSERT INTO [dbo].[Recipe]([Name],[IdBook]) VALUES('Tasks runners',1)
INSERT INTO [dbo].[Recipe]([Name],[IdBook]) VALUES('IoC',1)
INSERT INTO [dbo].[Recipe]([Name],[IdBook]) VALUES('DbContext',2)
INSERT INTO [dbo].[Recipe]([Name],[IdBook]) VALUES('In-Memory Provider',2)
GO
