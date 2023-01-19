using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardChart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
