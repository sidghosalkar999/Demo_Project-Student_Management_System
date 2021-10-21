using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sid.Intranet.Web.Models;

namespace Sid.Intranet.Web.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> stuList = new List<Student>()
            {
                new Student(){ Id = 1, FirstName = "Sid", LastName = "Ghosalkar", Course = "C#", Address = "Mangaon", PhoneNumber = "6756756767" },
                new Student(){ Id = 2, FirstName = "Vivek", LastName = "Patil", Course = ".Net Framework", Address = "Panvel", PhoneNumber = "9845434534" },
                new Student(){ Id = 3, FirstName = "Aniket", LastName = "Bhuse", Course = "Java", Address = "Vashi", PhoneNumber = "9875676677" },
                new Student(){ Id = 4, FirstName = "Abhishek", LastName = "Hadke", Course = "Python", Address = "Airoli", PhoneNumber = "9770968687" },
                new Student(){ Id = 5, FirstName = "Rupali", LastName = "Jadhav", Course = "Entity Framework", Address = "Nerul", PhoneNumber = "7768686680"},
                new Student(){ Id = 6, FirstName = "Bhavika", LastName = "Mehta", Course = "MVC", Address = "Jalgaon", PhoneNumber = "6887896998" },
            };

        // GET: Student
        public ViewResult Welcome()
        {
            return View();
            //return "Welcome to SMS";
        }
        public EmptyResult Empty()
        {
            return new EmptyResult();
            //return View();
            //return "Welcome to Student Management System";
        }
        public ContentResult Content()
        {
            return new ContentResult() { Content = "Welcome to Student Management System", ContentType = "Text/Html" };
        }
        public ActionResult Index()
        {
            stuList.OrderBy(e => e.FirstName);
            return View(stuList);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get Record from DB
            var model = stuList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            //Save record in Db
            Student dbStudent = stuList.Where(x => x.Id == stu.Id).FirstOrDefault();
            stuList.Remove(dbStudent);
            dbStudent = stu;
            stuList.Add(dbStudent);
            stuList.OrderBy(e => e.FirstName);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student stu)
        {
            stuList.Add(stu);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = stuList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = stuList.Where(x => x.Id == id).FirstOrDefault();
            stuList.Remove(model);
            return RedirectToAction("Index");
        }
    }
}
