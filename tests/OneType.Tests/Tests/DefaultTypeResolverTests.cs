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
            IOrderedEnumerable<string> getNamesOrdered(IEnumerable<DefaultObjectProperty> objectProperties) =>
                objectProperties.Select(p => p.Name)
                    .OrderBy(pn => pn);

            Assert.True(getNamesOrdered(expected).SequenceEqual(getNamesOrdered(actual)));
        });

        [Fact]
        public void PropertiesHaveCorrectType() =>
            TestGetPropertiesMethod(ResultedPropertiesHaveCorrectTypes);

        private readonly static GetPropertiesAssert ResultedPropertiesHaveCorrectTypes = new GetPropertiesAssert((expected, actual) =>
        {
            IOrderedEnumerable<Type> getTypesOrdered(IEnumerable<DefaultObjectProperty> objectProperties) =>
                objectProperties.Select(p => p.Type)
                    .OrderBy(pt => pt.Name);

            Assert.True(getTypesOrdered(expected).SequenceEqual(getTypesOrdered(actual)));
        });

        private delegate void GetPropertiesAssert(IEnumerable<DefaultObjectProperty> expected, IEnumerable<DefaultObjectProperty> actual);
        private void TestGetPropertiesMethod(GetPropertiesAssert assert)
        {
            // arrange
            var testObj = new User();
            var target = new DefaultTypeResolver();
            var expectedProperties = new List<DefaultObjectProperty>
            {
                new DefaultObjectProperty(typeof(Name), nameof(User.Name)),
                new DefaultObjectProperty(typeof(string), nameof(User.Email)),
                new DefaultObjectProperty(typeof(int), nameof(User.Age))
            };

            // act
            var result = target.GetProperties(testObj);

            // assert
            assert(expectedProperties, result);
        }

        [Fact]
        public void CanGetProperty()
        {
            // arrange 
            var testObject = new User
            {
                Name = new Name("John", "Smith")
            };

            var objectProperty = new DefaultObjectProperty(typeof(Name), nameof(User.Name));
            var target = new DefaultTypeResolver();

            // act
            var result = target.GetValue(testObject, objectProperty);

            // assert
            Assert.Equal(testObject.Name, result);
        }

        [Fact]
        public void CanGetPropertyValueByName()
        {
            // arrange 
            var testObject = new User
            {
                Age = 26
            };

            var target = new DefaultTypeResolver();

            // act
            var result = target.GetValue(testObject, nameof(User.Age));

            // assert
            Assert.Equal(testObject.Age, result);
        }

        [Fact]
        public void CanGetObjectProperty() =>
            TestGetPropertyMethod(ResultIsNotNull);

        private static readonly GetPropertyAssert ResultIsNotNull = new GetPropertyAssert((_, result) => Assert.NotNull(result));

        [Fact]
        public void GetPropertyMethodResultHasCorrectType() =>
            TestGetPropertyMethod(ResultedPropertyHasCorrectType);

        private static readonly GetPropertyAssert ResultedPropertyHasCorrectType = new GetPropertyAssert((expected, result) => Assert.Equal(expected.Type, result.Type));

        [Fact]
        public void GetPropertyMethodResultHasCorrectName() =>
            TestGetPropertyMethod(ResultedPropertyHasCorrectName);

        private static readonly GetPropertyAssert ResultedPropertyHasCorrectName = new GetPropertyAssert((expected, result) => Assert.Equal(expected.Name, result.Name));

        private delegate void GetPropertyAssert(DefaultObjectProperty expected, DefaultObjectProperty actual);
        private void TestGetPropertyMethod(GetPropertyAssert assert)
        {
            // arrange
            var testObject = new User
            {
                Email = "somecool@mail.com"
            };

            var expectedProperty = new DefaultObjectProperty(typeof(string), nameof(User.Email));
            var target = new DefaultTypeResolver();

            // act
            var result = target.GetProperty(testObject, nameof(User.Email));

            // assert
            assert(expectedProperty, result);
        }
    }
}
