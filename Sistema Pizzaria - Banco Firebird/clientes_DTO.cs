using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Sistema_Pizzaria___Banco_Firebird
{
    public class clientes_DTO
    {
        public int cli_codigo { get; set; }
        public string cli_nome { get; set; }
        public string cli_cpf { get; set; }
        public string cli_cep { get; set; }
        public string cli_endereco { get; set; }
        public int cli_numero { get; set; }
        public string cli_complemento { get; set; }
        public string cli_bairro { get; set; }
        public string cli_uf { get; set; }
        public string cli_telefone { get; set; }
        public string cli_celular { get; set; }
        public string cli_email { get; set; }

    }
}
