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
    
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }
        public ViewResult Index()
        {
            // 查询所有学生信息
            var model = _studentRepository.GetAllStudents();
            // 将查询到的数据传递到视图层
            return View(model); 
        }
        public ViewResult Details() 
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(1),
                PageTitle = "这是详情页"
            };

            return View(homeDetailsViewModel);
        }
    }
}
