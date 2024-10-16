using CandidateManager.Application.Services;
using CandidateManager.Core.Entities;
using CandidateManager.Infrastructure.OutboundPorts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CandidateManager.Tests
{
    public class CandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _candidateRepositoryMock;
        private readonly CandidateService _candidateService;

        public CandidateServiceTests()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _candidateService = new CandidateService(_candidateRepositoryMock.Object);
        }

        [Fact]
        public void CreateOrUpdateCandidateShouldCreateCandidate()
        {
            var candidate = new Candidate
            {
                FirstName = "Anusharan",
                LastName = "Adhikari",
                Email = "anusharanadhikari@abc.com",
                PhoneNumber = "9860000000",
                LinkedInProfile = "https://linkedin.com/in",
                GitHubProfile = "https://github.com/abc",
                CallTimeInterval = "9 AM - 11 AM",
                Comment = "First candidate"
            };

            _candidateRepositoryMock.Setup(r => r.GetByEmail(candidate.Email)).Returns((Candidate)null);

            // Act
            _candidateService.CreateOrUpdateCandidate(candidate);

            // Assert
            _candidateRepositoryMock.Verify(r => r.Create(candidate), Times.Once);
            _candidateRepositoryMock.Verify(r => r.Update(It.IsAny<Candidate>()), Times.Never);
        }

        [Fact]
        public void CreateOrUpdateCandidateShouldUpdateCandidate()
        {
            // Arrange
            var existingCandidate = new Candidate
            {
                FirstName = "Test",
                LastName = "101",
                Email = "test.101@abc.com",
                PhoneNumber = "9856556555"
            };

            var updatedCandidate = new Candidate
            {
                FirstName = "Test",
                LastName = "101",
                Email = "test.101@abc.com",
                PhoneNumber = "9856556555",
                LinkedInProfile = "https://linkedin.com/in",
                GitHubProfile = "https://github.com/test",
                CallTimeInterval = "10 AM - 12 PM",
                Comment = "Updated candidate Information"
            };

            _candidateRepositoryMock.Setup(r => r.GetByEmail(existingCandidate.Email)).Returns(existingCandidate);

            // Act
            _candidateService.CreateOrUpdateCandidate(updatedCandidate);

            // Assert
            _candidateRepositoryMock.Verify(r => r.Update(existingCandidate), Times.Once);
            _candidateRepositoryMock.Verify(r => r.Create(It.IsAny<Candidate>()), Times.Never);

            // Check if the existing candidate was updated correctly
            Assert.Equal("Test", existingCandidate.FirstName);
            Assert.Equal("101", existingCandidate.LastName);
            Assert.Equal("9856556555", existingCandidate.PhoneNumber);
            Assert.Equal("https://linkedin.com/in", existingCandidate.LinkedInProfile);
            Assert.Equal("https://github.com/test", existingCandidate.GitHubProfile);
            Assert.Equal("10 AM - 12 PM", existingCandidate.CallTimeInterval);
            Assert.Equal("Updated candidate Information", existingCandidate.Comment);
        }
    }
}
