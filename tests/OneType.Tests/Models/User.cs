using System;
using System.Collections.Generic;
using System.Text;

namespace OneType.Tests.Models
{
    [Serializable]
    public struct Name
    {
        public Name(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FullName => $"{FirstName} {SecondName}";
    }

    [Serializable]
    public class User
    {
        public Name Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
