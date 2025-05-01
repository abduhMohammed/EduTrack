using Microsoft.AspNetCore.Mvc;
using MVC02.Models;

namespace MVC02.Controllers
{
    public class BindController : Controller
    {
        //3 Ways to Binding
        //Request HTML (Data) --> From Frontend to Backend
        //Binding Premitive (int, string, ....)
        ///Bind/TestPremitive --> Route Segmant
        ///Bind/TestPremitive?name=ahmed&age=12&id=12 --> Query String 
        ///Bind/TestPremitive/10?name=abdo&age=20 --> Route Values
        public IActionResult TestPremitive(string name, int age)
        {
            return Content($"{name} \t {age}");
        }

        //Binding Collection (List, Dictionary)
        ///Bind/TestDic?phones[abdo]=123&phones[ahmed]=456&name=mohamed
        public IActionResult TestDic(Dictionary<string, string> phones, string name) {
            return Content("OK");
        }

        //1- Form Date
        //2- Route Values
        //3- Query String

        //Bind Class
        ///Bind/testObj/10?name=abdo&manager=ali&Instructors[0].name=ahmed
        public IActionResult testObj(Department deptObj)
        {
            return Content("Bla Bla");
        }
    }
}
