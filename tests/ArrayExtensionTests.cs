using Xunit;
using AutoFixture;
using FluentAssertions;
using System;
using System.Linq;

namespace Wizkisoft.DotNet.Extension.Test
{
    public class ArrayExtensionTests
    {
        public class JoinAllShould : IDisposable
        {
            private Fixture fixture;
            private (string Foo, int Bar)[] arr;

            public JoinAllShould()
            {
                this.fixture = new Fixture();
                this.arr = fixture.Create<(string Foo, int Bar)[]>();
            }

            [Fact]
            public void JoinAll_GivenListOfElements_CombinesAllInstancesOfSinglePropertyInList()
            {
                Func<(string Foo, int Bar), string> transformFunc = i => i.Foo;

                var result = ArrayExtension.JoinAll(this.arr, ", ", transformFunc);

                result.Should().Be(string.Join(", ", this.arr.Select(transformFunc)));
            }

            [Fact]
            public void JoinAll_GivenListOfElements_CombinesTransformOfPropertiesInList()
            {
                Func<(string Foo, int Bar), string> transformFunc = i => (i.Bar + 1).ToString();

                var result = ArrayExtension.JoinAll(this.arr, ", ", transformFunc);

                result.Should().Be(string.Join(", ", this.arr.Select(transformFunc)));
            }

            [Fact]
            public void JoinAll_GivenListOfElements_CombinesAllInstancesOfSinglePropertiesSeparatedByGivenSeparator()
            {
                var separator = ", ";

                var result = ArrayExtension.JoinAll(this.arr, separator, i => i.Foo);

                result.Should().Be(string.Join(separator, this.arr.Select(i => i.Foo)));
            }

            public void Dispose()
            {
                this.fixture = null;
                this.arr = null;
            }
        }
    }
}
