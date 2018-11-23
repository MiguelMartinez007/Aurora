drop database if exists AURORA;
create database AURORA;

use AURORA;

-- Creacion de la tabla de usuario
create table usuario(
	id_usuario int not null auto_increment primary key,
	nombre varchar(50) not null,
	contrasena varchar(30) not null
);

-- Creacion de la tabla donde se guardaran los diferentes asistentes de cada usuario
create table asistente(
	id_asistente int not null auto_increment primary key,
	nombre varchar(50) not null,
	voz varchar(30) not null,
	tiempoLimite int not null,
	palabraActiva varchar(30) not null,
	palabraDesactiva varchar(15) not null,
    respuestaDesactiva varchar(60) null,
    respuestaActiva varchar(60) null,
    respuestaNombre varchar(20) null,
	usuario_fk int not null,
	index index_asistente_usuario_fk (usuario_fk),
	constraint constraint_asistente_usuario
		foreign key (usuario_fk) references usuario(id_usuario)
);

-- Creacion de las tabla donde se guardan los eventos, tareas, etc
-- Agenda
create table agenda(
	id_agenda int not null auto_increment primary key,
	fecha varchar(10) not null,
	hora varchar(15) not null,
	evento varchar(30) not null,
	direccion varchar(60) null,
	con varchar(60) null,
	recordatorio varchar(100) null,
	usuario_fk int not null,
	index index_agenda_usuario_fk (usuario_fk),
	constraint constraint_agenda_usuario
		foreign key (usuario_fk) references usuario(id_usuario)
);

-- Alarma
create table alarma(
	id_alarma int not null auto_increment primary key,
	titulo varchar(30) not null,
	tono varchar(30) not null,
	fecha varchar(10) not null,
	hora varchar(15) not null,
	usuario_fk int not null,
	index index_alarma_usuario_fk (usuario_fk),
	constraint constraint_alarma_usuario
		foreign key (usuario_fk) references usuario(id_usuario)
);

-- Creacion de las tablas para el guardado de las gramaticas
-- Ejecuta
create table ejecuta(
	id_ejecuta int not null auto_increment primary key,
	ejecuta varchar(1000) not null
);
-- Responde
create table responde(
	id_responde int not null auto_increment primary key,
	responde varchar(50) not null
);
-- Escucha
create table escucha(
	id_escucha int not null auto_increment primary key,
	escucha varchar(50) not null
);

-- Tabla para el tipo de gramatica
create table tipo(
	id_tipo int not null auto_increment primary key,
	tipo varchar(15) not null
);

-- Tabla de gramaticas
create table gramatica(
	id_gramatica int not null auto_increment primary key,
	escucha_fk int not null,
	responde_fk int not null,
	ejecuta_fk int not null,
	tipo_fk int not null,
	asistente_fk int null,
	index index_gramatica_escucha_fk (escucha_fk),
	constraint constraint_gramatica_escucha
		foreign key (escucha_fk) references escucha(id_escucha),
	index index_gramatica_responde_fk (responde_fk),
	constraint constraint_gramatica_responde
		foreign key (responde_fk) references responde(id_responde),
	index index_gramatica_ejecuta_fk (ejecuta_fk),
	constraint constraint_gramatica_ejecuta
		foreign key (ejecuta_fk) references ejecuta(id_ejecuta),
	index index_gramatica_tipo_fk (tipo_fk),
	constraint constraint_gramatica_tipo
		foreign key (tipo_fk) references tipo(id_tipo),
	index index_gramatica_asistente_fk (asistente_fk),
	constraint constraint_gramatica_asistente
		foreign key (asistente_fk) references asistente(id_asistente)
);




-- Procedimintos
use AURORA;

-- Selecciona los comandos que puede escuchar el asistente
delimiter //
drop procedure if exists escucha //
create procedure escucha(idAsistente int)
begin
	select escucha.escucha from escucha, gramatica where (gramatica.asistente_fk = idAsistente and gramatica.escucha_fk = escucha.id_escucha) or (gramatica.tipo_fk = 1 and gramatica.escucha_fk = escucha.id_escucha);
end //
delimiter ;
call escucha(2);

-- Selecciona las respuestas de las gramaticas agregadas por el usuario
delimiter //
drop procedure if exists respuesta //
create procedure respuesta(idAsistente int, escuchaAsistente varchar(50))
begin
	select responde.responde, ejecuta.ejecuta from responde, ejecuta, escucha, gramatica
	where gramatica.escucha_fk = escucha.id_escucha and gramatica.ejecuta_fk = ejecuta.id_ejecuta and gramatica.responde_fk = responde.id_responde
	and escucha.escucha = escuchaAsistente and (gramatica.asistente_fk = idAsistente or gramatica.tipo_fk = 1);
end //
delimiter ;

-- Selecciona las gramaticas globales que puede escuchar culaquier asistente
delimiter //
drop procedure if exists escuchaGlobal //
create procedure escuchaGlobal(idAsistente int)
begin
	-- Selecciona las gramticas reconocibles globales
	select escucha.escucha from escucha, gramatica where gramatica.escucha_fk = escucha.id_escucha and gramatica.asistente_fk = idAsistente;
end //
delimiter ;


-- Selecciona el nombre del asistente deacuerdo a el usuario
delimiter //
drop procedure if exists identificadorAsistente //
create procedure identificadorAsistente(nombreUsuario varchar(15))
begin
	-- Selecciona el asitente deacuerdo al login del usuario
	select asistente.id_asistente, asistente.nombre from asistente,usuario where usuario.nombre = nombreUsuario and asistente.usuario_fk = usuario.id_usuario;
end //
delimiter ;


-- Selecciona la voz el tiempo de espera y las palabras para activar y desactivar el asistente
delimiter //
drop procedure if exists vozTiempoPalabra //
create procedure vozTiempoPalabra(idUsuario int)
begin
	-- Selecciona el tiempo de espera del asistente en el que este puede reconocer comandos, tambien selecciona la palabra activadora
    -- del asistente y
	-- la palabra que desactiva el reconocimeinto de voz
	select asistente.voz,asistente.tiempoLimite,asistente.palabraActiva,asistente.palabraDesactiva,asistente.respuestaDesactiva,asistente.respuestaActiva,asistente.respuestaNombre
    from asistente where asistente.id_asistente = idUsuario;
end //
delimiter ;

-- Verifica la identidad del login del usuario
delimiter //
drop procedure if exists existeUsuario //
create procedure existeUsuario(nombreUsuario varchar(15), contrasenaUsuario varchar(30))
begin
	-- Verifica la identidad del usuario
	select count(usuario.id_usuario) from usuario where usuario.nombre = nombreUsuario and usuario.contrasena = contrasenaUsuario;
end //
delimiter ;





-- Inserciones
use AURORA;

/* Inserciones a la tabla de tipo */
insert into tipo (tipo) values
('Global'),
('Arduino'),
('Teclado'),
('Usuario');

insert into usuario(nombre,contrasena) values
('Señor','1234'),
('Migue','1234'),
('Wafflez','queso123');

insert into asistente(nombre,voz,tiempoLimite,palabraActiva,palabraDesactiva,respuestaDesactiva,respuestaActiva,respuestaNombre,usuario_fk) values
('JARVIS','Jorge',5,'Despierta','Duerme','Hasta luego','Aqui estoy a sus ordenes','Si',1),
('AURORA','Jorge',15,'Despierta','Adios','Adios','Bienvenido','Si',2),
('Conejita ardiente','Jorge',10,'¿Estas despierta?','Nos vemos luego','Nos vemos','Para ti siempre','Si',3);

insert into escucha (escucha) values
('Abre google'),
('Abre youtube'),
('Abre facebook'),
('Abre modem'),
('Abre word'),
('Abre Reproductor'),
('Abre calculadora'),
('Abre google chrome'),
('Abre powerpoint'),
('Abre access'),
('Abre administrador de tareas'),
('Abre teclado en pantalla'),
('Abre bloc de notas'),
('Abre paint'),
('Abre información del sistema'),
('Abre optimización de unidades'),
('Abre panel de control'),
('Abre ventana de comandos'),
('Abre explorador de archivos'),
('Abre firefox'),
('bloquea sesión'),
('hibernar'),
('abre música'), -- Gramaticas para abrir carpetas
('abre videos'),
('abre imágenes'),
('abre documentos'),
('abre escritorio'),
('abre descargas'),
('que fecha es'), -- A partir de aqui son comandos del sistema sin respuesta
('que día es'),
('que hora es'),
('copiar'), -- Comandos de simulacion de teclado
('pegar'),
('enter'),
('alinea a la derecha'),
('centrar'),
('alinea a la izquierda'),
('justificado'),
('en negrita'),
('en cursiva'),
('subrayado'),
('reproduce'),
('reproducir'),
('pausa'),
('sube volumen'),
('mas volumen'),
('baja volumen'),
('menos volumen'),
('silencio'),
('sonido'),
('siguiente pista'),
('siguiente'),
('pista anterior'),
('anterior'),
('minimizar'),
('maximizar'),
('seleccionar'),
('ejecutar'),
('mayuscula'),
('deshacer'),
('recuperar'),
('ver ventanas'),
('cierra ventana')
;
insert into responde (responde) values
('Abriendo google'),
('Abriendo youtube'),
('Abriendo facebook'),
('Abriendo dirección del modem'),
('Abriendo word'),
('Abriendo reproductor'),
('Abriendo calculadora'),
('Abriendo google chrome'),
('Abriendo powerpoint'),
('Abriendo access'),
('Abriendo administrador de tareas'),
('Abriendo teclado en pantalla'),
('Abriendo bloc de notas'),
('Abriendo paint'),
('Abriendo información del sistema'),
('Abriendo optimización de unidades'),
('Abriendo panel de control'),
('Abriendo ventana de comandos'),
('Abriendo explorador de archivos'),
('Abriendo firefox'),
('Bloqueando sesión'),
('Hibernando sistema, hasta luego'),
('Abriendo música'),-- Gramaticas para abrir carpetas
('Abriendo videos'),
('Abriendo imágenes'),
('Abriendo documentos'),
('Abriendo escritorio'),
('Abriendo descargas'),
(''), -- A partir de aqui son comandos del sistema sin respuesta
(''),
(''),
('copiando'), -- Comandos de simulacion de teclado
('pegando'),
('enter'),
('texto a la derecha'),
('centrando'),
('texto a la izquierda'),
('justificado'),
('texto en negrita'),
('texto en cursiva'),
('texto subrayado'),
('reproduciendo pista'),
('reproduciendo pista'),
('pausando reproducción'),
('subiendo volumen'),
('subiendo volumen'),
('bajando volumen'),
('bajando volumen'),
(''),
('sonido actiavado'),
('adelantando pista'),
('adelantando pista'),
('retrasando pista'),
('retrasando pista'),
('minimizando'),
('maximizando'),
('seleccionado'),
('F 5'),
('tecla activada'),
('control z'),
('control y'),
('ventanas'),
('cerran')
;
insert into ejecuta (ejecuta) values
('http://www.google.com'),
('http://www.youtube.com'),
('http://www.facebook.com'),
('http://192.168.1.254'),
('WINWORD.EXE'),
('wmplayer.exe'),
('calc.exe'),
('chrome.exe'),
('POWERPNT.exe'),
('MSACCESS.exe'),
('Taskmgr.exe'),
('osk.exe'),
('notepad.exe'),
('mspaint.exe'),
('msinfo32.exe'),
('dfrgui.exe'),
('control.exe'),
('cmd.exe'),
('explorer.exe'),
('firefox.exe'),
('bat\\blocsesion.bat'),
('bat\\hibernar.bat'),
(''),-- Gramaticas para abrir carpetas
(''),
(''),
(''),
(''),
(''),
(''), -- A partir de aqui son comandos del sistema sin respuesta
(''),
(''),
('Teclado 1'),-- Comandos de simulacion de teclado
('Teclado 2'),
('Teclado 3'),
('Teclado 4'),
('Teclado 5'),
('Teclado 6'),
('Teclado 7'),
('Teclado 8'),
('Teclado 9'),
('Teclado 10'),
('Teclado 11'),
('Teclado 12'),
('Teclado 13'),
('Teclado 14'),
('Teclado 15'),
('Teclado 16'),
('Teclado 17'),
('Teclado 18'),
('Teclado 19'),
('Teclado 20'),
('Teclado 21'),
('Teclado 22'),
('Teclado 23'),
('Teclado 24'),
('Teclado 25'),
('Teclado 26'),
('Teclado 27'),
('Teclado 28'),
('Teclado 29'),
('Teclado 30'),
('Teclado 31'),
('Teclado 32')
;

insert into gramatica (escucha_fk,responde_fk,ejecuta_fk,tipo_fk,asistente_fk) values
(1,1,1,1,null),
(2,2,2,1,null),
(3,3,3,1,null),
(4,4,4,1,null),
(5,5,5,1,null),
(6,6,6,1,null),
(7,7,7,1,null),
(8,8,8,1,null),
(9,9,9,1,null),
(10,10,10,1,null),
(11,11,11,1,null),
(12,12,12,1,null),
(13,13,13,1,null),
(14,14,14,1,null),
(15,15,15,1,null),
(16,16,16,1,null),
(17,17,17,1,null),
(18,18,18,1,null),
(19,19,19,1,null),
(20,20,20,1,null),
(21,21,21,1,null),
(22,22,22,1,null),
(23,23,23,1,null),
(24,24,24,1,null),
(25,25,25,1,null),
(26,26,26,1,null),
(27,27,27,1,null),
(28,28,28,1,null),
(29,29,29,1,null),
(30,30,30,1,null),
(31,31,31,1,null),
(32,32,32,1,null),
(33,33,33,1,null),
(34,34,34,1,null),
(35,35,35,1,null),
(36,36,36,1,null),
(37,37,37,1,null),
(38,38,38,1,null),
(39,39,39,1,null),
(40,40,40,1,null),
(41,41,41,1,null),
(42,42,42,1,null),
(43,43,43,1,null),
(44,44,44,1,null),
(45,45,45,1,null),
(46,46,46,1,null),
(47,47,47,1,null),
(48,48,48,1,null),
(49,49,49,1,null),
(50,50,50,1,null),
(51,51,51,1,null),
(52,52,52,1,null),
(53,53,53,1,null),
(54,54,54,1,null),
(55,55,55,1,null),
(56,56,56,1,null),
(57,57,57,1,null),
(58,58,58,1,null),
(59,59,59,1,null),
(60,60,60,1,null),
(61,61,61,1,null),
(62,62,62,1,null),
(63,63,63,1,null)
;


-- Opciones para el desarrollador
insert into escucha (escucha) values
('Abre visual studio'),
('Abre sublime'),
('Abre Blend'),
('Abre WorkBench'),
('Abre WampServer')
;

insert into responde (responde) values
('abriendo visual studio'),
('abriendo sublime'),
('abriendo Blend'),
('abriendo My sql work Bench'),
('abriendo Wamp Server')
;

insert into ejecuta (ejecuta) values
('devenv.exe'),
('C:\\Sublime Text Build 3059 x64\\sublime_text.exe'),
('Blend.exe'),
('MySQLWorkbench.exe'),
('C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Wampserver64\\Wampserver64.lnk')
;

insert into gramatica (escucha_fk,responde_fk,ejecuta_fk,tipo_fk,asistente_fk) values
(64,64,64,1,null),
(65,65,65,1,null),
(66,66,66,1,null),
(67,67,67,1,null),
(68,68,68,1,null)
;

-- Opciones para el Arduino
insert into escucha (escucha) values
('Luces'),
('Apaga luces'),
('Luces de la entrada'),
('Apaga luces de la entrada'),
('Luces del pasillo'),
('Apaga luces del pasillo'),
('Prende luces de la cosina'),
('Apaga luces de la cosina'),
('Prende luces de la sala'),
('Apaga luces de la sala'),
('Prende luces del dormitorio'),
('Apaga luces del dormitorio'),
('Prende luces del baño'),
('Apaga luces del baño'),
('Prende luces del cuarto de juegos'),
('Apaga luces del cuarto de juegos'),
('Prende luces de la cochera'),
('Apaga luces de la cochera')
;

insert into responde (responde) values
('Prendiendo luces'),
('Apagando luces'),
('Prendiendo luces de la entrada'),
('Apagando luces de la entrada'),
('Prendiendo luces del pasillo'),
('Apagando luces del pasillo'),
('Prendiendo luces de la cosina'),
('Apagando luces de la cosina'),
('Prendiendo luces de la sala'),
('Apagando luces de la sala'),
('Prendiendo luces del dormitorio'),
('Apagando luces del dormitorio'),
('Prendiendo luces del baño'),
('Apagando luces del baño'),
('Prendiendo luces del cuerto de juegos'),
('Apagando luces del cuerto de juegos'),
('Prendiendo luces de la cochera'),
('Apagando luces de la cochera')
;

insert into ejecuta (ejecuta) values
('Arduino 1'),
('Arduino 2'),
('Arduino 3'),
('Arduino 4'),
('Arduino 5'),
('Arduino 6'),
('Arduino 7'),
('Arduino 8'),
('Arduino 9'),
('Arduino A'),
('Arduino B'),
('Arduino C'),
('Arduino D'),
('Arduino E'),
('Arduino F'),
('Arduino G'),
('Arduino H'),
('Arduino I')
;

insert into gramatica (escucha_fk,responde_fk,ejecuta_fk,tipo_fk,asistente_fk) values
(69,69,69,1,null),
(70,70,70,1,null),
(71,71,71,1,null),
(72,72,72,1,null),
(73,73,73,1,null),
(74,74,74,1,null),
(75,75,75,1,null),
(76,76,76,1,null),
(77,77,77,1,null),
(78,78,78,1,null),
(79,79,79,1,null),
(80,80,80,1,null),
(81,81,81,1,null),
(82,82,82,1,null),
(83,83,83,1,null),
(84,84,84,1,null),
(85,85,85,1,null),
(86,86,86,1,null)
;