using LibraryApp.Model;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseRepository repository = new DatabaseRepository();
            Console.WriteLine(repository.IsDbConnectionEstablished());

            // Task 1: Get all books published within the last five years
            repository.GetBooksPublishedInLastFiveYears();

            // Task 2: Calculate the average age of library customers
            repository.CalculateAverageAgeOfLibraryCustomers();

            // Task 3: Get the most available book in the library
            repository.GetMostAvailableBookInLibrary();

            // Task 4: Get the members who borrowed at least one book
            repository.GetMembersWhoBorrowedBooks();

            // Task 5 (Bonus): Get all the information of the three most cited books
            repository.GetMostCitedBooks();

            // Task 6: Get all books published within the last ten years
            repository.GetBooksPublishedInLastTenYears();

            // Task 7: Get the highest age of library customers
            repository.GetOldestMember();

            // Task 8: Get the least available book in the library
            repository.GetLeastAvailableBook();

            // Task 9: Get the members who did not borrow any books
            repository.GetMembersWhoDidNotBorrowBooks();

            // Task 10 (Bonus): Get the publication year of the three most quoted books
            repository.GetPublicationYearOfMostCitedBooks();

            Console.ReadLine();


        }
    }
}
