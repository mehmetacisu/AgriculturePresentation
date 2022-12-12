using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _TopAddress : ViewComponent
    {
        private readonly IAddressService _addressService;

        public _TopAddress(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var addresses = _addressService.GetListAll();
            return View(addresses);
        }
    }
}
