
using Dominios;
using ModeloDLL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AppBanco
{
    class Program
    {
        static void Main(string[] args)
        {

            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            //Console.WriteLine("Digite o nome usúario");
            //usuario.NomeUsu = Console.ReadLine();
            //Console.WriteLine("Digite o cargo usúario");
            //usuario.Cargo = Console.ReadLine();
            //Console.WriteLine("Digite a data de nascimento do usúario");
            //usuario.DataNasc = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Digite a data de nascimento do usúario");
            //usuario.DataNasc = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Digite o Código do usúario");
            //usuario.IdUsu = int.Parse(Console.ReadLine());

            //usuarioDAO.Insert(usuario);
            //usuarioDAO.Update(usuario);
            //usuarioDAO.Delete(usuario);


            MySqlDataReader leitor = usuarioDAO.Select();


            while (leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Senha:{3} Data: {4}",
                         leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["SenhaUsu"], leitor["DataNasc"]);
            }

            Console.ReadLine();

        }
    }
}