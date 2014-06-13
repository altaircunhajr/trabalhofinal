using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trabalhofinal.Models;
using trabalhofinal.DAL;

namespace trabalhofinal.Controllers
{
    public class ClienteController : Controller
    {
        private SystemDbContext db = new SystemDbContext();

        // GET: /Cliente/
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Endereco).Include(c => c.Usuario);
            return View(clientes.ToList());
        }

        // GET: /Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: /Cliente/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoID = new SelectList(db.EnderecosDeCliente, "EnderecoID", "Rua");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Login");
            return View();
        }

        // POST: /Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ClienteID,PrimeiroNome,Sobrenome,Cpf,DataNascimento,Email,Telefone,Celular,EnderecoID,UsuarioID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnderecoID = new SelectList(db.EnderecosDeCliente, "EnderecoID", "Rua", cliente.EnderecoID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Login", cliente.UsuarioID);
            return View(cliente);
        }

        // GET: /Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnderecoID = new SelectList(db.EnderecosDeCliente, "EnderecoID", "Rua", cliente.EnderecoID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Login", cliente.UsuarioID);
            return View(cliente);
        }

        // POST: /Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ClienteID,PrimeiroNome,Sobrenome,Cpf,DataNascimento,Email,Telefone,Celular,EnderecoID,UsuarioID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoID = new SelectList(db.EnderecosDeCliente, "EnderecoID", "Rua", cliente.EnderecoID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Login", cliente.UsuarioID);
            return View(cliente);
        }

        // GET: /Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
