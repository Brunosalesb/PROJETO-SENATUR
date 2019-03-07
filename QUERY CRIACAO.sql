CREATE DATABASE SENATUR_TARDE

CREATE TABLE PACOTES(
	PacoteId int identity primary key
	,NomePacote varchar(150) unique not null 
	,Descricao text not null
	,DataIda datetime not null
	,DataVolta datetime not null
	,Valor decimal not null
	,NomeCidade varchar(150) not null 
	,Ativo bit not null
)

CREATE TABLE USUARIOS(
	UsuarioId int identity primary key
	,Email varchar(150) not null unique
	,Senha varchar(150) not null
	,TipoUsuario Varchar(150) not null
)

select * from USUARIOS
select * from PACOTES

DROP TABLE USUARIOS