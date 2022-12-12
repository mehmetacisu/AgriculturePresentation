using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var addresses = _addressService.GetListAll();
            return View(addresses);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var member = _addressService.GetById(id);
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Address address)
        {
            AddressValidator validationRules = new AddressValidator();
            ValidationResult validationResult = validationRules.Validate(address);
            if (validationResult.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
