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
        public ActionResult Index()
        {
            var statioinRepository = new JUIN.Repository.DataRepository();

            var stations = statioinRepository.FindAllStations();

            var message = string.Format("共收到{0}筆資料</br>", stations.Count);

            stations.ForEach(x => {
                message += string.Format("ID: {0}, 時間: {1}, 高度: {2}</br>", x.StationIdentifier, x.RecordTime, x.WaterLevel);
            });

            return Content(message);
        }
    }
}