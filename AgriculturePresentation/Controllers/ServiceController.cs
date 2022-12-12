using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
        //private readonly IServiceService _serviceService;
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        //public TestController(IServiceService serviceService)
        //{
        //    _serviceService = serviceService;
        //}

        public IActionResult Index()
        {
            var services = serviceManager.GetListAll();
            return View(services);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View(new ServiceAddViewModel());
        }

        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                serviceManager.Insert(new Service()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteService(int id)
        {
            var ser = serviceManager.GetById(id);
            serviceManager.Delete(ser);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var service = serviceManager.GetById(id);
            return View(service);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            serviceManager.Update(service);
            return RedirectToAction("Index");
        }

        public IActionResult Deneme()
        {
            return View();
        }
    }
}
