using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult GetAll()
        {
            ML.Result result = BL.Persona.GetAllPersona();
            ML.Persona persona = new ML.Persona();

            if (result.Correct)
            {
                persona.Personas = result.Objects;
            }

            return View(persona);
        }

        [HttpGet]
        public ActionResult Form(int? IdPersona)
        {
            ML.Persona persona = new ML.Persona();

            if (IdPersona == null) //add
            {
                return View(persona);
            }
            else //update
            {
                ML.Result result = BL.Persona.GetByIdPersona(IdPersona.Value);

                if (result.Correct)
                {
                    persona = (ML.Persona)result.Object;
                }

                return View(persona);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Persona persona)
        {
            if (persona.IdPersona == 0) //add
            {
                ML.Result result = BL.Persona.AddPersona(persona);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado correctamente los datos de la persona";
                }
                else
                {
                    ViewBag.Mensaje = "No se ha registrado correctamente los datos de la persona";
                }
            }
            else //update
            {
                ML.Result result = BL.Persona.UpdatePersona(persona);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se han actualizado correctamente los datos de la persona";
                }
                else
                {
                    ViewBag.Mensaje = "No se han podido actualizar correctamente los datos de la persona";
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdPersona)
        {
            ML.Result result = BL.Persona.DeletePersona(IdPersona);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se han eliminado correctamente los datos de la persona";
            }
            else
            {
                ViewBag.Mensaje = "No se han podido eliminar correctamente los datos de la persona";
            }
            return PartialView("Modal");
        }
    }
}