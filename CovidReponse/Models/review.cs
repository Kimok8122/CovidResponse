using System;
namespace CovidReponse.Models
{
    public class Review
    {
        public Review()
        {
        }

        public int review_ID { get; set; }
        public int user_ID { get; set; }
        public int place_ID { get; set; }
        public DateTime entered_date { get; set; }


        public string message { get; set; }
    }
}
