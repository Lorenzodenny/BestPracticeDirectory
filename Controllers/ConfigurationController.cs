using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller dimostra l'uso di IConfiguration.
    /// IConfiguration consente di accedere a valori di configurazione
    /// definiti in appsettings.json, variabili d'ambiente o altre fonti.
    /// </summary>
    public class ConfigurationController : Controller
    {
        private readonly IConfiguration _configuration;

        // Dependency Injection di IConfiguration
        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Recupera un valore dalla configurazione (esempio: "AppName").
        /// </summary>
        public IActionResult GetConfigValue()
        {
            // Recupera il valore di configurazione con chiave "AppName"
            var name = _configuration["IlMioNome"];
            return Content($"Il valore configurato per 'IlMioNome' è: {name}");
        }

        /// <summary>
        /// Recupera un valore annidato dalla configurazione (esempio: "Database:ConnectionString").
        /// </summary>
        public IActionResult GetNestedConfigValue()
        {
            // Recupera il valore annidato dalla configurazione
            var connectionString = _configuration["MyCustomSettings:Database:ConnectionString"];
            return Content($"La stringa di connessione è: {connectionString}");
        }
    }
}

/*
    Ora puoi accedere a:
    - /Configuration/GetConfigValue -> Recupera un valore semplice dalla configurazione
    - /Configuration/GetNestedConfigValue -> Recupera un valore annidato dalla configurazione
*/
