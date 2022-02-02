using Microsoft.AspNetCore.Mvc;
using mobilus_test_api.Interfaces;
using mobilus_test_api.Model;

namespace mobilus_test_api.Controllers
{
    public class HomeController : Controller
    {
        ICovid19Api _covid19Api;
        public HomeController(ICovid19Api covid19Api)
        {
            _covid19Api = covid19Api;
        }

        [HttpGet("last-six-months")]
        public List<Case> getLastSixMonthsCase()
        {
            var cases = _covid19Api.getLastSixMonthsCase();

            return cases;
        }
    }
}
