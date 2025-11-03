using System;

namespace LibrarySystem
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public int PageCount { get; }

        public Book(int id, string title, string author, int year, int pageCount)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            PageCount = pageCount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[{Id}] {Title} - {Author} ({Year}) - {PageCount} səhifə");
        }
    }
}
