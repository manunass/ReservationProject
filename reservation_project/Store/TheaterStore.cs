using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using reservation_project.Datacontracts.Theaters;
using MongoDB.Driver;

namespace reservation_project.Store
{
    public class TheaterStore:ITheaterStore
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<TheaterEntity> _theaters;
        public TheaterStore(ITheaterstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _theaters = database.GetCollection<TheaterEntity>(settings.TheatersCollectionName);
        
        var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Theater, TheaterEntity>();
                cfg.CreateMap<TheaterEntity, Theater>();
                cfg.CreateMap<IList<Theater>, IList<TheaterEntity>>();
                cfg.CreateMap< IList<TheaterEntity>,List<Theater>>();
            });
            _mapper = configuration.CreateMapper();
        }
      
        public async Task<Theater> CreateTheater(Theater theater)
        {
           
            var theaterId= CreateGUID();
            var playId = CreateGUID();
            theater.Id = theaterId;
            theater.PlaysId = playId;
            TheaterEntity theaterEntity = _mapper.Map<TheaterEntity>(theater);
            await _theaters.InsertOneAsync(theaterEntity);
            return theater;

        }
        public async Task<Theater> GetTheater(string theaterId )
        {
            var entity = await _theaters.FindAsync(theater => theater.Id == theaterId);
            Theater theater = _mapper.Map<Theater>(entity);
            return theater;
        }

        public async Task<IList<Theater>> GetTheaters()
        {

            var entities =  _theaters.Find(theaterEntity => true).ToList();
            var result = _mapper.Map<IList<Theater>>(entities);
            return result;
            
        }

        public async Task DeleteTheater(string theaterId)
        {
            await _theaters.DeleteOneAsync(theaterEntity => theaterEntity.Id == theaterId);
            
        }

        public  async Task<Theater> UpdateTheater(Theater theater)
        {
            var entity = _mapper.Map<TheaterEntity>(theater);
            var result =await _theaters.ReplaceOneAsync(theaterEntity => theaterEntity.Id == theater.Id, entity);

            return theater;
        }


        private static string CreateGUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
    
}
