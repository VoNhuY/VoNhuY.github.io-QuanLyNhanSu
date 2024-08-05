using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien.Controllers
{
    public class PhongbansController : Controller
    {
        private readonly QLNSContext _context;

        public PhongbansController(QLNSContext context)
        {
            _context = context;
        }

        // GET: Phongbans
        public async Task<IActionResult> Index(string id)
        {
            var qLNSContext = from m in _context.Phongbans
                              select m;

            if (!String.IsNullOrEmpty(id))
            {
                qLNSContext = qLNSContext.Where(s => s.Tenpb!.Contains(id));
            }

            return View(await qLNSContext.ToListAsync());

        }

        // GET: Phongbans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Phongbans == null)
            {
                return NotFound();
            }

            var phongban = await _context.Phongbans
                .FirstOrDefaultAsync(m => m.Idpb == id);
            if (phongban == null)
            {
                return NotFound();
            }

            return View(phongban);
        }

        // GET: Phongbans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phongbans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpb,Tenpb")] Phongban phongban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phongban);
        }

        // GET: Phongbans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Phongbans == null)
            {
                return NotFound();
            }

            var phongban = await _context.Phongbans.FindAsync(id);
            if (phongban == null)
            {
                return NotFound();
            }
            return View(phongban);
        }

        // POST: Phongbans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpb,Tenpb")] Phongban phongban)
        {
            if (id != phongban.Idpb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongbanExists(phongban.Idpb))
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
            return View(phongban);
        }

        // GET: Phongbans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Phongbans == null)
            {
                return NotFound();
            }

            var phongban = await _context.Phongbans
                .FirstOrDefaultAsync(m => m.Idpb == id);
            if (phongban == null)
            {
                return NotFound();
            }

            return View(phongban);
        }

        // POST: Phongbans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Phongbans == null)
            {
                return Problem("Entity set 'QLNSContext.Phongbans'  is null.");
            }
            var phongban = await _context.Phongbans.FindAsync(id);
            if (phongban != null)
            {
                _context.Phongbans.Remove(phongban);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongbanExists(int id)
        {
          return (_context.Phongbans?.Any(e => e.Idpb == id)).GetValueOrDefault();
        }
    }
}
