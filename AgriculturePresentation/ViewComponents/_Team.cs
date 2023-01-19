using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _Team : ViewComponent
    {
        private readonly ITeamService _teamService;

        public _Team(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            var members = _teamService.GetListAll();
            return View(members);  
        }
    }
}
