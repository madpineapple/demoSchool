using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using schoolDataMngmt;


namespace schoolManagerWebsite.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        //create new class
        
        public IActionResult ClassCreate()
        {
            List<teacherModel> teachers = new List<teacherModel>();
            teachers = DataAccess.LoadTeachers();
            teachers.Insert(0, new teacherModel { TeacherId = 0,fname = "Select" });
            ViewBag.Teachers = teachers;

        var dictionary = new Dictionary< int, int>
            {
                {9,9 },
                {10,10 }
            };

            ViewBag.SelectList = new SelectList(dictionary, "Key", "Value");



            return View();
        }

       

        [HttpPost]
        public IActionResult ClassCreate(classModel m)
        {
            ClassDataAccess.CreateNew(m);
            return RedirectToAction("Index");
        }
    }
}
