using System;
namespace CovidReponse.Models
{
    public class PlaceReviewed
    {
        public PlaceReviewed()
        {
        }

        public int place_ID { get; set; }
        public int user_ID { get; set; }
        public string company { get; set; }
    }
}
