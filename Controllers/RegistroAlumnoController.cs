using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Pc1Laboratorio.Models;//AGREGAR SIEMPRE

namespace Pc1Laboratorio.Controllers
{
    
    public class RegistroAlumnoController : Controller
    {
        private readonly ILogger<RegistroAlumnoController> _logger;

        public RegistroAlumnoController(ILogger<RegistroAlumnoController> logger)
        {
            _logger = logger;
        }

        public IActionResult VistaRegistro()
        {
            return View("VistaRegistro");
        }

        [HttpPost]

        public IActionResult registrar(Registro objRegistro) //crear un c# class "Registro"
        {
            string? nombre,apellido,cursos=null;
            int credito=3,precioCredito=100;
            double precTotalCursos=0,IGV,total;
            
            nombre=objRegistro.name;
            apellido=objRegistro.LastName;
            List<Course>curso=objRegistro.Courses;

            for (int i = 0; i < curso.Count; i++){
                if(curso[i].active == true){
                    cursos += curso[i].type+" ";
                    precTotalCursos += (credito * precioCredito);
                }
            }

            IGV=precTotalCursos*0.18;
            total=IGV+precTotalCursos;

            ViewData["Message"]="⇛ Nombre del alumno:"+nombre;
            ViewData["Message1"]="⇛ Apellido del alumno:"+apellido;
            ViewData["Message2"]="⇛ Cursos elegidos :"+cursos;
            ViewData["Message3"]="⇛ Precio total de créditos :"+precTotalCursos;
            ViewData["Message4"]="⇛ IGV: "+" S/"+IGV+" soles";
            ViewData["Message5"]="⇛ Total a pagar:"+" S/"+total+" soles";

            return View("VistaResultado");
        }

        [HttpGet]

        public ActionResult VistaRegistro(Registro objRegistro)
        {
            var registroCurso = new Registro 
            {
                Courses = new List<Course>
                {
                    new Course{id="1",type="Matemática"},
                    new Course{id="2",type="Lenguaje"},
                    new Course{id="3",type="Historia"},
                }

            };

            return View(registroCurso);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}