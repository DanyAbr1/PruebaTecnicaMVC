using PruebaTecnicaMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PruebaTecnicaMVC.Controllers
{
    public class PersonaController : Controller
    {
        private static List<Persona> _listaPersona = new List<Persona>();

        /// <summary>
        /// Es la pagina principal de la aplicacion de personas
        /// </summary>
        /// <returns></returns>
        /// 
        public static bool MostrarRenglonCerveza;
        public ActionResult Index()
        {
            MostrarRenglonCerveza = false;
            return View(_listaPersona.OrderBy(o => o.Id));
        }

        public ActionResult VerInformacion(int? id)
        {
            return View(_listaPersona.FirstOrDefault(o => o.Id == id));
        }

        /// <summary>
        /// Es el metodo que llama la pagina de crear nuevo
        /// </summary>
        /// <returns></returns>
        public ActionResult CrearNuevo()
        {            
            return View();
        }

        /// <summary>
        /// Este metodo se utiliza para agregar personas a la lista
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AgregarEnLista(Persona vm)
        {            
            if (_listaPersona.Count > 0)
            {
                var item = _listaPersona.Max(o => o.Id);
                vm.Id = item + 1;
            }
            else
            {
                vm.Id = 1;
            }

            _listaPersona.Add(vm);
            return RedirectToAction("Index","Persona");
        }

        /// <summary>
        /// Este metodo se utiliza para llamar la pagina de edicion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Editar(int? id)
        {                    
            return View(_listaPersona.FirstOrDefault(o => o.Id == id));
        }

        /// <summary>
        /// Este Metodo es el que se utiliza para actulizar una persona de la lista
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Este metodo se utiliza para borrar un item de la lista enviandole como parametro el id de la persona 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Borrar(int? id)
        {
            var item  = _listaPersona.FirstOrDefault(o => o.Id == id);
            _listaPersona.Remove(item);

            return RedirectToAction("Index", "Persona");
        }



        public void OnBblurEdad(int edad)
        {
            if (edad > 30)
            {
                MostrarRenglonCerveza = true;
            }
        }

    }
}