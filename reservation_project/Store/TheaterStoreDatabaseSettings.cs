using System;
namespace reservation_project.Store
{
    public class TheaterstoreDatabaseSettings : ITheaterstoreDatabaseSettings
    {
        public string TheatersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITheaterstoreDatabaseSettings
    {
        string TheatersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
