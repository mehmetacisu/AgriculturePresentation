using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _SocialMedia : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public _SocialMedia(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var socialMedias = _socialMediaService.GetListAll();
            return View(socialMedias);
        }
    }
}
