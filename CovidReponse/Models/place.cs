using System;
namespace CovidReponse.Models
{
    public class place
    {
        public place()
        {
        }

        public int place_ID { get; set; }
        public string place_type { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public string logo_ID { get; set; }
        public DateTime entered_date { get; set; }

    }

}
