using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Sistema_Pizzaria___Banco_Firebird
{
    public partial class Form1 : Form
    {
        public string strConn = @"DataSource=localhost; Database=D:\Daniel\BD\PIZZARIA.FDB; username = SYSDBA; password=masterkey;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FbConnection conn;
                conn = new FbConnection(strConn);
                FbCommand cm = new FbCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "SELECT usu_login, usu_senha FROM tb_usuario " +
                "where usu_login=@usu_login and usu_senha=@usu_senha";
                cm.Connection = conn;

                FbParameter Login = new FbParameter("@usu_login", FbDbType.VarChar);
                FbParameter Senha = new FbParameter("@usu_senha", FbDbType.VarChar);

                Login.Value = txtUsuario.Text;
                Senha.Value = txtSenha.Text;

                cm.Parameters.Add(Login);
                cm.Parameters.Add(Senha);
                conn.Open();

                FbDataReader Leitura = cm.ExecuteReader(CommandBehavior.CloseConnection);

                if (Leitura.Read() == true)
                {
                    txtUsuario.Clear();
                    txtSenha.Clear();                   
                    MessageBox.Show("Login realizado com sucesso!");
                    MenuPrincipal menu = new MenuPrincipal();
                    menu.ShowDialog();                   
                }
                else
                {
                    MessageBox.Show("Nome de usuário ou senha incorretos :(", "Acesso Negado!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtSenha.Clear();
                }
            }
            catch (Exception fbex)
            {
                MessageBox.Show("Erro inesperado " + fbex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string message = "Deseja Sair?";
            const string caption = "Sair do Sistema";

            var result = MessageBox.Show(message, caption,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*const string message = "Deseja Sair?";
            const string caption = "Sair do Sistema";

            var result = MessageBox.Show(message, caption,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);          
            if (result == DialogResult.No)
            {
                Application.Exit();
            }  */             
            
        }
    }
}
