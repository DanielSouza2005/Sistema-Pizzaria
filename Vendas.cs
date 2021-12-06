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
    public partial class Vendas : Form
    {
        int proCodSelecionado = -1;
        public Vendas()
        {
            InitializeComponent();
        }

        private void carregaGrid()
        {
            try
            {
                IList<vendas_DTO> listvendas_DTO = new List<vendas_DTO>();
                listvendas_DTO = new vendas_BLL().cargaVendas();

                dgVendas.DataSource = listvendas_DTO;
            }
            catch (Exception fbex)
            {
                MessageBox.Show(fbex.Message);
            }
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            carregaGrid();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtQtde_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValorTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Certeza que deseja inserir estes dados?", "Atenção!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    vendas_DTO ven = new vendas_DTO();
                    ven.ven_numero = Convert.ToInt32(txtCodigoVen.Text);
                    ven.cli_codigo = Convert.ToInt32(txtCodigoCli.Text);
                    ven.pro_codigo = Convert.ToInt32(txtCodigoProd.Text);
                    ven.ven_qtde = Convert.ToInt32(txtQtde.Text);
                    ven.ven_tipopagto = cbTipopagto.Text;
                    ven.ven_valortotal = Convert.ToDouble(txtValorTotal.Text);


                    int x = new vendas_BLL().insereVendas(ven);
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

                    vendas_DTO ven = new vendas_DTO();
                    ven.ven_numero = Convert.ToInt32(txtCodigoVen.Text);
                    ven.cli_codigo = Convert.ToInt32(txtCodigoCli.Text);
                    ven.pro_codigo = Convert.ToInt32(txtCodigoProd.Text);
                    ven.ven_qtde = Convert.ToInt32(txtQtde.Text);
                    ven.ven_tipopagto = cbTipopagto.Text;
                    ven.ven_valortotal = Convert.ToDouble(txtValorTotal.Text);

                    int x = new vendas_BLL().editaVendas(ven);

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

        private void dgVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dgVendas.CurrentRow.Index;

            txtCodigoVen.Text = Convert.ToString(dgVendas["ven_numero", sel].Value);
            txtCodigoCli.Text = Convert.ToString(dgVendas["cli_codigo", sel].Value);
            txtCodigoProd.Text = Convert.ToString(dgVendas["pro_codigo", sel].Value);
            txtQtde.Text = Convert.ToString(dgVendas["ven_qtde", sel].Value);
            cbTipopagto.Text = Convert.ToString(dgVendas["ven_tipopagto", sel].Value);
            txtValorTotal.Text = Convert.ToString(dgVendas["ven_valortotal", sel].Value);
            proCodSelecionado = Convert.ToInt32(dgVendas["pro_codigo", sel].Value);
        }

        private void txtCodigoVen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                    vendas_DTO ven = new vendas_DTO();
                    ven.ven_numero = Convert.ToInt32(txtCodigoVen.Text);
                    int x = new vendas_BLL().deletaVendas(ven);
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
            txtCodigoVen.Text = "";
            txtCodigoCli.Text = "";
            txtCodigoProd.Text = "";
            txtQtde.Text = "";
            cbTipopagto.Text = "";
            txtValorTotal.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Certeza que deseja limpar os dados preenchidos?", "Atenção!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                limpar_campos();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
