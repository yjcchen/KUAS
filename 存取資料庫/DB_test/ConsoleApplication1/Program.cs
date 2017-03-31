using JUIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var import = new JUIN.Service.ImportService();

            var db = new JUIN.Repository.DataRepository();

            //新增資料至資料庫
            //var stations = import.FindStations(@"E:\water.xml");

            //stations.ToList().ForEach(x =>
            //{
            //    db.Creat(x);
            //});

            //讀取資料表資料
            var stations = db.FindAllStations();

            showData(stations);

            Console.ReadKey();
        }

        public static void showData(List<Station> stations)
        {

            Console.WriteLine(string.Format("共收到{0}筆資料", stations.Count));

            stations.ForEach(x =>
            {
                Console.WriteLine(string.Format("ID{0},時間{1},高度{2}", x.StationIdentifier, x.RecordTime, x.WaterLevel));
            });
        }

        
    }
}
