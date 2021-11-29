using System;
namespace reservation_project.Datacontracts.Plays
{
    public class CreatePlayRequest
    {
     
        public string Name { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColums { get; set; }
        public string TheaterId { get; set; }

    }
}
