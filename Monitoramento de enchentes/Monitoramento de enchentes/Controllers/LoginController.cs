using Microsoft.AspNetCore.Mvc;

namespace Monitoramento_de_enchentes.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AcessoInicial()
        {
            return RedirectToAction("TelaInicial");
        }
    }
}
