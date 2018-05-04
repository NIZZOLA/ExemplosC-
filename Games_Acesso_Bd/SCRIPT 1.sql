create database GAMESETEC;


CREATE TABLE USUARIO (
   USUARIOID INT  not null identity(1,1) primary key,
   NOME VARCHAR(50),
   EMAIL VARCHAR(80),
   SENHA VARCHAR(10) )
