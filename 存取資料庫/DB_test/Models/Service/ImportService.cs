using JUIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JUIN.Service
{
    public class ImportService
    {
        public  List<Station> FindStations(string XmlPath)
        {

            List<Station> station = new List<Station>();

            var xml = XElement.Load(XmlPath);

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
    }
}
