using CandidateManager.Application.Ports;
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
        public ActionResult CreateOrUpdateCandidate([FromBody] CandidateDto candidateDto)
        {
            var candidate = CandidateMapper.ConvertToEntity(candidateDto);
            _candidateService.CreateOrUpdateCandidate(candidate);
            return Ok();
        }
    }
}
