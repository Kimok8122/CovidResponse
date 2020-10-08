using System;
using System.Collections.Generic;
using CovidReponse.Models;

namespace CovidReponse.Repositories
{
    public interface IQuestionRepository
    {
        public IEnumerable<Question> FindQuestionsByPlaceType(string place_type);
    }

}
