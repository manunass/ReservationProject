using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using reservation_project.Datacontracts.Plays;
using reservation_project.services.interfaces;
using reservation_project.Store;

namespace reservation_project.services
{
    public class PlayService:IPlayService
    {
        private readonly IPlayStore _playStore;
        private readonly IMapper _mapper;
        public PlayService(IPlayStore playStore)
        {
            _playStore = playStore;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatePlayRequest, Play>();
            });
            _mapper = configuration.CreateMapper();
        }

        public async Task <Play> AddPlay(CreatePlayRequest createPlayRequest)
        {
            Play play = _mapper.Map<Play>(createPlayRequest);
            var result = await  _playStore.CreatePlay(play);

            return result;

        }

        

        public async Task DeletePlay(string playId)
        {
            var play= await _playStore.Getplay(playId);
            string message = $"in Play {play.Name} : ";
            foreach (Seat seat in play.SeatsList)
            {
                if (seat.ReservationIsConfirmed)
                {
                    message += $"seat number {seat.SeatNb} is reserved by {seat.ReservingUser} /n";
                }
            }
        }

        public async Task<Play> EditPlay(Play play)
        {
            var currentPlay =await  _playStore.Getplay(play.Id);
            
            if(currentPlay.SeatsList != play.SeatsList)
            {

                throw new Exception("400 Bad Request");
            }
            var result = await _playStore.UpdatePlay(play);
            return result;
        }

        public async Task<Play> GetPlay(string playId)
        {
            var result = await _playStore.Getplay(playId);
            return result;
        }

        public async Task<IList<Play>> GetPlaysList(string theaterId)
        {
            var result = await _playStore.GetPlaysList(theaterId) ;
            return result;
        }

        

        public async Task <IList<Seat>> AddSeat(string playId, int numberOfSeats)
        {
            var result = await _playStore.CreateSeat(playId, numberOfSeats);
            return result.SeatsList;
        }

        public async Task <Seat>GetSeat(string playId, int seatNb)
        {
            var result = await _playStore.GetSeat(playId, seatNb);
            return result;
        }

        public async Task <IList<Seat>> EditSeats(string playId, IList<Seat> seats)
        {
            var result =await _playStore.UpdateSeats(playId, seats);

            return result.SeatsList;
        }

        public async Task<IList<Seat>> DeleteSeats(string playId, IList<int> seatsNb)
        {
            var play = await _playStore.Getplay(playId);
            string errorMessage = "";
            foreach (Seat seat in play.SeatsList)
            {
                if (seatsNb.Contains(seat.SeatNb))
                {
                    if (seat.ReservationIsConfirmed)
                    {
                        errorMessage += $"Seat {seat.SeatNb} is reserved by user {seat.ReservingUser}. /n";
                    }
                    play.SeatsList.Remove(seat);
                }
            }
            if (errorMessage != "")
            {
                throw new Exception(errorMessage);
            }
            throw new NotImplementedException();
        }

        private async Task<IList<Seat>> UpdateSeats(Play play, IList<Seat> seats)
        {
            List<Seat> currentSeating = new List<Seat>(play.SeatsList);
            string errorMessage = "";
            foreach (Seat seat in seats)
            {
                var matchingSeat = currentSeating.Find(x => (x.SeatNb == seat.SeatNb));
                    
                if(matchingSeat==null)
                {
                    throw new Exception("400 Bad Request");
                }
                else if(matchingSeat.ReservationIsConfirmed && !seat.ReservationIsConfirmed)
                {
                    errorMessage+= $"Seat {seat.SeatNb} is reserved by user {seat.ReservingUser}, you cannot cancel the reservation. /n";
                }
                else
                {
                    play.SeatsList[play.SeatsList.IndexOf(matchingSeat)] = seat;
                }
            }
            throw new NotImplementedException();
        }

        public Task<IList<Seat>> AddReservation(string playId, IList<Seat> seats)
        {
            throw new NotImplementedException();
        }
    }
}
