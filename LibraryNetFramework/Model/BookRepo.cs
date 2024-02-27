using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LibraryNetFramework.Model
{
    public class BookRepo
    {
        public int AddBookReturnId(Book book) 
        {

            string sql = "INSERT INTO Book(Title, Author, Price, Describe, CountryId) " +
                               "values(@Title, @Author, @Price, @Describe, @CountryId); " +
                               "SELECT CAST(SCOPE_IDENTITY() as int)";

            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                var returnId = connection.Query<int>(sql, book).SingleOrDefault();
                //book.Id = returnId;
                return returnId;
            }
        }

        public List<Book> GetAllBooks()
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                var sql = "Select * from Book";
                return connection.Query<Book>(sql).ToList();
            }
        }

        public void DeleteBookById(int id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                connection.Execute("Delete from book where Id=@id", new { Id = id });

            }
        }

        public void UpdateBook(Book book)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                connection.Execute("UPDATE book SET Title = @Title, Author = @Author," +
                    "Price = @Price, Describe = @Describe, CountryId = @CountryId WHERE Id=@Id",
                    new
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Price = book.Price, 
                        Describe = book.Describe,
                        CountryId = book.CountryId,
                        Id=book.Id
                    });
            }
        }

    }
}
