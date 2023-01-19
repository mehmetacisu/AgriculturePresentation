using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgriculturePresentation.ViewComponents
{
    public class _Map : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            AgricultureContext db = new AgricultureContext();
            var maps = db.Addresses.Select(x => x.MapInfo).FirstOrDefault();
            ViewBag.Maps = maps;
            return View();
        }
    }
}
