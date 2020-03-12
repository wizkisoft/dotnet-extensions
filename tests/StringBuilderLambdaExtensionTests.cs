using System.Text;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Wizkisoft.DotNet.Extension.Test
{
    public static class StringBuilderLambdaExtensionTests
    {
        public class AppendShould
        {
            #region Append(this StringBuilder @this, Func<StringBuilder> func)

            [Fact]
            public void TakeAParameterlessFunctionThatReturnsGivenTypeAndExecuteIt()
            {
                var stringBuilder = new StringBuilder();

                var result = StringBuilderLambdaExtension.Append(stringBuilder, () => stringBuilder);

                result.Should().BeSameAs(stringBuilder);
            }

            #endregion

            #region Append(this StringBuilder @this, Func<StringBuilder, StringBuilder> func)

            [Fact]
            public void TakeSelfClassAsSingleParameterInFunctionThatReturnsGivenTypeAndExecuteIt()
            {
                var stringBuilder = new StringBuilder();

                var result = StringBuilderLambdaExtension.Append(stringBuilder, stringBuilder => stringBuilder);

                result.Should().BeSameAs(stringBuilder);
            }

            [Fact]
            public void ReturnTheStringOnAToStringCall()
            {
                var stringBuilder = new StringBuilder();

                var result = StringBuilderLambdaExtension.Append(stringBuilder, stringBuilder => stringBuilder.Append("Hello world!"));

                result.ToString().Should().Be("Hello world!");
            }

            #endregion

            #region Append(this StringBuilder @this, Func<string> func)

            [Fact]
            public void ExecuteFunctionThatReturnsAString()
            {
                var fixture = new Fixture();

                var stringBuilder = new StringBuilder();
                var str = fixture.Create<string>();

                var result = StringBuilderLambdaExtension.Append(stringBuilder, () => str);

                result.ToString().Should().Be(str);
            }

            #endregion
        }
    }
}
