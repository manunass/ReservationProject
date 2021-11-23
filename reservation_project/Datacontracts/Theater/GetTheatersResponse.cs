using System;
using System.Collections.Generic;

namespace reservation_project.Datacontracts.Theaters

{
    public class GetTheatersResponse
    {
        public IList<Theater> TheatersList { get; set; }
    }
}
