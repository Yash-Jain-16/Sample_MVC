using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_APP_EF_DB_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_APP_EF_DB_First.Controllers
{
    public class CategoryController : Controller
    {

        public ShoppingContext _context { get; }
        public CategoryController(ShoppingContext context)
        {
            _context = context;
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id < 0)
            {
                return BadRequest();
            }
            var cat = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            else
            {
                return View(cat);
            }
        }


        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category newcat)
        {
            _context.Categories.Add(newcat);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Index()
        {
            List<Category> cats = _context.Categories.ToList();
            return View(cats);
        }


        public ActionResult ShowByType()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            List<Category> c = _context.Categories.ToList();
            foreach (Category x in c)
            {
                types.Add(new SelectListItem() { Text = x.CategoryName, Value = x.CategoryName });
            }
            ViewBag.type = types;
            return View();
        }


        [Route("ShowProd/Category/{pl}")]
        public ActionResult ShowProd(List<Product> pl)
        {
            return View(pl);
        }


        [HttpPost]
        public ActionResult ShowByType(Category C)
        {
            List<Product> pl  = _context.Prods.Where(u => u.Type == C.CategoryName).ToList();
            Console.WriteLine(pl);
            //List<Product> plist = new List<Product>();
            //foreach (Product p in pl)
            //{
            //    plist.Add(p);
            //}
            //ViewBag.listp = plist;
            return RedirectToAction("ShowProd","Category",pl);
        }

    }
}
