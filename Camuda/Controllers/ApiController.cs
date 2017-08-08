using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camuda.Models;
using Newtonsoft.Json;
namespace Camuda.Controllers
{
    public class ApiController : Controller
    {
        class item
        {
            public long id { get; set; }
            public string dev { get; set; }
            public string dri { get; set; }
            public string tim { get; set; }
            public string dat { get; set; }
            public Nullable<double> lat { get; set; }
            public Nullable<double> lon { get; set; }
            public string wng { get; set; }
            public Nullable<double> anl { get; set; }
            public Nullable<double> pul { get; set; }
            public string opt { get; set; }
            public string dig { get; set; }
            public Nullable<double> vgp { get; set; }
            public Nullable<double> dir { get; set; }
            public Nullable<double> vsr { get; set; }
            public Nullable<double> mil { get; set; }
            public Nullable<int> old { get; set; }
            public Nullable<int> sat { get; set; }
            public Nullable<double> hwv { get; set; }
            public Nullable<double> fwv { get; set; }
            public Nullable<double> clt { get; set; }
            public Nullable<double> clg { get; set; }
            public Nullable<int> sig { get; set; }
            public Nullable<double> hdo { get; set; }
            public Nullable<int> bat { get; set; }
            public Nullable<double> epw { get; set; }
            public string drt { get; set; }
            public string cdt { get; set; }
        }
        private carmudaEntities db = new carmudaEntities();
        // GET: Api
        public ActionResult Index(string data)
        {
            
            return View();
        }
        public string get(string data)
        {
            try
            {
                var i = JsonConvert.DeserializeObject<item>(data);
                log lg = new log();
                lg.anl = i.anl;
                lg.bat = i.bat;
                lg.cdt = i.cdt;
                lg.clg = i.clg;
                lg.clt = i.clt;
                lg.dat = i.dat;
                lg.dev = i.dev;
                lg.dig = i.dig;
                lg.dir = i.dir;
                lg.dri = i.dri;
                lg.drt = i.drt;
                lg.epw = i.epw;
                lg.fwv = i.fwv;
                lg.hdo = i.hdo;
                lg.hwv = i.hwv;
                lg.lat = i.lat;
                lg.lon = i.lon;
                lg.mil = i.mil;
                lg.old = i.old;
                lg.opt = i.opt;
                lg.pul = i.pul;
                lg.sat = i.sat;
                lg.sig = i.sig;
                lg.tim = i.tim;
                lg.vgp = i.vgp;
                lg.vsr = i.vsr;
                lg.wng = i.wng;
                lg.date_id = Config.datetimeid();
                lg.date_time = DateTime.Now;
                db.logs.Add(lg);
                db.SaveChangesAsync();
                return "1";
            }
            catch(Exception ex)
            {
                return "0";
            }
        }

    }
}