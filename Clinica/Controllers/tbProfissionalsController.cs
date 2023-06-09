﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;
using Clinica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Clinica.Controllers
{
    [Authorize]
    public class tbProfissionalsController : Controller
    {
        private ModelDB db = new ModelDB();


        // GET: tbProfissionals
        [Authorize(Roles = "Gerente,Medico,Nutricionista")]
        public ActionResult Index()
        {
            //var tbProfissional = db.tbProfissional.Include(t => t.tbCidade).Include(t => t.tbContrato).Include(t => t.tbTipoAcesso);
            // IQueryable<tbProfissional> tbProfissional = db.tbProfissional.Include(t => t.tbCidade).Include(t => t.tbContrato).Include(t => t.tbTipoAcesso);
            //return View(tbProfissional.ToList());
            IQueryable<tbProfissional> tbProfissional = null;
            
           
            if (User.IsInRole("Gerente"))
            {
              
                if (User.IsInRole("Medico"))
                {
                 
                    var k = (from c in db.tbProfissional
                             where ((Models.Enum.Plan)c.tbContrato.IdPlano == Models.Enum.Plan.MedicoTotal || (Models.Enum.Plan)c.tbContrato.IdPlano == Models.Enum.Plan.MedicoParcial
                             || (Models.Enum.Plan)c.tbContrato.IdPlano == Models.Enum.Plan.Especial)
                             select c).ToList();
                    return View("Index", k);
                }
                else if (User.IsInRole("Nutricionista"))
                {
                    var k = (from c in db.tbProfissional
                             where ((Models.Enum.Plan)c.tbContrato.IdPlano == Models.Enum.Plan.Nutricional)                             
                             select c).ToList();
                    return View("Index", k);
                }
                    tbProfissional = db.tbProfissional.Include(t => t.tbCidade).Include(t => t.tbContrato).Include(t => t.tbTipoAcesso);
                return View(tbProfissional.ToList());
                return View("Index", tbProfissional);
            }
            else
            {
                var idLogado = User.Identity.GetUserId();
                if (User.IsInRole("Medico"))
                {
                    //var k = (from c in db.tbProfissional
                    //        where ((Plan)c.tbContrato.IdPlano == Plan.MedicoTotal)
                    //        select c).ToList().Select(x => new tbProfissional() { Bairro = x.Bairro, CEP = x.CEP}).ToList();
                    //var k = (from c in db.tbProfissional
                    //         where ((Models.Enum.Plan)c.tbContrato.IdPlano == Models.Enum.Plan.MedicoTotal)
                    //         select new ParteProfissional() { Bairro = c.Bairro, CEP =c.CEP, CPF = c.CPF, Nome = c.Nome}).ToList();
                    //return View("Index2",k);
                   
                    var k = (from c in db.tbProfissional
                                         where (c.IdUser == idLogado && (Models.Enum.Plan)c.tbContrato.IdPlano == Models.Enum.Plan.MedicoTotal
                                          )
                             select c).ToList();
                    return View("Index", k);

                }
                else if (User.IsInRole("Nutricionista"))
                    {
                        //var k = (from c in db.tbProfissional
                        //        where ((Plan)c.tbContrato.IdPlano == Plan.MedicoTotal)
                        //        select c).ToList().Select(x => new tbProfissional() { Bairro = x.Bairro, CEP = x.CEP}).ToList();
                        var k = (from c in db.tbProfissional
                                 where (c.IdUser == idLogado && (Models.Enum.Plan)c.tbContrato.IdPlano == Models.Enum.Plan.Nutricional
                                  )
                                 select c).ToList();
                        return View("Index", k);
                    }
                }
               
            
            return View(tbProfissional.ToList());
            //LINQ
            //var k = (from c in db.tbProfissional
            //         where ((Plan)c.tbContrato.IdPlano == Plan.MedicoTotal)
            //         orderby (c.Salario)
            //         select c).ToList();
            //return View(k);

            //var k = (from c in db.tbProfissional
            //         from d in db.tbPlano
            //         where (d.Nome == "Medico Total")
            //         where (d.IdPlano == c.tbContrato.IdPlano)
            //         select c).ToList();
            //return View(k);
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
        [Authorize(Roles = "Gerente,Medico")]
        [Authorize(Roles = "Gerente,Nutricionista")]
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
        public ActionResult Create([Bind(Include = "IdProfissional,IdTipoProfissional,IdTipoAcesso,IdCidade,IdUser,Nome,CPF,CRM_CRN,Especialidade,Logradouro,Numero,Bairro,CEP,Cidade,Estado,DDD1,DDD2,Telefone1,Telefone2,Salario")] tbProfissional tbProfissional, [Bind(Include = "IdPlano")] tbContrato tbContrato)//[Bind(Include = "IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,IdUser,Nome,CPF,CRM_CRN,Especialidade,Logradouro,Numero,Bairro,CEP,Cidade,Estado,DDD1,DDD2,Telefone1,Telefone2,Salario")] tbProfissional tbProfissional
        {
            try
            {
                ModelState.Remove("IdUser");
                if (ModelState.IsValid)
                {

                    //Contrato//
                    tbContrato.DataInicio = DateTime.UtcNow;
                    tbContrato.DataFim = tbContrato.DataInicio.Value.AddMonths(1);
                    db.tbContrato.Add(tbContrato);
                    db.SaveChanges();
                    //
                    //Profissional
                    tbProfissional.IdContrato = tbContrato.IdContrato;
                    tbProfissional.IdUser = User.Identity.GetUserId();
                    db.tbProfissional.Add(tbProfissional);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", $"Ocorreu um erro.Não foi possivel salvar os dados.Tente mais tarde!{ex}");
                ViewBag.Erro = ex.Message;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Erro = ex.Message;
            }
            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome", tbProfissional.IdCidade);
            ViewBag.IdPlano = new SelectList(db.tbPlano, "IdPlano", "IdPlano");
            //ViewBag.IdContrato = new SelectList(db.tbContrato, "IdContrato", "IdContrato", tbProfissional.IdContrato);
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
            ViewBag.IdPlano = new SelectList(db.tbPlano, "IdPlano", "IdPlano");
            //ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome", tbProfissional.IdCidade);
            //ViewBag.IdContrato = new SelectList(db.tbContrato, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            ViewBag.IdTipoAcesso = new SelectList(db.tbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // POST: tbProfissionals/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)//[Bind(Include = "IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,IdUser,Nome,CPF,CRM_CRN,Especialidade,Logradouro,Numero,Bairro,CEP,Cidade,Estado,DDD1,DDD2,Telefone1,Telefone2,Salario")] tbProfissional tbProfissional
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tbProfissional = db.tbProfissional.Find(id);
            if (TryUpdateModel(tbProfissional, "",
                new string[] { "IdCidade", "Nome", "Logradouro", "Numero", "Bairro", "CEP", "Cidade", "Estado", "DDD1", "DDD2", "Telefone1", "Telefone2", "Salario" }))
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

            //if (ModelState.IsValid)
            //{
            //    db.Entry(tbProfissional).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            ViewBag.IdCidade = new SelectList(db.tbCidade, "IdCidade", "nome", tbProfissional.IdCidade);
            //ViewBag.IdContrato = new SelectList(db.tbContrato, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            //ViewBag.IdTipoAcesso = new SelectList(db.tbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
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
