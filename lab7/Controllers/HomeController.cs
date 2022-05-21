using lab7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace lab7.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly StudentContext _studentContext;

        public HomeController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/students")]
        public IActionResult List()
        {
            return View(_studentContext.students.OrderBy(student => student.Lastname));
        } 
        
        [HttpGet("/about")]
        public IActionResult About()
        {
            return View(_studentContext.students.OrderBy(student => student.Lastname));
        }

        [HttpGet("/students/:id")]
        public IActionResult Details(Guid ID)
        {
            return View(_studentContext.students.FirstOrDefault(student => student.ID == ID));
        }

        [HttpGet("/students/add/")]
        public IActionResult Add()
        {
            return View();
        } 
        
        [HttpPost("/students/add/")]
        public RedirectToActionResult Add(Student student)
        {
            student.ID = Guid.NewGuid();
            _studentContext.Add(student);
            _studentContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet("/students/delete/:id")]
        public RedirectToActionResult Delete(Guid ID)
        {
            _studentContext.students.Remove(_studentContext.students.FirstOrDefault(student => student.ID == ID));
            _studentContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
