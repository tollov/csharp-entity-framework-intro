﻿using exercise.webapi.Models.BaseModels;

namespace exercise.webapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate",
            "Corky",
            "Ted",
            "Mark",
            "Teddy",
            "Mimmi",
            "Max",
            "Chuck",
            "Chad",
            "Alexander"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton",
            "Corky",
            "Zuckerberg",
            "Norris",
            "Kroeger",
            "Smith",
            "Oldenburg",
            "Wilson",
            "Bush",
        };
        private List<string> _domain = new List<string>()
        {
            "bbc.co.uk",
            "google.com",
            "theworld.ca",
            "something.com",
            "tesla.com",
            "nasa.org.us",
            "gov.us",
            "gov.gr",
            "gov.nl",
            "gov.ru"
        };
        private List<string> _firstword = new List<string>()
        {
            "The",
            "Two",
            "Several",
            "Fifteen",
            "A Bunch of",
            "An Army of",
            "A herd of",
            "My Story:",
            "The Hidden Downsides of",
            "Casually explained:",
            "The Potential of",
            "A Tale of",
            "We Need to Talk About",
            "Keys to",
            "Man's Search for",
            "The Secret of",
            "Untold Stories of",
            "The Story of",
            "The Chronicles of",
            "Story of My Life:"
        };
        private List<string> _secondword = new List<string>()
        {
            "Orange",
            "Purple",
            "Large",
            "Microscopic",
            "Green",
            "Transparent",
            "Rose Smelling",
            "Bitter",
            "Ancient",
            "Future",
            "Magnificent",
            "Urban",
            "Cyclical",
            "Award-Winning",
            "Mediocre",
            "Underrated",
            "Ancient Alien"
        };
        private List<string> _thirdword = new List<string>()
        {
            "Buildings",
            "Cars",
            "Planets",
            "Houses",
            "Flowers",
            "Leopards",
            "Hamsters",
            "Food Trucks",
            "Street Food",
            "Food",
            "Smartphones",
            "Cesspools",
            "Table Cloths",
            "Science Teachers",
            "Vegan Food Recipes",
            "Fake News Stories",
            "Influencers",
            "Craft Beers",
            "Pancakes",
            "Hollywood Actors",
            "Storage Units",
            "Shopping Malls",
            "Politicians",
            "Coffee Cups",
            "Cats",
            "Dogs",
            "Neanderthals",
            "Baristas",
            "UFOs"
        };

        private List<string> _publisherSuffixes = new List<string>()
        {
            "International",
            "Journals",
            "Media",
            "Publications",
            "Imprints",
            "Books",
            "Press",
            "Publishing",
            "Ltd.",
            "Editions",
            "Co.",
            "Reads"
        };

        private List<Author> _authors = new List<Author>();
        private List<Book> _books = new List<Book>();
        private List<Publisher> _publishers = new List<Publisher>();

        public Seeder()
        {

            Random authorRandom = new Random();
            Random bookRandom = new Random();
            Random publisherRandom = new Random();

            for (int z = 1; z < 10; z++)
            {
                Publisher publisher = new Publisher();
                publisher.ID = z;
                publisher.Name = $"{_lastnames[publisherRandom.Next(_lastnames.Count)]} {_publisherSuffixes[publisherRandom.Next(_publisherSuffixes.Count)]}";
                _publishers.Add(publisher);
            }

            for (int x = 1; x < 100; x++)
            {
                Author author = new Author();
                author.ID = x;
                author.FirstName = _firstnames[authorRandom.Next(_firstnames.Count)];
                author.LastName = _lastnames[authorRandom.Next(_lastnames.Count)];
                author.Email = $"{author.FirstName}.{author.LastName}@{_domain[authorRandom.Next(_domain.Count)]}".ToLower();
                _authors.Add(author);
            }

            for (int y = 1; y < 300; y++)
            {
                Book book = new Book();
                book.ID = y;
                book.Title = $"{_firstword[bookRandom.Next(_firstword.Count)]} {_secondword[bookRandom.Next(_secondword.Count)]} {_thirdword[bookRandom.Next(_thirdword.Count)]}";
                book.AuthorID = _authors[authorRandom.Next(_authors.Count)].ID;
                book.PublisherID = _publishers[publisherRandom.Next(_publishers.Count)].ID;
                //book.Author = authors[book.AuthorId-1];
                _books.Add(book);
            }
        }

        public List<Author> Authors { get { return _authors; } }
        public List<Book> Books { get { return _books; } }
        public List<Publisher> Publishers { get { return _publishers; } }
    }
}
