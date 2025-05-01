using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Models;
using MVC02.Repository;
using MVC02.ViewModel;
using System.Collections.Immutable;

namespace MVC02.Controllers
{
    public class InstructorController : Controller
    {
        //Object From Data Base
        //AppDBContext context = new AppDBContext();
        InstructorRepository InstructorRepository;
        CourseRepository CourseRepository;
        DepartmentRepository DepartmentRepository;

        public InstructorController
            (InstructorRepository instRepo, CourseRepository courRepo, DepartmentRepository deptRepo)
        {
            InstructorRepository = instRepo;
            CourseRepository = courRepo;
            DepartmentRepository = deptRepo;
        }

        ///Instructor/Index
        public IActionResult Index()
        {
            List<Instructor> instructors = InstructorRepository.GetAll();
            return View("Index", instructors);
        }

        ///Instructor/Details?id=3
        public IActionResult Details(int id)
        {
            Instructor? instructorModel = InstructorRepository.GetByID(id);

            if (instructorModel == null)
            {
                return NotFound();
            }

            return View("Details", instructorModel);
        }

        [HttpGet]
        ///Instructor/Add
        public IActionResult Add()
        {
            ViewBag.DeptList = DepartmentRepository.GetAll();
            ViewBag.CourseList = CourseRepository.GetAll();
            return View("Add");
        }

        [HttpPost]
        public IActionResult SaveAdd(Instructor instObjFromRequest)
        {
            if (ModelState.IsValid)
            {
                //01Coustom Valuation deptit != 0
                //Server Side Attribute
                if(instObjFromRequest.DeptartmentID != 0)
                {
                    /*
                    try
                    {
                        context.Instructor.Add(instObjFromRequest);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch(Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    */
                    InstructorRepository.Add(instObjFromRequest);
                    InstructorRepository.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("DeptartmentID", "Select Department");
                }
                /* 02 Create My Own Atrribute -> Server Side Attribute
                 * make custom attribute when:
                 * 01 - when i don't fund built-in attribute like [Required] 
                 * 02 - when i want to connect with database
                 */

                /*03
                 * Remote -> in this case i use Client Side Attirbute
                 */
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            ViewData["CourseList"] = CourseRepository.GetAll();

            return View("Add", instObjFromRequest);
        }

        ///Instructor/Edit/1
        public IActionResult Edit(int id)
        {
            Instructor? instModel = InstructorRepository.GetByID(id);
            if (instModel == null)
            {
                return NotFound();
            }
            List<Department> DepartmentList = DepartmentRepository.GetAll();
            List<Course> CourseList = CourseRepository.GetAll();
                
            InstDeptCourseViewModel instViewModel = new InstDeptCourseViewModel();

            instViewModel.id = instModel.id;
            instViewModel.Name = instModel.Name;
            instViewModel.Image = instModel.Image;
            instViewModel.Salary = instModel.Salary;
            instViewModel.Address = instModel.Address;
            instViewModel.DeptartmentID = instModel.DeptartmentID;
            instViewModel.CourseID = instModel.CourseID;

            instViewModel.DeptList = DepartmentList;
            instViewModel.CourseList = CourseList;

            return View("Edit", instViewModel);//InstDeptCourseViewModel
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, InstDeptCourseViewModel instFromRequest)
        {
            if(ModelState.IsValid)
            {
                Instructor? instFromDB = InstructorRepository.GetByID(id);
                
                instFromDB.Name = instFromRequest.Name;
                instFromDB.Image = instFromRequest.Image;
                instFromDB.Address = instFromRequest.Address;
                instFromDB.Salary = instFromRequest.Salary;
                instFromDB.DeptartmentID = instFromRequest.DeptartmentID;
                instFromDB.CourseID = instFromRequest.CourseID;

                InstructorRepository.Save();
                return RedirectToAction("Index");
            }
            instFromRequest.DeptList = DepartmentRepository.GetAll();
            instFromRequest.CourseList = CourseRepository.GetAll();

            return View("Edit", instFromRequest);
        }

        /*[HttpGet]
        public IActionResult Delete(int id)
        {
            Instructor instObj = InstructorRepository.Delete(id);
            if (instObj == null)
                return NotFound();
            return View("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {
            Instructor? instObj = context.Instructor.Find(id);
            if(instObj != null)
            {
                context.Instructor.Remove(instObj);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }*/
    }
}