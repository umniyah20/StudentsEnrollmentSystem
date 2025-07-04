using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsEnrollmentSystem.Data;
using StudentsEnrollmentSystem.Models;

namespace StudentsEnrollmentSystem.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _context;

        public InstructorController(AppDbContext context)
        {
            _context = context;
        }

        // Index
        public IActionResult Index()
        {
            var instructors = _context.Instructors
                .Include(i => i.Department)
                .ToList();

            return View(instructors);
        }

        // Details
        public IActionResult Details(int id)
        {
            var instructor = _context.Instructors
                .Include(i => i.Department)
                .FirstOrDefault(i => i.Id == id);

            if (instructor == null)
                return NotFound();

            return View(instructor);
        }

        // Create - GET
        // GET
        public IActionResult Create()
        {   
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // إعادة تعبئة القائمة إذا فشل التحقق
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", instructor.DepartmentId);
            return View(instructor);
        }


        // Edit - GET
        public IActionResult Edit(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
                return NotFound();

            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", instructor.DepartmentId);
            return View(instructor);
        }

        // Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Instructor instructor)
        {
            if (id != instructor.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existing = _context.Instructors.Find(id);
                if (existing == null)
                    return NotFound();

                existing.FirstName = instructor.FirstName;
                existing.LastName = instructor.LastName;
                existing.DepartmentId = instructor.DepartmentId;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", instructor.DepartmentId);
            return View(instructor);
        }

        // Delete - GET
        public IActionResult Delete(int id)
        {
            var instructor = _context.Instructors
                .Include(i => i.Department)
                .FirstOrDefault(i => i.Id == id);

            if (instructor == null)
                return NotFound();

            return View(instructor);
        }

        // Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor == null)
                return NotFound();

            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
