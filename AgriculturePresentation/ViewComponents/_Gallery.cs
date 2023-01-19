using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _Gallery : ViewComponent
    {

        private readonly IImageService _imageService;

        public _Gallery(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IViewComponentResult Invoke()
        {
            var gallery = _imageService.GetListAll();
            return View(gallery);
        }
    }
}
