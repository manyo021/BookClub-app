using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub_app.Models
{
    public class Books
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public Genre Genres { get; set; } = Genre.Classics;

        public User? User { get; set; }
    }
}