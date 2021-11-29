using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ExemploBancoDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestarConexao();
            //TestarCadastro();
            var result = TestarPesquisa();
        }

        static void TestarConexao()
        {
            try
            {
                var connection = ConnectionManager.GetConnection();
                connection.Open();
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TestarCadastro()
        {
            try
            {
                var contatos = ListarContatos();

                var connection = ConnectionManager.GetConnection();
                connection.Open();

                foreach(var contato in contatos)
                {
                    var query = "insert into contato (id, nome, email, fone) values (@id, @nome, @email, @fone)";

                    var command = new SqlCommand(query, connection);

                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = contato.Id;
                    command.Parameters.Add("@nome", SqlDbType.VarChar).Value = contato.Nome;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = contato.Email;
                    command.Parameters.Add("@fone", SqlDbType.VarChar).Value = contato.Fone;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static List<Contato> TestarPesquisa()
        {
            try
            {
                var contatos = new List<Contato>();

                var connection = ConnectionManager.GetConnection();
                connection.Open();

                var query = "select id, nome, email, fone from contato order by nome";
                var command = new SqlCommand(query, connection);

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);

                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach(DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var email = colunas[2].ToString();
                    var fone = colunas[3].ToString();

                    var contato = new Contato(id, nome, email, fone);
                    contatos.Add(contato);
                }

                connection.Close();

                return contatos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        static List<Contato> ListarContatos()
        {
            var contatos = new List<Contato>();

            var c1 = new Contato("Joao Silva","joao.silva@gmail.com","11 1010-2054");
            var c2 = new Contato("Pedro Santos", "pedro.santos@gmail.com", "11 3366-5070");
            var c3 = new Contato("Antonio Alves", "antonio.alves@gmail.com", "11 4020-7895");

            contatos.Add(c1);
            contatos.Add(c2);
            contatos.Add(c3);

            return contatos;
        }
    }
}
