using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Wizkisoft.DotNet.Extension.Test
{
    public class StringExtensionTests
    {
        public class RemoveEverythingAfterTickShould
        {
            [Fact]
            public void ReturnTheOriginalString_WhenNoTickMarksExist()
            {
                var fixture = new Fixture();
                var str = fixture.Create<string>();

                var result = StringExtension.RemoveEverythingAfterTick(str);

                result.Should().Be(str);
            }

            [Fact]
            public void RemoveEverythingFromStringStartingAtFirstTickCharacter()
            {
                var fixture = new Fixture();
                var firstHalf = fixture.Create<string>();
                var secondHalf = fixture.Create<string>();
                var str = $"{firstHalf}`{secondHalf}";

                var result = StringExtension.RemoveEverythingAfterTick(str);

                result.Should().Be(firstHalf);
            }
        }
    }
}
