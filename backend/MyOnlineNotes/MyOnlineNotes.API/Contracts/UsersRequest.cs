namespace MyOnlineNotes.API.Contracts {
    public record UsersRequest(
        string login,
        string password
    );
}
