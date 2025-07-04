using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsEnrollmentSystem.Data;
using StudentsEnrollmentSystem.Models;

namespace StudentsEnrollmentSystem.Controllers
{
    public class StudentController : Controller
    {
        public StudentController(AppDbContext db)
        {
            Context = db;
        }
        public AppDbContext Context { get; set; }
        public IActionResult Index()
        {
            var result = Context.Students.ToList();
            var departments = Context.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var departments = Context.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Context.Students.Add(student);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            // لو فيه أخطاء في الإدخال، لازم تعبيء القائمة قبل عرض الصفحة من جديد
            var departments = Context.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");

            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = Context.Students
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            // تجهيز قائمة الأقسام لو في اختيار قسم
            var departments = Context.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingStudent = Context.Students.FirstOrDefault(s => s.Id == id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                // نحدث فقط الحقول اللي مسموح بتعديلها
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                existingStudent.EnrollmentDate = student.EnrollmentDate;
                existingStudent.DepartmentId = student.DepartmentId;

                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            // لو فيه أخطاء، نرجّع نفس الصفحة مع الأقسام
            var departments = Context.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");

            return View(student);
        }
        // GET: عرض صفحة تأكيد الحذف
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await Context.Students
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: تنفيذ الحذف بعد التأكيد
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await Context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            Context.Students.Remove(student);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
