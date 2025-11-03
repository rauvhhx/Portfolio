using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class Member
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public List<Book> BorrowedBooks { get; }

        public Member(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count >= 3)
            {
                Console.WriteLine("Maksimum 3 kitab götürə bilərsiniz!");
                return;
            }

            BorrowedBooks.Add(book);
            Console.WriteLine($"Kitab götürüldü: {book.Title}");
        }

        public void ReturnBook(int bookId)
        {
            Book toRemove = null;
            foreach (var b in BorrowedBooks)
            {
                if (b.Id == bookId)
                {
                    toRemove = b;
                    break;
                }
            }

            if (toRemove != null)
            {
                BorrowedBooks.Remove(toRemove);
                Console.WriteLine($"Kitab qaytarıldı: {toRemove.Title}");
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
                return;
            }

            foreach (var b in BorrowedBooks)
            {
                b.DisplayInfo();
            }
        }
    }
}
