using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using ClassLibrary1.Entites;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private MonProjetDbContext db = new MonProjetDbContext();

        public ActionResult Index()
        {
            var eleves = db.Eleves.Include(e => e.Classe).Include(e => e.notes).OrderByDescending( e => (from n in e.notes select n.Notation).Average()).Take(5).ToList();

            var map = new Dictionary<Eleve, string>();

            foreach( var e in eleves)
            {
                map.Add(e, e.notes.Average(n => n.Notation).ToString("##.##"));
            }
            ViewData["elevesMap"] = map;


            ViewData["absences"] = db.Absences.Include(a => a.Eleve).OrderBy( a => a.DateAbsence).Take(5).ToList();


            return View();
        }



    }
}
