using CandidateManager.Core.Entities;
using CandidateManager.Infrastructure.Adapters.Outbound;
using CandidateManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CandidateManager.Tests
{
    public class CandidateRepositoryTest
    {
            private readonly SqlCandidateRepository _repository;
            private readonly CandidateDbContext _context;

            public CandidateRepositoryTest()
            {
                // Use InMemoryDatabase for testing
                var options = new DbContextOptionsBuilder<CandidateDbContext>()
                                .UseInMemoryDatabase(databaseName: "CandidateDatabase")
                                .Options;

                _context = new CandidateDbContext(options);
                _repository = new SqlCandidateRepository(_context);
            }

            [Fact]
            public void GetByEmailShouldReturnCandidateWhenCandidateExists()
            {
                // Arrange
                var candidate = new Candidate
                {
                    Email = "johnterry@abc.com",
                    FirstName = "John",
                    LastName = "Terry",
                    Comment = "Returns candidate information if exists."
                };

                _context.Candidates.Add(candidate);
                _context.SaveChanges();

                // Act
                var result = _repository.GetByEmail("johnterry@abc.com");

                // Assert
                Assert.NotNull(result);
                Assert.Equal("johnterry@abc.com", result.Email);
            }

            [Fact]
            public void CreateShouldAddCandidate()
            {
                // Arrange
                var candidate = new Candidate
                {
                    Email = "frankribery@abc.com",
                    FirstName = "Frank",
                    LastName = "Ribery",
                    Comment = "Create candidate."
                };

                // Act
                _repository.Create(candidate);

                // Assert
                var createdCandidate = _context.Candidates.FirstOrDefault(c => c.Email == "frankribery@abc.com");
                Assert.NotNull(createdCandidate);
                Assert.Equal("Frank", createdCandidate.FirstName);
            }

            [Fact]
            public void UpdateShouldModifyExistingCandidate()
            {
                // Arrange
                var candidate = new Candidate
                {
                    Email = "frankribery@abc.com",
                    FirstName = "Frank",
                    LastName = "Ribery",
                    Comment = "Initial comment."
                };

                _context.Candidates.Add(candidate);
                _context.SaveChanges();

                // Modify the candidate
                candidate.LastName = "Riberyy";
                candidate.Comment = "Updated the candidate successfully!.";

                // Act
                _repository.Update(candidate);

                // Assert
                var updatedCandidate = _context.Candidates.FirstOrDefault(c => c.Email == "frankribery@abc.com");
                Assert.NotNull(updatedCandidate);
                Assert.Equal("Riberyy", updatedCandidate.LastName);
            }
        }
    }
