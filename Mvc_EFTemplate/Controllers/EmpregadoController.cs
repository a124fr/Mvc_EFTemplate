using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_EFTemplate.EntidadeDAL;

namespace Mvc_EFTemplate.Controllers
{
    public class EmpregadoController : Controller
    {
        private CadastroContext db = new CadastroContext();

        // GET: /Empregado/
        public async Task<ActionResult> Index()
        {
            var empregados = db.empregados.Include(e => e.Departamento);
            return View(await empregados.ToListAsync());
        }

        // GET: /Empregado/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = await db.empregados.FindAsync(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            return View(empregado);
        }

        // GET: /Empregado/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.departamentos, "Id", "Nome");
            return View();
        }

        // POST: /Empregado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Nome,Sobrenome,Email,DepartamentoId")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                db.empregados.Add(empregado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
                        
            ViewBag.DepartamentoId = new SelectList(db.departamentos, "Id", "Nome", empregado.DepartamentoId);
            return View(empregado);
        }

        // GET: /Empregado/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = await db.empregados.FindAsync(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.departamentos, "Id", "Nome", empregado.DepartamentoId);
            return View(empregado);
        }

        // POST: /Empregado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Nome,Sobrenome,Email,DepartamentoId")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empregado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.departamentos, "Id", "Nome", empregado.DepartamentoId);
            return View(empregado);
        }

        // GET: /Empregado/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = await db.empregados.FindAsync(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            return View(empregado);
        }

        // POST: /Empregado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empregado empregado = await db.empregados.FindAsync(id);
            db.empregados.Remove(empregado);
            await db.SaveChangesAsync();
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
