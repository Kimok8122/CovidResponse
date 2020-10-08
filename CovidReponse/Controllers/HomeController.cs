using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidReponse.Models;
using System.Data;
using CovidReponse.Repositories;

namespace CovidReponse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository userRepo;
        private readonly IPlaceRepository placeRepository;

        public HomeController(IUserRepository repo, IPlaceRepository placeRepository)
        {
            this.userRepo = repo;
            this.placeRepository = placeRepository;
        }

        public IActionResult Home()
        {
            var user = new User();
            return View(user);
        }

        public IActionResult InsertUserToDatabase(User user)
        {
            userRepo.CreateUser(user);

            var newUser = userRepo.FindUser(user);

            return RedirectToAction("PickAPlace", new { user_ID = newUser.user_ID });
        }

        public IActionResult PickAPlace(int user_ID)
        {
            
            var user = userRepo.FindUserById(user_ID);

            ViewData["Places"] = placeRepository.GetAllCompanies();
            ViewData["FirstName"] = user.first_name;
            ViewData["Last"] = user.last_name;
            ViewData["Email"] = user.email;

            return View();

            //return View(places);
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
