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
    public class ReviewController : Controller
    {
        private readonly IPlaceRepository placeRepo;
        private readonly IQuestionRepository questionRepo;
        private readonly IReviewRepository reviewRepo;
        

        public ReviewController(IPlaceRepository placeRepo, IQuestionRepository questionRepo, IReviewRepository reviewRepo)
        {
            this.placeRepo = placeRepo;
            this.questionRepo = questionRepo;
            this.reviewRepo = reviewRepo;
        }

        // GET: /review/
        public IActionResult Review(int place_ID, int user_ID)
        {
            var place = placeRepo.FindPlaceByID(place_ID);

            ViewData["Place"] = place;
            ViewData["Questions"] = questionRepo.FindQuestionsByPlaceType(place.place_type);
            ViewData["UserID"] = user_ID;

            return View();
        }


        // POST: /review/save
        public IActionResult save(ReviewForm form)
        {

            var existingReview = reviewRepo.FindByUserAndPlace(form.user_ID, form.place_ID);


            if (existingReview != null)
            {
                TempData["Error"] = "OH WOW! Looks like you already did a review this place. Click 'Go Back' to select another place to view.";
                
                return RedirectToAction("Review", new { user_ID = form.user_ID, place_ID = form.place_ID });
            }



            var review = new Review();
            review.place_ID = form.place_ID;
            review.user_ID = form.user_ID;
            //review.point_value = form.point_value;
            reviewRepo.Save(review);

            var savedReview = reviewRepo.FindByUserAndPlace(form.user_ID, form.place_ID);

            var i = 0;

            foreach (var qID in form.question_ID)
            {
                var answer = new Answer();
                answer.questioin_ID = qID;
                answer.review_ID = savedReview.review_ID;
                answer.point_value = form.point_value[i];

                reviewRepo.AnswerSave(answer);
                i++;
            }

            //return RedirectToAction("PickAPlace", "Home", new { user_ID = form.user_ID });
            //return RedirectToAction("Summary", "Place", new { user_ID = form.user_ID });
            //return RedirectToAction("Summary", "Review", new { user_ID = form.user_ID });
            return RedirectToAction("summary", "Place", new { user_ID = form.user_ID, place_ID = form.place_ID});
        }

    }
}
