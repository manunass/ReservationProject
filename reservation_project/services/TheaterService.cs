using System;
using System.Threading.Tasks;
using AutoMapper;
using reservation_project.Datacontracts.Plays;
using reservation_project.Datacontracts.Theaters;
using reservation_project.services.interfaces;
using reservation_project.Store;

namespace reservation_project.services
{
    public class TheaterService:ITheaterService
    {
        private readonly ITheaterStore _theaterStore;
        private readonly IPlayStore _playStore;
        private readonly IMapper _mapper;
        public TheaterService(ITheaterStore theaterStore, IPlayStore playStore)
        {
            _theaterStore = theaterStore;
            _playStore = playStore;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateTheaterRequest, TheaterEntity>();
            });
            _mapper = configuration.CreateMapper();

        }

        public async Task<Theater> AddTheater(CreateTheaterRequest createTheaterRequest)
        {
            Theater theater = _mapper.Map<Theater>(createTheaterRequest);
            var result = await _theaterStore.CreateTheater(theater);
            return result;
        }

        public async  Task<GetTheatersResponse> GetTheaters()
        {
            var result = await _theaterStore.GetTheaters();
            GetTheatersResponse response = new GetTheatersResponse();
            response.TheatersList = result;
            return response;


        }

        public async Task DeleteTheater(string theaterId)
        {
            var theater = await _theaterStore.GetTheater(theaterId);
            var plays = await _playStore.GetPlaysList(theater.Id);
            string errorMessage = "";
            foreach (Play play in plays )
            {
                string message = $"in Play {play.Name} : ";
                foreach(Seat seat in play.SeatsList)
                {
                    if (seat.ReservationIsConfirmed)
                    {
                         message += $"seat number {seat.SeatNb} is reserved by {seat.ReservingUser} /n";
                        
                    }
                }
                if (message != $"in Play {play.Name} : ")
                {
                    errorMessage += message;
                }
            }
            if (errorMessage != "")
            {
                throw new Exception(errorMessage);
            }
            else
            {
                await _theaterStore.DeleteTheater(theaterId);
                await _playStore.DeletePlays(theaterId);
            }
        }

        public async Task <Theater> UpdateTheater(Theater theater)
        {
            var result = await _theaterStore.UpdateTheater(theater);
            return result;

        }
    }
}
