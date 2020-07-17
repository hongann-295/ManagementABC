using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagementABC.Models;
using Microsoft.AspNetCore.Hosting;
using ManagementABC.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ManagementABC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository studentRepository;

        private readonly IClassRepository classRepository;

        public HomeController(IStudentRepository studentRepository,

            IClassRepository classRepository)
        {
            this.studentRepository = studentRepository;

            this.classRepository = classRepository;
        }
        public IActionResult Index()
        {

            var indexViewModel = (from cl in classRepository.Gets().ToList()
                                  select new ClassIndexViewModel()
                                  {
                                      ClassId = cl.ClassId,
                                      ClassName = cl.ClassName
                                  }).ToList();


            return View(indexViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Classes = GetClasses();
            return View();
        }


        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student()
                {
                    Fullname = model.Fullname,
                    DoB = model.DoB,
                    Gender = model.Gender,
                    Email = model.Email,
                    ClassId = model.ClassId

                };
                var newStd = studentRepository.Create(student);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Classes = GetClasses();
            return View();
        }

        public IActionResult ViewDetail(int id)
        {
            var detailView = (from st in studentRepository.Gets().ToList()
                              join cl in classRepository.Gets().ToList() on st.ClassId equals cl.ClassId
                              where cl.ClassId == id
                              select new DetailViewModel()
                              {
                                  Id = st.Id,
                                  Fullname = st.Fullname,
                                  Gender = st.Gender,
                                  DoB = st.DoB,
                                  Email = st.Email,
                                  ClassId = st.ClassId,
                                  ClassName = cl.ClassName
                              }).ToList();

            return View(detailView);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

           var student = studentRepository.Get(id);
           var editStudent = new HomeEditViewModel()
            {
                Id = student.Id,
                Fullname = student.Fullname,
                Gender = student.Gender,
                DoB = student.DoB,
                Email = student.Email,
                ClassId = student.ClassId
            };
            ViewBag.Classes = GetClasses();
            return View(editStudent);
        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editStd = new Student()
                {
                    Id = model.Id,
                    Fullname = model.Fullname,
                    Gender = model.Gender,
                    DoB = model.DoB,
                    Email = model.Email,
                    ClassId = model.ClassId
                };
               studentRepository.Edit(editStd);
               
               
                    return RedirectToAction("ViewDetail", "Home", new { id = editStd.ClassId });
             
            }
            ViewBag.Classes = GetClasses();
            return View();

        }
        public IActionResult Delete(int id)
        {
            var student = studentRepository.Get(id);
                 studentRepository.Delete(id);
               
                return RedirectToAction("ViewDetail", "Home" ,new {id=student.ClassId});
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public List<Class> GetClasses()
        {
            return classRepository.Gets().ToList();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
