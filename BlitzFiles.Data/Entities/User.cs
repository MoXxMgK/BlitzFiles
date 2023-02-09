namespace BlitzFiles.Data
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<File> Files { get; set; }

        public User(string login, string password)
        {
            Id = new Guid();
            Login = login;
            Password = password;
        }
    }
}
