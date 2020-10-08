using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidReponse.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidReponse.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser(User u)
        {
            return View();

        }

        public IActionResult FindUserByEmail(string email)
        {
            var u = repo.FindUserByEmail(email);

            return RedirectToAction("PickAPlace", "Home", new { user_ID = u.user_ID });
        }
       

    }
}
