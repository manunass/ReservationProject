using System;
namespace reservation_project.Datacontracts.Theaters
{
    public class Theater
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PlaysId { get; set; }
        public int NumberOfSeats { get; set; }


    }
}
