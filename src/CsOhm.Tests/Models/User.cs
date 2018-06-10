using CsOhm.Attributes;

namespace CsOhm.Tests.Models
{
    [Model]
    public class User
    {
        [Id]
        public long Id { get; set; }

        [Field]
        public string Name { get; set; }

        [Field]
        public int Age { get; set; }
    }
}
