using CandidateManager.Application.Ports;
using CandidateManager.Controllers;
using CandidateManager.Core.Entities;
using CandidateManager.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CandidateManager.Tests
{
    public class CandidatesControllerTests
    {
        private readonly Mock<ICandidateService> _candidateServiceMock;
        private readonly CandidateController _candidateController;

        public CandidatesControllerTests()
        {
            _candidateServiceMock = new Mock<ICandidateService>();
            _candidateController = new CandidateController(_candidateServiceMock.Object);
        }

        [Fact]
        public void CreateOrUpdateCandidateShouldReturnOkWhenCandidateDtoIsValid()
        {
            // Arrange
            var candidate = new Candidate
            {
                FirstName = "Eric",
                LastName = "Halland",
                Email = "eric.halland@abc.com",
                PhoneNumber = "9876543210",
                LinkedInProfile = "https://linkedin.com/in/eric",
                GitHubProfile = "https://github.com/eric",
                CallTimeInterval = "9 AM - 11 AM",
                Comment = "Great Player"
            };

            // Act
            var result = _candidateController.CreateOrUpdateCandidate(candidate);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            _candidateServiceMock.Verify(s => s.CreateOrUpdateCandidate(It.IsAny<Candidate>()), Times.Once);
        }

        [Fact]
        public void CreateOrUpdateCandidateShouldReturnBadRequestWhenCandidateDtoIsNull()
        {
            // Arrange
            Candidate candidate = null;

            // Act
            var result = _candidateController.CreateOrUpdateCandidate(candidate);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Candidate data is required.", badRequestResult.Value);
            _candidateServiceMock.Verify(s => s.CreateOrUpdateCandidate(It.IsAny<Candidate>()), Times.Never);
        }
    }
}
