using Crud_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Alumnos.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                using (var context = new AlumnosContext())
                {
                    //var consulta = context.Alumno.Join(context.Ciudad,
                    //    a => a.CiudadId,
                    //    d => d,
                    //    (a, b) => new
                    //    {
                    //        Alumno = a,
                    //        Ciudad = b.
                    //    }).Select(s => new AlumnoCE
                    //    {
                    //        AlumnoId = s.Alumno.AlumnoId,
                    //        Nombres = s.Alumno.Nombres,
                    //        Apellidos = s.Alumno.Apellidos,
                    //        Edad = s.Alumno.Edad,
                    //        Sexo = s.Alumno.Sexo,
                    //        Nombre = s.Ciudad.Nombre,
                    //        FechaAlta = s.Alumno.FechaAlta

                    //    }).ToList();
                    //var consulta = from a in context.Alumno
                    //               join c in context.Ciudad on a.CiudadId equals c.CiudadId
                    //               select new AlumnoCE()
                    //               {
                    //                   AlumnoId = a.AlumnoId,
                    //                   Nombres = a.Nombres,
                    //                   Apellidos = a.Apellidos,
                    //                   Edad = a.Edad,
                    //                   Sexo = a.Sexo,
                    //                   Nombre = c.Nombre,
                    //                   FechaAlta = a.FechaAlta
                    //               };
                    var consulta = context.Alumno;

                    return View(consulta.ToList());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var context = new AlumnosContext())
                {
                    a.FechaAlta = DateTime.Now;
                    context.Alumno.Add(a);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al agregar el alumno -" + ex.Message);
                return View();
            }


        }

        public ActionResult ListaCiudades()
        {
            using (var context = new AlumnosContext())
            {
                var consulta = context.Ciudad.ToList();
                return PartialView(consulta);
            }
        }


        public ActionResult Editar(int id)
        {
            try
            {
                using (var context = new AlumnosContext())
                {
                    Alumno alumno = context.Alumno.Where(w => w.AlumnoId == id).FirstOrDefault();

                    return View(alumno);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {
            try
            {
                using (var context = new AlumnosContext())
                {
                    Alumno alumno = context.Alumno.Where(w => w.AlumnoId == a.AlumnoId).FirstOrDefault();
                    alumno.Nombres = a.Nombres;
                    alumno.Apellidos = a.Apellidos;
                    alumno.Edad = a.Edad;
                    alumno.Sexo = a.Sexo;

                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Detalles(int id)
        {
            using (var context = new AlumnosContext())
            {

                Alumno alumno = context.Alumno.Where(w => w.AlumnoId == id).FirstOrDefault();

                return View(alumno);


            }
        }

        public ActionResult Eliminar(int id)
        {
            using (var context = new AlumnosContext())
            {

                Alumno alumno = context.Alumno.Where(w => w.AlumnoId == id).FirstOrDefault();
                context.Alumno.Remove(alumno);
                context.SaveChanges();
                return RedirectToAction("Index");


            }
        }

        public static string NombreCiudad(int CiudadId)
        {
            using (var context = new AlumnosContext())
            {
                var ciudad = context.Ciudad.Where(w => w.CiudadId == CiudadId).Select(s => s.Nombre).FirstOrDefault();
                return ciudad;

            }
        }
    }
}