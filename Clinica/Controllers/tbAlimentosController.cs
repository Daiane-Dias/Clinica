using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinica.Models;

namespace Clinica.Controllers
{
    public class tbAlimentosController : Controller
    {
        private ModelDB db = new ModelDB();

        // GET: tbAlimentos
        public ActionResult Index()
        {
            return View(db.tbAlimento.ToList());
        }

        // GET: tbAlimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            if (tbAlimento == null)
            {
                return HttpNotFound();
            }
            return View(tbAlimento);
        }

        // GET: tbAlimentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbAlimentos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlimento,IdTipoQuantidade,Nome,Carboidrato,VitaminaA,VitaminaB")] tbAlimento tbAlimento)
        {
            if (ModelState.IsValid)
            {
                db.tbAlimento.Add(tbAlimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbAlimento);
        }

        // GET: tbAlimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            if (tbAlimento == null)
            {
                return HttpNotFound();
            }
            return View(tbAlimento);
        }

        // POST: tbAlimentos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        //Daiane Dias Pereira
        public ActionResult EditPost(int? id)//[Bind(Include = "IdAlimento,IdTipoQuantidade,Nome,Carboidrato,VitaminaA,VitaminaB")] tbAlimento tbAlimento
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbAlimento = db.tbAlimento.Find(id);
            if (TryUpdateModel(tbAlimento, "",
                new string[] { "IdTipoQuantidade", "Nome", "Logradouro", "Carboidrato", "VitaminaA", "VitaminaB" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", " Aconteceu um erro,por favor tente mais tarde!");

                }

            }
            ViewBag.tbAlimento = new SelectList(db.tbAlimento, "IdAlimento", "nome", tbAlimento.IdAlimento);
            return View(tbAlimento);

            //if (ModelState.IsValid)
            //{
            //    db.Entry(tbAlimento).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(tbAlimento);
        }

        // GET: tbAlimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            if (tbAlimento == null)
            {
                return HttpNotFound();
            }
            return View(tbAlimento);
        }

        // POST: tbAlimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbAlimento tbAlimento = db.tbAlimento.Find(id);
            db.tbAlimento.Remove(tbAlimento);
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
