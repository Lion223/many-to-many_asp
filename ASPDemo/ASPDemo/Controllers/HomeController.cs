using ASPDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDemo.Controllers
{
    public class HomeController : Controller
    {
        private StudentsContext context = new StudentsContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCourse()
        {
            ViewBag.Students = context.Students.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course, int[] selectedStudents)
        {
            if (selectedStudents != null)
            {
                foreach (var s in context.Students.Where(st => selectedStudents.Contains(st.Id)))
                {
                    course.Students.Add(s);
                }
            }

            context.Courses.Add(course);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddStudent()
        {
            ViewBag.Courses = context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student, int[] selectedCourses)
        {
            if (selectedCourses != null)
            {
                foreach (var c in context.Courses.Where(co => selectedCourses.Contains(co.Id)))
                {
                    student.Courses.Add(c);
                }
            }

            context.Students.Add(student);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}