using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var admins = _adminService.GetListAll();
            return View(admins);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Admin admin)
        {

            _adminService.Insert(admin);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var admin = _adminService.GetById(id);
            _adminService.Delete(admin);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var admin = _adminService.GetById(id);
            return View(admin);
        }

        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            _adminService.Update(admin);
            return RedirectToAction("Index");
        }
    }
}
