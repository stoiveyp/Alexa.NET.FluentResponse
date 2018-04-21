using System;
using Alexa.NET.Response;
using Xunit;

namespace Alexa.NET.FluentResponse.Tests
{
    public class CardTests
    {
        [Fact]
        public void SimpleCard()
        {
            var builder = Fluent.Builder();
            var result = builder.WithSimpleCard("title", "content");
            Assert.NotNull(result);
			Assert.Equal(builder, result);

            var card = (SimpleCard)result.Response.Response.Card;

            Assert.Equal("title", card.Title);
            Assert.Equal("content", card.Content);
        }

        [Fact]
        public void StandardCardNoImage()      
		{
			var builder = Fluent.Builder();
            var result = builder.WithStandardCard("title", "content");
            Assert.NotNull(result);
            Assert.Equal(builder, result);

			var card = (StandardCard)result.Response.Response.Card;	
			Assert.Equal("title", card.Title);
            Assert.Equal("content", card.Content);
			Assert.Null(card.Image);
		}

        [Fact]
        public void StandardCardWithImage()
		{
			var smallUri = "https://test/image1.png";
			var largeUri = "https://test/image2.png";
			var builder = Fluent.Builder();
            var result = builder.WithStandardCard("title", "content", smallUri, largeUri);
            Assert.NotNull(result);
            Assert.Equal(builder, result);

            var card = (StandardCard)result.Response.Response.Card;
            Assert.Equal("title", card.Title);
            Assert.Equal("content", card.Content);
            Assert.NotNull(card.Image);
			Assert.Equal(smallUri, card.Image.SmallImageUrl);
			Assert.Equal(largeUri, card.Image.LargeImageUrl);
		}

        [Fact]
        public void WithLinkAccountCard()
		{
			var builder = Fluent.Builder();
			var result = builder.WithLinkAccountCard();

			Assert.NotNull(result);
            Assert.Equal(builder, result);
			Assert.IsType<LinkAccountCard>(result.Response.Response.Card);
		}
    }
}
