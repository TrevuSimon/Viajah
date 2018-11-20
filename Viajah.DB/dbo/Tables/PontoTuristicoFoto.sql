CREATE TABLE [dbo].[PontoTuristicoFoto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdPontoTuristico] INT NULL, 
    [Nome] VARCHAR(MAX) NULL, 
    [Foto] VARCHAR(MAX) NULL, 
    [Descricao] VARCHAR(MAX) NULL
)
