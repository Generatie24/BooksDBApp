using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Data.SqlClient;


namespace ClassLibraryBooks.Models
{
    public class BookRepo
    {
        public int AddBookReturnId(Book book)
        {
            string sql = "INSERT INTO Book(Title, Author,Price,Describe,CountryId)" +
                "VALUES(@Title, @Author, @Price, @Desribe, @CountryId)" +
                "Select Cast(SCOPE_IDENTITY() as int)";

            using (IDbConnection connection = new SqlConnection)
            {

            }
        }
    }
}
