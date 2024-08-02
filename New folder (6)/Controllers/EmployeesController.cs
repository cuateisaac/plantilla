using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using HorasExtra.Data;
using HorasExtra.Models;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
namespace HorasExtra.Controllers
{
    public class EmployeesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly HorasExtraDBContext _context;
        private Sp Sp = new Sp();
        public EmployeesController(HorasExtraDBContext context)
        {
            _context = context;
        }
        [System.Web.Mvc.HttpPost]
        public Microsoft.AspNetCore.Mvc.JsonResult GetEmployeeData(int EmpNum)
        {
            return Json(Sp.GetEmpData(EmpNum));
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Create([Microsoft.AspNetCore.Mvc.Bind("ID,EmpNum,Name,QtyHrs,Signature,CreatedAt,RequestID")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                employees.CreatedAt = DateTime.Now;
                _context.Add(employees);
                await _context.SaveChangesAsync();
            }
            return View("Requests/Details/" + employees.RequestID.ToString());
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Microsoft.AspNetCore.Mvc.Bind("ID,EmpNum,Name,QtyHrs,Signature,CreatedAt,ID_Request")] Employees employees)
        {
            if (id != employees.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!EmployeesExists(employees.ID))
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
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.ActionName("Delete")]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
