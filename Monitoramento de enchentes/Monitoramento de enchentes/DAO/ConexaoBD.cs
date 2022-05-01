using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoramento_de_enchentes.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection getConnection()
        {
            string strConexao = "data source=DESKTOP-AUHG4DS\\SQLEXPRESS;database=MonitoramentoEnchentes;user id=sa;password=123456";
            SqlConnection sqlConnection = new SqlConnection(strConexao);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
