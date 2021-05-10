using BancoADO;
using Dominios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloDLL
{
    public class UsuarioDAO
    {
        private Banco db = new Banco();

        public void Insert(Usuario usuario)
        {
            //string strInsert = string.Format("insert into tbUSUARIO(NomeUsu, Cargo, DataNasc) " +
            //                               "values('{0}','{1}',STR_TO_DATE( '{2}', '%d/%m/%Y' ));"
            //, usuario.NomeUsu, usuario.Cargo, usuario.DataNasc);

            string strInsert = string.Format("insert into tbUSUARIO(NomeUsu, Cargo, SenhaUsu, DataNasc) " +
                    "values('{0}','{1}','{2}','{3}');", usuario.NomeUsu, usuario.Cargo, usuario.Senha, (usuario.DataNasc).ToString("yyyy-MM-dd"));

            db.ExecutaComando(strInsert);
        }

        public void Update(Usuario usuario)
        {
            string strInsert = "update tbUsusrio set ";
            strInsert += string.Format("NomeUsu = '{0}',", usuario.NomeUsu);
            strInsert += string.Format("Cargo = '{0}',", usuario.Cargo);
            strInsert += string.Format("SenhaUsu = '{0}',", usuario.Senha);
            strInsert += string.Format("DataNasc = '{0}',", (usuario.DataNasc).ToString("yyyy-MM-dd"));
            strInsert += string.Format("where IdUsu = '{0}',", usuario.IdUsu);
            db.ExecutaComando(strInsert);
        }

        public void Delete(Usuario usuario)
        {
            string strInsert = "delete from tbUsusrio";
            strInsert += string.Format("where IdUsu = '{0}',", usuario.IdUsu);
            db.ExecutaComando(strInsert);
        }

        public MySqlDataReader Select()
        {
            string strString = "select * From tbUSUARIO ";
            return db.RetornaComando(strString);
        }

    }
}
