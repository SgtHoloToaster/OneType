using OneType.Interface.Models;
using OneType.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OneType.Tests.Tests
{
    public class DefaultTypeResolverTests
    {
        [Fact]
        public void CanGetObjectProperties() =>
            TestGetPropertiesMethod(ResultHasCorrectNumberOfProperties);

        private readonly static GetPropertiesAssert ResultHasCorrectNumberOfProperties = new GetPropertiesAssert((expected, result) =>
        {
            Assert.NotNull(result);
            Assert.Equal(expected.Count(), result.Count());
        });

        [Fact]
        public void PropertiesHaveCorrectNames() =>
            TestGetPropertiesMethod(ResultedPropertiesHaveCorrectNames);

        private readonly static GetPropertiesAssert ResultedPropertiesHaveCorrectNames = new GetPropertiesAssert((expected, actual) =>
        {
            IOrderedEnumerable<string> getNamesOrdered(IEnumerable<ObjectProperty> objectProperties) =>
                objectProperties.Select(p => p.Name)
                    .OrderBy(pn => pn);

            Assert.True(getNamesOrdered(expected).SequenceEqual(getNamesOrdered(actual)));
        });

        [Fact]
        public void PropertiesHaveCorrectType() =>
            TestGetPropertiesMethod(ResultedPropertiesHaveCorrectTypes);

        private readonly static GetPropertiesAssert ResultedPropertiesHaveCorrectTypes = new GetPropertiesAssert((expected, actual) =>
        {
            IOrderedEnumerable<Type> getTypesOrdered(IEnumerable<ObjectProperty> objectProperties) =>
                objectProperties.Select(p => p.Type)
                    .OrderBy(pt => pt.Name);

            Assert.True(getTypesOrdered(expected).SequenceEqual(getTypesOrdered(actual)));
        });

        private delegate void GetPropertiesAssert(IEnumerable<ObjectProperty> expected, IEnumerable<ObjectProperty> actual);
        private void TestGetPropertiesMethod(GetPropertiesAssert assert)
        {
            // arrange
            var testObj = new User();
            var target = new DefaultTypeResolver();
            var expectedProperties = new List<ObjectProperty>
            {
                new ObjectProperty(typeof(Name), nameof(User.Name)),
                new ObjectProperty(typeof(string), nameof(User.Email)),
                new ObjectProperty(typeof(int), nameof(User.Age))
            };

            // act
            var result = target.GetProperties(testObj);

            // assert
            assert(expectedProperties, result);
        }

        [Fact]
        public void CanGetPropertyValueByName()
        {
            // arrange 
            var testObject = new User
            {
                Age = 26
            };

            var objectProperty = new ObjectProperty(typeof(int), nameof(User.Age));
            var target = new DefaultTypeResolver();

            // act
            var result = target.GetValue(testObject, nameof(User.Age));

            // assert
            Assert.Equal(testObject.Age, result);
        }
    }
}
