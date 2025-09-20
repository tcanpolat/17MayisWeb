using _17_AdoNetExample.Models;
using Microsoft.Data.SqlClient;

namespace _17_AdoNetExample.DbServices.Abstract
{
    public interface IDbService
    {
        void ExecuteNonQuery(string query);
        void ExecuteNonQuery(string query, SqlParameter[] parameters);
        List<Student> ExecuteReader(string query);
        object ExecuteScalar(string query);
    }
}
