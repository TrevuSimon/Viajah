CREATE TABLE [dbo].[UsuarioDetalhe]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdUsuario] INT NULL, 
    [Nome] NCHAR(10) NULL, 
    [Sobrenome] NCHAR(10) NULL, 
    [Sexo] NCHAR(10) NULL, 
    [Telefone] NCHAR(10) NULL, 
    [Celular] NCHAR(10) NULL, 
    [Pais] NCHAR(10) NULL, 
    [IdRegiao] INT NULL, 
    [Foto] IMAGE NULL, 
    CONSTRAINT [FK_UsuarioDetalhe_Usuario] FOREIGN KEY (Idusuario) REFERENCES Usuario(Id), 
    CONSTRAINT [FK_UsuarioDetalhe_Regiao] FOREIGN KEY (IdRegiao) REFERENCES Regiao(Id)

)
