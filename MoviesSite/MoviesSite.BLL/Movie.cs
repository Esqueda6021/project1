using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesSite.BLL
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public DateTime DateReleased { get; set; }
    }
}
