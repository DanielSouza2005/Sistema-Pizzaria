using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Sistema_Pizzaria___Banco_Firebird
{
    public class vendas_BLL
    {
        string strConn = @"DataSource=localhost; Database=D:\Daniel\BD\PIZZARIA.FDB; username = SYSDBA; password=masterkey;";
        public IList<vendas_DTO> cargaVendas()
        {
            try
            {
                FbConnection conn;
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT * FROM tb_vendas";
                cm.Connection = conn;

                FbDataReader ER;
                IList<vendas_DTO> listVendasDTO = new List<vendas_DTO>();

                conn.Open();
                ER = cm.ExecuteReader();

                if (ER.HasRows)

                {
                    while (ER.Read())

                    {
                        vendas_DTO ven = new vendas_DTO();
                        ven.ven_numero = Convert.ToInt32(ER["ven_numero"]);
                        ven.cli_codigo = Convert.ToInt32(ER["cli_codigo"]);
                        //cli.cli_nome = Convert.ToString(ER["cli_nome"]);
                        //cli.cli_cpf = Convert.ToString(ER["cli_cpf"]);
                        ven.pro_codigo = Convert.ToInt32(ER["pro_codigo"]);
                        //pro.pro_nome = Convert.ToString(ER["pro_nome"]);
                        //pro.pro_preco = Convert.ToDouble(ER["pro_preco"]);
                        ven.ven_qtde = Convert.ToInt32(ER["ven_qtde"]);
                        ven.ven_tipopagto = Convert.ToString(ER["ven_tipopagto"]);
                        ven.ven_valortotal = Convert.ToDouble(ER["ven_valortotal"]);
                        listVendasDTO.Add(ven);

                    }

                }
                return listVendasDTO;

            }
            catch (Exception fbex)
            {
                throw fbex;
            }

        }

        public int insereVendas(vendas_DTO ven)
        {
            try
            {
                FbConnection conn = new FbConnection();
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "INSERT INTO tb_vendas (ven_numero, cli_codigo, pro_codigo, ven_qtde, ven_tipopagto, ven_valortotal)" +
                    "VALUES (@ven_numero, @cli_codigo, @pro_codigo, @ven_qtde, @ven_tipopagto, @ven_valortotal)";

                cm.Parameters.Add("ven_numero", FbDbType.Integer).Value = ven.ven_numero;
                cm.Parameters.Add("cli_codigo", FbDbType.Integer).Value = ven.cli_codigo;
                cm.Parameters.Add("pro_codigo", FbDbType.Integer).Value = ven.pro_codigo;
                cm.Parameters.Add("ven_qtde", FbDbType.Integer).Value = ven.ven_qtde;
                cm.Parameters.Add("ven_tipopagto", FbDbType.VarChar).Value = ven.ven_tipopagto;
                cm.Parameters.Add("ven_valortotal", FbDbType.Double).Value = ven.ven_valortotal;

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

        public int editaVendas(vendas_DTO ven)
        {
            try
            {
                FbConnection conn = new FbConnection();
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "UPDATE tb_vendas SET " +
                     "cli_codigo=@cli_codigo," + "pro_codigo=@pro_codigo," +
                     "ven_qtde=@ven_qtde, " + "ven_tipopagto=@ven_tipopagto," +
                    "ven_valortotal=@ven_valortotal WHERE ven_numero=@ven_numero";

                cm.Parameters.Add("cli_codigo", FbDbType.Integer).Value = ven.cli_codigo;
                cm.Parameters.Add("pro_codigo", FbDbType.Integer).Value = ven.pro_codigo;
                cm.Parameters.Add("ven_qtde", FbDbType.Integer).Value = ven.ven_qtde;
                cm.Parameters.Add("ven_tipopagto", FbDbType.VarChar).Value = ven.ven_tipopagto;
                cm.Parameters.Add("ven_valortotal", FbDbType.Double).Value = ven.ven_valortotal;
                cm.Parameters.Add("ven_numero", FbDbType.Integer).Value = ven.ven_numero;


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

        public int deletaVendas(vendas_DTO ven)
        {
            try
            {
                FbConnection conn = new FbConnection();
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = System.Data.CommandType.Text;

                cm.CommandText = "DELETE FROM tb_vendas WHERE ven_numero = @ven_numero";
                cm.Parameters.Add("ven_numero", FbDbType.Integer).Value = ven.ven_numero;

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
