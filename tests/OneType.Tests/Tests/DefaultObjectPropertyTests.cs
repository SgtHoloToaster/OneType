using OneType.Tests.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OneType.Tests.Tests
{
    public class DefaultObjectPropertyTests
    {
        [Fact]
        public void CanGetPropertyValue()
        {
            // arrange 
            var testObject = new User
            {
                Age = 26
            };

            var target = new DefaultObjectProperty(typeof(int), nameof(User.Age));

            // act
            var result = target.GetValue(testObject);

            // assert
            Assert.Equal(testObject.Age, result);
        }
    }
}
