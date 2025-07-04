using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsEnrollmentSystem.Data;
using StudentsEnrollmentSystem.Models;

namespace StudentsEnrollmentSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentController(AppDbContext db)
        {
            Context = db;
        }
        public AppDbContext Context { get; set; }
        public IActionResult Index()
        {
            var result = Context.Departments.ToList();
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {

                Context.Departments.Add(department);
                Context.SaveChanges();

                return RedirectToAction("Index");
            }




            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = Context.Departments
                .FirstOrDefault(s => s.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            // تجهيز قائمة الأقسام لو في اختيار قسم
            var departments = Context.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingdepartment = Context.Departments.FirstOrDefault(s => s.Id == id);
                if (existingdepartment == null)
                {
                    return NotFound();
                }

                // نحدث فقط الحقول اللي مسموح بتعديلها
                existingdepartment.Name = department.Name;
                existingdepartment.Budget = department.Budget;


                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            // لو فيه أخطاء، نرجّع نفس الصفحة مع الأقسام
            var departments = Context.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");

            return View(department);
        }
        // GET: عرض صفحة تأكيد الحذف
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var department = await Context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // POST: تنفيذ الحذف بعد التأكيد
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await Context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            Context.Departments.Remove(department);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var department = await Context.Departments
                .Include(d => d.Courses)
                .Include(d => d.Students)
                .Include(d => d.Instructors)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (department == null)
                return NotFound();

            return View(department);
        }

    }

}