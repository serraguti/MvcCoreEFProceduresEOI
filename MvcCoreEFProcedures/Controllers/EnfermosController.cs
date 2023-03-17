using Microsoft.AspNetCore.Mvc;
using MvcCoreEFProcedures.Repositories;

namespace MvcCoreEFProcedures.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryHospital repo;

        public EnfermosController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetEnfermos());
        }

        public IActionResult Details(string id)
        {
            return View(this.repo.FindEnfermos(id));
        }

        public IActionResult Delete(string id)
        {
            this.repo.DeleteEnfermo(id);
            return RedirectToAction("Index");
        }
    }
}
