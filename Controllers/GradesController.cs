using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using SchoolManagement.MVC.Data;

namespace SchoolManagement.MVC.Controllers
{
    [Authorize]
    public class GradesController : Controller
    {
        private readonly SchoolMngmntDbContext _context;

        public GradesController(SchoolMngmntDbContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var GradesContext = _context.Grades
                .Include(g => g.StudentsCourse)
                .ThenInclude(sc => sc.Student)
                .Include(g => g.StudentsCourse)
                .ThenInclude(sc => sc.Course);
            return View(await GradesContext.ToListAsync());
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.StudentsCourse)
                .ThenInclude(sc => sc.Student)
                .Include(g => g.StudentsCourse)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewData["StudentCourseId"] = new SelectList(_context.StudentsCourses .Select(s => new { s.Id, StudCourField = s.Student.LastName + ", " + s.Student.FirstName + " / " + s.Course.Name }), "Id", "StudCourField");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GradeObtained,DateRecorded,StudentCourseId")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                grade.DateRecorded = DateOnly.FromDateTime(DateTime.Now);
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentCourseId"] = new SelectList(_context.StudentsCourses .Select(s => new { s.Id, StudCourField = s.Student.LastName + ", " + s.Student.FirstName + " / " + s.Course.Name }), "Id", "StudCourField", grade.StudentCourseId);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["StudentCourseId"] = new SelectList(_context.StudentsCourses .Select(s => new { s.Id, StudCourField = s.Student.LastName + ", " + s.Student.FirstName + " / " + s.Course.Name }), "Id", "StudCourField", grade.StudentCourseId);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GradeObtained,DateRecorded,StudentCourseId")] Grade grade)
        {
            if (id != grade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.Id))
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
            ViewData["StudentCourseId"] = new SelectList(_context.StudentsCourses .Select(s => new { s.Id, StudCourField = s.Student.LastName + ", " + s.Student.FirstName + " / " + s.Course.Name }), "Id", "StudCourField", grade.StudentCourseId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.StudentsCourse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            try
            {
                _context.Grades.Remove(grade);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Check if the exception is a constraint violation
                if (ex.InnerException != null && ex.InnerException.Message.Contains("constraint"))
                {
                    TempData["DeleteError"] = "Unable to delete teacher. There are related records in the database. Check if there is a Student associated to the Grade.";
                    
                }
                else
                {
                    throw;
                }
            }            
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }
    }
}
