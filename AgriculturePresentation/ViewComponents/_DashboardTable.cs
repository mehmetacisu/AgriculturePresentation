using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardTable : ViewComponent
    {
        private readonly IContactService _contactService;

        public _DashboardTable(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var contacts = _contactService.GetListAll();
            return View(contacts);
        }
    }
}
