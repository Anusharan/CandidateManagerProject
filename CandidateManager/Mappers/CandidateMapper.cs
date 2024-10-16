using CandidateManager.Core.Entities;
using CandidateManager.DTOs;

namespace CandidateManager.Mappers
{
    public static class CandidateMapper
    {
        public static Candidate ConvertToEntity(CandidateDto dto)
        {
            return new Candidate
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                LinkedInProfile = dto.LinkedInProfile,
                GitHubProfile = dto.GitHubProfile,
                CallTimeInterval = dto.CallTimeInterval,
                Comment = dto.Comment
            };
        }
    }
}
