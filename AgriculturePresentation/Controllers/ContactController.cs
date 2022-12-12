using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetListAll();
            return View(contacts);
        }

        public IActionResult Delete(int id)
        {
            var contact = _contactService.GetById(id);
            _contactService.Delete(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var member = _contactService.GetById(id);
            return View(member);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var contact = _contactService.GetById(id);
            return View(contact);
        }

    }
}
