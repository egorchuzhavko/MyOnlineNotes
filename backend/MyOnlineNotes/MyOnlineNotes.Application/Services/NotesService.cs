using Microsoft.EntityFrameworkCore;
using MyOnlineNotes.Core.Models;
using MyOnlineNotes.DataAccess.Entities;
using MyOnlineNotes.DataAccess.Repositories;

namespace MyOnlineNotes.Application.Services {
    public class NotesService : INotesService {
        private readonly INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository) {
            _notesRepository = notesRepository;
        }

        public async Task<List<Notes>> GetAllNotes() {
            return await _notesRepository.GetAll();
        }

        public async Task<List<Notes>> GetAllNotesByUserId(Guid id) {
            return await _notesRepository.GetAllByUserId(id);
        }

        public async Task<Guid> CreateNote(Notes note) {
            return await _notesRepository.Create(note);
        }

        public async Task<Guid> UpdateNote(Guid id, string _note, DateTime lastUpdate) {
            return await _notesRepository.Update(id, _note, lastUpdate);
        }

        public async Task<Guid> DeleteNote(Guid id) {
            return await _notesRepository.Delete(id);
        }
    }
}
