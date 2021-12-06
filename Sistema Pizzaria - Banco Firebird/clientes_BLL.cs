using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Pizzaria___Banco_Firebird
{
    public class clientes_BLL
    {
        public IList<clientes_DTO> cargaClientes()
        {
            try
            {
                return new clientes_DAL().cargaClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insereClientes(clientes_DTO cli)
        {
            try
            {
                return new clientes_DAL().insereClientes(cli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int editaClientes(clientes_DTO cli)
        {
            try
            {
                return new clientes_DAL().editaClientes(cli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deletaClientes(clientes_DTO cli)
        {
            try
            {
                return new clientes_DAL().deletaClientes(cli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
