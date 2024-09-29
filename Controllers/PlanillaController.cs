using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using ExamenT1.Models;

namespace ExamenT1.Controllers
{
    public class PlanillaController : Controller
    {
        // GET: Planilla
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CrearTrabajador()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearTrabajador(Trabajador objTrabajador)
        {
            Debug.WriteLine("DNI: " + objTrabajador.dniTrab);
            Debug.WriteLine("Apellidos: " + objTrabajador.apeTrab);
            Debug.WriteLine("Nombres: " + objTrabajador.nomTrab);
            Debug.WriteLine("Fecha de Contrato: " + objTrabajador.fecContrato);
            Debug.WriteLine("Categoria: " + objTrabajador.categoriaTrab);

            ViewBag.SueldoBasico = objTrabajador.basico();
            ViewBag.Bonificacion = objTrabajador.bonificacion();
            ViewBag.Monto = objTrabajador.monto();

            return View();
        }


        //===================para crear asistentes===================
        [HttpGet]
        public ActionResult CreateAsistente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAsistente(Asistente objAsistente)
        {
            Debug.WriteLine("DNI N° " + objAsistente.dniTrab);
            Debug.WriteLine("Nombres : " + objAsistente.nomTrab);
            Debug.WriteLine("Apellidos :" + objAsistente.apeTrab);
            Debug.WriteLine("Fecha de contratación " + objAsistente.fecContrato);
            Debug.WriteLine("Cstegoria :" + objAsistente.categoriaTrab);
            Debug.WriteLine("Cantidad de Hijos : " + objAsistente.nro_hijos);
            Debug.WriteLine("Grado de Educación : " + objAsistente.grado_educacion);

            int validador = lista.FindIndex(y => y.dniTrab == objAsistente.dniTrab);
            if (validador == -1)
            {
                ViewBag.SueldoBasico = objAsistente.sueldo_basico();
                ViewBag.Bonificacion = objAsistente.bonificacion();
                ViewBag.Escolaridad = objAsistente.bonif_escolaridad();
                ViewBag.BonificacionEspecial = objAsistente.bonif_especial();
                ViewBag.Monto = objAsistente.monto();
                ViewBag.Mensaje = " Asistente Creado Exitosamente";              
                lista.Add(objAsistente);
            }
            else 
            {
                ViewBag.Mensaje = "Asistente ya Registrado";
   
            }
            return View(objAsistente);
        }

        public static  List<Asistente> lista;

        public PlanillaController()

        {
            if (lista == null)
            {
                lista = new List<Asistente>();
                lista.Add(new Asistente()
                {
                    dniTrab = "50505050",
                    apeTrab = "Salazar",
                    nomTrab = "Fernando",
                    fecContrato = DateTime.Parse("2024-07-21"),
                    nro_hijos = 14,
                    grado_educacion = "superior",
                    categoriaTrab = "A",
                });
            }
        }
        public ActionResult Listado()
        { 
            ViewBag.ContRegistro = lista.Count;
            return View(lista);
        }



        





    }
}