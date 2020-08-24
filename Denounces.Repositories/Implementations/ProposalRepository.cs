﻿using System;
namespace Denounces.Repositories.Implementations
{
    using Denounces.Infraestructure;
    using Denounces.Repositories.Contracts;
    using System.Threading.Tasks;
    using Domain.Entities;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {
        public ProposalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<ProposalType>> GetTypes()
        {
            return await Context.ProposalTypes.ToListAsync();
        }

        public async Task<Proposal> AddProposalAsync(Proposal entity)
        {
            entity.PriorityNumber = 9;
            entity.StatusId = 1;
            entity.ProposalTypeId = 1;

            await Context.Proposals.AddAsync(entity);
            await SaveAllAsync();
            return entity;
        }
    }
}
