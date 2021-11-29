using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using reservation_project.Datacontracts.Plays;

namespace reservation_project.Store
{
    public class PlayStore:IPlayStore
    {
        public PlayStore()
        {
        }

        public Task<Play> CreatePlay(Play Play)
        {
            throw new NotImplementedException();
        }

        public Task CreateSeat(string playId, int numberOfSeats)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlay(string playId)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlays(string theaterId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSeats(string playId, IList<int> seatNb)
        {
            throw new NotImplementedException();
        }

        public Task<Play> Getplay(string playId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Play>> GetPlaysList(string theatherId)
        {
            throw new NotImplementedException();
        }

        public Task GetSeat(string playId, int seatNb)
        {
            throw new NotImplementedException();
        }

        public Task<Play> UpdatePlay(Play play)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSeat(string playId, Seat seat)
        {
            throw new NotImplementedException();
        }

        public Task<Play> UpdateSeats(string playId, IList<Seat> seat)
        {
            throw new NotImplementedException();
        }
    }
}
