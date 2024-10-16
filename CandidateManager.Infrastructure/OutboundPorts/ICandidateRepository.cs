using CandidateManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManager.Infrastructure.OutboundPorts
{
    public interface ICandidateRepository
    {
        Candidate GetByEmail(string email);
        void Create(Candidate candidate);
        void Update(Candidate candidate);
    }
}
