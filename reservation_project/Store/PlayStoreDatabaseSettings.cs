using System;
namespace reservation_project.Store
{
    public class PlaystoreDatabaseSettings : IPlaystoreDatabaseSettings
    {
        public string PlaysCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPlaystoreDatabaseSettings
    {
        string PlaysCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
