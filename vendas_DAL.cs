using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Sistema_Pizzaria___Banco_Firebird
{
    public class vendas_DAL
    {
        public IList<vendas_DTO> cargaVendas()
        {
            try
            {
                return new vendas_DAL().cargaVendas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insereVendas(vendas_DTO ven)
        {
            try
            {
                return new vendas_DAL().insereVendas(ven);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int editaVendas(vendas_DTO ven)
        {
            try
            {
                return new vendas_DAL().editaVendas(ven);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deletaVendas(vendas_DTO ven)
        {
            try
            {
                return new vendas_DAL().deletaVendas(ven);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
