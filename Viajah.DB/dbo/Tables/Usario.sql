CREATE TABLE [dbo].[Usario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Login] VARCHAR(MAX) NULL, 
    [Senha] VARCHAR(MAX) NULL, 
    [idNativo] INT NULL, 
    [Admin] BIT NULL, 
    [Email] VARCHAR(MAX) NULL
)
