using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AsyncInMVC.Models;

namespace AsyncInMVC.Controllers
{
    public class HomeController : Controller
    {
        AniketEntities DB = new AniketEntities();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var List = await DB.Employee.ToListAsync(); 
            return View(List);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                DB.Employee.Add(emp);
                await DB.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}