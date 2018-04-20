using System;
using Alexa.NET.Response;
using Xunit;

namespace Alexa.NET.FluentResponse.Tests
{
    public class WithSimpleCardTests
    {
        [Fact]
        public void ExtensionAddsCard()
        {
            var builder = Fluent.Builder();
            var result = builder.WithSimpleCard("title", "content");
            Assert.NotNull(result);
			Assert.Equal(builder, result);

            var card = (SimpleCard)result.Response.Response.Card;

            Assert.Equal("title", card.Title);
            Assert.Equal("content", card.Content);
        }
    }
}
