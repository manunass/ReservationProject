using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using reservation_project.Datacontracts.Theaters;

namespace reservation_project.Store
{
    public interface ITheaterStore
    {
        Task <Theater> CreateTheater(Theater theater);
        Task <IList<Theater> >GetTheaters();
        Task<Theater> GetTheater(string theaterId);
        Task DeleteTheater(string theaterId);
        Task<Theater> UpdateTheater(Theater theater);
        
        
    }
}
