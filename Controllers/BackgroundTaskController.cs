using Microsoft.AspNetCore.Mvc;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Controller per verificare lo stato del servizio in background.
    /// </summary>
    public class BackgroundTaskController : Controller
    {
        public IActionResult Status()
        {
            return Content("Il servizio BackgroundTask è registrato e in esecuzione.");
        }
    }
}

/*
    Ora puoi accedere a:
    - /BackgroundTask/Status -> Conferma che il servizio BackgroundTask è attivo
*/
