using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;

namespace SallesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SallesWebMvcContext _context;

        public DepartmentsController(SallesWebMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
              return _context.Department != null ? 
                          View(_context.Department.ToList()) :
                          Problem("Entity set 'SallesWebMvcContext.Department'  is null.");
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = _context.Department
                .FirstOrDefault(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = _context.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = _context.Department
                .FirstOrDefault(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Department == null)
            {
                return Problem("Entity set 'SallesWebMvcContext.Department'  is null.");
            }
            var department = _context.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            _context.Department.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
          return (_context.Department?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
