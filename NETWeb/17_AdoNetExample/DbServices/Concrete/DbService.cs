using _17_AdoNetExample.DbServices.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.Data.SqlClient;

namespace _17_AdoNetExample.DbServices.Concrete
{
    public class DbService : IDbService
    {
        private readonly string _connectionString;

        public DbService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // ExecuteNonQuery AdoNet'te Insert,Update,Delete işlemleri için kullanılır. Geriye int değer döndürür.

        public void ExecuteNonQuery(string query)
        {
            // Dispose => Veri sızıntısını önlemek için
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                    
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if(parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
        }
        // ExecuteReader AdoNet'te geriye tablo döndürmek istiyorsak kullanılır. (SELECT * FROM Student)
        public List<Student> ExecuteReader(string query)
        {
            var result = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var model = new Student()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Age =  Convert.ToInt32(reader["Age"]),
                            };

                            result.Add(model); // Tablodan dönen her bir student ı List<student> a ekle.

                        }
                    }
                    
                }

            }

            return result;
        }

        // Eğer sorgunuz geriye tek bir değer dönüyorsa kullanılır. (select count(*) from Student)
        public object ExecuteScalar(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }

            }
        }
    }
}
