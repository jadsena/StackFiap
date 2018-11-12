using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackFiap.Core.Data;
using StackFiap.Core.Models;

namespace StackFiap.Controllers
{
    public class PerguntasController : Controller
    {
        private readonly Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }

        // GET: Perguntas
        public async Task<IActionResult> Index()
        {
            var context = _context.Perguntas.Include(p => p.Autor).Include(p => p.MelhorResposta);
            return View(await context.ToListAsync());
        }

        // GET: Perguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .Include(p => p.Autor)
                .Include(p => p.MelhorResposta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // GET: Perguntas/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, nameof(Autor.Id), nameof(Autor.Nome));
            //ViewData["MelhorRespostaId"] = new SelectList(_context.Respostas, "Id", "Id");
            return View();
        }

        // POST: Perguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MelhorRespostaId,Id,Texto,AutorId,DataCriacao,Aberto")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pergunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, nameof(Autor.Id), nameof(Autor.Nome), pergunta.AutorId);
            //ViewData["MelhorRespostaId"] = new SelectList(_context.Respostas, "Id", "Id", pergunta.MelhorRespostaId);
            pergunta.MelhorResposta = null;
            return View(pergunta);
        }

        // GET: Perguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.FindAsync(id);
            if (pergunta == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, nameof(Autor.Id), nameof(Autor.Nome), pergunta.AutorId);
            ViewData["MelhorRespostaId"] = new SelectList(_context.Respostas, nameof(Resposta.Id), nameof(Resposta.Texto), pergunta.MelhorRespostaId);
            return View(pergunta);
        }

        // POST: Perguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MelhorRespostaId,Id,Texto,AutorId,DataCriacao,Aberto")] Pergunta pergunta)
        {
            if (id != pergunta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pergunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerguntaExists(pergunta.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, nameof(Autor.Id), nameof(Autor.Nome), pergunta.AutorId);
            ViewData["MelhorRespostaId"] = new SelectList(_context.Respostas, nameof(Resposta.Id), nameof(Resposta.Texto), pergunta.MelhorRespostaId);
            return View(pergunta);
        }

        // GET: Perguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .Include(p => p.Autor)
                .Include(p => p.MelhorResposta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // POST: Perguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pergunta = await _context.Perguntas.FindAsync(id);
            _context.Perguntas.Remove(pergunta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerguntaExists(int id)
        {
            return _context.Perguntas.Any(e => e.Id == id);
        }
    }
}
