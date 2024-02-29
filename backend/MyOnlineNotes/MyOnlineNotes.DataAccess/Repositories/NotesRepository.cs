using Microsoft.EntityFrameworkCore;
using MyOnlineNotes.Core.Models;
using MyOnlineNotes.DataAccess.Entities;

namespace MyOnlineNotes.DataAccess.Repositories {
    public class NotesRepository : INotesRepository {
        private readonly MyOnlineNotesDbContext _context;

        public NotesRepository(MyOnlineNotesDbContext context) {
            _context = context;
        }

        public async Task<List<Notes>> GetAll() {
            var notesEntities = await _context.Notes
                .AsNoTracking()
                .ToListAsync();
            var notes = notesEntities.Select(n => Notes.Create(
                    n.Id,
                    n.Note,
                    n.LastUpdate,
                    n.UserId).Note)
                .ToList();

            return notes;
        }

        public async Task<List<Notes>> GetAllByUserId(Guid id) {
            var notesEntities = await _context.Notes
                .AsNoTracking()
                .Where(n => n.UserId == id)
                .ToListAsync();
            var notes = notesEntities.Select(n => Notes.Create(
                    n.Id,
                    n.Note,
                    n.LastUpdate,
                    n.UserId).Note)
                .ToList();

            return notes;
        }

        public async Task<Guid> Create(Notes note) {
            var noteEntity = new NotesEntity {
                Id = note.Id,
                Note = note.Note,
                LastUpdate = note.LastUpdate,
                UserId = note.UserId
            };

            await _context.Notes.AddAsync(noteEntity);
            await _context.SaveChangesAsync();

            return noteEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string _note, DateTime lastUpdate) {
            await _context.Notes
                .Where(n => n.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(n => n.Note, n => _note)
                    .SetProperty(n => n.LastUpdate, n => lastUpdate));

            return id;
        }

        public async Task<Guid> Delete(Guid id) {
            await _context.Notes
                .Where(n => n.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
