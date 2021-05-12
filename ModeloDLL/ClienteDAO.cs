using BancoADO;
using Dominios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDLL
{
    public class ClienteDAO
    {
        private Banco db = new Banco();

        public void Insert(Cliente cliente)
        {
            string strInsert = string.Format("insert into cliente(login_id_cli, senha_cli, nome_cli, cpf_cli, telefone_cli, endereco_cli, complemento_cli, email_cli, bairro_cli, cidade_cli, uf_id_est, cep_cli) " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');",
                    cliente.login_id_cli, cliente.senha_cli, cliente.nome_cli, cliente.cpf_cli, cliente.telefone_cli, cliente.endereco_cli,
                    cliente.complemento_cli, cliente.email_cli, cliente.bairro_cli, cliente.cidade_cli, cliente.uf_id_est, cliente.cep_cli);

            db.ExecutaComando(strInsert);
        }
        public void Update(Cliente cliente)
        {
            string strInsert = "update tbUsusrio set ";
            strInsert += string.Format("senha_cli = '{0}',", cliente.senha_cli);
            strInsert += string.Format("nome_cli = '{0}',", cliente.senha_cli);
            strInsert += string.Format("cpf_cli = '{0}',", cliente.senha_cli);
            strInsert += string.Format("telefone_cli = '{0}',", cliente.telefone_cli);
            strInsert += string.Format("where login_id_cli = '{0}',", cliente.login_id_cli);
            db.ExecutaComando(strInsert);
        }
        public MySqlDataReader Select()
        {
            string strString = "select * From cliente ";
            return db.RetornaComando(strString);
        }
    }
}
