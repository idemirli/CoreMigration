using CoreMigration.Data;
using CoreMigration.Entity;
using CoreMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            DeleteFromTables();
            AddStudentsAndUsers(); //bire-bir
            AddLessonToStudent();   //çoka-çok

            //Çoka-çok ilişkiyi görmek için
            List<Student> lstStudent = _context.Students.ToList();
            var students = _context.Students.AsQueryable();
            students = students.Include(x => x.Lesson).Where(y => y.Lesson.Any(z => z.Id == 2));
            
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

        public void DeleteFromTables()
        {
            List<Student> lstStudent = _context.Students.ToList();
            List<User> lstUsers = _context.Users.ToList();
            _context.Students.RemoveRange(lstStudent.ToArray());
            _context.Users.RemoveRange(lstUsers.ToArray());
            _context.SaveChanges();
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
            List<Department> departments = _context.Departments.ToList();
            List<Student> lstStudent = _context.Students.ToList();
            List<User> users = _context.Users.ToList();
            List<Lesson> lstLesson = new List<Lesson>() { new Lesson() { Name="Algoritma", Student=lstStudent }, new Lesson() { Name="Veri Yapıları",Student=lstStudent } };

            foreach (Lesson item in lstLesson)
            {
                _context.Lessons.Add(item);
                _context.SaveChanges();
            }
        }
    }
}
