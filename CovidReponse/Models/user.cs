using System;
namespace CovidReponse.Models
{
    public class user
    {
        public user()
        {
        }

        public int user_ID { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public DateTime creae_date { get; set; }
    }
}
