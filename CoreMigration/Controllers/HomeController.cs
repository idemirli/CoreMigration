using CoreMigration.Data;
using CoreMigration.Entity;
using CoreMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMigration.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;


        public HomeController(SchoolContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {

            //AddStudentsAndUsers(); bire-bir
            //AddLessonToStudent();  çoka-çok
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

        public void AddStudentsAndUsers() 
        {
            List<Student> lstDp = new List<Student>() {
                new Student() { Name="semih", Surname="demirli", address="asd", TelNo="456", DepartmentId=1,User= new User(){ Name="semih", TcNo="123" }  },
                new Student() {Name="ibrahim", Surname="demirli", address="dasd", TelNo="123", DepartmentId=2 , User= new User(){ Name="ibrahim", TcNo="456" } },
                };
            foreach (Student item in lstDp)
            {
                _context.Students.Add(item);
                _context.SaveChanges();
            }
        }

        public void AddLessonToStudent()
        {

            List<LessonToStudent> lessonToStudents = new List<LessonToStudent>() {
            
             new LessonToStudent() { Lesson=new Lesson{ Name="Algoritma" }, Student= new Student() { Name="kazım", Surname="duman", address="gdfg", TelNo="8989", DepartmentId=1,User= new User(){ Name="kazım", TcNo="887" }  } },
             new LessonToStudent() { Lesson=new Lesson{ Name="Veri Yapıları" }, Student= new Student() { Name="serdar", Surname="boz", address="gfhgf", TelNo="454", DepartmentId=2,User= new User(){ Name="serdar", TcNo="9967" }  } }
            };

            foreach (LessonToStudent item in lessonToStudents)
            {
                _context.LessonToStudents.Add(item);
                _context.SaveChanges();
            }
        }
    }
}
