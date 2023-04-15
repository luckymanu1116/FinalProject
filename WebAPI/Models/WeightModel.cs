using System;
namespace WebUI.Models
{
	public class WeightModel
	{
        private string Username { get; set; }

        private string UserId { get; set; }

        private string Weight { get; set; }

        private String Date { get; set; }

        public WeightModel(string username, string userId, string weight, string date)
        {
            Username = username;
            UserId = userId;
            Weight = weight;
            Date = date;
        }
    }
}

