using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUIN.Repository
{
    public class DataRepository
    {
        public const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\me\存取資料庫\DB_test\ConsoleApplication1\App_Data\water.mdf;Integrated Security=True";



        public void Creat(Models.Station station)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT INTO Table(StationIdentifier, RecordTime, WaterLevel)
VALUES           (N'{0}',N'{1}',N'{2}')" ,station.StationIdentifier, station.StationIdentifier, station.RecordTime);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
