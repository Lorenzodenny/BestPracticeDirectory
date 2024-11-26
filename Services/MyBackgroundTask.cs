using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BestPracticeDirectory.Services
{
    /// <summary>
    /// Un servizio in background che estende BackgroundService.
    /// Esegue un'operazione periodica ogni 5 secondi.
    /// </summary>
    public class MyBackgroundTask : BackgroundService
    {
        /// <summary>
        /// Metodo principale del servizio, eseguito in un ciclo continuo.
        /// </summary>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Servizio BackgroundTask avviato.");

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Esecuzione del task periodico: {DateTime.Now}");
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Console.WriteLine("Servizio BackgroundTask interrotto.");
        }
    }
}
