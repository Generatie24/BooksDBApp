using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LibraryNetFramework.Generics;

namespace LibraryNetFramework.Model
{
    public class BookRepo
    {
        private GenericRepo repo = new GenericRepo();
        public void AddBookReturnId(Book book) 
        {
            #region Without Generic repo
            //string sql = "INSERT INTO Book(Title, Author, Price, Describe, CountryId) " +
            //                   "values(@Title, @Author, @Price, @Describe, @CountryId); " +
            //                   "SELECT CAST(SCOPE_IDENTITY() as int)";

            //using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            //{
            //    var returnId = connection.Query<int>(sql, book).SingleOrDefault();
            //    //book.Id = returnId;
            //    return returnId;
            //}
            #endregion

            string sql = "INSERT INTO Book(Title, Author, Price, Describe, CountryId) " +
                               "values(@Title, @Author, @Price, @Describe, @CountryId)";
            repo.SaveData(sql, new { book.Title, book.Author, book.Price, book.Describe, book.CountryId });


        }

        public List<Book> GetAllBooks()
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                #region Without Generic repo
                //var sql = "select * from Book";
                //return connection.Query<Book>(sql).ToList();
                #endregion

                #region With Generic Repo
                var sql = "select * from Book";
                return repo.LoadData<Book, dynamic>(sql, new { });
                #endregion


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
