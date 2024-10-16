using CandidateManager.Application.Ports;
using CandidateManager.Core.Entities;
using CandidateManager.DTOs;
using CandidateManager.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController: ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public ActionResult CreateOrUpdateCandidate([FromBody] Candidate candidate)
        {
            if(candidate == null)
            {
                return BadRequest("Candidate data is required.");
            }
            _candidateService.CreateOrUpdateCandidate(candidate);
            return Ok();

        }
    }
}
