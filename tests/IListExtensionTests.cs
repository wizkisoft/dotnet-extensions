using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using AutoFixture;

namespace Wizkisoft.DotNet.Extension.Test
{
    public class IListExtensionTests
    {
        public class AddIfShould
        {
            [Fact]
            public void AddItemToList_WhenConditionIsTrue()
            {
                var fixture = new Fixture();

                var list = new List<string>();
                var item = fixture.Create<string>();

                var result = IListExtension.AddIf(list, true, item);

                result.Should().Contain(item);
            }
            [Fact]
            public void NotAddItemToList_WhenConditionIsFalse()
            {
                var fixture = new Fixture();

                var list = new List<string>();
                var item = fixture.Create<string>();

                var result = IListExtension.AddIf(list, false, item);

                result.Should().NotContain(item);
            }
        }
    }
}
