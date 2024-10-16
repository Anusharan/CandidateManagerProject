using CandidateManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManager.Application.Ports
{
    public interface ICandidateService
    {
        void CreateOrUpdateCandidate(Candidate candidate);
    }
}
