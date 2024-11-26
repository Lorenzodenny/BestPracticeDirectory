using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.ConstrainedExecution;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller dimostra l'uso di IMemoryCache.
    /// IMemoryCache è una cache in memoria per memorizzare dati temporanei.
    /// È utile per ridurre le chiamate a database o servizi esterni.
    /// </summary>
    public class MemoryCacheController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        // Dependency Injection di IMemoryCache
        public MemoryCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Imposta un valore nella cache in memoria.
        /// </summary>
        public IActionResult SetCache()
        {
            // Salva un valore nella cache con una chiave "ExampleKey"
            _memoryCache.Set("ExampleKey", "Hello from Memory Cache!", TimeSpan.FromMinutes(10));

            return Content("Valore salvato nella Memory Cache con chiave 'ExampleKey'.");
        }

        /// <summary>
        /// Recupera un valore dalla cache in memoria.
        /// </summary>
        public IActionResult GetCache()
        {
            // Prova a recuperare il valore dalla cache
            if (_memoryCache.TryGetValue("ExampleKey", out string cachedValue))
            {
                return Content($"Valore recuperato dalla Memory Cache: {cachedValue}");
            }

            return Content("La chiave 'ExampleKey' non è presente nella cache.");
        }

        /// <summary>
        /// Rimuove un valore dalla cache in memoria.
        /// </summary>
        public IActionResult RemoveCache()
        {
            _memoryCache.Remove("ExampleKey");
            return Content("La chiave 'ExampleKey' è stata rimossa dalla Memory Cache.");
        }
    }
}
//Ora puoi accedere a:

/// MemoryCache / SetCache per salvare un valore.
///MemoryCache/GetCache per recuperarlo.
///MemoryCache/RemoveCache per rimuoverlo.