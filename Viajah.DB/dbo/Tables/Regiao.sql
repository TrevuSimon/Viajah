﻿CREATE TABLE [dbo].[Regiao]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descricao] NVARCHAR(MAX) NULL, 
    [Cidade] NVARCHAR(MAX) NULL, 
    [Pais] NVARCHAR(MAX) NULL 
)
