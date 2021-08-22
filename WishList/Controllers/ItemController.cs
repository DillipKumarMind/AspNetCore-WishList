using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index",model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _context.Items.Remove(_context.Items.First(p => p.Id == Id));
            _context.SaveChanges();
            return View("Index");
        }
    }
}
