using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgriculturePresentation.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductChart()
        {
            //dbden çek
            List<ProductClass> productClasses = new List<ProductClass>();
            productClasses.Add(new ProductClass
            {
                name ="Buğday",
                value = 850
            });
            productClasses.Add(new ProductClass
            {
                name = "Mercimek",
                value = 480
            });
            productClasses.Add(new ProductClass
            {
                name = "Arpa",
                value = 250
            });
            productClasses.Add(new ProductClass
            {
                name = "Pirinç",
                value = 120
            });
            productClasses.Add(new ProductClass
            {
                name = "Domates",
                value = 960
            });
            return Json(new { jsonlist = productClasses });
        }
    }
}
