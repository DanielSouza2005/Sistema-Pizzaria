using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Sistema_Pizzaria___Banco_Firebird
{
    public class vendas_DTO
    {
        public int ven_numero { get; set; }
        public int cli_codigo { get; set; }
        public int pro_codigo { get; set; }
        public int ven_qtde { get; set; }
        public string ven_tipopagto { get; set; }
        public double ven_valortotal { get; set; }
    }
}
