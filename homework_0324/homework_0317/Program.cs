using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace homework_0317
{
    class Program
    {
        static void Main(string[] args)
        {
            //Station station = new Station();
            var station = FindStations();

            showData(station);

            Console.ReadLine();
            
        }

        public static List<Station> FindStations()
        {

            List<Station> station = new List<Station>();

            var xml = XElement.Load(@"E:\water.xml");

            XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";

            var StationNode = xml.Descendants(twed + "RealtimeWaterLevel");

            StationNode.ToList().ForEach(stationNode =>
            {
                var StationIdentifier = stationNode.Element(twed + "StationIdentifier").Value.Trim();
                var RecordTime = stationNode.Element(twed + "RecordTime").Value.Trim();
                var WaterLevel = stationNode.Element(twed + "WaterLevel").Value.Trim();

                Station stationData = new Station();
                stationData.StationIdentifier = StationIdentifier;
                stationData.RecordTime = RecordTime;
                stationData.WaterLevel = WaterLevel;

                station.Add(stationData);

                //Console.Write(stationData.StationIdentifier);
                //Console.Write(stationData.RecordTime);
                //Console.Write(stationData.WaterLevel);
            });

            //Console.ReadLine();
            return station;
        }

        public static void showData( List<Station> stations) {

            Console.WriteLine(string.Format("共收到{0}筆資料", stations.Count));

            stations.ForEach(x => 
            {
                Console.WriteLine(string.Format("id{0},時間{1},高度{2}", x.StationIdentifier,x.RecordTime,x.WaterLevel));
            });
        }
    }
}
