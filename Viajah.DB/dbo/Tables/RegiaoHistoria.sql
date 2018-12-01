CREATE TABLE [dbo].[RegiaoHistoria]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descricao] NVARCHAR(MAX) NULL, 
    [ExperienciasBoas] NVARCHAR(MAX) NULL, 
    [ExperienciasRuin] NVARCHAR(MAX) NULL, 
    [Conclusao] NVARCHAR(MAX) NULL, 
    [Indicacao] NVARCHAR(MAX) NULL, 
    [DataPostagem] DATETIME NULL, 
    [IdRegiao] INT NULL,
	[IdUsuario] INT NULL,
	CONSTRAINT [FKRegiaoHistoriaRegiao] FOREIGN KEY (IdRegiao) REFERENCES Regiao(Id), 
    CONSTRAINT [FKRegiaoHistoriaUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES Usuario(Id)
)
