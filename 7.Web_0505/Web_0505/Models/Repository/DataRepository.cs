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
        public const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\github\own\7.Web_0505\Web_0505\ConsoleApplication1\App_Data\water.mdf;Integrated Security=True";


        //寫入
        public void Creat(Models.Station stations)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT  INTO    Station(StationIdentifier, RecordTime, WaterLevel)
VALUES           (N'{0}',N'{1}',N'{2}')"
, stations.StationIdentifier,  stations.RecordTime, stations.WaterLevel);

            command.ExecuteNonQuery();

            connection.Close();
        }

        //讀取
        public List<Models.Station> FindAllStations()
        {
            var result = new List<Models.Station>();

            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("", connection);

            command.CommandText = @"Select * from Station";

            var reader = command.ExecuteReader();

            while (reader.Read()){

                Models.Station item = new Models.Station();

                item.StationIdentifier = reader["StationIdentifier"].ToString();
                item.RecordTime = reader["RecordTime"].ToString();
                item.WaterLevel = reader["WaterLevel"].ToString();

                result.Add(item);
            }

            return result;

        }
    }
}
