using System.Web.Mvc;

namespace Exercicio3.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tecnologia()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Vaga()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Candidato()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}