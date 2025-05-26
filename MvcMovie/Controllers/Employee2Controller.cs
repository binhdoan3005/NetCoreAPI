using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models.Entities;

namespace MvcMovie.Controllers
{
    [Authorize]
    public class Employee2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Employee2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee2s.ToListAsync());
        }

        [Authorize (Roles = "Employee")] 
        // GET: Employee2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee2 = await _context.Employee2s
                .FirstOrDefaultAsync(m => m.Employee2Id == id);
            if (employee2 == null)
            {
                return NotFound();
            }

            return View(employee2);
        }

        [Authorize (Roles = "Admin1")]
        // GET: Employee2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employee2Id,FirstName,LastName,Address,DateOfBirth,Position,Email,HireDate")] Employee2 employee2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee2);
        }

        [Authorize (Roles = "Admin")]
        // GET: Employee2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee2 = await _context.Employee2s.FindAsync(id);
            if (employee2 == null)
            {
                return NotFound();
            }
            return View(employee2);
        }

        // POST: Employee2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Employee2Id,FirstName,LastName,Address,DateOfBirth,Position,Email,HireDate")] Employee2 employee2)
        {
            if (id != employee2.Employee2Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee2Exists(employee2.Employee2Id))
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
            return View(employee2);
        }

        [Authorize (Roles = "Admin")]
        // GET: Employee2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee2 = await _context.Employee2s
                .FirstOrDefaultAsync(m => m.Employee2Id == id);
            if (employee2 == null)
            {
                return NotFound();
            }

            return View(employee2);
        }

        // POST: Employee2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee2 = await _context.Employee2s.FindAsync(id);
            if (employee2 != null)
            {
                _context.Employee2s.Remove(employee2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee2Exists(int id)
        {
            return _context.Employee2s.Any(e => e.Employee2Id == id);
        }
    }
}
