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
            var response = new SkillResponse();
            var result = response.Fluent().AddSpeech("test");
            Assert.IsType<PlainTextOutputSpeech>(response.Response.OutputSpeech);
            var plainText = (PlainTextOutputSpeech)response.Response.OutputSpeech;
            Assert.Equal("test", plainText.Text);
            Assert.NotNull(result);
        }

        [Fact]
        public void AddSpeechSsml()
        {
            var response = new SkillResponse();
            var result = response.Fluent().AddSpeech(new Speech(new PlainText("test")));
            Assert.IsType<SsmlOutputSpeech>(response.Response.OutputSpeech);
            var plainText = (SsmlOutputSpeech)response.Response.OutputSpeech;
            Assert.Equal("<speak>test</speak>", plainText.Ssml);
            Assert.NotNull(result);     
        }
    }
}
