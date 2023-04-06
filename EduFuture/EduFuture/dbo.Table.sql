CREATE TABLE [dbo].[Users]
(
	[Id_user] INT NOT NULL PRIMARY KEY, 
    [Username] NCHAR(30) NOT NULL, 
    [Badges] INT NOT NULL, 
    [Rank] INT NOT NULL, 
    [Tokens] INT NOT NULL
)
