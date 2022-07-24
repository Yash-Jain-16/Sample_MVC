using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_APP_EF_DB_First.Controllers
{
    public class GitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
