using PruebaTecnicaMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PruebaTecnicaMVC.Controllers
{
    public class PersonaController : Controller
    {
        private static List<Persona> _listaPersona = new List<Persona>();
        // GET: Persona 
        public ActionResult Index()
        {
            return View(_listaPersona);
        }

        public ActionResult CrearNuevo()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult AgregarEnLista(Persona vm)
        {
            vm.Id += 1;

            _listaPersona.Add(vm);

            return RedirectToAction("Index","Persona");
        }

        public ActionResult Editar(int? id)
        {                    
            return View(_listaPersona.FirstOrDefault(o => o.Id == id));
        }


        [HttpPost]
        public ActionResult Actualizar(Persona vm)
        {
            if (vm != null)
            {
               var item = _listaPersona.FirstOrDefault(o => o.Id == vm.Id);
                _listaPersona.Remove(item);
                _listaPersona.Add(vm);

            }

            return RedirectToAction("Index", "Persona");
        }
    }
}