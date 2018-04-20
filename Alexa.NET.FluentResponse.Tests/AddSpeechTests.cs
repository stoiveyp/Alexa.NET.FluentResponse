using System;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;
using Xunit;

namespace Alexa.NET.FluentResponse.Tests
{
    public class AddSpeechTests
    {
        [Fact]
        public void AddSpeechPlain()
        {
            var response = Fluent.Builder().AddSpeech("test").Response;
            Assert.IsType<PlainTextOutputSpeech>(response.Response.OutputSpeech);
            var plainText = (PlainTextOutputSpeech)response.Response.OutputSpeech;
            Assert.Equal("test", plainText.Text);
            Assert.NotNull(response);
        }

        [Fact]
        public void AddSpeechSsml()
        {
            var result = Fluent.Builder().AddSpeech(new Speech(new PlainText("test"))).Response;
            Assert.IsType<SsmlOutputSpeech>(result.Response.OutputSpeech);
            var plainText = (SsmlOutputSpeech)result.Response.OutputSpeech;
            Assert.Equal("<speak>test</speak>", plainText.Ssml);
            Assert.NotNull(result);     
        }

        [Fact]
        public void AddIOutputSpeech()
        {
            var output = new PlainTextOutputSpeech { Text = "xxx" };
            var result = Fluent.Builder().AddSpeech(output).Response;
            Assert.NotNull(result);
            Assert.Equal(output, result.Response.OutputSpeech);
        }
    }
}
