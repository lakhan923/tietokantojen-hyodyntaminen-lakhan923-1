using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace LibraryApp.Model
{
    public class DatabaseRepository
    {
        public readonly DatabaseConnection _dbConnection;
        private readonly LibraryContext _context;

        public DatabaseRepository()
        {
            _dbConnection = new DatabaseConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True");
            _context = new LibraryContext();
        }

        public string IsDbConnectionEstablished()
        {
            return _dbConnection.IsDbConnectionEstablished();
        }

        // Fetch all books published in the last 5 years
        public void GetBooksPublishedInLastFiveYears()
        {
            // Fetch books using LINQ and Entity Framework
            var books = _context.Books
                .Where(b => b.PublicationYear >= DateTime.Now.Year - 5)
                .ToList();

            Console.WriteLine("\nBooks published in the last five years:");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Year: {book.PublicationYear}, Available Copies: {book.AvailableCopies}");
            }
        }

        public void CalculateAverageAgeOfLibraryCustomers()
        {
            var age = _context.Members
                .Where(m => m.DateOfBirth != null).ToList();
            if (age.Count != 0)
            {
                var averageAge = age.Average(m => (DateTime.Now.Year - m.DateOfBirth.Year));
                Console.WriteLine($"\nAverage Age of Library Customers: {averageAge}");
            }
            else
            {
                Console.WriteLine("No valid DateOfBirth records found to calculate the average age.");
            }
        }

        public void GetMostAvailableBookInLibrary()
        {
            var mostAvailableBook = _context.Books
                .OrderByDescending(b => b.AvailableCopies)
                .FirstOrDefault();

            if (mostAvailableBook != null)
            {
                Console.WriteLine($"\nMost Available Book: {mostAvailableBook.Title} with {mostAvailableBook.AvailableCopies} copies.");
            }
        }

        public void GetMembersWhoBorrowedBooks()
        {
            var borrowedBooks = (from loan in _context.Loans
                                 join book in _context.Books on loan.BookId equals book.BookId
                                 join member in _context.Members on loan.MemberId equals member.MemberId
                                 select new
                                 {
                                     MemberName = $"{member.FirstName} {member.LastName}",
                                     ISBN = book.ISBN
                                 }).ToList();

            Console.WriteLine("\nMembers who borrowed books:");
            foreach (var borrowed in borrowedBooks)
            {
                Console.WriteLine($"Member: {borrowed.MemberName}, ISBN: {borrowed.ISBN}");
            }
        }

        public void GetMostCitedBooks()
        {
            var topCitedBooks = (from loan in _context.Loans
                                 join book in _context.Books on loan.BookId equals book.BookId
                                 group book by book.BookId into bookGroup
                                 orderby bookGroup.Count() descending
                                 select new
                                 {
                                     Book = bookGroup.FirstOrDefault(),
                                     CitationCount = bookGroup.Count()
                                 })
                                 .Take(3)
                                 .ToList();

            Console.WriteLine("\nTop 3 Most Cited Books:");
            foreach (var book in topCitedBooks)
            {
                Console.WriteLine($"Title: {book.Book.Title}, ISBN: {book.Book.ISBN}, Citation Count: {book.CitationCount}");
            }
        }

        public void GetBooksPublishedInLastTenYears()
        {
            var books = _context.Books
                .Where(b => b.PublicationYear >= DateTime.Now.Year - 10)
                .ToList();

            Console.WriteLine("\nBooks published in the last ten years:");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, ISBN: {book.ISBN}, Year: {book.PublicationYear}, Available Copies: {book.AvailableCopies}");
            }
        }

        public void GetOldestMember()
        {
            var oldestMember = _context.Members
                .Where(m => m.DateOfBirth != null)
                .OrderByDescending(m => (DateTime.Now.Year - m.DateOfBirth.Year))
                .FirstOrDefault();

            Console.WriteLine("\nHighest age of library customers:");
            if (oldestMember != null)
            {
                var age = DateTime.Now.Year - oldestMember.DateOfBirth.Year;
                Console.WriteLine($"Oldest Member: {oldestMember.FirstName} {oldestMember.LastName}, Age: {age}");
            }
        }

        public void GetLeastAvailableBook()
        {
            var leastAvailableBook = _context.Books
                .OrderBy(b => b.AvailableCopies)
                .FirstOrDefault();

            Console.WriteLine("\nLeast Available Book:");
            if (leastAvailableBook != null)
            {
                Console.WriteLine($"Least Available Book: {leastAvailableBook.Title} with {leastAvailableBook.AvailableCopies} copies.");
            }
        }

        public void GetMembersWhoDidNotBorrowBooks()
        {
            var membersWithNoLoans = _context.Members
                .Where(m => !_context.Loans.Any(l => l.MemberId == m.MemberId))
                .ToList();

            Console.WriteLine("\nMembers who did not borrow any books:");
            foreach (var member in membersWithNoLoans)
            {
                Console.WriteLine($"Member: {member.FirstName} {member.LastName}");
            }
        }

        public void GetPublicationYearOfMostCitedBooks()
        {
            var mostCitedBooks = _context.Loans
                .Join(_context.Books, loan => loan.BookId, book => book.BookId, (loan, book) => book)
                .GroupBy(book => book.BookId)
                .OrderByDescending(bookGroup => bookGroup.Count())
                .Take(3)
                .Select(bookGroup => new
                {
                    Book = bookGroup.FirstOrDefault(),
                    CitationCount = bookGroup.Count()
                })
                .ToList();

            Console.WriteLine("\nPublication Year of Top 3 Most Cited Books:");
            foreach (var book in mostCitedBooks)
            {
                Console.WriteLine($"Publication Year: {book.Book.PublicationYear}, Title: {book.Book.Title}");
            }
        }

    }
}
