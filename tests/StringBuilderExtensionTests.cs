using System.Text;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Wizkisoft.DotNet.Extension.Test
{
    public static class StringBuilderExtensionTests
    {
        public class AppendTabShould
        {
            [Fact]
            public void DefaultToSingleTab_WhenNoIndentSizeSpecified()
            {
                var result = StringBuilderExtension.AppendTab(new StringBuilder());

                result.ToString().Should().Be("    ");
            }

            [Fact]
            public void OutputNumberOfTabs_EqualToIndentNumberGiven()
            {
                var fixture = new Fixture();

                var indent = fixture.Create<int>();
                var expected = GetTabString();

                var result = StringBuilderExtension.AppendTab(new StringBuilder(), indent);

                result.ToString().Should().Be(expected);

                string GetTabString()
                {
                    var result = "";
                    for (int i = 0; i < indent; i++) result += "    ";
                    return result;
                }
            }
        }

        public class AppendSpaceShould
        {
            [Fact]
            public void OutputSingleSpace()
            {
                var result = StringBuilderExtension.AppendSpace(new StringBuilder());

                result.ToString().Should().Be(" ");
            }
        }
    }
}
