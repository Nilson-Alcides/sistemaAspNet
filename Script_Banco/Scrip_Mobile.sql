create database dbInfiniteMobile;

use dbInfiniteMobile;

/*cliente*/
create table cliente (
cod_cli int auto_increment,
nome_cli varchar(50),
tel_cli varchar(20),
email_cli varchar(50),
primary key(cod_cli));

/*consultor*/
create table consultor(
cod_cons int auto_increment,
nome_cons varchar(50),
tel_cons varchar(20),
email_cons varchar(50),
senha varchar(30),
primary key (cod_cons));

/*serviço*/
create table servico(
cod_serv int auto_increment,
nome_serv varchar(100),
descricao_serv varchar(500),
primary key(cod_serv),
foreign key(cod_cli) references cliente(cod_cli),
foreign key(cod_cons) references consultor(cod_cons));

/*atividade*/
create table atividade_consultor(
cod_ativ int auto_increment,
cod_cli int,
cod_cons int,
data_inicio date,
data_fim date,
descricao_ativ varchar(300),
primary key(cod_ativ),
foreign key(cod_cli) references cliente(cod_cli),
foreign key(cod_cons) references consultor(cod_cons));

/*agendamento*/
create table agendamento(
cod_agen int auto_increment,
cod_cli int,
cod_cons int,
data_agen date,
local_agen varchar(300),
descricao_agen varchar(500),
primary key (cod_agen),
foreign key (cod_cli) references cliente (cod_cli),
foreign key (cod_cons) references consultor(cod_cons));