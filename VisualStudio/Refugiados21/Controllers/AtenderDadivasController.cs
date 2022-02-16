#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Refugiados1.Models;

namespace Refugiados1.Controllers
{
    public class AtenderDadivasController : Controller
    {
        private readonly Context _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AtenderDadivasController(Context context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: AtenderDadivas
        
        

        public async Task<IActionResult> Index()
        {

            if (_signInManager.IsSignedIn(User))
            {
                var context = _context.AtenderDadiva.Include(a => a.SolicitarDadiva);
                return View(await context.ToListAsync());
            }
            else
            {
                return BadRequest();
            }

            
        }

        // GET: AtenderDadivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var atenderDadiva = await _context.AtenderDadiva
                .Include(a => a.SolicitarDadiva)
                .FirstOrDefaultAsync(m => m.IdAtender == id);
            if (atenderDadiva == null)
            {
                return NotFound();
            }
            if (_signInManager.IsSignedIn(User))
            {
                return View(atenderDadiva);
            }

            return BadRequest();
            
        }

        // GET: AtenderDadivas/Create
        public IActionResult Create()
        {
            ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva","Dádiva", "IdOng", "Ong");
            if (_signInManager.IsSignedIn(User))
            {
               return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: AtenderDadivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtender,Seu_Nome,Telefone,Email,CPF,IdDadiva")] AtenderDadiva atenderDadiva)
        {
           
                _context.Add(atenderDadiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva", "Dádiva", atenderDadiva.IdDadiva);
            
        }

        // GET: AtenderDadivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atenderDadiva = await _context.AtenderDadiva.FindAsync(id);
            if (atenderDadiva == null)
            {
                return NotFound();
            }
            if (_signInManager.IsSignedIn(User))
            {
                ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva", "Dádiva", "IdOng", "Ong");
                return View(atenderDadiva);
            }

            return BadRequest();
            
        }

        // POST: AtenderDadivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtender,Seu_Nome,Telefone,Email,CPF,IdDadiva")] AtenderDadiva atenderDadiva)
        {
            if (id != atenderDadiva.IdAtender)
            {
                return NotFound();
            }

           
                    _context.Update(atenderDadiva);
                    await _context.SaveChangesAsync();
                
            
            ViewData["IdDadiva"] = new SelectList(_context.SolicitarDadiva, "IdDadiva", "Dádiva", atenderDadiva.IdDadiva);
            return RedirectToAction(nameof(Index));
        }

        // GET: AtenderDadivas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atenderDadiva = await _context.AtenderDadiva
                .Include(a => a.SolicitarDadiva)
                .FirstOrDefaultAsync(m => m.IdAtender == id);
            if (atenderDadiva == null)
            {
                return NotFound();
            }
            if (_signInManager.IsSignedIn(User))
            {
                return View(atenderDadiva);
            }
            return BadRequest();
        }

        // POST: AtenderDadivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atenderDadiva = await _context.AtenderDadiva.FindAsync(id);
            _context.AtenderDadiva.Remove(atenderDadiva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtenderDadivaExists(int id)
        {
            return _context.AtenderDadiva.Any(e => e.IdAtender == id);
        }
    }
}
