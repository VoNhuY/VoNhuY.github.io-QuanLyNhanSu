using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien.Controllers
{
    public class NhanviensController : Controller
    {
        private readonly QLNSContext _context;
        IWebHostEnvironment hostingenviroment;
        public NhanviensController(QLNSContext context, IWebHostEnvironment hc)
        {

            _context = context;
            hostingenviroment = hc;
        }

        // GET: Nhanviens
        public async Task<IActionResult> Index(string searchString)
        {
            var qLNSContext = from m in _context.Nhanviens
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                qLNSContext = qLNSContext.Where(s => s.Hoten!.Contains(searchString));
            }

            return View(await qLNSContext.ToListAsync());
        }

        // GET: Nhanviens/search
        
        // GET: Nhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.IdcvNavigation)
                .Include(n => n.IdpbNavigation)
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanviens/Create
/*        public IActionResult Create()
        {
            ViewData["Idcv"] = new SelectList(_context.Chucvus, "Idcv", "Idcv");
            ViewData["Idpb"] = new SelectList(_context.Phongbans, "Idpb", "Idpb");
            return View();
        }*/
        public IActionResult Create(NhanvienViewsModels nhanvien)
        {
            String filename = "";
            byte[] bytes = Encoding.ASCII.GetBytes(filename);


            if (nhanvien.Photo != null)
            {
                String uploadfoder = Path.Combine(hostingenviroment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_" + nhanvien.Photo.FileName;
                String filepath = Path.Combine(uploadfoder, filename);
                nhanvien.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

            }


            Nhanvien p = new Nhanvien
            {

                Hoten = nhanvien.Hoten,
                Gioitinh = nhanvien.Gioitinh,
                Ngaysinh = nhanvien.Ngaysinh,
                Sdt = nhanvien.Sdt,
                Cccd = nhanvien.Cccd,
                Diachi = nhanvien.Diachi,
                Hinhanh = bytes

            };
            _context.Add(p);
/*            _context.SaveChanges();
            ViewBag.success = "Record add";*/
            ViewData["Idcv"] = new SelectList(_context.Chucvus, "Idcv", "Idcv");
            ViewData["Idpb"] = new SelectList(_context.Phongbans, "Idpb", "Idpb");
            return View();
        }

        // POST: Nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manv,Hoten,Gioitinh,Ngaysinh,Sdt,Cccd,Diachi,Hinhanh,Idpb,Idbp,Idcv")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcv"] = new SelectList(_context.Chucvus, "Idcv", "Idcv", nhanvien.Idcv);
            ViewData["Idpb"] = new SelectList(_context.Phongbans, "Idpb", "Idpb", nhanvien.Idpb);
            return View(nhanvien);
        }

        // GET: Nhanviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["Idcv"] = new SelectList(_context.Chucvus, "Idcv", "Idcv", nhanvien.Idcv);
            ViewData["Idpb"] = new SelectList(_context.Phongbans, "Idpb", "Idpb", nhanvien.Idpb);
            return View(nhanvien);
        }

        // POST: Nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Manv,Hoten,Gioitinh,Ngaysinh,Sdt,Cccd,Diachi,Hinhanh,Idpb,Idbp,Idcv")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Manv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Manv))
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
            ViewData["Idcv"] = new SelectList(_context.Chucvus, "Idcv", "Idcv", nhanvien.Idcv);
            ViewData["Idpb"] = new SelectList(_context.Phongbans, "Idpb", "Idpb", nhanvien.Idpb);
            return View(nhanvien);
        }

        // GET: Nhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.IdcvNavigation)
                .Include(n => n.IdpbNavigation)
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nhanviens == null)
            {
                return Problem("Entity set 'QLNSContext.Nhanviens'  is null.");
            }
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null)
            {
                _context.Nhanviens.Remove(nhanvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(int id)
        {
          return (_context.Nhanviens?.Any(e => e.Manv == id)).GetValueOrDefault();
        }

    }
}
