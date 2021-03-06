using System.Threading.Tasks;
using AmanaSite.Data;
using AmanaSite.Interfaces;
using AmanaSite.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AmanaSite.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _evn;
        public UnitOfWork(DContext context, IMapper mapper, IWebHostEnvironment evn)
        {
            this._evn = evn;
            this._mapper = mapper;
            this._context = context;

        }

        public INews News => new NewsRepository(_context, _mapper,_evn);

        public IAds Ads => new AdsRepository(_context, _mapper,_evn);

        public IAmanaService AmanaService => new AmanaServiceRepository(_context,_mapper,_evn);

        public IMob Mob => new MobRepository(_context,_mapper,_evn);
        public async Task<bool> Complete()
        {
            var state=_context.ChangeTracker.HasChanges();
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}