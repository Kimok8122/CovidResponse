using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidReponse.Models;
using CovidReponse.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidReponse.Controllers
{
    public class PlaceController : Controller
    {

        private readonly IPlaceRepository repo;

        public PlaceController(IPlaceRepository repo)
        {
            this.repo = repo;
        }

        // GET: /place/
        public IActionResult Place()
        {
            var places = repo.GetAllCompanies();

            return View(places);
        }

        // GET: /place/summary
        public IActionResult summary()
        {

            return View();
        }
    }
 
}
