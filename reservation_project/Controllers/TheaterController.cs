using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reservation_project.Datacontracts.Theaters;
using reservation_project.services;


namespace reservation_project.Controllers
{

    [Route("api/[controller]")]
    public class TheaterController : Controller
    {
        private readonly ITheaterService _theaterService;

        public TheaterController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        // GET: api/values
        [HttpGet]
        public async Task <IActionResult> GetTheaters()
        {
            var response = await _theaterService.GetTheaters();

            return Ok(response);
        }

        

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostTheater([FromBody] CreateTheaterRequest createTheaterRequest)
        {

            Theater response =await _theaterService.AddTheater(createTheaterRequest);
            return Ok(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task <IActionResult> Put( [FromBody] Theater theater)
        {
            var response = await _theaterService.UpdateTheater(theater);
            return Ok(response);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string theaterId)
        {

            await _theaterService.DeleteTheater(theaterId);
            return Ok();
        }


    }
}
