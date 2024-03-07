using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using LibraryNetFramework.Model;


namespace LibraryNetFramework.Generics
{
    public class GenericRepo
    {
        public List<T> LoadData<T, U>(string slqstatement, U paramaetrs)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                List<T> result = connection.Query<T>(slqstatement, paramaetrs).ToList();
                return result;
            }
        }
        public void SaveData<T>(string slqstatement, T paramaetrs)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConStr("Books")))
            {
                connection.Execute(slqstatement,paramaetrs);
            }
        }

    }
}
