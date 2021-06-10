-- --------------------------------------------------------
-- inserindo dados da tabela `autor`
--
INSERT INTO autor (nomeAutor) VALUES
('JOSE SABINO'),
('MARIA DAS DORES'),
('ANTONIO ARMINIO'),
('CARLOS EDUARDO'),
('VILMA DE OLIVEIRA'),
('ANA MARIA');

select * from autor;
-- --------------------------------------------------------
-- inserindo dados da tabela `categoria`
--
INSERT INTO categoria (nomeCategoria) VALUES
('ADMINISTRAÇÃO'),
('ARTES'),
('AUTOAJUDA'),
('CIÊNCIAS BIOLÓGICAS'),
('CIÊNCIAS EXATAS'),
('CIÊNCIAS HUMANAS E SOCIAIS'),
('DIDÁTICOS'),
('DIREITO'),
('DIVERSOS'),
('ECONOMIA'),
('ESOTERISMO'),
('ESPORTES E LAZER'),
('GEOGRAFIA E HISTORIA'),
('INFORMÁTICA'),
('LINGUÍSTICA'),
('LITERATURA BRASILEIRA	'),
('LITERATURA ESTRANGEIRA'),
('MEDICINA'),
('PSICOLOGIA E PSICANÁLISE'),
('RELIGIÃO'),
('FICÇÃO CIENTÍFICA FANTASIA'),
('BIOGRAFIA'),
('AVENTURA'),
('FANTASIA'),
('INFANTO JUVENIL');

select * from categoria;

-- --------------------------------------------------------
-- inserindo dados da tabela `cliente`
--
INSERT INTO cliente (nomeCliente, cpfCliente, emailCliente, 
sexoCliente, dataNascCliente, statusCliente) 
VALUES
('HENRIQUE DA SILVA', '47231907718', 'henri@teste.com.br', 'M', 
'2020-10-28 00:00:00', 'Ativo'),
('Guilherme da Cruz', '47137969909', 'guisz@teste.com.br', 'M',
 '2020-02-15 00:00:00', 'Ativo'),
('Bruno Eduardo Alcides', '05872112310', 'bruno@htomail.com', 'M',
 '2020-09-12 00:00:00', 'Ativo'),
('Claudia oliveira', '03875236910', 'claudia@hotmail.com', 'F',
 '2020-04-07 00:00:00', 'Ativo'),
('Joao de Deus', '05896578252', 'joao@hotmail.com', 'M',
 '1978-10-21 00:00:00', 'Ativo'),
('Matheus', '05789345262', 'matheus@hotmail.com', 'M',
 '2020-10-12 00:00:00', 'Ativo'),
('NILSON JOSE ALCIDES', '05879565410', 'Nilsonalcise@gmail.com', 'M',
 '2020-10-12 00:00:00', 'Ativo'),
('Thiago Asley', '02545454564', 'thiago@gmail.com', 'M', 
'2005-04-07 00:00:00', 'Ativo'),
('Claudia Oliveira Peixoto ', '20020020010', 'elisabete@gmail.com', 'F', 
'1981-12-15 00:00:00','Ativo'),
('Elisabete Ribeiro Alcides', '22220020001', 'elisabete@gmail.com', 'F',
 '1981-12-15 00:00:00', 'Ativo');

select * from cliente;

-- --------------------------------------------------------
-- Inserindo dados da tabela `editora`
--
INSERT INTO editora (nomeEditora) VALUES
('INTRINSECA'),
('ARQUEIRO'),
('RECORD'),
('SEXTANTE / GMT'),
('GENTE'),
('EDITORA NACIONAL'),
('CAMINHO SUAVE ED.'),
('ROCCO'),
('AGORA EDITORA'),
('COMPANHIA DAS LETRAS'),
('OBJETIVA'),
('BUZZ EDITORA'),
('RECORD'),
('GLOBO ART'),
('ALPH'),
('VALENTINA'),
('ARTMED'),
('FARO EDITORIAL'),
('BALÃO EDITORIAL'),
('BERTRAND BRASIL'),
('DAVID FINKING BOOKS'),
('SARAIVA'),
('MARTINS FONTES');

select * from editora;

-- --------------------------------------------------------
-- Inserindo dados da tabela `endereco do cliente`
--
INSERT INTO endereco (idCliente, logradouro, numero, complemento,
 bairro, CEP, cidade, estado, UF)
 VALUES
(1, 'Rua Tarira', 36, 'Casa 11', 'Santos', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(2, 'Rua Carvalho', 129, 'Casa 2', 'Pinheiros','5882120','São Paulo','São Paulo', 'SP'),
(3, 'Rua Quinze', 36, 'Casa 11', 'Leme', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(4, 'Rua Das Flores', 129, '', 'Jardim São Bento', '5882120', 'São Paulo', 'São Paulo', 'SP'),
(5, 'Rua 1° de Maio', 36, 'Casa 11', 'Jd do Santo', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(6, 'Rua 15 de Abril', 129, 'Casa 2', 'Bento', '5882120', 'São Paulo', 'São Paulo', 'SP'),
(7, 'Rua Tabajara', 36, 'Casa', 'Santo', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(8, 'Av. terra Santa', 129, 'Casa 2', 'Aovo', '5882120', 'São Paulo', 'São Paulo', 'SP'),
(9, 'Rua 7 de Junho', 129, 'Casa 2', 'São Bento', '5882120', 'São Paulo', 'São Paulo', 'SP'),
(10, 'Praça dos Poderes ', 129, 'Esquina 20', 'Jardim', '5882120', 'São Paulo', 'São Paulo', 'SP');


select * from endereco;
select  * from cliente;

-- --------------------------------------------------------
-- Inserindo dados da tabela `formatolivro`
--
INSERT INTO formatolivro (idFormato, descricao_for) VALUES
(1, 'CAPA DURA'),
(2, 'GRAMPO'),
(3, 'BROCHURA'),
(4, 'DIGITAL'),
(5, 'ASPIRAL');
select * from formatolivro;

-- --------------------------------------------------------
-- Inserindo dados da tabela `funcionario`
--
INSERT INTO funcionario (nomeFunc, cpfFunc, emailFunc, cargo, senhaFunc, nivelAcesso) 
VALUES
('Nilson Jose', '03958220035', 'nilson@gmail.com', 'Gerente geral', '123456', 'Admin'),
('João Almeida Ribeiro', '47329109816', 'joao@gmail.com', 'Analista de banco de dados',
 '123456', 'Usuario'),
('MARIA DE OLIVEIRA', '45329103256', 'maria@gmail.com', 'Analista mobile', '789654', 
'Usuario'),
('CARLOS DA SILVA', '50029103789', 'carlos@gmail.com', 'Analista de sistema', '123456', 
'Admin'),
('Natalia', '39845612310', 'natali@gmail.com', 'Analista de sistema', '123456', 
'Usuario'),
('Matheus Ribeiro', '09812345610', 'matheus@gmail.com', 'Gerente de Negocios', '123456',
 'Admin'),
('Bruno Eduardo', '20020020010', 'bruno@gmail.com', 'Analista de Mobile', '123456',
 'Admin'),
('Mileni', '07896312520', 'mileni@hotmail.com', 'Analista de Mobile', '123456', 'Admin'),
('NILSON JOSE ALCIDES', '39845612310', 'Nilsonalcise@gmail.com', 'Gerente de Negocios',
 '123456', 'Admin'),
('Elisabete Ribeiro', '02002202212', 'elisabete@gmail.com', 'Analista de Mobile',
 '123123', 'Usuario');

Select * from funcionario;

-- --------------------------------------------------------
-- Inserindo dados da tabela `endereco do funcionario`
--
INSERT INTO endereco (idFunc, logradouro, numero, complemento,
 bairro, CEP, cidade, estado, UF)
 VALUES
(1, 'Rua Tarira', 36, 'Casa 11', 'Jd do Santo', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(2, 'Rua Carvalho', 129, 'Casa 2', 'Pinheiros','5882120','São Paulo','São Paulo', 'SP'),
(3, 'Rua Quinze', 36, 'Casa 11', 'Leme', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(4, 'Rua Das Flores', 129, '', 'Jardim São Bento', '5882120', 'São Paulo', 'São Paulo', 'SP'),
(5, 'Rua 1° de Maio', 36, 'Casa 11', 'Jd do Santo', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(6, 'Rua 15 de Abril', 129, 'Casa 2', 'Bento', '5882120', 'São Paulo', 'São Paulo', 'SP'),
(7, 'Rua Tabajara', 36, 'Casa', 'Santo', '05842120', 'São Paulo', 'São Paulo', 'SP'),
(8, 'Av. terra Santa', 129, 'Casa 2', 'Aovo', '5882120', 'São Paulo', 'São Paulo', 'SP'),
(9, 'Rua 7 de Junho', 129, 'Casa 2', 'São Bento', '5882120', 'São Paulo', 'São Paulo', 'SP');


select * from endereco;
select  * from vwfuncionario;

-- --------------------------------------------------------
-- Inserindo dados da tabela `livro`
--
INSERT INTO livro (idLivro, idFormato, idEditora, idAutor, idCategoria, isbn, 
titulo, descricao, capaLivro, paginas, estoque, valorUnit, dataLanc)
VALUES
('L1', 1, 13, 1, 1, '8533613377', 'O SENHOR DOS ANÉIS I - A SOCIEDADE DO ANEL', 
'Em uma terra fantástica e única, um hobbit recebe de presente de seu tio um anel
 mágico e maligno que\nprecisa ser destruído antes que caia nas mãos do mal', '',
 600, 50, '44.00', '2000-02-03'),
('L2', 1, 14, 2, 5, '9788582714225', 'BIOLOGIA MOLECULAR DA CÉLULA - 6ª ED. 2017', 
'De modo mais específico, a Biologia Molecular busca compreender os mecanismos de\n
 replicação, transcrição e tradução do material genético,', '', 1000, 75, '342.90',
 '2017-01-01'),
('L3', 1, 1, 5, 2, '9788580572186', 'CINQUENTA TONS DE CINZA', 'A estudante de literatura
 Anastasia Steele, de 21 anos, entrevista o jovem bilionário Christian Grey, como um favor
 a sua colega de quarto Kate Kavanagh.', '', 800, 30, '29.90', '2011-06-20');
 
Select * from livro;

-- --------------------------------------------------------
-- Inserindo dados da tabela `pagamento`
--
INSERT INTO pagamento (FormaPag, ModalPag, numParcela) VALUES
('DEBITO', 'A VISTA', ''),
('Dinheiro', '', ''),
('Cartão', 'CRED A VISTA', ''),
('Cartão', 'CREDITO', 'PARC 2 VEZES SEM JUROS'),
('Cartão', 'CREDITO', 'PARC 3 VEZES SEM JUROS'),
('Cartão', 'CREDITO', 'PARC 4 VEZES SEM JUROS'),
('Cartão', 'CREDITO', 'PARC 5 VEZES SEM JUROS'),
('Cartão', 'CREDITO', 'PARC 3 VEZES SEM JUROS');

Select * from pagamento;

-- --------------------------------------------------------
-- Inserir dados da tabela `produto`
--
INSERT INTO produto (idProduto, idCategoria, nomeProd, marcaProd, quantidade, preco)
 VALUES
('P1', 14, 'Teclado sem fio', 'Exbom', 100, 15),
('P2', 9, 'Caneta', 'Bic', 300, 5),
('P3', 9, 'Marca texto', 'Pimaco', 300, 5);

select * from produto;

-- --------------------------------------------------------
-- Inserindo dados da tabela `telefone` fone cliente
--
INSERT INTO telefone (idCliente, numTel1, numTel2, numTel3)
 VALUES
(1, 11958732495, NULL, NULL),
(2, 1136905021, NULL, NULL),
(3, 1158703526, NULL, NULL),
(4, 1174016147, NULL, 1125656326),
(5, 1156452312, 1125956545, 1125658978),
(6, 1178954625, 1178954526, NULL),
(7, 1198562545, 1174259845, 1167896245),
(8, 1145789625, 1125647896, NULL),
(9, 1125456525, 1185794512, 1175984625),
(10, 1185964578, NULL, 1136457896);

select * from telefone;

-- --------------------------------------------------------
-- Inserindo dados da tabela `telefone` fone funcionarios
--
INSERT INTO telefone (idFunc, numTel1, numTel2, numTel3)
 VALUES
(1, 11958732495, NULL, NULL),
(2, 1136905021, NULL, NULL),
(3, 1158703526, NULL, NULL),
(4, 1174016147, 1130979730, 1125656326),
(5, 1156452312, NULL, 1125658978),
(6, 1178954625, 1178954526, NULL),
(7, 1198562545, 1174259845, 1167896245),
(8, 1145789625, NULL, 1174259635),
(9, 1125456525, 1185794512, NULL),
(10, 1185964578, 1165789645, 1136457896);

select * from vwfuncionario;

-- --------------------------------------------------------

