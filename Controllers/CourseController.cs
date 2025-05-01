using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Models;
using MVC02.Repository;
using System.Drawing.Printing;

namespace MVC02.Controllers
{
    public class CourseController : Controller
    {
        //AppDBContext context = new AppDBContext();
        CourseRepository CourseRepository;
        DepartmentRepository DepartmentRepository;
        public CourseController
            (CourseRepository courseRepository, DepartmentRepository departmentRepository)
        {
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
        }
        //still i don't understand this action
        public IActionResult Check(int minDegree, int Degree)
        {
            if (minDegree < Degree)
                return Json(true);
            return Json(false);
        }
        public IActionResult Index()
        {
            List<Course> courses = CourseRepository.GetAll();
            return View("Index", courses);
        }
        public IActionResult Add()
        {
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("Add");
        }
        [HttpPost]
        public IActionResult SaveAdd(Course courseObj)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Add(courseObj);
                CourseRepository.Save();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("Add", courseObj);
        }
    }
}
