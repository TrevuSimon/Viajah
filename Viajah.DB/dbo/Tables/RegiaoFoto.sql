CREATE TABLE [dbo].[RegiaoFoto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdRegiao] INT NULL, 
    [Foto] IMAGE NULL, 
    [Descricao] VARCHAR(MAX) NULL
)
