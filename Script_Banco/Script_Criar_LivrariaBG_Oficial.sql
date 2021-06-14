-- -----------------------------------------------------
-- Schema livrariabg
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS livrariabg DEFAULT CHARACTER SET utf8 ;
USE livrariabg;

-- -----------------------------------------------------
-- 1° Table autor --
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS autor (
  idAutor INT(11) NOT NULL AUTO_INCREMENT,
  nomeAutor VARCHAR(100) NOT NULL,
  PRIMARY KEY (idAutor))
DEFAULT CHARACTER SET = utf8;

-- -----------------------------------------------------
-- 2° Table categoria
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS categoria(
  idCategoria INT(11) NOT NULL AUTO_INCREMENT,
  nomeCategoria VARCHAR(100) NOT NULL,
  PRIMARY KEY (idCategoria))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 3° Table cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS cliente (
  idCliente INT(11) NOT NULL AUTO_INCREMENT,
  nomeCliente VARCHAR(45) NOT NULL,
  cpfCliente VARCHAR(11) NOT NULL,
  emailCliente VARCHAR(45) NOT NULL,
  sexoCliente CHAR(1) NOT NULL,
  dataNascCliente DATETIME NOT NULL,
  statusCliente VARCHAR(45) NOT NULL,
  PRIMARY KEY (idCliente))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 4° Table editora
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS editora (
  idEditora INT(11) NOT NULL AUTO_INCREMENT,
  nomeEditora VARCHAR(100) NOT NULL,
  PRIMARY KEY (idEditora))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 5° Table funcionario
CREATE TABLE IF NOT EXISTS funcionario (
  idFunc INT(11) NOT NULL AUTO_INCREMENT,
  nomeFunc VARCHAR(45) NOT NULL,
  cpfFunc VARCHAR(11) NOT NULL,
  emailFunc VARCHAR(45) NOT NULL,
  cargo VARCHAR(45) NOT NULL,
  senhaFunc VARCHAR(45) NOT NULL,
  nivelAcesso VARCHAR(15) NOT NULL,
  PRIMARY KEY (idFunc))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 6° Table endereco
CREATE TABLE IF NOT EXISTS endereco (
  idEndereco INT(11) NOT NULL AUTO_INCREMENT,
  idCliente INT(11) NULL DEFAULT NULL,
  idFunc INT(11) NULL DEFAULT NULL, 
  logradouro VARCHAR(45) NOT NULL,
  numero INT(11) NOT NULL,
  complemento VARCHAR(45) NOT NULL,
  bairro VARCHAR(45) NOT NULL,
  CEP VARCHAR(9) NOT NULL,
 cidade VARCHAR(100) NOT NULL,
  estado VARCHAR(100) NOT NULL,
  UF CHAR(2) NOT NULL,
  PRIMARY KEY (idEndereco),  
    FOREIGN KEY (idCliente) REFERENCES cliente (idCliente),  
    FOREIGN KEY (idFunc) REFERENCES funcionario (idFunc))
DEFAULT CHARACTER SET = utf8;
Select * from endereco;
ALTER TABLE endereco DROP  tipoEndereco;

-- -----------------------------------------------------
-- 7° Table formatolivro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS formatolivro (
  idFormato INT(11) NOT NULL AUTO_INCREMENT,
  descricao_for VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (idFormato))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 8° Table pagamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS pagamento (
  idPagamento INT(11) NOT NULL AUTO_INCREMENT,
  FormaPag VARCHAR(45) NOT NULL,
  ModalPag VARCHAR(100) NULL DEFAULT NULL,
  numParcela VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (idPagamento))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 9° Table pedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS pedido (
  idpedido INT(11) NOT NULL AUTO_INCREMENT,
  idFunc INT(11) NULL DEFAULT NULL,
  idCliente INT(11) NULL DEFAULT NULL,
  idPagamento INT(11) NULL DEFAULT NULL,
  tipoEntrega VARCHAR(45) NULL DEFAULT NULL,
  quantidade INT(11) NULL DEFAULT NULL,
  statusPedido VARCHAR(45) NULL DEFAULT NULL,
  valorTotal DECIMAL(10,2) NULL DEFAULT NULL,
  dataPedido DATE NULL DEFAULT NULL,
  dataEntrega DATE NULL DEFAULT NULL,
  PRIMARY KEY (idpedido),  
    FOREIGN KEY (idFunc)  REFERENCES funcionario (idFunc),  
    FOREIGN KEY (idCliente) REFERENCES cliente (idCliente),  
    FOREIGN KEY (idPagamento) REFERENCES pagamento (idPagamento))
DEFAULT CHARACTER SET = utf8;

-- -----------------------------------------------------
-- 10° Table livro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS livro (
  idLivro VARCHAR(15) NOT NULL,
  idFormato INT(11) NULL DEFAULT NULL,
  idEditora INT(11) NULL DEFAULT NULL,
  idAutor INT(11) NULL DEFAULT NULL,
  idCategoria INT(11) NULL DEFAULT NULL,
  isbn CHAR(15) NULL DEFAULT NULL,
  titulo VARCHAR(100) NOT NULL,
  descricao VARCHAR(250) NULL DEFAULT NULL,
  capaLivro VARCHAR(45) NULL DEFAULT NULL,
  paginas INT(11) NULL DEFAULT NULL,
  estoque INT(11) NULL DEFAULT NULL,
  valorUnit DECIMAL(10,2) NULL DEFAULT NULL,
  dataLanc DATE NULL DEFAULT NULL,
  PRIMARY KEY (`idLivro`),  
    FOREIGN KEY (idEditora) REFERENCES editora (idEditora),  
    FOREIGN KEY (idFormato) REFERENCES formatolivro (idFormato),  
    FOREIGN KEY (idAutor) REFERENCES autor (idAutor),  
    FOREIGN KEY (idCategoria) REFERENCES categoria (idCategoria))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 11° Table produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS produto (
  idProduto VARCHAR(15) NOT NULL,
  idCategoria INT(11) NOT NULL,
  nomeProd VARCHAR(100) NOT NULL,
  marcaProd VARCHAR(45) NOT NULL,
  quantidade INT(11) NOT NULL,
  preco DOUBLE NOT NULL,
  PRIMARY KEY (idProduto),  
    FOREIGN KEY (idCategoria)  REFERENCES categoria (idCategoria))
DEFAULT CHARACTER SET = utf8;

-- -----------------------------------------------------
-- 12° Tableitenspedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS itenspedido (
  idItensPedido INT(11) NOT NULL AUTO_INCREMENT,
  idPedido INT(11) NULL DEFAULT NULL,
  idLivro VARCHAR(15) NULL,
  idProduto VARCHAR(15) NULL,
  qtdade_item INT(11) NULL DEFAULT NULL,
  valorTotal DOUBLE NULL DEFAULT NULL,
  status VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (idItensPedido),
     FOREIGN KEY (idPedido) REFERENCES pedido (idpedido),
     FOREIGN KEY (idLivro) REFERENCES livro (idLivro),  
    FOREIGN KEY (idProduto) REFERENCES produto (idProduto))
DEFAULT CHARACTER SET = utf8;

-- -----------------------------------------------------
-- 13° Tabletelefone`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS telefone (
  idTelefone INT(11) NOT NULL AUTO_INCREMENT,
  idCliente INT(11) NULL DEFAULT NULL,
  idFunc INT(11) NULL DEFAULT NULL,  
  numTel1 INT(11) NULL DEFAULT NULL,
  numTel2 INT(11) NULL DEFAULT NULL,
  numTel3 INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (idTelefone),
    FOREIGN KEY (idCliente) REFERENCES cliente (idCliente), 
    FOREIGN KEY (idFunc) REFERENCES funcionario (idFunc))
DEFAULT CHARACTER SET = utf8;
-- -----------------------------------------------------
-- 14° create View vwcliente`
-- -----------------------------------------------------
CREATE    
VIEW vwcliente AS SELECT 
        t1.idCliente,
        t1.nomeCliente,
        t1.cpfCliente,
        t1.emailCliente,
        t1.sexoCliente,
        t1.dataNascCliente,
        t2.numTel1 AS Celular,
        t2.numTel2 AS Residencial,
        t2.numTel3 AS Comercial,
        t3.logradouro AS Endereço,
        t3.numero as N°,
        t3.complemento,
        t3.CEP AS CEP,
        t3.bairro,
        t3.cidade,
        t3.estado,
        t3.UF AS uf,
        t1.statusCliente
    FROM cliente  as t1
        LEFT JOIN telefone as t2 ON t1.idCliente = t2.idCliente
        LEFT JOIN endereco as t3 ON t1.idCliente = t3.idCliente
    GROUP BY t1.idCliente;
    
    select * from vwcliente;
-- -----------------------------------------------------
-- 15° Create View vwfuncionario`
-- -----------------------------------------------------
CREATE VIEW vwfuncionario AS
    SELECT 
        t1.idFunc AS Código,
        t1.nomeFunc AS Nome,
        t1.cpfFunc AS CPF,
        t1.emailFunc AS Email,
        t1.cargo AS Cargo,
        t2.numTel1 AS Celular,
        t2.numTel2 AS Residencial,
        t2.numTel3 AS Comercial,
        t3.logradouro AS Endereço,
        t3.numero AS N°,
        t3.complemento,
        t3.CEP AS CEP,
        t3.bairro,
        t3.cidade,
        t3.estado,
        t3.UF,
        t1.senhaFunc AS Senha
    FROM funcionario AS t1
        LEFT JOIN telefone AS t2 ON t1.idFunc = t2.idFunc
        LEFT JOIN endereco AS t3 ON t1.idFunc = t3.idFunc
    GROUP BY t1.idFunc