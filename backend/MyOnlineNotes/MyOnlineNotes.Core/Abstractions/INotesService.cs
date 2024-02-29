using MyOnlineNotes.Core.Models;

namespace MyOnlineNotes.Application.Services {
    public interface INotesService {
        Task<Guid> CreateNote(Notes note);
        Task<Guid> DeleteNote(Guid id);
        Task<List<Notes>> GetAllNotes();
        Task<List<Notes>> GetAllNotesByUserId(Guid id);
        Task<Guid> UpdateNote(Guid id, string _note, DateTime lastUpdate);
    }
}