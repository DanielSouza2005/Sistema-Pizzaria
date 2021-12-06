using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Pizzaria___Banco_Firebird
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            Produtos produtos = new Produtos();
            produtos.ShowDialog();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Vendas vendas = new Vendas();
            vendas.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja voltar ao menu de acesso?", "Atenção!",
                        MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
                
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*var result = MessageBox.Show("Deseja voltar ao menu de acesso?", "Atenção!",
                        MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }*/
        }
    }
}
