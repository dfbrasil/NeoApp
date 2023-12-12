using Dapper;
using Microsoft.Data.SqlClient;
using NeoApp.API.Models;
using System.Collections.Generic;
using System.Data;

namespace NeoApp.API.Repositories
{
    public class ConsultaDapperRepository
    {
        private readonly string _connectionString;

        public ConsultaDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Consulta> ObterConsultas()
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            // Utilize o Dapper para realizar a consulta
            string query = "SELECT * FROM Consulta";

            var consultas = dbConnection.Query<Consulta>(query, commandType: CommandType.Text);

            return consultas;
        }
    }
}
