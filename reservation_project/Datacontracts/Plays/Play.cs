using System;
using System.Collections.Generic;


namespace reservation_project.Datacontracts.Plays
{
    public class Play
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public IList <Seat> SeatsList { get; set; }
        
    }
}
