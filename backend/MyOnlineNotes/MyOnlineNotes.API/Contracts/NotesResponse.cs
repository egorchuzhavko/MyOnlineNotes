namespace MyOnlineNotes.API.Contracts {
    public record NotesResponse (
        Guid id,
        string note,
        DateTime lastUpdate,
        Guid userId
    );
}
