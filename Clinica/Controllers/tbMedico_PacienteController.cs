using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinica.Models;
using Microsoft.AspNet.Identity;

namespace Clinica.Controllers
{
    public class tbMedico_PacienteController : Controller
    {
        private ModelDB db = new ModelDB();

        // GET: tbMedico_Paciente
        [Authorize(Roles = "Medico,Nutricionista")]
        public ActionResult Index()
        {
            IQueryable<tbMedico_Paciente> tbMedicoPaciente = null;
            var idLogado = User.Identity.GetUserId();

            var id = (from c in db.tbProfissional
                      where (c.IdUser == idLogado)
                      select c.IdProfissional);
            int idProfissional = Convert.ToInt32(id);
            if (User.IsInRole("Medico"))
            {

                var k = (from c in db.tbMedico_Paciente
                         where (c.IdProfissional == idProfissional)
                         select c).ToList();
                return View("Index", k);
            }
            else if (User.IsInRole("Nutricionista"))
            {
                var k = (from c in db.tbMedico_Paciente
                         where  (c.IdProfissional == idProfissional)
                         select c).ToList();
                return View("Index", k);
            }

            var tbMedico_Paciente = db.tbMedico_Paciente.Include(t => t.tbPaciente).Include(t => t.tbProfissional);
            return View(tbMedico_Paciente.ToList());
        }

        // GET: tbMedico_Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMedico_Paciente tbMedico_Paciente = db.tbMedico_Paciente.Find(id);
            if (tbMedico_Paciente == null)
            {
                return HttpNotFound();
            }
            return View(tbMedico_Paciente);
        }

        // GET: tbMedico_Paciente/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.tbPaciente, "IdPaciente", "Nome");
            ViewBag.IdProfissional = new SelectList(db.tbProfissional, "IdProfissional", "IdUser");
            return View();
        }

        // POST: tbMedico_Paciente/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMedico_Paciente,IdPaciente,IdProfissional,InformacaoResumida")] tbMedico_Paciente tbMedico_Paciente)
        {
            if (ModelState.IsValid)
            {
                db.tbMedico_Paciente.Add(tbMedico_Paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.tbPaciente, "IdPaciente", "Nome", tbMedico_Paciente.IdPaciente);
            ViewBag.IdProfissional = new SelectList(db.tbProfissional, "IdProfissional", "IdUser", tbMedico_Paciente.IdProfissional);
            return View(tbMedico_Paciente);
        }

        // GET: tbMedico_Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMedico_Paciente tbMedico_Paciente = db.tbMedico_Paciente.Find(id);
            if (tbMedico_Paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.tbPaciente, "IdPaciente", "Nome", tbMedico_Paciente.IdPaciente);
            ViewBag.IdProfissional = new SelectList(db.tbProfissional, "IdProfissional", "IdUser", tbMedico_Paciente.IdProfissional);
            return View(tbMedico_Paciente);
        }

        // POST: tbMedico_Paciente/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMedico_Paciente,IdPaciente,IdProfissional,InformacaoResumida")] tbMedico_Paciente tbMedico_Paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMedico_Paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.tbPaciente, "IdPaciente", "Nome", tbMedico_Paciente.IdPaciente);
            ViewBag.IdProfissional = new SelectList(db.tbProfissional, "IdProfissional", "IdUser", tbMedico_Paciente.IdProfissional);
            return View(tbMedico_Paciente);
        }

        // GET: tbMedico_Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMedico_Paciente tbMedico_Paciente = db.tbMedico_Paciente.Find(id);
            if (tbMedico_Paciente == null)
            {
                return HttpNotFound();
            }
            return View(tbMedico_Paciente);
        }

        // POST: tbMedico_Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbMedico_Paciente tbMedico_Paciente = db.tbMedico_Paciente.Find(id);
            db.tbMedico_Paciente.Remove(tbMedico_Paciente);
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
