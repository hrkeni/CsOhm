using CsOhm.Tests.Models;
using Xunit;

namespace CsOhm.Tests
{
    public class BasicPersistenceTest
    {
        public BasicPersistenceTest()
        {
            CsOhm.Connect(prefix: "Test");
        }

        [Fact]
        public void Save()
        {
            var user = new User {Name = "foo", Age = 5};

            user = CsOhm.Save(user);

            Assert.NotNull(user);

            var savedUser = CsOhm.Get<User>(user.Id);

            Assert.NotNull(savedUser);

            Assert.Equal(savedUser.Id, user.Id);
            Assert.Equal(savedUser.Name, user.Name);
            Assert.Equal(savedUser.Age, user.Age);
        }
    }
}
