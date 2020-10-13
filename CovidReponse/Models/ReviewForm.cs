using System;
using System.Collections.Generic;

namespace CovidReponse.Models
{
    public class ReviewForm
    {
        public ReviewForm(){}

        public int user_ID { get; set; }
        public int place_ID { get; set; }
        public int[] question_ID { get; set; }
        public int[] point_value { get; set; }
    }
}