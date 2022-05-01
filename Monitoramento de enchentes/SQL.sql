create database MonitoramentoEnchentes

use MonitoramentoEnchentes

create table Usuarios (
	Id int not null primary key,
	Nome varchar(50) null,
	NomeUsuario decimal (18, 2) not null,
	Senha varchar(50) not null,
	Foto varchar(max) null
)

