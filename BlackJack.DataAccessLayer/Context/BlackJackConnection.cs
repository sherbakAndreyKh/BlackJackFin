using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DataAccessLayer.Context
{
    public class BlackJackConnection
    {
        private string _connectionString;

        public BlackJackConnection(string connectionString)
        {
            _connectionString = GetConnectionStringByName(connectionString);
        }

        private string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }
            return returnValue;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);

            return connection;
        }

    }
}
