using Lesson5;
using Microsoft.EntityFrameworkCore;

InsertPage();
//SelectAndDeletePage();
//SelectAndUpdatePage();
//InserBookWithPages();
//SelectBookWithPages();
//SelectPageWithBook();

void InsertPage()
{
    using var dbContext = new BookContext();
    var page = new Page(1, "1 skyrius");
    dbContext.Pages.Add(page);
    dbContext.SaveChanges();
}

void SelectAndDeletePage()
{
    using var dbContext = new BookContext();
    var pageFromDb = dbContext.Pages.FirstOrDefault(p => p.Number == 1);
    dbContext.Pages.Remove(pageFromDb);
    dbContext.SaveChanges();
}

void SelectAndUpdatePage()
{
    using var dbContext = new BookContext();
    var pageFromDb = dbContext.Pages.FirstOrDefault(p => p.Number == 1);
    pageFromDb.Content += ". Another update";
    dbContext.SaveChanges();
}

void InserBookWithPages()
{
    using var dbContext = new BookContext();
    var book = new Book("Harry Potter");
    for (int i = 1; i < 500; i++)
    {
        book.Pages.Add(new Page(i, $"content: {i}"));
    }
    dbContext.Books.Add(book);
    dbContext.SaveChanges();
}

void SelectBookWithPages()
{
    using var dbContext = new BookContext();
    var bookFromDb = dbContext.Books.Include(b => b.Pages).FirstOrDefault(b => b.Name == "Harry Potter");
    Console.WriteLine(bookFromDb.Name);
}

void SelectPageWithBook()
{
    using var dbContext = new BookContext();
    var pageFromBook = dbContext.Pages.Include(p => p.Book).FirstOrDefault(p => p.Number == 12);
    Console.WriteLine(pageFromBook.Book.Name);
}

void DeleteBookWithAllPages()
{
    using var dbContext = new BookContext();
    var bookFromDb = dbContext.Books.FirstOrDefault(b => b.Name == "Harry Potter");
    dbContext.Books.Remove(bookFromDb);
    dbContext.SaveChanges();
}
