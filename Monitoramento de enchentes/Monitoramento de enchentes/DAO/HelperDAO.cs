using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoramento_de_enchentes.DAO
{
    public static class HelperDAO
    {
        public static void ExecutaSQL(String sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.getConnection())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    if (parametros != null) 
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static DataTable executaSelect (string sql, SqlParameter[] parametros)
        {
            using (var cx = ConexaoBD.getConnection())
            {
                using (var adapter = new SqlDataAdapter(sql, cx))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);

                    return tabela;
                }
            }
        }

        public static DataTable ExecutaProcSelect(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.getConnection())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(nomeProc, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }

        public static void ExecutaProc(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.getConnection())
            {
                using (SqlCommand comando = new SqlCommand(nomeProc, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
    }
}
