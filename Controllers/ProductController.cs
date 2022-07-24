using Microsoft.AspNetCore.Mvc;
using MVC_APP_EF_DB_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_APP_EF_DB_First.Controllers
{
   
    public class ProductController : Controller
    {

        public ShoppingContext _context { get; }
        public ProductController(ShoppingContext context)
        {
            _context = context;
        }

        

      
        public IActionResult Index()
        {
            List<Product> products=_context.Prods.ToList();
            return View(products);
        }


        public ActionResult Details(int? id)
        {
            if(id==null || id<0)
            {
                return BadRequest();
            }
            var prod = _context.Prods.FirstOrDefault(p=>p.Id==id);
            if(prod==null)
            {
                return NotFound();
            }
            else
            {
                return View(prod);
            }
        }

        public ActionResult Create()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            List<Category> c = _context.Categories.ToList();
            foreach(Category x in c)
            {
                types.Add(new SelectListItem() { Text=x.CategoryName,Value = x.CategoryName});
            }
            ViewBag.type = types;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product newproduct)
        {
            _context.Prods.Add(newproduct);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product prod = _context.Prods.FirstOrDefault(p => p.Id == id);
            return View(prod);
        }

        [HttpPost]
        public ActionResult Delete(Product P)
        {
            //Product prod = _context.Prods.FirstOrDefault(p => p.Id == id);
            _context.Prods.Remove(P);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> types = new List<SelectListItem>();
            List<Category> c = _context.Categories.ToList();
            foreach (Category x in c)
            {
                types.Add(new SelectListItem() { Text = x.CategoryName, Value = x.CategoryName });
            }
            ViewBag.type = types;
            Product prod = _context.Prods.FirstOrDefault(p => p.Id == id);
            return View(prod);
        }

        [HttpPost]

        public ActionResult Edit(int id, Product P)
        {
            Product prod = _context.Prods.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                prod.ProductName = P.ProductName;
                prod.Price = P.Price;
                prod.Type = P.Type;
                _context.Entry(prod).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));

        }


        

        




    }
}
