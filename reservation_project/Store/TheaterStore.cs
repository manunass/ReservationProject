using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using reservation_project.Datacontracts.Theaters;

namespace reservation_project.Store
{
    public class TheaterStore:ITheaterStore
    {
        private readonly IMapper _mapper;
        public TheaterStore()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
               
                cfg.CreateMap<Theater, TheaterEntity>();
                
                cfg.CreateMap<TheaterEntity, Theater>();
            });
            _mapper = configuration.CreateMapper();
        }
      
        public async  Task<Theater> CreateTheater(Theater theater)
        {
            
            var theaterId= CreateGUID();
            var playId = CreateGUID();
            theater.TheaterId = theaterId;
            theater.PlaysId = playId;
            TheaterEntity theaterEntity = _mapper.Map<TheaterEntity>(theater);
            //db.store(theaterEntity);
            theater =  _mapper.Map<Theater>(theaterEntity);
            return theater;

        }
        public async Task<Theater> GetTheater(string theaterId )
        {
            //db.Get(theaterId)

            throw new NotImplementedException();
        }

        public async Task<IList<Theater>> GetTheaters()
        {

            throw new NotImplementedException();
        }

        public async Task DeleteTheater(string theaterId)
        {
            //db.delete(theaterId)
            throw new NotImplementedException();
        }

        public Task<Theater> UpdateTheater(Theater theater)
        {
            var entity = _mapper.Map<TheaterEntity>(theater);


            throw new NotImplementedException();
        }


        private static string CreateGUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
    
}
