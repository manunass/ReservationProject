using System;
namespace reservation_project.Datacontracts.Theaters
{
    public class CreateTheaterRequest
    {
        public string TheaterName { get; set; }
        public string TheaterCity { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColums { get; set; }
    }
}
