using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BestPracticeDirectory.Services
{
    /// <summary>
    /// Un servizio in background che implementa IHostedService.
    /// Esegue un'operazione periodica ogni 10 secondi.
    /// </summary>
    public class MyBackgroundService : IHostedService, IDisposable
    {
        private Timer _timer;
        private bool _isRunning;

        /// <summary>
        /// Metodo chiamato quando il servizio parte.
        /// </summary>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Servizio in background avviato.");
            _isRunning = true;

            // Avvia un timer che esegue un'operazione ogni 10 secondi
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Operazione da eseguire periodicamente.
        /// </summary>
        private void DoWork(object state)
        {
            if (!_isRunning)
                return;

            Console.WriteLine($"Esecuzione del servizio in background: {DateTime.Now}");
        }

        /// <summary>
        /// Metodo chiamato quando il servizio si ferma.
        /// </summary>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Servizio in background interrotto.");
            _isRunning = false;

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Rilascia risorse usate dal servizio.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
