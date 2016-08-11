using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController 
    {
        public string Phone()
        {
            return "+44 983031231";
        }
        
        public string Country()
        {
            return "UK";
        }
    }
}
