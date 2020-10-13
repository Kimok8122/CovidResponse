using System;
using System.Collections.Generic;
using System.Data;
using CovidReponse.Models;

namespace CovidReponse.Repositories
{

    
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAllReviews();
        public Review FindByUserAndPlace(int UserId, int PlaceId);
        public void Save(Review r);
        public void AnswerSave(Answer a);


    }
}
