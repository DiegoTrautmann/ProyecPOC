using ProyecPOC.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProyecPOC.Controllers
{
	public class pymes1Controller : Controller
	{
		private BDPOC db = new BDPOC();

		// GET: pymes1
		public ActionResult Index()
		{
			var pymes = db.pymes.Include(p => p.categoria).Include(p => p.sub_categoria);
			return View(pymes.ToList());
		}

		// GET: pymes1/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			pymes pymes = db.pymes.Find(id);
			if (pymes == null)
			{
				return HttpNotFound();
			}
			return View(pymes);
		}

		// GET: pymes1/Create
		public ActionResult Create()
		{
			ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre");
			ViewBag.id_subcategoria = new SelectList(db.sub_categoria, "id", "nombre");
			return View();
		}

		// POST: pymes1/Create
		// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
		// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "rut,nombre,descripcion,id_categoria,id_subcategoria,celular,correo,dirección,sitioweb,redsocial1,redsocial2,redsocial3")] pymes pymes)
		{
			if (ModelState.IsValid)
			{
				db.pymes.Add(pymes);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre", pymes.id_categoria);
			ViewBag.id_subcategoria = new SelectList(db.sub_categoria, "id", "nombre", pymes.id_subcategoria);
			return View(pymes);
		}

		// GET: pymes1/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			pymes pymes = db.pymes.Find(id);
			if (pymes == null)
			{
				return HttpNotFound();
			}
			ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre", pymes.id_categoria);
			ViewBag.id_subcategoria = new SelectList(db.sub_categoria, "id", "nombre", pymes.id_subcategoria);
			return View(pymes);
		}

		// POST: pymes1/Edit/5
		// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
		// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "rut,nombre,descripcion,id_categoria,id_subcategoria,celular,correo,dirección,sitioweb,redsocial1,redsocial2,redsocial3")] pymes pymes)
		{
			if (ModelState.IsValid)
			{
				db.Entry(pymes).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre", pymes.id_categoria);
			ViewBag.id_subcategoria = new SelectList(db.sub_categoria, "id", "nombre", pymes.id_subcategoria);
			return View(pymes);
		}

		// GET: pymes1/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			pymes pymes = db.pymes.Find(id);
			if (pymes == null)
			{
				return HttpNotFound();
			}
			return View(pymes);
		}

		// POST: pymes1/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			pymes pymes = db.pymes.Find(id);
			db.pymes.Remove(pymes);
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
