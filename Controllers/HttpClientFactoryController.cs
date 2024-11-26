using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller dimostra l'uso di IHttpClientFactory.
    /// IHttpClientFactory consente di creare e configurare istanze di HttpClient centralizzate,
    /// con timeout, intestazioni o politiche di retry personalizzate.
    /// </summary>
    public class HttpClientFactoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Dependency Injection di IHttpClientFactory
        public HttpClientFactoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Effettua una richiesta GET utilizzando un client configurato.
        /// </summary>
        public async Task<IActionResult> GetConfiguredApi()
        {
            // Usa il client "ConfiguredClient" registrato in Program.cs
            var client = _httpClientFactory.CreateClient("ConfiguredClient");

            // Effettua una richiesta GET
            var response = await client.GetStringAsync("/posts/1");

            return Content($"Risposta dall'API configurata: {response}");
        }
    }
}

/*
    Ora puoi accedere a:
    - /HttpClientFactory/GetConfiguredApi -> Effettua una richiesta GET con un client configurato
*/


//La differenza fondamentale tra HttpClient e IHttpClientFactory sta proprio nella gestione e configurazione centralizzata:

//Differenza tra HttpClient e IHttpClientFactory
//HttpClient:

//È una classe che permette di fare chiamate HTTP (GET, POST, ecc.) direttamente.
//Ogni volta che crei un'istanza di HttpClient manualmente, devi configurarla individualmente.
//Problema comune: Se non gestisci le connessioni correttamente, puoi esaurire i socket disponibili.
//IHttpClientFactory:

//È una factory che ti permette di creare HttpClient con configurazioni già pronte definite in Program.cs.
//Gestisce il pooling delle connessioni in modo automatico, evitando problemi di risorse.
//Ti consente di registrare più configurazioni per API diverse e riutilizzarle.
//Esempio pratico:

//Con HttpClient: Ogni volta che devi accedere a un'API, devi impostare manualmente BaseAddress, Timeout, e altre proprietà.
//Con IHttpClientFactory: Definisci queste configurazioni una volta in Program.cs, e poi richiami un client specifico in base al nome.