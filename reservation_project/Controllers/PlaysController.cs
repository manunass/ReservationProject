using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reservation_project.Datacontracts.Plays;
using reservation_project.services;
using reservation_project.services.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace reservation_project.Controllers
{
    [Route("api/[controller]")]
    public class PlaysController : Controller
    {
        private readonly IPlayService _playService;

        PlaysController(IPlayService playService)
        {
            _playService = playService;
        }

        // GET: api/values

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostPlay([FromBody] CreatePlayRequest createPlayRequest)
        {
            var response = await _playService.AddPlay(createPlayRequest);
            return CreatedAtAction(nameof(PostPlay),new { response.Id },response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlays(string theaterId)
        {
            var Response = await _playService.GetPlaysList(theaterId);
            return Ok(Response);
        }

        // GET api/values/5
        [HttpGet("{id}")] //this is useles?
        public async Task <IActionResult> GetPlay(string playId)
        {
            var response = await _playService.GetPlay(playId);
            return Ok(response);
        }

        


        [HttpPut("{id}")]
        public async Task <IActionResult> EditPlay( [FromBody] Play play)
        {
             var response = await _playService.EditPlay(play);
            return Ok(response);
        }

        [HttpPut("{id}/seatings")]
        public void EditSeats(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
