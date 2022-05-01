using Monitoramento_de_enchentes.DAO;
using Monitoramento_de_enchentes.Models;
using System;

namespace Monitoramento_de_enchentes.Controllers
{
    public class UsuarioController : PadraoController<UsuarioViewModel>
    {
        public UsuarioController()
        {
            DAO = new UsuarioDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(UsuarioViewModel usuario, String operacao)
        {
            ModelState.Clear();

            var dao = new UsuarioDAO();
            var usuarioConsultado = dao.Consulta(usuario.Id);
            
            if (operacao == "I" && usuarioConsultado != null)
                ModelState.AddModelError("Id", "Código já em uso!");

            if (operacao == "A" && usuarioConsultado == null)
                ModelState.AddModelError("Id", "Usuário não existe!");

            if (usuario.Id < 0)
                ModelState.AddModelError("Id", "Id inválido!");

            if (string.IsNullOrEmpty(usuario.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome!");

            if (string.IsNullOrEmpty(usuario.Usuario))
                ModelState.AddModelError("Usuario", "Preencha o usuário!");

            if (operacao == "I" && dao.ConsultaPorUsuario(usuario.Usuario) != null)
                ModelState.AddModelError("Usuario", "Usuário já existe!");

            if (string.IsNullOrEmpty(usuario.Senha))
                ModelState.AddModelError("Senha", "Preencha a senha!");

            if (string.IsNullOrEmpty(usuario.Foto))
                ModelState.AddModelError("Foto", "Anexe uma foto!");
        }
    }
}
