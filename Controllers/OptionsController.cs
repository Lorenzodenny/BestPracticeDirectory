using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BestPracticeDirectory.Models.Configurations;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller dimostra l'uso di IOptions<T> e IOptionsMonitor<T>.
    /// IOptions<T> fornisce configurazioni statiche, mentre IOptionsMonitor<T> consente di rilevare modifiche in tempo reale.
    /// </summary>
    public class OptionsController : Controller
    {
        private readonly MyCustomSettings _options;
        private readonly IOptionsMonitor<MyCustomSettings> _optionsMonitor;

        // Dependency Injection di IOptions e IOptionsMonitor
        public OptionsController(IOptions<MyCustomSettings> options, IOptionsMonitor<MyCustomSettings> optionsMonitor)
        {
            _options = options.Value;
            _optionsMonitor = optionsMonitor;
        }

        /// <summary>
        /// Recupera configurazioni utilizzando IOptions.
        /// </summary>
        public IActionResult GetOptions()
        {
            return Content($"AppName: {_options.AppName}, ConnectionString: {_options.Database.ConnectionString}, Timeout: {_options.Database.Timeout}");
        }

        /// <summary>
        /// Recupera configurazioni utilizzando IOptionsMonitor.
        /// </summary>
        public IActionResult GetOptionsMonitor()
        {
            var currentOptions = _optionsMonitor.CurrentValue;
            return Content($"[Monitor] AppName: {currentOptions.AppName}, ConnectionString: {currentOptions.Database.ConnectionString}, Timeout: {currentOptions.Database.Timeout}");
        }
    }
}

/*
    Ora puoi accedere a:
    - /Options/GetOptions -> Recupera configurazioni statiche tramite IOptions<T>
    - /Options/GetOptionsMonitor -> Recupera configurazioni dinamiche tramite IOptionsMonitor<T>
*/
