namespace MyOnlineNotes.API.Contracts {
    public record UsersResponse (
        Guid id, 
        string login, 
        string password
    );
}
