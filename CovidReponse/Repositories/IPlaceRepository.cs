using System;
using System.Collections.Generic;
using CovidReponse.Models;

namespace CovidReponse.Repositories
{
    public interface IPlaceRepository
    {
        public IEnumerable<Place> GetAllCompanies();
        public Place FindPlaceByID(int place_ID);
        public IEnumerable<QuestionAvg> FindPlacePointAvg(int place_ID);
        public IEnumerable<PlaceReviewed> FindPlaceReviewedByUserID(int user_ID);
    }

}
