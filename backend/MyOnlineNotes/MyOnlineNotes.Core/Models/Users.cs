namespace MyOnlineNotes.Core.Models {
    public class Users {
        public const int MAX_SYMBOLS_LENGTH = 32;

        private Users(Guid id, string login, string password) {
            Id = id;
            Login = login;
            Password = password;
        }

        public Guid Id { get; }
        public string Login { get; } = string.Empty;
        public string Password { get; } = string.Empty;

        public static (Users User, string Error) Create(Guid id, string login, string password) {
            var error = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) {
                error = "There is empty login or password..";
            }

            if (login.Length > MAX_SYMBOLS_LENGTH || password.Length > MAX_SYMBOLS_LENGTH) {
                error = "Login or password is too long..";
            }

            var user = new Users(id, login, password);

            return (user, error);
        }
    }
}
