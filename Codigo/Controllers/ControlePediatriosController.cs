using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaCadernetaPediatrica;

namespace SistemaCadernetaPediatrica.Controllers
{
    public class ControlePediatriosController : Controller
    {
        private CadernetaPediatricaEntities db = new CadernetaPediatricaEntities();

        // GET: ControlePediatrios
        public ActionResult Index()
        {
            var controlePediatrios = db.ControlePediatrios.Include(c => c.Paciente);
            return View(controlePediatrios.ToList());
        }

        // GET: ControlePediatrios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlePediatrio controlePediatrio = db.ControlePediatrios.Find(id);
            if (controlePediatrio == null)
            {
                return HttpNotFound();
            }
            return View(controlePediatrio);
        }

        // GET: ControlePediatrios/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nome");
            return View();
        }

        // POST: ControlePediatrios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdControlePediatrio,IdPaciente,Data,Idade,Peso,Estatura,PCef,IMC,Observacoes")] ControlePediatrio controlePediatrio)
        {
            if (ModelState.IsValid)
            {
                db.ControlePediatrios.Add(controlePediatrio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nome", controlePediatrio.IdPaciente);
            return View(controlePediatrio);
        }

        // GET: ControlePediatrios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlePediatrio controlePediatrio = db.ControlePediatrios.Find(id);
            if (controlePediatrio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nome", controlePediatrio.IdPaciente);
            return View(controlePediatrio);
        }

        // POST: ControlePediatrios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdControlePediatrio,IdPaciente,Data,Idade,Peso,Estatura,PCef,IMC,Observacoes")] ControlePediatrio controlePediatrio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlePediatrio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "Nome", controlePediatrio.IdPaciente);
            return View(controlePediatrio);
        }

        // GET: ControlePediatrios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlePediatrio controlePediatrio = db.ControlePediatrios.Find(id);
            if (controlePediatrio == null)
            {
                return HttpNotFound();
            }
            return View(controlePediatrio);
        }

        // POST: ControlePediatrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ControlePediatrio controlePediatrio = db.ControlePediatrios.Find(id);
            db.ControlePediatrios.Remove(controlePediatrio);
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
