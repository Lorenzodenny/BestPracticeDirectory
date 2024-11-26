using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace BestPracticeDirectory.Controllers
{
    /// <summary>
    /// Questo controller dimostra l'uso di IDistributedCache.
    /// IDistributedCache è una cache condivisa tra più server.
    /// Può utilizzare provider come Redis o SQL Server.
    /// </summary>
    public class DistributedCacheController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        // Dependency Injection di IDistributedCache
        public DistributedCacheController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        /// <summary>
        /// Imposta un valore nella Distributed Cache.
        /// </summary>
        public async Task<IActionResult> SetCache()
        {
            // Salva un valore nella cache distribuita
            await _distributedCache.SetStringAsync("ExampleKey", "Hello from Distributed Cache!", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });

            return Content("Valore salvato nella Distributed Cache con chiave 'ExampleKey'.");
        }

        /// <summary>
        /// Recupera un valore dalla Distributed Cache.
        /// </summary>
        public async Task<IActionResult> GetCache()
        {
            var cachedValue = await _distributedCache.GetStringAsync("ExampleKey");

            if (string.IsNullOrEmpty(cachedValue))
            {
                return Content("La chiave 'ExampleKey' non è presente nella Distributed Cache.");
            }

            return Content($"Valore recuperato dalla Distributed Cache: {cachedValue}");
        }

        /// <summary>
        /// Rimuove un valore dalla Distributed Cache.
        /// </summary>
        public async Task<IActionResult> RemoveCache()
        {
            await _distributedCache.RemoveAsync("ExampleKey");
            return Content("La chiave 'ExampleKey' è stata rimossa dalla Distributed Cache.");
        }
    }
}
//Ora puoi accedere a:

/// DistributedCache / SetCache
/// DistributedCache / GetCache
/// DistributedCache / RemoveCache