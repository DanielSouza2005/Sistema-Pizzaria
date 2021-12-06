using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Sistema_Pizzaria___Banco_Firebird
{
    public class clientes_DAL

    {
        string strConn = @"DataSource=localhost; Database=D:\Daniel\BD\PIZZARIA.FDB; username = SYSDBA; password=masterkey;";

        public IList<clientes_DTO> cargaClientes()
        {
            try
            {
                FbConnection conn;
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT * FROM TB_CLIENTES";
                cm.Connection = conn;

                FbDataReader ER;
                IList<clientes_DTO> listClientesDTO = new List<clientes_DTO>();

                conn.Open();
                ER = cm.ExecuteReader();

                if (ER.HasRows)

                {
                    while (ER.Read())

                    {
                        clientes_DTO cli = new clientes_DTO();
                        cli.cli_codigo = Convert.ToInt32(ER["cli_codigo"]);
                        cli.cli_nome = Convert.ToString(ER["cli_nome"]);
                        cli.cli_cpf = Convert.ToString(ER["cli_cpf"]);
                        cli.cli_endereco = Convert.ToString(ER["cli_endereco"]);
                        cli.cli_bairro = Convert.ToString(ER["cli_bairro"]);
                        cli.cli_numero = Convert.ToInt32(ER["cli_numero"]);
                        cli.cli_complemento = Convert.ToString(ER["cli_complemento"]);
                        cli.cli_uf = Convert.ToString(ER["cli_uf"]);
                        cli.cli_cep = Convert.ToString(ER["cli_cep"]);
                        cli.cli_telefone = Convert.ToString(ER["cli_telefone"]);
                        cli.cli_celular = Convert.ToString(ER["cli_celular"]);
                        cli.cli_email = Convert.ToString(ER["cli_email"]);
                        listClientesDTO.Add(cli);

                    }

                }
                return listClientesDTO;

            }
            catch (Exception fbex)
            {
                throw fbex;
            }
        }
        public int insereClientes(clientes_DTO cli)
        {
            try
            {
                FbConnection conn = new FbConnection();
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "INSERT INTO tb_clientes (cli_codigo, cli_nome, cli_cpf, cli_cep, cli_endereco," +
                    "cli_numero, cli_complemento, cli_bairro, cli_uf, cli_telefone, cli_celular, cli_email)" +
                    "VALUES (@cli_codigo, @cli_nome, @cli_cpf, @cli_cep, @cli_endereco, @cli_numero, " +
                    "@cli_complemento, @cli_bairro, @cli_uf, @cli_telefone, @cli_celular, @cli_email)";

                cm.Parameters.Add("cli_codigo", FbDbType.Integer).Value = cli.cli_codigo;
                cm.Parameters.Add("cli_nome", FbDbType.VarChar).Value = cli.cli_nome;
                cm.Parameters.Add("cli_cpf", FbDbType.VarChar).Value = cli.cli_cpf;
                cm.Parameters.Add("cli_cep", FbDbType.VarChar).Value = cli.cli_cep;
                cm.Parameters.Add("cli_endereco", FbDbType.VarChar).Value = cli.cli_endereco;
                cm.Parameters.Add("cli_numero", FbDbType.Integer).Value = cli.cli_numero;
                cm.Parameters.Add("cli_complemento", FbDbType.VarChar).Value = cli.cli_complemento;
                cm.Parameters.Add("cli_bairro", FbDbType.VarChar).Value = cli.cli_bairro;
                cm.Parameters.Add("cli_uf", FbDbType.VarChar).Value = cli.cli_uf;
                cm.Parameters.Add("cli_telefone", FbDbType.VarChar).Value = cli.cli_telefone;
                cm.Parameters.Add("cli_celular", FbDbType.VarChar).Value = cli.cli_celular;
                cm.Parameters.Add("cli_email", FbDbType.VarChar).Value = cli.cli_email;

                cm.Connection = conn;

                conn.Open();
                int qtd = cm.ExecuteNonQuery();
                return qtd;


            }
            catch (FbException fbex)
            {
                throw fbex;
            }
        }
        public int editaClientes(clientes_DTO cli)
        {
            try
            {
                FbConnection conn = new FbConnection();
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "UPDATE tb_clientes SET "
                    + "cli_nome=@cli_nome," + "cli_cpf=@cli_cpf," +
                    "cli_cep=@cli_cep," + "cli_endereco=@cli_endereco, " +
                    "cli_numero=@cli_numero," + "cli_complemento=@cli_complemento," +
                    "cli_bairro=@cli_bairro," + "cli_uf=@cli_uf," + "cli_telefone=@cli_telefone," +
                    "cli_celular=@cli_celular," + "cli_email=@cli_email " +
                    "WHERE cli_codigo=@cli_codigo";

                cm.Parameters.Add("cli_codigo", FbDbType.Integer).Value = cli.cli_codigo;
                cm.Parameters.Add("cli_nome", FbDbType.VarChar).Value = cli.cli_nome;
                cm.Parameters.Add("cli_cpf", FbDbType.VarChar).Value = cli.cli_cpf;
                cm.Parameters.Add("cli_cep", FbDbType.VarChar).Value = cli.cli_cep;
                cm.Parameters.Add("cli_endereco", FbDbType.VarChar).Value = cli.cli_endereco;
                cm.Parameters.Add("cli_numero", FbDbType.Integer).Value = cli.cli_numero;
                cm.Parameters.Add("cli_complemento", FbDbType.VarChar).Value = cli.cli_complemento;
                cm.Parameters.Add("cli_bairro", FbDbType.VarChar).Value = cli.cli_bairro;
                cm.Parameters.Add("cli_uf", FbDbType.VarChar).Value = cli.cli_uf;
                cm.Parameters.Add("cli_telefone", FbDbType.VarChar).Value = cli.cli_telefone;
                cm.Parameters.Add("cli_celular", FbDbType.VarChar).Value = cli.cli_celular;
                cm.Parameters.Add("cli_email", FbDbType.VarChar).Value = cli.cli_email;


                cm.Connection = conn;

                conn.Open();
                int qtd = cm.ExecuteNonQuery();
                return qtd;
            }
            catch (Exception fbex)
            {
                throw fbex;
            }
        }

        public int deletaClientes(clientes_DTO cli)
        {
            try
            {
                FbConnection conn = new FbConnection();
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;

                cm.CommandText = "DELETE FROM tb_clientes WHERE cli_codigo = @cli_codigo";
                cm.Parameters.Add("cli_codigo", FbDbType.Integer).Value = cli.cli_codigo;

                cm.Connection = conn;

                conn.Open();
                int qtd = cm.ExecuteNonQuery();
                return qtd;

            }
            catch (FbException fbex)
            {
                throw fbex;
            }
        }
    }
}
