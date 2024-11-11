using NoteProject.Domain.Entity;
using NoteProject.Dal.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NoteProject.Dal.Repositories
{
    public class NoteRepository : IBaseRepository<NoteEntity>
    {
        private readonly AppDbContext _appDbContext;

        // Конструктор для инициализации AppDbContext
        public NoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task Create(NoteEntity entity)
        {
            await _appDbContext.Notes.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(NoteEntity entity)
        {
            _appDbContext.Notes.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<NoteEntity> GetAll()
        {
            if (_appDbContext == null)
            {
                throw new InvalidOperationException("AppDbContext is not initialized.");
            }
            return _appDbContext.Notes;
        }

        public async Task<NoteEntity> Update(NoteEntity entity)
        {
            _appDbContext.Notes.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
