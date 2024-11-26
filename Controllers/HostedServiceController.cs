using BestPracticeDirectory.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller consente di interagire con i servizi in background.
    /// </summary>
    public class HostedServiceController : Controller
    {
        private readonly MyBackgroundService _backgroundService;

        // Dependency Injection del servizio
        public HostedServiceController(MyBackgroundService backgroundService)
        {
            _backgroundService = backgroundService;
        }

        /// <summary>
        /// Arresta manualmente il servizio in background.
        /// </summary>
        public async Task<IActionResult> StopService()
        {
            await _backgroundService.StopAsync(CancellationToken.None);
            return Content("Servizio in background arrestato manualmente.");
        }
    }
}

/*
    Ora puoi accedere a:
    - /HostedService/StopService -> Arresta il servizio in background manualmente
*/
