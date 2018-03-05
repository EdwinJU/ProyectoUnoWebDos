using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProyecto.Models;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MvcProyecto.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MvcProyectoContext _context;

        public UsuarioController(MvcProyectoContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }
        public IActionResult Login()
        {
         
            return View();
        }
          public IActionResult Corriente()
        {
           
            return View();
        }
        
          public IActionResult Admin()
        {
           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login([Bind("Username,Password")] Usuario users)
        {

            var user = await _context.Usuario
               .SingleOrDefaultAsync(m => m.Username == users.Username && m.Password == users.Password);

            if (user != null)
            {


                HttpContext.Session.SetString("User", user.ToString());

               

                if (user.TipoUsuario == "Admin")
                {

                    return RedirectToAction("Admin");
                }
                else if (user.TipoUsuario == "Corriente")
                {
                    return RedirectToAction("Corriente");
                }

               ViewData["Message"]= HttpContext.Session.GetString("User");


            }
            else
            {
                return RedirectToAction("Corriente");
            }
            return View();


        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .SingleOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Apellido,Username,Password,TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.SingleOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Apellido,Username,Password,TipoUsuario")] Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .SingleOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.SingleOrDefaultAsync(m => m.ID == id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.ID == id);
        }
    }
}
