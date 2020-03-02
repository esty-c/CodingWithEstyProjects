using System;

namespace SwaggerTest.api.Models
{
    public class Movie
    {
        public string MovieID { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string MovieType { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}