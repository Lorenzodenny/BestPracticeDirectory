namespace BestPracticeDirectory.Models.Configurations
{
    /// <summary>
    /// Classe di configurazione per mappare i valori di appsettings.json.
    /// </summary>
    public class MyCustomSettings
    {
        public string AppName { get; set; }
        public DatabaseSettings Database { get; set; }

        public class DatabaseSettings
        {
            public string ConnectionString { get; set; }
            public int Timeout { get; set; }
        }
    }
}
