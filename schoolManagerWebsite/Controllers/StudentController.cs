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
using Newtonsoft.Json;
namespace schoolManagerWebsite.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int? value)
        {
            //dropwdown list
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Select Option", Value = "null" };
            SelectListItem item2 = new SelectListItem() { Text = "Student", Value = "1" };
            SelectListItem item3 = new SelectListItem() { Text = "Teacher", Value = "2" };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            ViewBag.Options = items;

            if (value != null)
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
            List<studentModel> students = new List<studentModel>();

            students = StudentDataAccess.LoadStudentName();
            ViewBag.StudentFname = students;

            return View();
        }
        public IActionResult StudentCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentCreate(studentModel m)
        {
            StudentDataAccess.CreateNew(m);
            return RedirectToAction("Index");
        }
        public IActionResult SelectStudent(int id)
        {
            int i = id;
            List<studentModel> student = new List<studentModel>();
            student = StudentDataAccess.SelectStudent(i);
            return View(student);
        }
        //push update
        [HttpPost]
        public IActionResult UpdateStudent(studentModel m)
        {
            StudentDataAccess.Update(m);
            return RedirectToAction("Index");
        }

    }
}
