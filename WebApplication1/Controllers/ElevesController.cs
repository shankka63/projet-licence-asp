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

namespace WebApplication1
{
    public class ElevesController : Controller
    {
        private MonProjetDbContext db = new MonProjetDbContext();

        // GET: Eleves
        public ActionResult Index(string searchString)
        {

            var eleves = db.Eleves.Include(e => e.Classe);
            if (!String.IsNullOrEmpty(searchString))
            {
                eleves = eleves.Where(e => e.Nom.Contains(searchString)
                                       || e.Prenom.Contains(searchString));
            }

           
            return View(eleves.ToList());
        }

        // GET: Eleves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Include(e => e.Classe).Include(e => e.notes).Include(e => e.absences).FirstOrDefault(e => e.EleveId == id.Value);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // GET: Eleves/Create
        public ActionResult Create()
        {
            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "NomEtablissement");
            return View();
        }

        // POST: Eleves/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EleveId,Nom,Prenom,DateNaissance,ClasseId")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Eleves.Add(eleve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "NomEtablissement", eleve.ClasseId);
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "NomEtablissement", eleve.ClasseId);
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EleveId,Nom,Prenom,DateNaissance,ClasseId")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseId = new SelectList(db.Classes, "ClasseId", "NomEtablissement", eleve.ClasseId);
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eleve eleve = db.Eleves.Find(id);
            db.Eleves.Remove(eleve);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
