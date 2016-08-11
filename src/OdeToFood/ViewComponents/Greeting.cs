using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class Greeting : ViewComponent
    {
        private IGreeter _greeter;

        public Greeting(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _greeter.GetGreetingAsync();
            return View("Default", model);
        }
    }
}
