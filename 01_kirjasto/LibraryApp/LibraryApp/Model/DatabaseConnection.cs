using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Model
{
    public class DatabaseConnection
    {
        public readonly string _connectionString;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }


        public string IsDbConnectionEstablished()
        {
            var connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                return "Connection established!";
            }
            catch (SqlException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
