using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _Service : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _Service(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var services = _serviceService.GetListAll();
            return View(services);
        }
    }
}
