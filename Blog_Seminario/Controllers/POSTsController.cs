using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog_Seminario.Models;

namespace Blog_Seminario.Controllers
{
    public class POSTsController : Controller
    {
        private BLOG_SEMINARIOEntities db = new BLOG_SEMINARIOEntities();

        // GET: POSTs
        public ActionResult Index()
        {
            var pOST = db.POST.Include(p => p.CATEGORIAS).Include(p => p.SUB_CATEGORIA);
            return View(pOST.ToList());
        }

        // GET: POSTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST pOST = db.POST.Find(id);
            if (pOST == null)
            {
                return HttpNotFound();
            }
            return View(pOST);
        }

        // GET: POSTs/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "NOMBRE_CATEGORIA");
            ViewBag.SUBCATEGORIA = new SelectList(db.SUB_CATEGORIA, "ID_SUB_CATEGORIA", "NOMBRE_CATEGORIA");
            return View();
        }

        // POST: POSTs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_POST,TITULO,NOTA_POST,STATUS_POST,CATEGORIA,SUBCATEGORIA")] POST pOST)
        {
            if (ModelState.IsValid)
            {
                db.POST.Add(pOST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "NOMBRE_CATEGORIA", pOST.CATEGORIA);
            ViewBag.SUBCATEGORIA = new SelectList(db.SUB_CATEGORIA, "ID_SUB_CATEGORIA", "NOMBRE_CATEGORIA", pOST.SUBCATEGORIA);
            return View(pOST);
        }

        // GET: POSTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST pOST = db.POST.Find(id);
            if (pOST == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "NOMBRE_CATEGORIA", pOST.CATEGORIA);
            ViewBag.SUBCATEGORIA = new SelectList(db.SUB_CATEGORIA, "ID_SUB_CATEGORIA", "NOMBRE_CATEGORIA", pOST.SUBCATEGORIA);
            return View(pOST);
        }

        // POST: POSTs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_POST,TITULO,NOTA_POST,STATUS_POST,CATEGORIA,SUBCATEGORIA")] POST pOST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORIA = new SelectList(db.CATEGORIAS, "ID_CATEGORIA", "NOMBRE_CATEGORIA", pOST.CATEGORIA);
            ViewBag.SUBCATEGORIA = new SelectList(db.SUB_CATEGORIA, "ID_SUB_CATEGORIA", "NOMBRE_CATEGORIA", pOST.SUBCATEGORIA);
            return View(pOST);
        }

        // GET: POSTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST pOST = db.POST.Find(id);
            if (pOST == null)
            {
                return HttpNotFound();
            }
            return View(pOST);
        }

        // POST: POSTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POST pOST = db.POST.Find(id);
            db.POST.Remove(pOST);
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
