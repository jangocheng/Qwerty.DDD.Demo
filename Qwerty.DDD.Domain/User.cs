using Framework.Domain.Core;

namespace Qwerty.DDD.Domain
{
    public class User : IAggregateRoot
    {
        public User() { }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public long Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
