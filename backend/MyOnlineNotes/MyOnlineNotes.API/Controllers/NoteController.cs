using Microsoft.AspNetCore.Mvc;
using MyOnlineNotes.API.Contracts;
using MyOnlineNotes.Application.Services;
using MyOnlineNotes.Core.Models;

namespace MyOnlineNotes.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase {
        private readonly INotesService _notesService;

        public NoteController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NotesResponse>>> GetAll() {
            var notes = await _notesService.GetAllNotes();

            var response = notes.Select(n =>
                new NotesResponse(
                    n.Id,
                    n.Note,
                    n.LastUpdate,
                    n.UserId)
                );

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<NotesResponse>>> GetAllNotesByUserId(Guid id) {
            var notes = await _notesService.GetAllNotesByUserId(id);

            var response = notes.Select(n =>
                new NotesResponse(
                    n.Id,
                    n.Note,
                    n.LastUpdate,
                    n.UserId)
                );

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNote([FromBody] NotesRequest notesResponse) {
            var (note, error) = Notes.Create(
                Guid.NewGuid(),
                notesResponse.note,
                DateTime.UtcNow,
                notesResponse.userId);

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            var noteId = await _notesService.CreateNote(note);

            return Ok(noteId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateNote(Guid id, [FromBody] NotesRequest notesResponse) {
            return Ok(await _notesService.UpdateNote(id, notesResponse.note, DateTime.UtcNow));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteNote(Guid id) {
            return Ok(await _notesService.DeleteNote(id));
        }
    }
}
