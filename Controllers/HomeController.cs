using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_APP_EF_DB_First.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_APP_EF_DB_First.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        //[Route("Home/Index")]
        //[Route("home/index/{id?}")]
        public IActionResult Index()
        {
            //if(id!=null)
            //{
            //    return "Received " + id.ToString();
            //}
            //else
            //{
            //    return "Received nothing";
            //}
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

        public IActionResult Welcome()
        {
            ViewBag.msg = "Welcome";
            return View();
        }

    }
}
