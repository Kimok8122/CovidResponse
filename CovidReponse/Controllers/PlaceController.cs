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

        private readonly IPlaceRepository placeRepo;
        private readonly IQuestionRepository questionRepo;

        public PlaceController(IPlaceRepository repo, IQuestionRepository qrepo)
        {
            this.placeRepo = repo;
            this.questionRepo = qrepo;
        }

        // GET: /place/
        public IActionResult Place()
        {
            var places = placeRepo.GetAllCompanies();

            return View(places);
        }

        // GET: /place/summary
        public IActionResult summary(int place_ID)
        {

            var viewplace = placeRepo.FindPlaceByID(place_ID);

            ViewData["Places"] = placeRepo.GetAllCompanies();
            ViewData["ViewedPlace"] = viewplace;
            ViewData ["ViewedQuestion"] = questionRepo.FindQuestionsByPlaceType(viewplace.place_type);
            return View();
        }
    }
 
}
