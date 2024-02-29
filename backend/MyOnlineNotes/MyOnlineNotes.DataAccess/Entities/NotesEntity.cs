namespace MyOnlineNotes.DataAccess.Entities {
    public class NotesEntity {
        public Guid Id { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime LastUpdate { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
