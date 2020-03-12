using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Wizkisoft.DotNet.Extension.Test
{
    public class TypeExtensionTests
    {
        public class GetPublicConcreteMethodsShould
        {
            [Theory]
            [InlineData(nameof(Foo.PublicFoo1))]
            [InlineData(nameof(Foo.PublicFoo2))]
            public void ReturnAllPublicConcreteMethods(string methodName)
            {
                var result = TypeExtension.GetPublicConcreteMethods(typeof(Foo));

                result.Select(m => m.Name).Should()
                    .Contain(methodName,
                    because: "the returned methods should include all of the public concrete method names should be returned");
            }

            [Theory]
            [InlineData("get_" + nameof(Foo.PublicPropertyFoo))]
            [InlineData("set_" + nameof(Foo.PublicPropertyFoo))]
            public void NotIncludePublicProperties(string methodName)
            {
                var result = TypeExtension.GetPublicConcreteMethods(typeof(Foo));

                result.Select(m => m.Name).Should()
                    .NotContain(methodName,
                    because: "the returned methods should not include any property accessors or mutators");
            }

            [Fact]
            public void NotReturnAnyPrivateMethods()
            {
                var result = TypeExtension.GetPublicConcreteMethods(typeof(Foo));

                result.Select(m => m.Name).Should()
                    .NotContain("PrivateFoo",
                    because: "private methods should be filtered");
            }

            [Theory]
            [InlineData(nameof(Foo.GetType))]
            [InlineData(nameof(Foo.ToString))]
            [InlineData(nameof(Foo.Equals))]
            [InlineData(nameof(Foo.GetHashCode))]
            public void ReturnAllInheritedPublicConcreteMethods(string methodName)
            {
                var result = TypeExtension.GetPublicConcreteMethods(typeof(Foo));

                result.Select(m => m.Name).Should()
                    .Contain(methodName,
                    because: "even inherited methods should be included in the result");
            }

            [Theory]
            [InlineData(nameof(Object.GetType))]
            [InlineData(nameof(Object.ToString))]
            [InlineData(nameof(Object.Equals))]
            [InlineData(nameof(Object.GetHashCode))]
            public void ReturnAllPublicConcreteInstanceObjectMethods(string methodName)
            {
                var result = TypeExtension.GetPublicConcreteMethods(typeof(object));

                result.Select(m => m.Name).Should()
                    .Contain(methodName,
                    because: "all public, concrete, instance object methods should be returned");
            }

            [Fact]
            public void NotContainAnyAbstractOrStaticMethods()
            {
                var abstractOrStaticMethodNames = new List<string> {
                    nameof(Foo.AbstractFoo),
                    nameof(Foo.StaticFoo)
                };

                var result = TypeExtension.GetPublicConcreteMethods(typeof(Foo));

                var publicMethodNames = result.Select(m => m.Name);
                publicMethodNames.Should().NotContain(abstractOrStaticMethodNames);
            }
        }

        public class GetPublicConcretePropertiesShould
        {
            [Fact]
            public void ReturnAllPublicConcreteProperties()
            {
                var result = TypeExtension.GetPublicConcreteProperties(typeof(Foo));

                var publicPropertyNames = result.Select(m => m.Name);
                publicPropertyNames.Should().BeEquivalentTo(nameof(Foo.PublicPropertyFoo));
            }

            [Fact]
            public void NotReturnAnyStaticProperties()
            {
                var result = TypeExtension.GetPublicConcreteProperties(typeof(Foo));

                var publicPropertyNames = result.Select(m => m.Name);
                publicPropertyNames.Should().NotContain(nameof(Foo.PublicStaticPropertyFoo));
            }
        }

        public class BaseTypeShould
        {
            [Theory]
            [InlineData(typeof(Foo))]
            // [InlineData(typeof(Bar))]
            public void BeObject(Type t)
            {
                var result = t.BaseType;

                result.Should().Be(typeof(object));
            }
        }

        private abstract class Foo
        {
            public string PublicPropertyFoo { get; set; }
            public static string PublicStaticPropertyFoo { get; set; }

            public void PublicFoo1() => PrivateFoo();
            public void PublicFoo2() { }
            private void PrivateFoo() { }
            public abstract void AbstractFoo();
            public static void StaticFoo() { }
        }
    }
}
