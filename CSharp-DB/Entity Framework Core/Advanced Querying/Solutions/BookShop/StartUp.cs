namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string input = Console.ReadLine();
            string result = GetBookTitlesContaining(db, input);

            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {
                    Title = b.Title
                })
                .OrderBy(b => b.Title)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType editionType = EditionType.Gold;

            var books = context.Books
                .Where(b => b.EditionType == editionType && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    BookId = b.BookId,
                    Title = b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            input = input.ToLower();

            List<string> categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var books = context.Books
                .Include(b => b.BookCategories)
                .ThenInclude(bk => bk.Category)
                .OrderBy(b => b.Title)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                foreach (var bk in book.BookCategories)
                {
                    if (categories.Contains(bk.Category.Name.ToLower()))
                    {
                        sb.AppendLine(book.Title);
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            //the title, edition type and price 

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price,
                    ReleseDate = b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleseDate)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .ToArray()
                .Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => new
                {
                    Title = b.Title
                })
                .OrderBy(b => b.Title)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.FirstName.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(b => b.AuthorId)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {

            }
        }
    }
}
