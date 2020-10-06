using System;
using System.Collections.Generic;
using CovidReponse.Models;

namespace CovidReponse.Repositories
{
    public interface IPlaceRepository
    {
        public IEnumerable<Place> GetAllCompanies();
    }

}
