using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Models;
using MVC02.Repository;

namespace MVC02.Controllers
{
    public class DepartmentController : Controller
    {
        //AppDBContext Context = new AppDBContext();
        DepartmentRepository DepartmentRepository;
        DepartmentController(DepartmentRepository departmentRepository)
        {
            DepartmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            List<Department> departments = DepartmentRepository.GetAll();
            return View("Index", departments);
        }
        [HttpGet] //Default
        public IActionResult Add()
        {
            return View("Add");
        }
        //Filtter
        [HttpPost]
        public IActionResult SaveAdd(Department deptObjFromRequest)
        {
            if(deptObjFromRequest.Name != null)
            {
                DepartmentRepository.Add(deptObjFromRequest);
                DepartmentRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Add", deptObjFromRequest);//Model Department
        }
    }
}
