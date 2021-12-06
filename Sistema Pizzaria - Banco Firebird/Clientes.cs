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
    public partial class Clientes : Form
    {
        int proCodSelecionado = -1;
        public Clientes()
        {
            InitializeComponent();
        }

        private void carregaGrid()
        {
            try
            {
                IList<clientes_DTO> listclientes_DTO = new List<clientes_DTO>();
                listclientes_DTO = new clientes_BLL().cargaClientes();

                dgClientes.DataSource = listclientes_DTO;
            }
            catch (Exception fbex)
            {
                MessageBox.Show(fbex.Message);
            }
        }

        private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            carregaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Certeza que deseja inserir estes dados?", "Atenção!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    clientes_DTO cli = new clientes_DTO();
                    cli.cli_codigo = Convert.ToInt32(txtCodigo.Text);
                    cli.cli_nome = txtNome.Text;
                    cli.cli_cep = txtCEP.Text;
                    cli.cli_cpf = txtCPF.Text;
                    cli.cli_endereco = txtEndereco.Text;
                    cli.cli_numero = Convert.ToInt32(txtNumero.Text);
                    cli.cli_complemento = txtComplemento.Text;
                    cli.cli_bairro = txtBairro.Text;                 
                    cli.cli_uf = cbEstado.Text;
                    cli.cli_telefone = txtTelefone.Text;
                    cli.cli_celular = txtCelular.Text;
                    cli.cli_email = txtEmail.Text;

                    int x = new clientes_BLL().insereClientes(cli);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso!");
                    }

                    carregaGrid();

                }
                catch (Exception fbex)
                {
                    MessageBox.Show("Erro inesperado " + fbex.Message);
                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Certeza que deseja deletar estes dados?", "Atenção!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (proCodSelecionado < 0)
                    {
                        MessageBox.Show("Selecione um usuário antes");
                        return;
                    }
                    clientes_DTO cli = new clientes_DTO();
                    cli.cli_codigo = Convert.ToInt32(txtCodigo.Text);
                    int x = new clientes_BLL().deletaClientes(cli);
                    x = x + 10;
                    if (x > 0)
                    {
                        MessageBox.Show("Excluido com Sucesso!");
                    }

                    carregaGrid();
                    limpar_campos();

                }
                catch (Exception fbex)
                {
                    MessageBox.Show("Erro inesperado " + fbex.Message);
                }
            }
        }

        private void limpar_campos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtCEP.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            cbEstado.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Certeza que deseja atualizar estes dados?", "Atenção!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (proCodSelecionado < 0)
                    {
                        MessageBox.Show("Selecione um usuário antes de prosseguir");
                        return;
                    }

                    clientes_DTO cli = new clientes_DTO();
                    cli.cli_codigo = Convert.ToInt32(txtCodigo.Text);
                    cli.cli_nome = txtNome.Text;
                    cli.cli_cep = txtCEP.Text;
                    cli.cli_cpf = txtCPF.Text;
                    cli.cli_endereco = txtEndereco.Text;
                    cli.cli_numero = Convert.ToInt32(txtNumero.Text);
                    cli.cli_complemento = txtComplemento.Text;
                    cli.cli_bairro = txtBairro.Text;
                    cli.cli_uf = cbEstado.Text;
                    cli.cli_telefone = txtTelefone.Text;
                    cli.cli_celular = txtCelular.Text;
                    cli.cli_email = txtEmail.Text;

                    int x = new clientes_BLL().editaClientes(cli);

                    if (x > 0)
                    {
                        MessageBox.Show("Alterado com Sucesso!");
                    }

                    carregaGrid();
                }
                catch (Exception fbex)
                {
                    MessageBox.Show("Erro inesperado " + fbex.Message);
                }
            }
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dgClientes.CurrentRow.Index;

            txtCodigo.Text = Convert.ToString(dgClientes["cli_codigo", sel].Value);
            txtNome.Text = Convert.ToString(dgClientes["cli_nome", sel].Value);
            txtCPF.Text = Convert.ToString(dgClientes["cli_cpf", sel].Value);
            txtCEP.Text = Convert.ToString(dgClientes["cli_cep", sel].Value);
            txtEndereco.Text = Convert.ToString(dgClientes["cli_endereco", sel].Value);
            txtNumero.Text = Convert.ToString(dgClientes["cli_numero", sel].Value);
            txtComplemento.Text = Convert.ToString(dgClientes["cli_complemento", sel].Value);
            txtBairro.Text = Convert.ToString(dgClientes["cli_bairro", sel].Value);
            cbEstado.Text = Convert.ToString(dgClientes["cli_uf", sel].Value);
            txtTelefone.Text = Convert.ToString(dgClientes["cli_telefone", sel].Value);
            txtCelular.Text = Convert.ToString(dgClientes["cli_celular", sel].Value);
            txtEmail.Text = Convert.ToString(dgClientes["cli_email", sel].Value);
            proCodSelecionado = Convert.ToInt32(dgClientes["cli_codigo", sel].Value);
        }

        private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dgClientes.CurrentRow.Index;

            txtCodigo.Text = Convert.ToString(dgClientes["cli_codigo", sel].Value);
            txtNome.Text = Convert.ToString(dgClientes["cli_nome", sel].Value);
            txtCPF.Text = Convert.ToString(dgClientes["cli_cpf", sel].Value);
            txtCEP.Text = Convert.ToString(dgClientes["cli_cep", sel].Value);
            txtEndereco.Text = Convert.ToString(dgClientes["cli_endereco", sel].Value);
            txtNumero.Text = Convert.ToString(dgClientes["cli_numero", sel].Value);
            txtComplemento.Text = Convert.ToString(dgClientes["cli_complemento", sel].Value);
            txtBairro.Text = Convert.ToString(dgClientes["cli_bairro", sel].Value);
            cbEstado.Text = Convert.ToString(dgClientes["cli_uf", sel].Value);
            txtTelefone.Text = Convert.ToString(dgClientes["cli_telefone", sel].Value);
            txtCelular.Text = Convert.ToString(dgClientes["cli_celular", sel].Value);
            txtEmail.Text = Convert.ToString(dgClientes["cli_email", sel].Value);
            proCodSelecionado = Convert.ToInt32(dgClientes["cli_codigo", sel].Value);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Certeza que deseja limpar os dados preenchidos?", "Atenção!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                limpar_campos();
            }
        }
    }
}
