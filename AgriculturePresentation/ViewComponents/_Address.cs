using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _Address : ViewComponent
    {
        private readonly IAddressService _addressService;

        public _Address(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var addreses = _addressService.GetListAll();
            return View(addreses);
        }
    }
}
