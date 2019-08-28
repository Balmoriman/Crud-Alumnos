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


        public void Carga()
        {
            using (var context = new AlumnosContext())
            {
                var lista = new List<Ciudad>();
                lista.Add(new Ciudad { Nombre = "" });

                lista.Add(new Ciudad { Nombre = " Nueva York     " });
                lista.Add(new Ciudad { Nombre = " Los Ángeles     " });
                lista.Add(new Ciudad { Nombre = " Londres         " });
                lista.Add(new Ciudad { Nombre = " París           " });
                lista.Add(new Ciudad { Nombre = " Seúl            " });
                lista.Add(new Ciudad { Nombre = " Osaka           " });
                lista.Add(new Ciudad { Nombre = " Shanghái        " });
                lista.Add(new Ciudad { Nombre = " Chicago         " });
                lista.Add(new Ciudad { Nombre = " Moscú           " });
                lista.Add(new Ciudad { Nombre = " Pekín           " });
                lista.Add(new Ciudad { Nombre = " Colonia         " });
                lista.Add(new Ciudad { Nombre = " Houston         " });
                lista.Add(new Ciudad { Nombre = " Washington D.C. " });
                lista.Add(new Ciudad { Nombre = " São Paulo       " });
                lista.Add(new Ciudad { Nombre = " Hong Kong       " });
                lista.Add(new Ciudad { Nombre = " Dallas          " });
                lista.Add(new Ciudad { Nombre = " Ciudad de México" });
                lista.Add(new Ciudad { Nombre = " Cantón          " });
                lista.Add(new Ciudad { Nombre = " Tianjin         " });
                lista.Add(new Ciudad { Nombre = " Singapur        " });
                lista.Add(new Ciudad { Nombre = " Nagoya          " });
                lista.Add(new Ciudad { Nombre = " Shenzhen        " });
                lista.Add(new Ciudad { Nombre = " Boston          " });
                lista.Add(new Ciudad { Nombre = " Estambul        " });
                lista.Add(new Ciudad { Nombre = " Filadelfia      " });
                lista.Add(new Ciudad { Nombre = " El Cairo        " });
                lista.Add(new Ciudad { Nombre = " San Francisco   " });
                lista.Add(new Ciudad { Nombre = " Taipéi          " });
                lista.Add(new Ciudad { Nombre = " Yakarta         " });
                lista.Add(new Ciudad { Nombre = " Ámsterdam       " });
                lista.Add(new Ciudad { Nombre = " Buenos Aires    " });
                lista.Add(new Ciudad { Nombre = " Chongqing       " });
                lista.Add(new Ciudad { Nombre = " Milán           " });
                lista.Add(new Ciudad { Nombre = " Bangkok         " });
                lista.Add(new Ciudad { Nombre = " Busan           " });
                lista.Add(new Ciudad { Nombre = " Atlanta         " });
                lista.Add(new Ciudad { Nombre = " Delhi           " });
                lista.Add(new Ciudad { Nombre = " Toronto         " });
                lista.Add(new Ciudad { Nombre = " Seattle         " });
                lista.Add(new Ciudad { Nombre = " Miami           " });
                lista.Add(new Ciudad { Nombre = " Madrid          " });
                lista.Add(new Ciudad { Nombre = " Bruselas        " });
                lista.Add(new Ciudad { Nombre = " Chengdu         " });
                lista.Add(new Ciudad { Nombre = " Wuhan           " });
                lista.Add(new Ciudad { Nombre = " Fráncfort del Me" });
                lista.Add(new Ciudad { Nombre = " Sídney          " });
                lista.Add(new Ciudad { Nombre = " Múnich          " });
                lista.Add(new Ciudad { Nombre = " Hangzhou        " });
                lista.Add(new Ciudad { Nombre = " Wuxi            " });
                lista.Add(new Ciudad { Nombre = " Mineápolis      " });
                lista.Add(new Ciudad { Nombre = " Qingdao         " });
                lista.Add(new Ciudad { Nombre = " Río de Janeiro  " });
                lista.Add(new Ciudad { Nombre = " Phoenix         " });
                lista.Add(new Ciudad { Nombre = " Nankín          " });
                lista.Add(new Ciudad { Nombre = " San Diego       " });
                lista.Add(new Ciudad { Nombre = " Dalian          " });
                lista.Add(new Ciudad { Nombre = " Fukuoka         " });
                lista.Add(new Ciudad { Nombre = " Shenyang        " });
                lista.Add(new Ciudad { Nombre = " Changsha        " });
                lista.Add(new Ciudad { Nombre = " Foshan          " });
                lista.Add(new Ciudad { Nombre = " Viena           " });
                lista.Add(new Ciudad { Nombre = " Manila          " });
                lista.Add(new Ciudad { Nombre = " Lima            " });
                lista.Add(new Ciudad { Nombre = " Melbourne       " });
                lista.Add(new Ciudad { Nombre = " Abu Dabi        " });
                lista.Add(new Ciudad { Nombre = " Detroit         " });
                lista.Add(new Ciudad { Nombre = " Ningbo          " });
                lista.Add(new Ciudad { Nombre = " Baltimore       " });
                lista.Add(new Ciudad { Nombre = " Kuala Lumpur    " });
                lista.Add(new Ciudad { Nombre = " Santiago        " });
                lista.Add(new Ciudad { Nombre = " Barcelona       " });
                lista.Add(new Ciudad { Nombre = " Denver          " });
                lista.Add(new Ciudad { Nombre = " Kuwait          " });
                lista.Add(new Ciudad { Nombre = " Riad            " });
                lista.Add(new Ciudad { Nombre = " Roma            " });
                lista.Add(new Ciudad { Nombre = " Lille           " });
                lista.Add(new Ciudad { Nombre = " Hamburgo        " });
                lista.Add(new Ciudad { Nombre = " Yeda            " });
                lista.Add(new Ciudad { Nombre = " San José        " });
                lista.Add(new Ciudad { Nombre = " Bogotá          " });
                lista.Add(new Ciudad { Nombre = " Portland        " });
                lista.Add(new Ciudad { Nombre = " Stuttgart       " });
                lista.Add(new Ciudad { Nombre = " Berlín          " });
                lista.Add(new Ciudad { Nombre = " Zhengzhou       " });
                lista.Add(new Ciudad { Nombre = " Montreal        " });
                lista.Add(new Ciudad { Nombre = " Riverside       " });
                lista.Add(new Ciudad { Nombre = " Tel Aviv        " });
                lista.Add(new Ciudad { Nombre = " Bombay          " });
                lista.Add(new Ciudad { Nombre = " Yantái          " });
                lista.Add(new Ciudad { Nombre = " Estocolmo       " });
                lista.Add(new Ciudad { Nombre = " Brasilia        " });
                lista.Add(new Ciudad { Nombre = " Caracas         " });
                lista.Add(new Ciudad { Nombre = " Dongguan        " });
                lista.Add(new Ciudad { Nombre = " Varsovia        " });
                lista.Add(new Ciudad { Nombre = " San Luis        " });
                lista.Add(new Ciudad { Nombre = " Pittsburgh      " });
                lista.Add(new Ciudad { Nombre = " Karlsruhe       " });
                lista.Add(new Ciudad { Nombre = " Jinan           " });
                lista.Add(new Ciudad { Nombre = " Perth           " });
                lista.Add(new Ciudad { Nombre = " Shijiazhuang    " });
                lista.Add(new Ciudad { Nombre = " Tampa           " });
                lista.Add(new Ciudad { Nombre = " Atenas          " });
                lista.Add(new Ciudad { Nombre = " Nantong         " });
                lista.Add(new Ciudad { Nombre = " Harbin          " });
                lista.Add(new Ciudad { Nombre = " Sacramento      " });
                lista.Add(new Ciudad { Nombre = " Copenhague      " });
                lista.Add(new Ciudad { Nombre = " Charlotte       " });
                lista.Add(new Ciudad { Nombre = " Lyon            " });
                lista.Add(new Ciudad { Nombre = " Xi'an           " });
                lista.Add(new Ciudad { Nombre = " Monterrey       " });
                lista.Add(new Ciudad { Nombre = " Katowice        " });
                lista.Add(new Ciudad { Nombre = " Birmingham      " });
                lista.Add(new Ciudad { Nombre = " Hefei           " });
                lista.Add(new Ciudad { Nombre = " San Petersburgo " });
                lista.Add(new Ciudad { Nombre = " Fuzhou          " });
                lista.Add(new Ciudad { Nombre = " Orlando         " });
                lista.Add(new Ciudad { Nombre = " Cleveland       " });
                lista.Add(new Ciudad { Nombre = " Taichung        " });
                lista.Add(new Ciudad { Nombre = " Kaohsiung       " });
                lista.Add(new Ciudad { Nombre = " Indianápolis    " });
                lista.Add(new Ciudad { Nombre = " Xuzhou          " });
                lista.Add(new Ciudad { Nombre = " Cincinnati      " });
                lista.Add(new Ciudad { Nombre = " Changzhou       " });
                lista.Add(new Ciudad { Nombre = " Vancouver       " });
                lista.Add(new Ciudad { Nombre = " Zúrich          " });
                lista.Add(new Ciudad { Nombre = " Columbus        " });
                lista.Add(new Ciudad { Nombre = " Austin          " });
                lista.Add(new Ciudad { Nombre = " Kansas City     " });
                lista.Add(new Ciudad { Nombre = " Ankara          " });
                lista.Add(new Ciudad { Nombre = " San Antonio     " });
                lista.Add(new Ciudad { Nombre = " Lagos           " });
                lista.Add(new Ciudad { Nombre = " Wenzhou         " });
                lista.Add(new Ciudad { Nombre = " Hartford        " });
                lista.Add(new Ciudad { Nombre = " Zibo            " });
                lista.Add(new Ciudad { Nombre = " Aachen          " });
                lista.Add(new Ciudad { Nombre = " Marsella        " });
                lista.Add(new Ciudad { Nombre = " Daqing          " });
                lista.Add(new Ciudad { Nombre = " Budapest        " });
                lista.Add(new Ciudad { Nombre = " Calgary         " });
                lista.Add(new Ciudad { Nombre = " Niza            " });
                lista.Add(new Ciudad { Nombre = " Brisbane        " });
                lista.Add(new Ciudad { Nombre = " Lisboa          " });
                lista.Add(new Ciudad { Nombre = " Abiyán          " });
                lista.Add(new Ciudad { Nombre = " Nashville       " });
                lista.Add(new Ciudad { Nombre = " Baotou          " });
                lista.Add(new Ciudad { Nombre = " Las Vegas       " });
                lista.Add(new Ciudad { Nombre = " Mánchester      " });
                lista.Add(new Ciudad { Nombre = " Virginia Beach  " });
                lista.Add(new Ciudad { Nombre = " Eindhoven       " });
                lista.Add(new Ciudad { Nombre = " Dublín          " });
                lista.Add(new Ciudad { Nombre = " Praga           " });
                lista.Add(new Ciudad { Nombre = " Kunming         " });
                lista.Add(new Ciudad { Nombre = " Taoyuan         " });
                lista.Add(new Ciudad { Nombre = " Milwaukee       " });
                lista.Add(new Ciudad { Nombre = " Nápoles         " });
                lista.Add(new Ciudad { Nombre = " Belo Horizonte  " });
                lista.Add(new Ciudad { Nombre = " Dongying        " });
                lista.Add(new Ciudad { Nombre = " Edmonton        " });
                lista.Add(new Ciudad { Nombre = " Johannesburgo   " });
                lista.Add(new Ciudad { Nombre = " Dubái           " });
                lista.Add(new Ciudad { Nombre = " Guadalajara     " });
                lista.Add(new Ciudad { Nombre = " Sapporo         " });
                lista.Add(new Ciudad { Nombre = " Bursa           " });
                lista.Add(new Ciudad { Nombre = " Esmirna         " });
                lista.Add(new Ciudad { Nombre = " Turín           " });
                lista.Add(new Ciudad { Nombre = " Providence      " });
                lista.Add(new Ciudad { Nombre = " Helsinki        " });
                lista.Add(new Ciudad { Nombre = " Tainan          " });
                lista.Add(new Ciudad { Nombre = " Xiamen          " });
                lista.Add(new Ciudad { Nombre = " Sendai          " });
                lista.Add(new Ciudad { Nombre = " Hiroshima       " });
                lista.Add(new Ciudad { Nombre = " Leeds           " });
                lista.Add(new Ciudad { Nombre = " Núremberg       " });
                lista.Add(new Ciudad { Nombre = " Oslo            " });
                lista.Add(new Ciudad { Nombre = " Nueva Orleans   " });
                lista.Add(new Ciudad { Nombre = " Salt Lake City  " });
                lista.Add(new Ciudad { Nombre = " Búfalo          " });
                lista.Add(new Ciudad { Nombre = " Bucarest        " });
                lista.Add(new Ciudad { Nombre = " Richmond        " });
                lista.Add(new Ciudad { Nombre = " Ciudad Ho Chi Mi" });
                lista.Add(new Ciudad { Nombre = " Nanning         " });
                lista.Add(new Ciudad { Nombre = " Hohhot          " });
                lista.Add(new Ciudad { Nombre = " Oklahoma City   " });
                lista.Add(new Ciudad { Nombre = " Bridgeport      " });
                lista.Add(new Ciudad { Nombre = " Zhongshan       " });
                lista.Add(new Ciudad { Nombre = " Rochester       " });
                lista.Add(new Ciudad { Nombre = " Anshan          " });
                lista.Add(new Ciudad { Nombre = " Liverpool       " });
                lista.Add(new Ciudad { Nombre = " Dakar           " });
                lista.Add(new Ciudad { Nombre = " Raleigh         " });
                lista.Add(new Ciudad { Nombre = " Jacksonville    " });
                lista.Add(new Ciudad { Nombre = " Taiyuan         " });
                lista.Add(new Ciudad { Nombre = " Luxemburgo      " });
                lista.Add(new Ciudad { Nombre = " Louisville      " });
                lista.Add(new Ciudad { Nombre = " Porto Alegre    " });
                lista.Add(new Ciudad { Nombre = " Calcuta         " });
                lista.Add(new Ciudad { Nombre = " Amiens          " });
                lista.Add(new Ciudad { Nombre = " Hannover        " });
                lista.Add(new Ciudad { Nombre = " Urumchi         " });
                lista.Add(new Ciudad { Nombre = " Campinas        " });
                lista.Add(new Ciudad { Nombre = " Ciudad del Cabo " });
                lista.Add(new Ciudad { Nombre = " Honolulu        " });
                lista.Add(new Ciudad { Nombre = " Madrás          " });
                lista.Add(new Ciudad { Nombre = " Shizuoka        " });
                lista.Add(new Ciudad { Nombre = " Albany          " });
                lista.Add(new Ciudad { Nombre = " Ottawa          " });
                lista.Add(new Ciudad { Nombre = " Curitiba        " });
                lista.Add(new Ciudad { Nombre = " Venecia         " });
                lista.Add(new Ciudad { Nombre = " Okayama         " });
                lista.Add(new Ciudad { Nombre = " Glasgow         " });
                lista.Add(new Ciudad { Nombre = " Basilea         " });
                lista.Add(new Ciudad { Nombre = " East Rand       " });
                lista.Add(new Ciudad { Nombre = " Daegu           " });
                lista.Add(new Ciudad { Nombre = " Birmingham      " });
                lista.Add(new Ciudad { Nombre = " Macao           " });
                lista.Add(new Ciudad { Nombre = " Baton Rouge     " });
                lista.Add(new Ciudad { Nombre = " New Haven       " });
                lista.Add(new Ciudad { Nombre = " Almaty          " });
                lista.Add(new Ciudad { Nombre = " Valencia        " });
                lista.Add(new Ciudad { Nombre = " Florencia       " });
                lista.Add(new Ciudad { Nombre = " Hamamatsu       " });
                lista.Add(new Ciudad { Nombre = " Portsmouth      " });
                lista.Add(new Ciudad { Nombre = " Grand Rapids    " });
                lista.Add(new Ciudad { Nombre = " Omaha           " });
                lista.Add(new Ciudad { Nombre = " Nottingham      " });
                lista.Add(new Ciudad { Nombre = " Bielefeld       " });
                lista.Add(new Ciudad { Nombre = " Niigata         " });
                lista.Add(new Ciudad { Nombre = " Pretoria        " });
                lista.Add(new Ciudad { Nombre = " Auckland        " });
                lista.Add(new Ciudad { Nombre = " Durban          " });
                lista.Add(new Ciudad { Nombre = " Tulsa           " });
                lista.Add(new Ciudad { Nombre = " Bremen          " });
                lista.Add(new Ciudad { Nombre = " Bakersfield     " });
                lista.Add(new Ciudad { Nombre = " Brístol         " });
                lista.Add(new Ciudad { Nombre = " Adelaida        " });
                lista.Add(new Ciudad { Nombre = " Toulouse        " });
                lista.Add(new Ciudad { Nombre = " Oxnard          " });
                lista.Add(new Ciudad { Nombre = " Brest           " });
                lista.Add(new Ciudad { Nombre = " Braunschweig    " });
                lista.Add(new Ciudad { Nombre = " Fresno          " });
                lista.Add(new Ciudad { Nombre = " Bangalore       " });
                lista.Add(new Ciudad { Nombre = " Worcester       " });
                lista.Add(new Ciudad { Nombre = " Newcastle       " });
                lista.Add(new Ciudad { Nombre = " Linz            " });
                lista.Add(new Ciudad { Nombre = " Arnhem          " });
                lista.Add(new Ciudad { Nombre = " Ginebra         " });
                lista.Add(new Ciudad { Nombre = " Sofía           " });
                lista.Add(new Ciudad { Nombre = " Medellín        " });
                lista.Add(new Ciudad { Nombre = " Oporto          " });
                lista.Add(new Ciudad { Nombre = " San Juan        " });
                lista.Add(new Ciudad { Nombre = " Kumamoto        " });
                lista.Add(new Ciudad { Nombre = " Madison         " });
                lista.Add(new Ciudad { Nombre = " Saarbrucken     " });
                lista.Add(new Ciudad { Nombre = " Zhuhai          " });
                lista.Add(new Ciudad { Nombre = " Daejeon         " });
                lista.Add(new Ciudad { Nombre = " Greensboro      " });
                lista.Add(new Ciudad { Nombre = " Little Rock     " });
                lista.Add(new Ciudad { Nombre = " Syracuse        " });
                lista.Add(new Ciudad { Nombre = " Recife          " });
                lista.Add(new Ciudad { Nombre = " Haifa           " });
                lista.Add(new Ciudad { Nombre = " Burdeos         " });
                lista.Add(new Ciudad { Nombre = " Hyderabad       " });
                lista.Add(new Ciudad { Nombre = " Gotemburgo      " });
                lista.Add(new Ciudad { Nombre = " Albuquerque     " });
                lista.Add(new Ciudad { Nombre = " Sheffield       " });
                lista.Add(new Ciudad { Nombre = " Daejeon         " });
                lista.Add(new Ciudad { Nombre = " Leipzig         " });
                lista.Add(new Ciudad { Nombre = " Des Moines      " });
                lista.Add(new Ciudad { Nombre = " Shantou         " });
                lista.Add(new Ciudad { Nombre = " Bilbao          " });
                lista.Add(new Ciudad { Nombre = " Salvador        " });
                lista.Add(new Ciudad { Nombre = " Hsinchu         " });
                lista.Add(new Ciudad { Nombre = " Knoxville       " });
                lista.Add(new Ciudad { Nombre = " Puebla de Zarago" });
                lista.Add(new Ciudad { Nombre = " George Town     " });
                lista.Add(new Ciudad { Nombre = " Casablanca      " });
                lista.Add(new Ciudad { Nombre = " Dayton          " });
                lista.Add(new Ciudad { Nombre = " Allentown       " });
                lista.Add(new Ciudad { Nombre = " Estrasburgo     " });
                lista.Add(new Ciudad { Nombre = " Izmir           " });
                lista.Add(new Ciudad { Nombre = " Durham          " });
                lista.Add(new Ciudad { Nombre = " Gwangju         " });
                lista.Add(new Ciudad { Nombre = " Bolonia         " });
                lista.Add(new Ciudad { Nombre = " Cardiff         " });
                lista.Add(new Ciudad { Nombre = " Sevilla         " });
                lista.Add(new Ciudad { Nombre = " Vitória         " });
                lista.Add(new Ciudad { Nombre = " Greenville      " });
                lista.Add(new Ciudad { Nombre = " Fortaleza       " });
                lista.Add(new Ciudad { Nombre = " Harrisburg      " });
                lista.Add(new Ciudad { Nombre = " Kagoshima       " });
                lista.Add(new Ciudad { Nombre = " Quebec          " });
                lista.Add(new Ciudad { Nombre = " Cracovia        " });
                lista.Add(new Ciudad { Nombre = " Akron           " });
                lista.Add(new Ciudad { Nombre = " Springfield     " });
                lista.Add(new Ciudad { Nombre = " El Paso         " });
                lista.Add(new Ciudad { Nombre = " Edimburgo       " });
                lista.Add(new Ciudad { Nombre = " Winnipeg        " });
                lista.Add(new Ciudad { Nombre = " Alejandría      " });
                lista.Add(new Ciudad { Nombre = " Nantes      " });


                foreach(var item in lista)
                {
                    item.FechaAlta = DateTime.Now;
                    context.Ciudad.Add(item);
                    
                }
                context.SaveChanges();

            }
        }
    }
}