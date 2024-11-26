using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller dimostra l'uso di HttpClient.
    /// HttpClient è utilizzato per effettuare richieste HTTP (GET, POST, ecc.) verso API o servizi web.
    /// </summary>
    public class HttpClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Dependency Injection di IHttpClientFactory
        public HttpClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Effettua una richiesta HTTP GET verso un endpoint pubblico.
        /// </summary>
        public async Task<IActionResult> GetPublicApi()
        {
            // Crea un'istanza di HttpClient tramite IHttpClientFactory
            var client = _httpClientFactory.CreateClient();

            // Effettua una richiesta GET
            var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");

            return Content($"Risposta dall'API: {response}");
        }
    }
}

/*
    Ora puoi accedere a:
    - /HttpClient/GetPublicApi -> Effettua una richiesta GET verso un'API pubblica
*/

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