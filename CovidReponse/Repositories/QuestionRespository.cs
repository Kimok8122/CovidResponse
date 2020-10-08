using System;
using System.Collections.Generic;
using System.Data;
using CovidReponse.Models;
using Dapper;

namespace CovidReponse.Repositories
{
    public class QuestionRespository : IQuestionRepository
    {
        private readonly IDbConnection _conn;

        public QuestionRespository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Question> FindQuestionsByPlaceType(string place_type)

        {
            return _conn.Query<Question>("SELECT * FROM QUESTION WHERE place_type = @q", new { q = place_type });

        }

    }

        
}
