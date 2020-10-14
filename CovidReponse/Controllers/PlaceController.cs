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
        private readonly IUserRepository userReop;



        public PlaceController(IPlaceRepository repo, IQuestionRepository qrepo, IUserRepository urepo)
        {
            this.placeRepo = repo;
            this.questionRepo = qrepo;
            this.userReop = urepo;
        }

        // GET: /place/
        public IActionResult Place(int user_ID)
        {
            var places = placeRepo.GetAllCompanies();
            ViewData["UserID"] = user_ID;
            return View(places);
        }

        // GET: /place/summary
        public IActionResult summary(int place_ID, int user_ID)
        {

          
            var viewplace = placeRepo.FindPlaceByID(place_ID);


            ViewData["Places"] = placeRepo.GetAllCompanies();
            ViewData["ViewedPlace"] = viewplace;
            //ViewData["ViewedQuestion"] = questionRepo.FindQuestionsByPlaceType(viewplace.place_type);
            ViewData["UserID"] = user_ID;
            ViewData["user_ID"] = user_ID;
            ViewData["questionAvg"] = placeRepo.FindPlacePointAvg(place_ID);
            ViewData["reviewedPlace"] = placeRepo.FindPlaceReviewedByUserID(user_ID);

            return View();
        }

       


    }
 
}
