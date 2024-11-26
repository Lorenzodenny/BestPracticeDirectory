using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller dimostra l'uso di ILogger.
    /// ILogger consente di registrare messaggi di log utili per diagnosticare problemi o monitorare l'applicazione.
    /// I livelli di log includono: Trace, Debug, Information, Warning, Error, Critical.
    /// </summary>
    public class LoggerController : Controller
    {
        private readonly ILogger<LoggerController> _logger;

        // Dependency Injection di ILogger
        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Emette un log di tipo Informativo.
        /// </summary>
        public IActionResult LogInformation()
        {
            _logger.LogInformation("Questo è un messaggio informativo di esempio.");
            return Content("Log di tipo Informativo registrato con successo.");
        }

        /// <summary>
        /// Emette un log di tipo Warning.
        /// </summary>
        public IActionResult LogWarning()
        {
            _logger.LogWarning("Questo è un messaggio di avviso (Warning) di esempio.");
            return Content("Log di tipo Warning registrato con successo.");
        }

        /// <summary>
        /// Emette un log di tipo Errore.
        /// </summary>
        public IActionResult LogError()
        {
            _logger.LogError("Questo è un messaggio di errore di esempio.");
            return Content("Log di tipo Errore registrato con successo.");
        }
    }
}

/*
    Ora puoi accedere a:
    - /Logger/LogInformation -> Registra un log di tipo Informativo
    - /Logger/LogWarning -> Registra un log di tipo Warning
    - /Logger/LogError -> Registra un log di tipo Errore
*/
