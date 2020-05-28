using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    [Route("[controller]/[action]")]
    public class DepartmentsController : Controller
    {
        public string List()
        {
            return "Departments List";
        }

        public string Details()
        {
            return "Departments Details";
        }
    }
}
