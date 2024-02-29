namespace MyOnlineNotes.API.Contracts {
    public record NotesRequest(
        string note,
        Guid userId
    );
}
