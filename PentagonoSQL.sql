Create Database PruebaPentagono;

use PruebaPentagono;

drop table if exists paciente;
create table paciente(
	id int not null identity(1,1) primary key,
	nombre varchar(100) not null,
	apellido varchar(100),
	fecha_nacimiento date,
	peso float,
	estatura float
);

drop table if exists especialidad;
create table especialidad(
	id int not null identity(1,1) primary key,
	nombre varchar(100)
);

drop table if exists medico;
create table medico(
	id int not null identity(1,1) primary key,
	nombre varchar(100) not null,
	apellido varchar(100),
	id_especialidad int 
);

drop table if exists cita_medica;
create table cita_medica(
	id int not null identity(1,1) primary key,
	id_paciente int references paciente(id) not null,
	id_medico int references medico(id) not null,
	fecha_hora datetime not null,
	terminada int default 0 not null
);

drop table if exists historial;
create table historial(
	id_cita_medica int references cita_medica(id),
	diagnostico text
);

insert into especialidad(nombre) values('Pediatra');
insert into especialidad(nombre) values('Urologo');
insert into especialidad(nombre) values('Ortopeda');
insert into especialidad(nombre) values('Cirujano');
insert into especialidad(nombre) values('General');

insert into medico(nombre,apellido,id_especialidad) values('Leo','Figueras',5);
insert into medico(nombre,apellido,id_especialidad) values('Kilian','Andrade',4);
insert into medico(nombre,apellido,id_especialidad) values('Fermina','Calleja',3);
insert into medico(nombre,apellido,id_especialidad) values('Adela','Toledo',2);
insert into medico(nombre,apellido,id_especialidad) values('Samir','Gaspar',1);

insert into paciente(nombre,apellido,fecha_nacimiento,peso,estatura) values('Ana Maria','Salvador','02/11/1974',155,1.63);
insert into paciente(nombre,apellido,fecha_nacimiento,peso,estatura) values('Alfonsa','Benavides','04/26/1998',151,1.89);
insert into paciente(nombre,apellido,fecha_nacimiento,peso,estatura) values('Ana Belen','Molina','09/15/1996',179,1.74);
insert into paciente(nombre,apellido,fecha_nacimiento,peso,estatura) values('Joaquin','Huerta','12/08/1979',157,1.77);
insert into paciente(nombre,apellido,fecha_nacimiento,peso,estatura) values('Jose Andres','Vega','06/06/1996',168,1.80);