CREATE TABLE [dbo].[RegiaoComentario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdUsuario] INT NULL, 
    [IdRegiao] INT NULL, 
    [Comentario] NVARCHAR(MAX) NULL, 
    [Data] DATETIME NULL, 
    CONSTRAINT [FKRegiaoComentarioUsuario] FOREIGN KEY (Id) REFERENCES Usuario(Id), 
    CONSTRAINT [FKRegiaoComentarioRegiao] FOREIGN KEY (Id) REFERENCES Regiao(Id)
)
