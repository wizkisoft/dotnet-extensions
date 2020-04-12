using Xunit;
using AutoFixture;
using FluentAssertions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Wizkisoft.DotNet.Extension.Test
{
    public class IEnumerableExtensionTests
    {
        public class ForEachShould
        {
            [Fact]
            public void PerformGivenActionOnEachItemInCollection()
            {
                var fixture = new Fixture();
                var arr = fixture.Create<List<(string Foo, int Bar)>>();

                var counter = 0;
                void act((string Foo, int Bar) i) => ++counter;

                IEnumerableExtension.ForEach(arr, act);

                counter.Should().Be(arr.Count());
            }
        }
    }
}
