using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    //[Route("Home")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {

        private readonly IStudentRepository _studentRepository;


        public HomeController(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }
        [Route("/")]
        //[Route("")]
        //[Route("Index")]
        public ViewResult Index()
        {
            // 查询所有学生信息
            var model = _studentRepository.GetAllStudents();
            // 将查询到的数据传递到视图层
            return View(model); 
        }
        // id参数可选
        //[Route("Details/{id?}")]
        public ViewResult Details(int? id) 
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(id ?? 1),
                PageTitle = "这是详情页"
            };

            return View(homeDetailsViewModel);
        }

        public ViewResult Create()
        {
            return View();
        }
    }
}
