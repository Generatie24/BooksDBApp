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
        public int AddBookReturnId(Book book)  // this method adds new record in database using stored procedure
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

    }
}
