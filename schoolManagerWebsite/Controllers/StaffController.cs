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
    public class StaffController : Controller
    {
        public IActionResult Index(int? value)
        {
            //dropwdown list
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Select Option", Value = "null" };
            SelectListItem item2 = new SelectListItem() { Text = "Teacher", Value = "1" };
            SelectListItem item3 = new SelectListItem() { Text = "Staff", Value = "2" };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            ViewBag.Options = items;

            if (value != null)
            {
                ViewBag.Value = value;
            }

            //Teacher Model
            List<teacherModel> teacher = new List<teacherModel>();
            teacher = DataAccess.LoadTeachers();
            ViewBag.Teachers = teacher;

            //Staff Model
            List<staffModel> staff = new List<staffModel>();
            staff = StaffDataAccess.LoadStaff();
            ViewBag.Staff = staff;

            return View();
           
        }
        //Add new teacher data to teacher table
        public IActionResult TeacherCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TeacherCreate(teacherModel m)
        {
            DataAccess.CreateNew(m);
            return RedirectToAction("Index");
        }

        //Add new staff data to staff table
        public IActionResult StaffCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StaffCreate(staffModel m)
        {
            StaffDataAccess.CreateNewStaff(m);
            return RedirectToAction("Index");
        }

        //Update teacher table
        public IActionResult SelectTeacher(int id)
        {
            int i = id;
            List<teacherModel> teacher = new List<teacherModel>();
            teacher = DataAccess.SelectTeacher(i);
            return View(teacher);
        }
        [HttpPost]
        public IActionResult UpdateTeacher(teacherModel m)
        {
            DataAccess.Update(m);
            return RedirectToAction("Index");
        }

        //Update staff table
        public IActionResult SelectStaff(int id)
        {
            int i = id;
            List<staffModel> staff = new List<staffModel>();
            staff = StaffDataAccess.SelectStaff(i);
            return View(staff);
        }
        [HttpPost]
        public IActionResult UpdateStaff(staffModel m)
        {
            StaffDataAccess.UpdateStaff(m);
            return RedirectToAction("Index");
        }

        //delete row from teacher table
        public ActionResult DeleteTeacher(int id)
        {
            int i = id;
            List<teacherModel> teacher = new List<teacherModel>();
            teacher = DataAccess.SelectTeacher(i);
            return View(teacher);
        }
        public ActionResult ConfirmTeacherDelete(int id)
        {
            int i = id;
            DataAccess.Delete(i);
            return RedirectToAction("Index");
        }

        //delete row from teacher table
        public ActionResult DeleteStaff(int id)
        {
            int i = id;
            List<staffModel> staff = new List<staffModel>();
            staff = StaffDataAccess.SelectStaff(i);
            return View(staff);
        }
        public ActionResult ConfirmStaffDelete(int id)
        {
            int i = id;
            StaffDataAccess.DeleteStaff(i);
            return RedirectToAction("Index");
        }

    }
}
