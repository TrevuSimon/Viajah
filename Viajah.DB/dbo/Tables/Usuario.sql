CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Login] VARCHAR(MAX) NULL, 
    [Senha] VARCHAR(MAX) NULL, 
    [Nome] VARCHAR(MAX) NULL, 
    [Email] VARCHAR(MAX) NULL, 
    [DataCadastro] DATETIME NULL, 
    [Moderador] BIT NULL
)
