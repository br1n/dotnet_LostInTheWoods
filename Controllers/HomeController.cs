using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostInTheWoods.Models;
using LostInTheWoods.Factories;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private TrailFactory trailfactory;
        public HomeController()
        {
            trailfactory = new TrailFactory();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            //GET/Display all trails
            ViewBag.allTrails = trailfactory.GetAllTrails();
            return View();
        }

        [HttpGet("NewTrail")]
        public IActionResult NewTrail()
        {
            return View();
        }

        // add a new trail
        [HttpPost("create")]
        public IActionResult Create(Trail newTrail)
        {
            if(ModelState.IsValid)
            {
            trailfactory.Create(newTrail);
            return RedirectToAction("Index");
            }
            return View("NewTrail");
        }

        //get trail by {Id}
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var trail = trailfactory.GetTrailById(id);
            if(trail == null)
            {
                return RedirectToAction("Index");
            }
            return View(trail);
        }
    }
}
