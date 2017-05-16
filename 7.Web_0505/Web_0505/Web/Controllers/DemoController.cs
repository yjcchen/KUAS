using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult IndexMessage()
        {
            var statioinRepository = new JUIN.Repository.DataRepository();

            var stations = statioinRepository.FindAllStations();

            var message = string.Format("共收到{0}筆資料</br>", stations.Count);

            stations.ForEach(x => {
                message += string.Format("ID: {0}, 時間: {1}, 高度: {2}</br>", x.StationIdentifier, x.RecordTime, x.WaterLevel);
            });

            return Content(message);
        }

        public ActionResult Index(string userName = "")
        {
            var stationRepository = new JUIN.Repository.DataRepository();

            var stations = stationRepository.FindAllStations();
            //var message = string.Format("共收到{0}筆監測站的資料<br/>", stations.Count);
            //stations.ForEach(x =>
            //{
            //    message += string.Format("站點名稱：{0},地址:{1}<br/>", x.ObservatoryName, x.LocationAddress);


            //});
            ViewBag.UserName = userName;
            ViewBag.Stations = stations;

            return View(stations);
        }
    }
}