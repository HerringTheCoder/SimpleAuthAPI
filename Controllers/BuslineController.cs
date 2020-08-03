using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthAPI.Interfaces;
using SimpleAuthAPI.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class BuslineController : ControllerBase
    {

        private readonly IBuslineRepository _buslineRepository;

        public BuslineController(IBuslineRepository buslineRepository)
        {
            _buslineRepository = buslineRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CreateBuslineRequest request)
        {
            var busline = await _buslineRepository.AddBusline(request);
            return CreatedAtAction(nameof(GetAsync), busline.Id, busline);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var item = await _buslineRepository.GetBusline(id);
            if (item != null)
                return Ok(item);
            return NotFound();
        }

        [HttpGet]
        public async Task<IEnumerable<Busline>> GetAllAsync()
        {
            return await _buslineRepository.GetBuslines();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateBuslineRequest request, int id)
        {
            await _buslineRepository.UpdateBusline(request, id);
            return Ok();
        }
    }
}
