using CandidateManager.Application.Ports;
using CandidateManager.Core.Entities;
using CandidateManager.Infrastructure.OutboundPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManager.Application.Services
{
    public class CandidateService: ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public void CreateOrUpdateCandidate(Candidate candidate)
        {
            var existingCandidate = _candidateRepository.GetByEmail(candidate.Email);

            if (existingCandidate == null)
            {
                _candidateRepository.Create(candidate);
            }
            else
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                existingCandidate.GitHubProfile = candidate.GitHubProfile;
                existingCandidate.CallTimeInterval = candidate.CallTimeInterval;
                existingCandidate.Comment = candidate.Comment;

                _candidateRepository.Update(existingCandidate);
            }
        }
    }
}
