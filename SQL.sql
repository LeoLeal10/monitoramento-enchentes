create database MonitoramentoEnchentes

use MonitoramentoEnchentes

create table Usuarios (
	Id int not null primary key,
	Nome varchar(50) null,
	Usuario varchar (50) not null,
	Senha varchar(50) not null,
	Foto varchar(max) null
)

insert into Usuarios values (1, 'Administrador', '1', '1', 'Foto')

create procedure spConsulta_PorUsuario (@usuario varchar(50))
as 
begin 
	select * from Usuarios u where u.Usuario = @usuario
end

exec spConsulta_PorUsuario '1'