using System;
using System.Collections.Generic;
using System.Data;
using CovidReponse.Models;
using Dapper;

namespace CovidReponse.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbConnection _conn;

        public ReviewRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return (IEnumerable<Review>)_conn.Query<Review>("SELECT * FROM REVIEW;");
        }

        public Review FindByUserAndPlace(int UserId, int PlaceId)
        {
            var x = new { user_ID = UserId, place_ID = PlaceId };
            return _conn.QuerySingleOrDefault<Review>("SELECT * FROM REVIEW WHERE user_ID = @user_ID AND place_ID = @place_ID;", x);

        }  

        public void Save(Review r)
        {
            var sql = "INSERT into REVIEW (user_id, place_id)"
                + "VALUES (@user_id, @place_id)";
            _conn.Execute(sql, new { user_id = r.user_ID, place_id= r.place_ID});
        }

        public void AnswerSave(Answer a)
        {
            var sql = "INSERT into ANSWER (review_ID, question_ID, point_value)"
                + "VALUES (@review_ID, @question_ID, @point_value)";
            _conn.Execute(sql, new { review_ID = a.review_ID, question_ID = a.questioin_ID, point_value = a.point_value });
        }
    }
}
