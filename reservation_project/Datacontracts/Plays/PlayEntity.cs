using System;
using System.Collections.Generic;

namespace reservation_project.Datacontracts.Plays
{
    public class PlayEntity
    {
        public string PlayId { get; set; }
        public string PlayName { get; set; }
        public string TheaterId { get; set; }
        public int NumberOfRow { get; set; }
        public int NumberOfColumns { get; set; }
        public List<Seat>  Seats { get; set; }

    }
}
