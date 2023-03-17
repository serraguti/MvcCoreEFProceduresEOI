using Microsoft.AspNetCore.Mvc;
using MvcCoreEFProcedures.Models;
using MvcCoreEFProcedures.Repositories;

namespace MvcCoreEFProcedures.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryHospital repo;

        public EmpleadosController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        //LA POSICION, LA PRIMERA VEZ NO LA RECIBIMOS
        public async Task<IActionResult> Index(int? posicion)
        {
            if (posicion == null)
            {
                posicion = 1;
            }
            int numRegistros = this.repo.GetNumeroEmpleados();
            ViewData["REGISTROS"] = numRegistros;
            List<Empleado> empleados = await
                this.repo.GetEmpleadosGrupoAsync(posicion.Value);
            return View(empleados);
        }
    }
}
