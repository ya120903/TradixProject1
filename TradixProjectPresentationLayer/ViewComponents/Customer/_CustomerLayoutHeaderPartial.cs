using Microsoft.AspNetCore.Mvc;

namespace TradixProjectPresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial:ViewComponent

    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
