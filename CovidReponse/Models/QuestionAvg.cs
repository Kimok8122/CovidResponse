using System;
namespace CovidReponse.Models
{
    public class QuestionAvg
    {
        public QuestionAvg()
        {
        }

        public int question_ID { get; set; }
        public string text { get; set; }
        public double average { get; set; }
        public int review_count { get; set; }

    }
}
