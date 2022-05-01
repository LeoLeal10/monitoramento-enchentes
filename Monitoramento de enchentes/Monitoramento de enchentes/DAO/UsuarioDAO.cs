using Monitoramento_de_enchentes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoramento_de_enchentes.DAO
{
    public class UsuarioDAO : PadraoDAO<UsuarioViewModel>
    {

        protected override SqlParameter[] CriaParametros(UsuarioViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("Id", model.Id);
            parametros[1] = new SqlParameter("Nome", model.Nome);
            parametros[2] = new SqlParameter("Usuario", model.Usuario);
            parametros[3] = new SqlParameter("Senha", model.Senha);
            parametros[4] = new SqlParameter("Foto", model.Foto);

            return parametros;
        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            UsuarioViewModel u = new UsuarioViewModel();

            u.Id = Convert.ToInt32(registro["Id"]);
            u.Nome = registro["Nome"].ToString();
            u.Usuario = registro["Usuario"].ToString();
            u.Senha = registro["Senha"].ToString();
            u.Foto = registro["Foto"].ToString();

            return u;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuarios";
        }

        public UsuarioViewModel ConsultaPorUsuario(String usuarioString)
        {
            var u = new SqlParameter[]
            {
                new SqlParameter("Usuario", usuarioString),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta_PorUsuario", u);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }
    }
}
