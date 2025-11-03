using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            
            var book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            var book2 = new Book(2, "1984", "George Orwell", 1949, 328);
            var book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            var book4 = new Book(4, "Ağ Gəmi", "Cingiz Aytmatov", 1970, 200);
            var book5 = new Book(5, "Qırıq Budaq", "Elçin", 1998, 350);

            Console.WriteLine("--- Kitablar ---");
            foreach (var b in new[] { book1, book2, book3, book4, book5 })
                b.DisplayInfo();

            
            var lib = new Library<Book>("Milli Kitabxana");
            lib.Add(book1); lib.Add(book2); lib.Add(book3); lib.Add(book4); lib.Add(book5);

            Console.WriteLine($"Kitab sayı: {lib.Count()}");
            lib.FindByIndex(0)?.DisplayInfo();
            lib.FindByIndex(2)?.DisplayInfo();

            Console.WriteLine("Bütün kitablar:");
            foreach (var b in lib.GetAll())
                b.DisplayInfo();

          
            var members = new List<Member>
            {
                new Member(1, "Ali Məmmədov", "ali@mail.com"),
                new Member(2, "Leyla Həsənova", "leyla@mail.com"),
                new Member(3, "Vüqar Əliyev", "vuqar@mail.com")
            };

            var m1 = members[0];
            m1.BorrowBook(book1);
            m1.BorrowBook(book2);
            m1.DisplayBorrowedBooks();
            m1.ReturnBook(1);
            m1.DisplayBorrowedBooks();
            m1.BorrowBook(book3);
            m1.BorrowBook(book4);
            m1.BorrowBook(book5);
            m1.BorrowBook(book2); 

            
            var manager = new BookManager();
            manager.AddBook(book1);
            manager.AddBook(book2);
            manager.AddBook(book3);
            manager.AddBook(book4);
            manager.AddBook(book5);

            Console.WriteLine("\\nGeorge Orwell kitabları:");
            foreach (var b in manager.GetBooksByAuthor("George Orwell")) b.DisplayInfo();

            Console.WriteLine("\\nCingiz Aytmatov kitabları:");
            foreach (var b in manager.GetBooksByAuthor("Cingiz Aytmatov")) b.DisplayInfo();

            Console.WriteLine("\\nJack London kitabları:");
            foreach (var b in manager.GetBooksByAuthor("Jack London")) b.DisplayInfo();

            Console.WriteLine("\\nDostoyevski kitabları:");
            Console.WriteLine($"Tapılan kitablar: {manager.GetBooksByAuthor("Dostoyevski").Count}");

           
            manager.AddToWaitingQueue("Nigar");
            manager.AddToWaitingQueue("Rəşad");
            manager.AddToWaitingQueue("Səbinə");
            Console.WriteLine($"Növbədə: {manager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmət edilir: {manager.ServeNextInQueue()}");
            Console.WriteLine($"Qalan: {manager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmət edilir: {manager.ServeNextInQueue()}");
            Console.WriteLine($"Qalan: {manager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmət edilir: {manager.ServeNextInQueue()}");
            Console.WriteLine($"Qalan: {manager.WaitingQueue.Count}");

          
            manager.ReturnBook(book1);
            manager.ReturnBook(book2);
            manager.ReturnBook(book3);
            Console.WriteLine($"Stack-də kitab sayı: {manager.RecentlyReturned.Count}");
            Console.WriteLine($"Son qaytarılan: {manager.GetLastReturnedBook()?.Title}");
            manager.RecentlyReturned.Pop();
            Console.WriteLine($"Stack-də kitab sayı: {manager.RecentlyReturned.Count}");
            Console.WriteLine($"Yeni son kitab: {manager.GetLastReturnedBook()?.Title}");

            
            var found = manager.SearchByTitle("1984");
            Console.WriteLine(found != null ? $"Tapıldı: {found.Title}" : "Tapılmadı");

            var notFound = manager.SearchByTitle("Harry Potter");
            Console.WriteLine(notFound == null ? "Tapılmadı: Harry Potter" : notFound.Title);

            
            int minYear = int.MaxValue, maxYear = int.MinValue;
            foreach (var b in manager.Books)
            {
                if (b.Year < minYear) minYear = b.Year;
                if (b.Year > maxYear) maxYear = b.Year;
            }

            Console.WriteLine("\\n--- Statistika ---");
            Console.WriteLine($"Ümumi kitab sayı: {manager.Books.Count}");
            Console.WriteLine($"Ümumi üzv sayı: {members.Count}");
            Console.WriteLine($"Növbədə nəfər sayı: {manager.WaitingQueue.Count}");
            Console.WriteLine($"Stack-də kitab sayı: {manager.RecentlyReturned.Count}");
            Console.WriteLine($"Ən köhnə kitab ili: {minYear}");
            Console.WriteLine($"Ən yeni kitab ili: {maxYear}");
        }
    }
}
