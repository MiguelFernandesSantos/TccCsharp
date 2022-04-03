using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace GerenciadorDeOs
{

    class DataBase
    {
        // string para conectar com o banco de dados:
        public string ConnectionString { get; set; }
        // conector mysql:
        public MySqlConnection connection { get; set; }
        // execultador de sql:
        public MySqlCommand command { get; set; }

        // metodo construtor:
        public DataBase()
        {

            // atribuindo valor para a connection string:
            ConnectionString = "Server=localhost;Database=DataChamado;uid=Miguel;pwd=Photomemories@123";
            
            // criando uma conexao com o banco de dados usando a string:
            connection = new MySqlConnection(ConnectionString);

            // criando um execultador de sql:
            command = connection.CreateCommand();

        }

        // Metodo abrir conexao:
        public void AbrirConexao()
        {
            
            // verifica se ja nao esta aberta:
            if(this.connection.State != System.Data.ConnectionState.Open)
            {

                // abre a conexao:
                connection.Open();

            }

        }

        // Metodo fechar conexao:
        public void FecharConexao()
        {

            // verifica se ja nao esta fechada:
            if (this.connection.State != System.Data.ConnectionState.Closed)
            {

                // fecha a conexao:
                connection.Close();

            }

        }

        // metodo para inserir cargo:
        public void InserirCargo(string nome, int permissao)
        {

            // passa uma string para o execultador de comando:
            this.command.CommandText = "insert into Tb_Cargo ( " +
                                       "Tb_Cargo_Nome, Tb_Cargo_Permissao ) " +
                                       "Values ( '@Nome', @Permissao )";

            // adiciona o parametro nome:
            this.command.Parameters.AddWithValue("@Nome", nome);

            // adiciona o parametro permissao:
            this.command.Parameters.AddWithValue("@Permissao", permissao);

            // abre a conexao:
            this.AbrirConexao();

            // execulta a query:
            command.ExecuteNonQuery();

            // fecha a conexao:
            this.FecharConexao();


        }

        // metodo para verificar se o usuario existe:
        public int UsuarioExiste(string usuario, string senha, string Tipo)
        {

            // Declara uma variavel do tipo inteiro para armazenar a quantidade de valores retornados pela query Select:
            int QuantidadeRegistros;

            // cria um adaptador sql:
            MySqlDataAdapter adapter = null;

            // cria uma tabela para os dados:
            DataTable Table = new DataTable();

            // Cria uma string para ser utilizada como uma query SQL:
            string SelectLogin = String.Format("select tb_funcionario_matricula, tb_funcionario_senha from Tb_funcionario Where Tb_funcionario_matricula = {0} and tb_funcionario_senha = '{1}'", usuario, senha);

            // para a conexao e a string para o adaptador:
            adapter = new MySqlDataAdapter(SelectLogin, this.connection);

            // adiciona os dados na tabela:
            adapter.Fill(Table);

            // conta quantos registros foram retornados e armazena na variavel:
            QuantidadeRegistros = Table.Rows.Count;

            // verifica se retornou algo:
            if(QuantidadeRegistros > 0 && Tipo == "Login")
            {

                // pega o id da primeira linha:
                int id = Convert.ToInt32(Table.Rows[0][0]);

                // retorna o id:
                return id;

            }

            // O metodo retorna o numero de registros:
            return QuantidadeRegistros;

        }

    }

}
