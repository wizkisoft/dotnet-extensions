using Xunit;
using FluentAssertions;

namespace Wizkisoft.DotNet.Extension.Test
{
    public class MethodInfoExtensionTests
    {
        private abstract class Foo
        {
            public string PropertyFoo { get; set; }
            public void PublicFoo() { }
            private void PrivateFoo() { }
            public abstract void AbstractFoo();
            public static void StaticFoo() { }
        }

        public class IsPublicConcreteInstanceShould
        {
            [Fact]
            public void BeTrue_WhenMethodIsPublicConcreteAndNonStatic()
            {
                var methodInfo = typeof(Foo).GetMethod(nameof(Foo.PublicFoo));

                var result = MethodInfoExtension.IsConcreteInstance(methodInfo);

                result.Should().BeTrue();
            }

            [Fact]
            public void BeFalse_WhenMethodIsAbstract()
            {
                var methodInfo = typeof(Foo).GetMethod(nameof(Foo.AbstractFoo));

                var result = MethodInfoExtension.IsConcreteInstance(methodInfo);

                result.Should().BeFalse();
            }

            [Fact]
            public void BeFalse_WhenMethodIsStatic()
            {
                var methodInfo = typeof(Foo).GetMethod(nameof(Foo.StaticFoo));

                var result = MethodInfoExtension.IsConcreteInstance(methodInfo);

                result.Should().BeFalse();
            }
        }

        public class IsPropertyShould
        {
            [Fact]
            public void BeTrue_WhenMethodIsAPropertyAccessor()
            {
                var methodInfo = typeof(Foo).GetMethod($"get_{nameof(Foo.PropertyFoo)}");
                var result = MethodInfoExtension.IsProperty(methodInfo);

                result.Should().BeTrue();
            }

            [Fact]
            public void BeTrue_WhenMethodIsAPropertyMutator()
            {
                var methodInfo = typeof(Foo).GetMethod($"set_{nameof(Foo.PropertyFoo)}");
                var result = MethodInfoExtension.IsProperty(methodInfo);

                result.Should().BeTrue();
            }

            [Fact]
            public void BeFalse_WhenMethodIsNotAProperty()
            {
                var methodInfo = typeof(Foo).GetMethod(nameof(Foo.PublicFoo));
                var result = MethodInfoExtension.IsProperty(methodInfo);

                result.Should().BeFalse();
            }
        }
    }
}
