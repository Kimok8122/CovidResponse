using System;
using System.Collections.Generic;
using System.Data;
using CovidReponse.Models;
using Dapper;

namespace CovidReponse.Repositories
{
    public class PlaceRespository : IPlaceRepository
    {
        private readonly IDbConnection _conn;

        public PlaceRespository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Place> GetAllCompanies()
        {
            return _conn.Query<Place>("SELECT * FROM PLACE order by company");
              
               
        }
    }
}
