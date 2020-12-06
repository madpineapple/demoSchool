using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using schoolManagerWebsite.Models;
using schoolDataMngmt;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace schoolManagerWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Students( int? value)
        {
            //dropwdown list
            List<SelectListItem> items= new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Select Option", Value = "null" };
            SelectListItem item2 = new SelectListItem() { Text = "Student" , Value="1"};
            SelectListItem item3 = new SelectListItem() { Text = "Teacher", Value = "2" };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            ViewBag.Options = items;

            if(value != null)
            {
                ViewBag.Value = value;
            }

            //Student Model
            List<studentModel> student = new List<studentModel>();
            student = StudentDataAccess.LoadStudents();
            ViewBag.Students = student;
            //Teacher Model
            List<teacherModel> teacher = new List<teacherModel>();
            teacher = DataAccess.LoadTeachers();
            ViewBag.Teachers = teacher;

            //chart data
            string[] authors = { "Mike Gold", "Don Box" };
            List<string> authorsRange = new List<string>(authors);
            ViewBag.Authors = authors;
            return View();
        }

        //[HttpPost]
        //public IActionResult Students(string value)
        //{
        //    ViewBag.Options = new List<string>() { "teachers", "students" };

        //    ViewBag.Value = value;
        //    List<studentModel> student = new List<studentModel>();
        //    student = StudentDataAccess.LoadStudents();
        //    return View( student);
        //}

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
