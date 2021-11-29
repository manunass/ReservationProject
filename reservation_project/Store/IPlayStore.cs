using System.Collections.Generic;
using System.Threading.Tasks;
using reservation_project.Datacontracts.Plays;

namespace reservation_project.Store
{
    public interface IPlayStore
    {
        Task<Play> CreatePlay(Play Play);
        Task<Play> Getplay(string playId);
        Task<IList<Play>> GetPlaysList(string theatherId);
        Task DeletePlay(string playId);
        Task DeletePlays(string theaterId);
        Task<Play> UpdatePlay(Play play );
        Task <Play>CreateSeat(string playId, int numberOfSeats);
        Task <Seat>GetSeat(string playId, int seatNb);
        Task <Play>UpdateSeat(string playId, Seat seat);
        Task <Play>UpdateSeats(string playId, IList<Seat> seat);
        Task <Play>DeleteSeats(string playId, IList<int> seatNb);
    }
}
