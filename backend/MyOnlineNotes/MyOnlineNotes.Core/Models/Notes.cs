namespace MyOnlineNotes.Core.Models {
    public class Notes {
        private Notes(Guid id, string note, DateTime lastUpdate, Guid userId)
        {
            Id = id;
            Note = note;
            LastUpdate = lastUpdate;
            UserId = userId;
        }

        public Guid Id { get; }
        public string Note { get; } = string.Empty;
        public DateTime LastUpdate { get; }
        public Guid UserId { get; }

        public static (Notes Note, string Error) Create(Guid id, string _note, DateTime lastUpdate, Guid userId) {
            var error = string.Empty;

            var note = new Notes(id, _note, lastUpdate, userId);

            return (note, error);
        }
    }
}
