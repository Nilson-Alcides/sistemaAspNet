   
use dbbanco;


select * from tbusuario;


SELECT *,date_format(`DataNasc`,'%d/%m/%Y') as `data_formatada` FROM `tbusuario`;
-- ======================================
INSERT INTO tbusuario (NomeUsu,Cargo,DataNasc)
             values('Teste','Teste',STR_TO_DATE( '31/05/2014', '%d/%m/%Y' ));
             
-- =======================================
insert into tbusuario (NomeUsu,Cargo,DataNasc) 
             values('Teste2','Teste2',STR_TO_DATE( '15/01/2017 10:10:15','%d/%m/%Y %H:%i:%s'));


-- ===============================================


insert into tbUSUARIO(NomeUsu, Cargo, DataNasc) values('Enildo','Enildo29/11/1990',STR_TO_DATE( '29/11/1990', '%d/%m/%Y' ));
