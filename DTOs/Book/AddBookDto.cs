using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub_app.DTOs.Book
{
    public class AddBookDto
    {


        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public Genre Genres { get; set; } = Genre.Classics;
    }
}