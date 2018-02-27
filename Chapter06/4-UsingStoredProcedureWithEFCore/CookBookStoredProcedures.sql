CREATE PROCEDURE [dbo].[GetBooks] 
AS
BEGIN
    SET NOCOUNT ON;
    SELECT [Id],[Name] FROM [dbo].[Book]
END
GO

CREATE PROCEDURE [dbo].[InsertBook]
    @name varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[Book] ([Name]) VALUES (@name)
END
GO
