using HubCount.Urna.Core.Models.DTOs.Vote;
using HubCount.Urna.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HubCount.Urna.API.Controllers
{
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _service;

        public VoteController(IVoteService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("votes")]
        public async Task<ActionResult> Get()
        {
            var result = await _service.GetResultAsync();
            if (result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpPost("vote")]
        public async Task<ActionResult> Create(VoteCreateRequestDTO request)
        {
            var (validate, result) = await _service.CreateAsync(request);
            if (validate != null && validate.HasError)
                return BadRequest(new { validate.HasError, validate.ErrorMessage });
            return Ok(result);
        }
    }
}