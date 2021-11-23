using System;
using System.Threading.Tasks;
using reservation_project.Datacontracts.Theaters;

namespace reservation_project.services
{
    public interface ITheaterService
    {
        Task <GetTheatersResponse>GetTheaters();
        Task <Theater>AddTheater(CreateTheaterRequest createTheaterRequest);
        Task DeleteTheater(string theaterId);
        Task <Theater>UpdateTheater(Theater theater);


    }
}
