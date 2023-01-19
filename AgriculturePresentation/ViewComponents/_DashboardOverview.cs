using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverview : ViewComponent
    {
        AgricultureContext db = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            DateTime dt = DateTime.Now;
            ViewBag.totalMember = db.Teams.Count();
            ViewBag.totalService = db.Services.Count();
            ViewBag.totalMessage = db.Contacts.Count();
            ViewBag.currentMonthMessage = db.Contacts.Where(x => x.Date.Month == dt.Month).Count();

            ViewBag.activeAnnouncenement = db.Announcements.Where(x => x.Status == true).Count();
            ViewBag.disableAnnouncenement = db.Announcements.Where(x => x.Status == false).Count();
            ViewBag.sutUrunYoneticisi = db.Teams.Where(x => x.Title == "Süt Ürünleri Yöneticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.jrDeveloper = db.Teams.Where(x => x.Title == "Junior Software Developer").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.tester = db.Teams.Where(x => x.Title == "Tester").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}
