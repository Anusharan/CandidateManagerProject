using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManager.Core.Entities
{
    public class Candidate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Key]
        [EmailAddress] 
        [Required]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LinkedInProfile { get; set; }
        public string? GitHubProfile { get; set; }
        public string? CallTimeInterval { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
