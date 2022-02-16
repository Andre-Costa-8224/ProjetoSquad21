#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Refugiados1.Data;
using Refugiados1.Models;

namespace Refugiados1.Controllers
{
    public class AvaliacaosController : Controller
    {
        private readonly Refugiados1Context _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AvaliacaosController(Refugiados1Context context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Avaliacaos
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View(await _context.Avaliacao.ToListAsync());
            }
            else { 
                return BadRequest();
            }
        }

        // GET: Avaliacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao
                .FirstOrDefaultAsync(m => m.IdAvaliacao == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            if (_signInManager.IsSignedIn(User))
            {
                return View(avaliacao);
            }

            return BadRequest();
        }

        // GET: Avaliacaos/Create
        public IActionResult Create()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            return BadRequest();
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvaliacao,Nome,Tipo,Avaliacoes")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            if (_signInManager.IsSignedIn(User))
            {
                return View(avaliacao);
            }
            return BadRequest();
        }

        // POST: Avaliacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAvaliacao,Nome,Tipo,Avaliacoes")] Avaliacao avaliacao)
        {
            if (id != avaliacao.IdAvaliacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.IdAvaliacao))
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
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao
                .FirstOrDefaultAsync(m => m.IdAvaliacao == id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            if (_signInManager.IsSignedIn(User))
            {
                return View(avaliacao);
            }
            return BadRequest();
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.Avaliacao.FindAsync(id);
            _context.Avaliacao.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacao.Any(e => e.IdAvaliacao == id);
        }
    }
}
