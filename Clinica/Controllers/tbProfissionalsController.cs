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
    public class tbProfissionalsController : Controller
    {
        private ModelDB db = new ModelDB();

        // GET: tbProfissionals
        public ActionResult Index()
        {
            var tbProfissional = db.tbProfissional.Include(t => t.tbCidade).Include(t => t.tbContrato).Include(t => t.tbTipoAcesso);
            return View(tbProfissional.ToList());
        }

        // GET: tbProfissionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfissional tbProfissional = db.tbProfissional.Find(id);
            if (tbProfissional == null)
            {
                return HttpNotFound();
            }
            return View(tbProfissional);
        }

        // GET: tbProfissionals/Create
        public ActionResult Create()
        {
            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome");
            ViewBag.IdPlano = new SelectList(db.tbPlano, "IdPlano", "Nome");
            //ViewBag.IdContrato = new SelectList(db.tbContrato, "IdContrato", "IdContrato");
            ViewBag.IdTipoAcesso = new SelectList(db.tbTipoAcesso, "IdTipoAcesso", "Nome");
            return View();
        }

        // POST: tbProfissionals/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,IdUser,Nome,CPF,CRM_CRN,Especialidade,Logradouro,Numero,Bairro,CEP,Cidade,Estado,DDD1,DDD2,Telefone1,Telefone2,Salario")] tbProfissional tbProfissional)
        {
            if (ModelState.IsValid)
            {
                tbProfissional.IdUser = User.Identity.GetUserId();
                db.tbProfissional.Add(tbProfissional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome", tbProfissional.IdCidade);
            ViewBag.IdContrato = new SelectList(db.tbContrato, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            ViewBag.IdTipoAcesso = new SelectList(db.tbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // GET: tbProfissionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfissional tbProfissional = db.tbProfissional.Find(id);
            if (tbProfissional == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome", tbProfissional.IdCidade);
            ViewBag.IdContrato = new SelectList(db.tbContrato, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            ViewBag.IdTipoAcesso = new SelectList(db.tbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // POST: tbProfissionals/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,IdUser,Nome,CPF,CRM_CRN,Especialidade,Logradouro,Numero,Bairro,CEP,Cidade,Estado,DDD1,DDD2,Telefone1,Telefone2,Salario")] tbProfissional tbProfissional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbProfissional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome", tbProfissional.IdCidade);
            ViewBag.IdContrato = new SelectList(db.tbContrato, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            ViewBag.IdTipoAcesso = new SelectList(db.tbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // GET: tbProfissionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbProfissional tbProfissional = db.tbProfissional.Find(id);
            if (tbProfissional == null)
            {
                return HttpNotFound();
            }
            return View(tbProfissional);
        }

        // POST: tbProfissionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbProfissional tbProfissional = db.tbProfissional.Find(id);
            db.tbProfissional.Remove(tbProfissional);
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
