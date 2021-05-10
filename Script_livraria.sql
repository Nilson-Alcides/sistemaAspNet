Create database DBlivraria;

use DBlivraria;

/*Autor */
create table autor (
codigo_id_aut int auto_increment,
nome_aut varchar(60),
dtnascimento_aut date,
primary key (codigo_id_aut));

/* Pagamento*/
create table pagamento(
codigo_id_pag int auto_increment,
descricao_pag varchar(30),
primary key (codigo_id_pag));

/*Funcionario*/
create table funcionario(
codigo_id_fun int auto_increment,
nome_fun varchar(50),
primary key (codigo_id_fun));

/*Estado*/
create table estado(
uf_id_est char(2),
descricao_uf varchar(20),
primary key (uf_id_est));

/* categoria  */
create table categoria(
codigo_id_cat int auto_increment,
descricao_cat varchar(30),
primary key(codigo_id_cat));

/*formato_livro */
create table formato_livro(
codigo_id_for int auto_increment,
descricao_for varchar(20),
primary key (codigo_id_for));

/*editora  */
create table editora(
codigo_id_ed int auto_increment,
nome_ed varchar(60),
primary key(codigo_id_ed));

/*cliente */
create table cliente(
login_id_cli varchar(10),
senha_cli varchar(8),
nome_cli varchar(50),
cpf_cli varchar(11),
telefone_cli varchar(15),
email_cli varchar(100),
endereco_cli varchar(100),
complemento_cli varchar(15),
bairro_cli varchar(20),
cidade_cli varchar(30),
uf_id_est char(2),
cep_cli varchar(8),
primary key (login_id_cli),
foreign key (uf_id_est) references estado (uf_id_est));

/*livro */
create table livro(
isbn_id_liv char(15),
titulo_liv varchar(100),
resumo_liv varchar(250),
codigo_id_for int,
codigo_id_ed int,
dtpublicacao_liv date,
vlcusto_liv numeric(10,2),
vlvenda_liv numeric(10,2),
primary key (isbn_id_liv),
foreign key (codigo_id_for) references formato_livro (codigo_id_for),
foreign key (codigo_id_ed) references editora (codigo_id_ed));

/*livro autor */
create table livro_autor(
isbn_id_liv char(15),
codigo_id_aut int,
primary key(isbn_id_liv, codigo_id_aut),
foreign key (isbn_id_liv) references livro (isbn_id_liv),
foreign key (codigo_id_aut) references autor(codigo_id_aut));

/*livro categoria */
create table livro_categoria(
isbn_id_liv char(15),
codigo_id_cat int,
primary key (isbn_id_liv, codigo_id_cat),
foreign key (isbn_id_liv) references livro (isbn_id_liv),
foreign key (codigo_id_cat) references categoria (codigo_id_cat));

/*carrinho*/
create table carrinho(
numero_id_car int auto_increment,
login_id_cli varchar(10),
data_pedido_car datetime,
data_entrega_car datetime,
endereco_entrega_car varchar(60),
complemento_entrega_car varchar(15),
bairro_entrega_car varchar(20),
cidade_entrega_car varchar(30),
uf_id_est char(2),
codigo_id_pag int,
codigo_id_fun int,
primary key (numero_id_car),
foreign key (login_id_cli) references cliente (login_id_cli),
foreign key (uf_id_est) references estado (uf_id_est),
foreign key (codigo_id_pag) references pagamento(codigo_id_pag),
foreign key (codigo_id_fun) references funcionario (codigo_id_fun));

create table item_carrinho(
isbn_id_liv char(15),
numero_id_car int,
qtdade_item int,
vltotal_item numeric(10,2),
situacao_item char(1),
primary key (isbn_id_liv, numero_id_car),
foreign key (isbn_id_liv) references livro (isbn_id_liv),
foreign key (numero_id_car) references carrinho(numero_id_car));
/*__________________________________________________________________________________*/
/*SCRIPT I INSERIR DADOS */
/*PAGAMENTO*/
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('DEBITO');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('BOLETO');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('CRED A VISTA');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 2 VEZES SEM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 3 VEZES SEM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 4 VEZES SEM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 5 VEZES SEM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 6 VEZES COM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 7 VEZES COM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 8 VEZES COM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 9 VEZES COM JUROS');
INSERT INTO PAGAMENTO (DESCRICAO_PAG) VALUES ('PARC 10 VEZES COM JUROS');
 
/*ESTADO*/
INSERT INTO ESTADO VALUES ('AC', 'ACRE');
INSERT INTO ESTADO VALUES ('AL', 'ALAGOAS');
INSERT INTO ESTADO VALUES ('AP', 'AMAPÁ');
INSERT INTO ESTADO VALUES ('AM', 'AMAZONAS');
INSERT INTO ESTADO VALUES ('BA', 'BAHIA');
INSERT INTO ESTADO VALUES ('CE', 'CEARÁ');
INSERT INTO ESTADO VALUES ('DF', 'DISTRITO FEDERAL');
INSERT INTO ESTADO VALUES ('ES', 'ESPÍRITO SANTO');
INSERT INTO ESTADO VALUES ('GO', 'GOIÁS');
INSERT INTO ESTADO VALUES ('MA', 'MARANHÃO');
INSERT INTO ESTADO VALUES ('MT', 'MATO GROSSO');
INSERT INTO ESTADO VALUES ('MS', 'MATO GROSSO DO SUL');
INSERT INTO ESTADO VALUES ('MG', 'MINAS GERAIS');
INSERT INTO ESTADO VALUES ('PA', 'PARÁ');
INSERT INTO ESTADO VALUES ('PB', 'PARAÍBA');
INSERT INTO ESTADO VALUES ('PR', 'PARANÁ');
INSERT INTO ESTADO VALUES ('PE', 'PERNAMBUCO');
INSERT INTO ESTADO VALUES  ('PI', 'PIAUÍ');
INSERT INTO ESTADO VALUES ('RJ', 'RIO DE JANEIRO');
INSERT INTO ESTADO VALUES ('RN', 'RIO GRANDE DO NORTE');
INSERT INTO ESTADO VALUES ('RS', 'RIO GRANDE DO SUL');
INSERT INTO ESTADO VALUES ('RO', 'RONDÔNIA');
INSERT INTO ESTADO VALUES ('RR', 'RORAIMA');
INSERT INTO ESTADO VALUES ('SC', 'SANTA CATARINA');
INSERT INTO ESTADO VALUES ('SP', 'SÃO PAULO');
INSERT INTO ESTADO VALUES ('SE', 'SERGIPE');
INSERT INTO ESTADO VALUES ('TO', 'TOCANTINS');

/*FORMATO_LIVRO*/
INSERT INTO FORMATO_LIVRO  VALUES (NULL,'CAPA DURA');
INSERT INTO FORMATO_LIVRO  VALUES (NULL, 'GRAMPO');
INSERT INTO FORMATO_LIVRO  VALUES (NULL, 'BROCHURA');
INSERT INTO FORMATO_LIVRO  VALUES (NULL, 'DIGITAL');
INSERT INTO FORMATO_LIVRO VALUES (NULL, 'ASPIRAL');

 /*CATEGORIA*/
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('ADMINISTRAÇÃO');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('ARTES');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('AUTOAJUDA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('CIÊNCIAS BIOLÓGICAS');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('CIÊNCIAS EXATAS');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('CIÊNCIAS HUMANAS E SOCIAIS');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('DIDÁTICOS');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('DIREITO');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('DIVERSOS');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('ECONOMIA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('ESOTERISMO');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('ESPORTES E LAZER');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('GEOGRAFIA E HISTORIA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('INFORMÁTICA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('LINGUÍSTICA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('LITERATURA BRASILEIRA	');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('LITERATURA ESTRANGEIRA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('MEDICINA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('PSICOLOGIA E PSICANÁLISE');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('RELIGIÃO');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('FICÇÃO CIENTÍFICA FANTASIA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('BIOGRAFIA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('AVENTURA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('FANTASIA');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('INFANTO JUVENIL');
INSERT INTO CATEGORIA(DESCRICAO_CAT) VALUES ('INFANTO JUVENIL');

/* EDITORA */
INSERT INTO EDITORA(NOME_ED) VALUES ('INTRINSECA');
INSERT INTO EDITORA(NOME_ED) VALUES ('ARQUEIRO');
INSERT INTO EDITORA(NOME_ED) VALUES ('RECORD');
INSERT  INTO EDITORA(NOME_ED) VALUES ('SEXTANTE / GMT');
INSERT INTO EDITORA(NOME_ED) VALUES ('GENTE');
INSERT INTO EDITORA(NOME_ED) VALUES ('EDITORA NACIONAL');
INSERT INTO EDITORA(NOME_ED) VALUES ('CAMINHO SUAVE ED.');
INSERT INTO EDITORA(NOME_ED) VALUES ('ROCCO');
INSERT INTO EDITORA(NOME_ED) VALUES ('AGORA EDITORA');
INSERT INTO EDITORA(NOME_ED) VALUES ('COMPANHIA DAS LETRAS');
INSERT INTO EDITORA(NOME_ED) VALUES ('OBJETIVA');
INSERT INTO EDITORA(NOME_ED) VALUES ('BUZZ EDITORA');
INSERT INTO EDITORA(NOME_ED) VALUES ('RECORD');
INSERT INTO EDITORA(NOME_ED) VALUES ('GLOBO ART');
INSERT INTO EDITORA(NOME_ED) VALUES ('ALPH');
INSERT INTO EDITORA(NOME_ED) VALUES ('VALENTINA');
INSERT INTO EDITORA(NOME_ED) VALUES ('ARTMED'); 
INSERT INTO EDITORA(NOME_ED) VALUES ('FARO EDITORIAL');
INSERT INTO EDITORA(NOME_ED) VALUES ('BALÃO EDITORIAL');
INSERT INTO EDITORA(NOME_ED) VALUES ('BERTRAND BRASIL');
INSERT INTO EDITORA(NOME_ED) VALUES ('DAVID FINKING BOOKS');
INSERT INTO EDITORA(NOME_ED) VALUES ('SARAIVA');
INSERT INTO EDITORA(NOME_ED) VALUES ('MARTINS FONTES');

/*FUNCIONARIO*/
INSERT INTO FUNCIONARIO VALUES (NULL, 'JOÃO ALMEIDA');
INSERT INTO FUNCIONARIO VALUES (NULL, 'MARIA DE OLIVEIRA');
INSERT INTO FUNCIONARIO VALUES (NULL, 'CARLOS DA SILVA');
INSERT INTO FUNCIONARIO VALUES (NULL, 'ANA DA CRUZ');
INSERT INTO FUNCIONARIO VALUES (NULL, 'JOSE DA COSTA');


Select * from categoria;
/*____________________________________________________________________*/
/* SCRIPT II - INSERIR DADOS */
-- LIVRO---
INSERT INTO LIVRO 
VALUES 
('8533613377',
'O SENHOR DOS ANÉIS I - A SOCIEDADE DO ANEL', 
'Em uma terra fantástica e única, um hobbit recebe de presente de seu tio um anel mágico e maligno que precisa ser destruído antes que caia nas mãos do mal',
1,
13,
'2000/02/03',
25.00,
44.00);

INSERT INTO LIVRO 
VALUES 
('9788582714225',
 'BIOLOGIA MOLECULAR DA CÉLULA - 6ª ED. 2017',
 'De modo mais específico, a Biologia Molecular busca compreender os mecanismos de replicação, transcrição e tradução do material genético,',
1,
14,
'2017/01/01',
200.00,
342.90);

INSERT INTO LIVRO 
VALUES('9788580572186', 
'CINQUENTA TONS DE CINZA',
'A estudante de literatura Anastasia Steele, de 21 anos, entrevista o jovem bilionário Christian Grey, como um favor a sua colega de quarto Kate Kavanagh.',
 1,
 1,
 '2011/06/20',
 11.00, 29.90);

INSERT INTO LIVRO
VALUES (
'9788562409882', 
'A GAROTA DO LAGO',
'uma pequena cidade entre montanhas, é esse tipo de lugar, bucólico e com encantadoras casas dispostas à beira de um longo trecho de água intocada.',
3,
15,
'2017/01/04',
8.00,
11.90);

INSERT INTO LIVRO 
VALUES (
'9788593156755',
'A ORAÇÃO DE SÃO FRANCISCO',
'É a chamada Oração de São Francisco de Assis, um pequeno texto cheio de boas ideias.',
4,
11,
'2018/11/01',
30.00,
34.90);

INSERT INTO LIVRO
VALUES
(9788504019742,
'O RETORNO DE SHERLOCK HOLMES',
'Ressuscitou Sherlock Holmes, após contar sua morte na cena famosa em que desaparece nas cataratas de Reichenbach...',
1,
5,
'2015/03/25',
29.99,
39.90);

INSERT INTO LIVRO
 VALUES 
 ('9788569514732', 
 'ESTRELAS ALÉM DO TEMPO ',
 'No auge da corrida espacial travada entre Estados Unidos e Rússia durante a Guerra Fria, uma equipe de cientistas da NASA...',
 1,
 16,
 '2017/01/16'
 ,22.90,
 23.30);

INSERT INTO LIVRO 
VALUES 
('9788575426234',
'JOGANDO PARA VENCER ',
'coleção esportiva de lições de liderança organizados pelo então treinador da seleção brasileira masculina de vôlei Bernardinho...',
3,
3,
'2011/01/20',
29.90,
19.99);

INSERT INTO LIVRO
 VALUES 
 ('9788555390494', 
 'AS MELHORES HISTÓRIAS DE VIAGEM NO TEMPO',
 '...dezoito contos de alguns dos gigantes do universo sci-fi, abrangendo cinco década...',
  2,
 20,
 '2016/09/14',
 54.90,
 36.90);
  
INSERT INTO LIVRO 
VALUES 
('9788593911224',
 'E SE EU FOSSE PURA',
 'Amara mostra a vida por trás dos panos da profissão mais malfalada do mundo, mostrando as angústias, os medos, os preconceitos...',
3,
10,
'2016/02/05',
20.90,
39.39);
 
INSERT INTO LIVRO
VALUES (
'9788576831303',
'DIARIO DE UM BANANA',
'um garoto da sexta série que não tem muitos amigos, não é muito popular...',
1,
22,
'2007/04/01',
22.90,
30.90);

INSERT INTO LIVRO
VALUES (
'9788533613393',
'SENHOR DOS ANÉIS: O RETORNO DO REI',
'O confronto final entre as forças do bem e do mal que lutam pelo controle do futuro da Terra Média se aproxima.',
3,
10,
'1955/07/29',
60.45,
90.80);

INSERT INTO LIVRO
VALUES 
('9788553611218',
'CLT – CONSOLIDAÇÃO DAS LEIS DO TRABALHO',
'A CLT surgiu pelo Decreto-Lei nº 5.452, de 1 de maio de 1943, sancionada pelo então presidente Getúlio Vargas',
4,
20,
'2019/03/21',
110.00,
220.00
);

INSERT INTO LIVRO
VALUES (
'9788576849209',
'REGRAS DO JOGO',
'Mateus é um garoto pobre, afrodescendente, abandonado pelo pai ver- dadeiro e rejeitado pelo pai adotivo... ',
4,
21,
'2015/08/08',
20.50,
40.90
);

alter table autor drop column dtnascimento_aut;

INSERT INTO AUTOR VALUES (NULL, 'JOSE SABINO');
INSERT INTO AUTOR VALUES (NULL, 'MARIA DAS DORES');
INSERT INTO AUTOR VALUES (NULL, 'ANTONIO ARMINIO');
INSERT INTO AUTOR VALUES (NULL, 'CARLOS EDUARDO');
INSERT INTO AUTOR VALUES (NULL, 'VILMA DE OLIVEIRA');
INSERT INTO AUTOR VALUES (NULL, 'ANA MARIA');

-- LIVRO_AUTOR --
INSERT INTO LIVRO_AUTOR VALUES ('9788504019742', 1);
INSERT INTO LIVRO_AUTOR VALUES ('9788562409882', 1);
INSERT INTO LIVRO_AUTOR VALUES ('9788562409882', 3);
INSERT INTO LIVRO_AUTOR VALUES ('9788593156755', 2);
INSERT INTO LIVRO_AUTOR VALUES ('9788555390494', 5);
INSERT INTO LIVRO_AUTOR VALUES ('9788555390494', 6);
INSERT INTO LIVRO_AUTOR VALUES ('9788504019742', 6);
INSERT INTO LIVRO_AUTOR VALUES ('9788582714225', 5);
INSERT INTO LIVRO_AUTOR VALUES ('9788504019742', 4);
INSERT INTO LIVRO_AUTOR VALUES ('9788553611218', 3);
INSERT INTO LIVRO_AUTOR VALUES ('9788576831303', 4);
INSERT INTO LIVRO_AUTOR VALUES ('9788576831303', 2);
INSERT INTO LIVRO_AUTOR VALUES ('9788593911224', 1);
INSERT INTO LIVRO_AUTOR VALUES ('9788569514732', 6);

SELECT * FROM AUTOR;
-- LIVRO_CATEGORIA
INSERT INTO LIVRO_CATEGORIA VALUES ('9788504019742', 24);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788562409882', 1);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788562409882', 3);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788593156755', 9);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788555390494', 10);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788555390494', 11);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788504019742', 23);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788582714225', 5);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788504019742', 16);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788553611218', 9);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788576831303', 10);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788576831303', 11);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788593911224', 21);
INSERT INTO LIVRO_CATEGORIA VALUES ('9788569514732', 21);

/*___________________________________________________________*/
/* SCRIPT III - INSERIR DADOS */

-- Cliente
INSERT INTO CLIENTE 
(LOGIN_ID_CLI, SENHA_CLI, NOME_CLI, CPF_CLI, TELEFONE_CLI, EMAIL_CLI, ENDERECO_CLI, BAIRRO_CLI, CIDADE_CLI, UF_ID_EST, CEP_CLI)
VALUES
('HENRI','1234567','HENRIQUE DA SILVA','47231907718','989867554', 'henri@teste.com.br','RUA GUAÍPA','LEOPOLDINA','São Paulo','SP','05578220');

INSERT INTO CLIENTE 
(LOGIN_ID_CLI, SENHA_CLI, NOME_CLI, CPF_CLI, TELEFONE_CLI, EMAIL_CLI, ENDERECO_CLI, BAIRRO_CLI, CIDADE_CLI, UF_ID_EST, CEP_CLI)
VALUES
('GUISZ','333','GUILHERME DA CRUZ','47137969909','6779867554', 'guisz@teste.com.br','RUA PIETRA','PERUS','São Paulo','SP','03958220');

INSERT INTO CLIENTE 
(LOGIN_ID_CLI, SENHA_CLI, NOME_CLI, CPF_CLI, TELEFONE_CLI, EMAIL_CLI, ENDERECO_CLI, BAIRRO_CLI, CIDADE_CLI, UF_ID_EST, CEP_CLI)
VALUES
('MARL','1234567','MARLI DE OLIVEIRA','49937813347','98067554', 'marl@teste.com.br','RUA ARGENTINA','MORRO DOCE','São Paulo','SP','07798420');

INSERT INTO CLIENTE 
(LOGIN_ID_CLI, SENHA_CLI, NOME_CLI, CPF_CLI, TELEFONE_CLI, EMAIL_CLI, ENDERECO_CLI, BAIRRO_CLI, CIDADE_CLI, UF_ID_EST, CEP_CLI)
VALUES
('FERZINHA','123','FERNANDA DE SOUZA','47329109816','8879867554', 'ferzinha@teste.com.br','RUA AFRICA','JARAGUA','São Paulo','SP','09815029');

/*---------- Carrinho 1 ----- */
INSERT INTO CARRINHO VALUES(
null,
'FERZINHA',
'2021/01/10',
'2021/01/15',
'',
'',
'',
'',
'SP',
5,
3);

/*---------- item Carrinho 1 ----- */
insert into item_carrinho values (
'9788580572186',
1,
1,
29.90,
'S');

insert into item_carrinho values (
'9788562409882',
1,
2,
23.80,
'S');


insert into item_carrinho values (
'9788562409882',
1,
2,
23.80,
'S');





/*---------- Carrinho 2 ----- */
INSERT INTO CARRINHO VALUES(
null,
'MARL',
'2021/02/13',
'2021/02/15',
'Rua XXXXXX',
'Apto 10',
'Centro',
'São Paulo',
'SP',
2,
4);

/*----------item  Carrinho 2 ----- */
insert into item_carrinho values (
'9788593156755',
2,
1,
34.90,
'S');


/*---------- Carrinho 3 ----- */
INSERT INTO CARRINHO VALUES(
null,
'MARL',
'2021/03/05',
'2021/03/08',
'Rua YYYYYYYY',
'',
'Vila Bela',
'São Paulo',
'SP',
1,
3);


/*----------item  Carrinho 3 ----- */
insert into item_carrinho values (
'9788593156755',
3,
1,
34.90,
'S');


insert into item_carrinho values (
'9788504019742',
3,
1,
39.90,
'S');


/*---------- Carrinho 4 ----- */
INSERT INTO CARRINHO VALUES(
null,
'GUISZ',
'2021/03/06',
'2021/03/15',
'',
'',
'',
'',
null,
1,
3);

/*----------item  Carrinho 4 ----- */
insert into item_carrinho values (
'9788575426234',
4,
1,
19.99,
'S');



/*---------- Carrinho 5 ----- */
INSERT INTO CARRINHO VALUES(
null,
'GUISZ',
'2021/03/06',
'2021/03/15',
'',
'',
'',
'',
null,
1,
1);


/*----------item  Carrinho 5 ----- */
insert into item_carrinho values (
'9788593911224',
5,
1,
39.39,
'N');

insert into item_carrinho values (
'9788533613393',
5,
1,
90.80,
'N');

/*---------- Carrinho 6 ----- */
INSERT INTO CARRINHO VALUES(
null,
'HENRI',
'2021/04/01',
'2021/04/05',
'',
'',
'',
'',
null,
5,
4);

insert into item_carrinho values (
'9788533613393',
6,
1,
90.80,
'N');
Select * from cliente;
/*_______________________________________________________________________*/
/* FIM */
