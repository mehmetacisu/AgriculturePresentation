using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : Controller
    {
		private readonly ITeamService _teamService;

		public TeamController(ITeamService teamService)
		{
			_teamService = teamService;
		}

		//TeamManager teamManager = new TeamManager(new EfTeamDal());

        public IActionResult Index()
        {
            var members = _teamService.GetListAll();
            return View(members);
        }

        [HttpGet]
        public IActionResult Add()
		{
            return View();
		}

        [HttpPost]
        public IActionResult Add(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult validationResult = validationRules.Validate(team);
            if (validationResult.IsValid)
            {
                _teamService.Insert(team);
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

        public IActionResult Delete(int id)
        {
            var member = _teamService.GetById(id);
            _teamService.Delete(member);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var member = _teamService.GetById(id);
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult validationResult = validationRules.Validate(team);
            if (validationResult.IsValid)
            {
                _teamService.Update(team);
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
