using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string GetGreeting();
        Task<string> GetGreetingAsync();
    }

    public class Greeter : IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration cofiguration)
        {
            _greeting = cofiguration["greeting"];
        }

        public string GetGreeting()
        {
            return _greeting;
        }

        public async Task<string> GetGreetingAsync()
        {
            var result = await Task.Run(() 
                        => {
                            return GetGreeting();
                        });

            return result;
        }
    }
}
