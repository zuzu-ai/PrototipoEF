-- drop database hotelsancarlos;
create database hotelsancarlos;
use hotelsancarlos;

-- OTROS
create table empleado (
id int primary key,
nombre varchar(30) not null,
estado int not null
)engine=innodb;

create table usuario (
pkid varchar (15) primary key,
fkidempleado int not null,
nombre varchar(30) not null,
contraseña varchar(80),
estado int not null,
intento int not null,

foreign key (fkidempleado) references empleado(id)
)engine=innodb;

CREATE TABLE modulo(
	pkId VARCHAR(15) PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL,
	descripcion VARCHAR(200) NOT NULL,
	estado VARCHAR(1) NOT NULL
) ENGINE=innodb;
	
CREATE TABLE aplicacion(
	pkId VARCHAR(15) PRIMARY KEY,
	fkIdModulo VARCHAR(15) NOT NULL,
	nombre VARCHAR(45) NULL,
	estado INT NOT NULL,
	rutaChm varchar(180) not null,
	rutaHtml varchar(180) not null,
	FOREIGN KEY (fkIdModulo) REFERENCES modulo(pkId)
) ENGINE=innodb;

CREATE TABLE bitacoraUsuario(
	pkId INT AUTO_INCREMENT PRIMARY KEY,
	fkIdUsuario VARCHAR(15) NOT NULL,
	`host` VARCHAR(45) NULL DEFAULT NULL,
	ip VARCHAR(20) NULL,
	fkIdModulo VARCHAR(15) NOT NULL,
	fkIdAplicacion VARCHAR(15) NOT NULL,
	accion VARCHAR(200) NOT NULL,
	conexionFecha DATE NULL,
	conexionHora TIME NULL,
  
	FOREIGN KEY (fkIdUsuario) REFERENCES usuario (pkId),
	FOREIGN KEY (fkIdModulo) REFERENCES modulo (pkId),
	FOREIGN KEY (fkIdAplicacion) REFERENCES aplicacion(pkID)
) ENGINE=innodb;
-- RELACIONADO CON EL REQUERIMIENTO
create table tipocuenta
(
id int primary key,
nombre varchar(30) not null,
estado int not null
)engine=innodb;

create table cuenta
(
id int primary key,
nombre varchar(30) not null,
tipocuenta int not null,
estado int not null,

foreign key (tipocuenta) references tipocuenta(id)
)engine=innodb;

create table bancos
(
id int primary key,
nombre varchar(30) not null,
estado int not null
)engine=innodb;

create table cuentabancaria
(
id int primary key,
nombre varchar(50) not null,
numero int not null,
banco int not null,
estado int not null,

foreign key (banco) references bancos(id)
)engine=innodb;

create table tipomovimiento
(
id int primary key,
nombre varchar(30) not null,
estado int not null
)engine=innodb;

create table movimientoe
(
id int primary key,
cuentabancaria int not null,
cuentacontable int not null,
empleado int not null,
fecha date not null,
hora time not null,
estado int not null,

foreign key (cuentabancaria) references cuentabancaria(id),
foreign key (empleado) references empleado(id),
foreign key (cuentacontable) references cuenta(id)
)engine=innodb;

create table movimientod
(
id int primary key,
encabezado int not null,
tipomovimiento int not null,
monto float not null,

foreign key (encabezado) references movimientoe(id),
foreign key (tipomovimiento) references tipomovimiento(id)
)engine=innodb;

-- INSERTS REQUERIDOS
-- EMPLEADO
insert into empleado values (1,"Mario Fuentes",1);
-- USUARIO
insert into usuario values (1,1,"admin","LKAekHU9EtweB49HAaTRfg==",1,0);
-- TIPO CUENTA
insert into tipocuenta values (1,"activo",1);
insert into tipocuenta values (2,"pasivo",1);
-- TIPO MOVIMIENTO
insert into tipomovimiento values (1,"cheque",1);
insert into tipomovimiento values (2,"deposito",1);
insert into tipomovimiento values (3,"nota de crédito",1);
insert into tipomovimiento values (4,"nota de debito",1);
-- MODULO
INSERT INTO modulo VALUES ('1','Seguridad','Módulo de Seguridad',1);
INSERT INTO modulo VALUES ('2','Bancos','Módulo de Bancos',1);
-- APLICACION
INSERT INTO aplicacion VALUES ("0001","1","Login Seguridad HSC",1,0,0);
INSERT INTO aplicacion VALUES ("0002","2","Cuentas Contables",1,0,0);
INSERT INTO aplicacion VALUES ("0003","2","Cuentas Bancarias",1,0,0);
INSERT INTO aplicacion VALUES ("0004","2","Bancos",1,0,0);
INSERT INTO aplicacion VALUES ("0005","2","Tipo Movimiento",1,0,0);
INSERT INTO aplicacion VALUES ("0006","2","Movimiento Bancario",1,0,0);
