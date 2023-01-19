using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _Announcement : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public _Announcement(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var announcements = _announcementService.GetListAll();
            return View(announcements);
        }
    }
}
