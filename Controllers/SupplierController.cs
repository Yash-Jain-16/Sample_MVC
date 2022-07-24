using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_APP_EF_DB_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_APP_EF_DB_First.Controllers
{
    public class SupplierController : Controller
    {
        public ShoppingContext _context { get; }
        public SupplierController(ShoppingContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Supplier> sups = _context.Suppliers.ToList();
            return View(sups);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Supplier S)
        {
            _context.Suppliers.Add(S);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id < 0)
            {
                return BadRequest();
            }
            var sup = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (sup == null)
            {
                return NotFound();
            }
            else
            {
                return View(sup);
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Supplier Sp = _context.Suppliers.FirstOrDefault(p => p.Id == id);
            return View(Sp);
        }

        [HttpPost]
        public ActionResult Delete(Supplier S)
        {
            //Product prod = _context.Prods.FirstOrDefault(p => p.Id == id);
            _context.Suppliers.Remove(S);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Supplier Sp = _context.Suppliers.FirstOrDefault(p => p.Id == id);
            return View(Sp);
        }

        [HttpPost]

        public ActionResult Edit(int id, Supplier S)
        {
            Supplier Sp = _context.Suppliers.FirstOrDefault(p => p.Id == id);
            if (Sp != null)
            {
                Sp.SupplierName = S.SupplierName;
                Sp.Contact = S.Contact;
                Sp.City = S.City;
                _context.Entry(Sp).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
