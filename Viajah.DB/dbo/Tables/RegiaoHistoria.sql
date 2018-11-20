CREATE TABLE [dbo].[RegiaoHistoria]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Descricao] NVARCHAR(MAX) NULL, 
    [ExperienciasBoas] NVARCHAR(MAX) NULL, 
    [ExperienciasRuin] NVARCHAR(MAX) NULL, 
    [Conclusao] NVARCHAR(MAX) NULL, 
    [Indicacao] NVARCHAR(MAX) NULL
)
