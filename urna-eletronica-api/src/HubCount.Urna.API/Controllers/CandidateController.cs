using HubCount.Urna.Core.Models.DTOs.Candidate;
using HubCount.Urna.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HubCount.Urna.API.Controllers
{
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service) => _service = service;

        [HttpGet("candidates")]
        public async Task<ActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            if (result.Any())
                return Ok(result);
            return
                NotFound();
        }

        [HttpGet("candidate/{legenda}")]
        public async Task<ActionResult> GetByLegenda(int legenda)
        {
            var result = await _service.GetByLegendaAsync(legenda);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpPost("candidate")]
        public async Task<ActionResult> Create(CandidateCreateRequestDTO request)
        {
            var (validate, result) = await _service.CreateAsync(request);
            if (!validate.HasError)
                return Ok(result);
            return BadRequest(new { validate.HasError, validate.ErrorMessage });
        }

        [HttpDelete("candidate/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result)
                return Ok(result);
            return BadRequest(result);
        }
    }
}