CREATE TABLE [dbo].[RegiaoComentario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdUsuario] INT NULL, 
    [IdRegiao] INT NULL, 
    [Comentario] NVARCHAR(MAX) NULL, 
    [Data] DATETIME NULL
)
