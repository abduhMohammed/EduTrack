using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Models;

namespace MVC02.Controllers
{
    public class StateController : Controller
    {
        //Store Info in Server Side 
        public IActionResult SetSession(string name, int age)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);

            return Content("Data Session Saved Success");
        }
        public IActionResult GetSession()
        {
            string? name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");

            return Content($"Name = {name} \t Age = {age}");
        }
    }
}
