using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Appen.Controllers
{
    public class HomeController : Controller
    {
        private IHamtaIndex hamtaIndex;
        private ISparaIndex sparaIndex;

        public HomeController()
        {
            hamtaIndex = new HamtaIndex();
            sparaIndex = new SparaIndex();
        }

        public IActionResult Index()
        {
			var lista = hamtaIndex.Hamta();

			var dto = new Dto() { Lista = lista };

			return View("~/Views/Home/Index.cshtml", dto);
        }

        [HttpPost]
        public ActionResult Spara(string namn, string djurnamn)
        {
            sparaIndex.Spara(namn, djurnamn);

            var lista = hamtaIndex.Hamta();

            var dto = new Dto() { Lista = lista };

            return View("~/Views/Home/Index.cshtml", dto);
        }
    }
}
