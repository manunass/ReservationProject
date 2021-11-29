using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using reservation_project.Datacontracts.Plays;

namespace reservation_project.services.interfaces
{
    public interface IPlayService
    {
        Task <Play> AddPlay(CreatePlayRequest createPlayRequest);
        Task <Play> GetPlay(string playId);
        Task<IList<Play>> GetPlaysList(string theaterId);
        Task <Play> EditPlay(Play play);
        Task DeletePlay(string playId);
        Task <IList<Seat>>AddSeat(string playId, int numberOfSeats);
        Task<IList<Seat>> AddReservation(string playId, IList<Seat> seats);
        Task <Seat>GetSeat(string playId, int seatNb);
        Task <IList<Seat>>EditSeats(string playId, IList<Seat> seats);
        Task <IList<Seat>>DeleteSeats(string playId, IList<int> seatNb);
    }
}
