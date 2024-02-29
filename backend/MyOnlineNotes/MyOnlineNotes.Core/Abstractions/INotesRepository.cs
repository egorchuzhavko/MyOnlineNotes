using MyOnlineNotes.Core.Models;

namespace MyOnlineNotes.DataAccess.Repositories {
    public interface INotesRepository {
        Task<Guid> Create(Notes note);
        Task<Guid> Delete(Guid id);
        Task<List<Notes>> GetAll();
        Task<List<Notes>> GetAllByUserId(Guid id);
        Task<Guid> Update(Guid id, string _note, DateTime lastUpdate);
    }
}