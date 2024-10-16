using CandidateManager.Core.Entities;
using CandidateManager.Infrastructure.Data;
using CandidateManager.Infrastructure.OutboundPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManager.Infrastructure.Adapters.Outbound
{
    public class SqlCandidateRepository: ICandidateRepository
    {
        private readonly CandidateDbContext _context;

        public SqlCandidateRepository(CandidateDbContext context)
        {
            _context = context;
        }

        public Candidate GetByEmail(string email)
        {
            return _context.Candidates.FirstOrDefault(x => x.Email == email);
        }

        public void Create(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }

        public void Update(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            _context.SaveChanges();
        }
    }
}
