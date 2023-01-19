using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardScripts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                return View();
        }

    }
}
