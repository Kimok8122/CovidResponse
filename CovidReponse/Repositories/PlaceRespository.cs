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

        public Place FindPlaceByID(int place_ID)
        {
            return _conn.QuerySingle<Place>("SELECT * FROM PLACE WHERE place_id = @id", new { id = place_ID });
        }

        public IEnumerable<QuestionAvg> FindPlacePointAvg(int place_ID)
        {
            return _conn.Query<QuestionAvg>("Select A.question_ID, Q.text, avg(A.point_value) as average, count(*) as review_count FROM ANSWER A join REVIEW R on A.review_ID = R.review_ID join PLACE P on R.place_ID = P.place_ID"
            + " join QUESTION Q on A.question_ID = Q.question_ID where r.place_ID = @id"
            + " group by A.question_ID, P.place_ID", new { id = place_ID }); 
        }
       
    }
}
