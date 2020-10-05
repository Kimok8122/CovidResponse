using System;
namespace CovidReponse.Models
{
    public class answer
    {
        public answer()
        {
        }

        public int answer_ID { get; set; }
        public int review_ID { get; set; }
        public int questioin_ID { get; set; }
        public int point_value { get; set; }

    }
}
