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
	CONSTRAINT [FKRegiaoHistoriaRegiao] FOREIGN KEY (Id) REFERENCES Regiao(Id)
)
