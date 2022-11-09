using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Film 
    {
        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public int Rating { get; set; }

        public Film(string iD, string title, string year, int rating)
        {
            ID = iD;
            Title = title;
            Year = year;
            Rating = rating;
        }
    }
}
