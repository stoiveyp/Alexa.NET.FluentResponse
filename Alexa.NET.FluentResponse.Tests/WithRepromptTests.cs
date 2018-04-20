using System;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;
using Xunit;

namespace Alexa.NET.FluentResponse.Tests
{
    public class WithRepromptTests
    {
        [Fact]
        public void PlainTextReprompt()
        {
            var response = Fluent.Builder().WithReprompt("huh").Response;
            Assert.NotNull(response.Response.Reprompt);
            Assert.NotNull(response.Response.Reprompt.OutputSpeech);
            Assert.IsType<PlainTextOutputSpeech>(response.Response.Reprompt.OutputSpeech);
            var reprompt = (PlainTextOutputSpeech)response.Response.Reprompt.OutputSpeech;
            Assert.Equal("huh", reprompt.Text);
        }

        [Fact]
        public void SsmlReprompt(){
            var response = Fluent.Builder().WithReprompt(new Speech(new PlainText("huh"))).Response;
            Assert.NotNull(response.Response.Reprompt);
            Assert.NotNull(response.Response.Reprompt.OutputSpeech);
            Assert.IsType<SsmlOutputSpeech>(response.Response.Reprompt.OutputSpeech);
            var reprompt = (SsmlOutputSpeech)response.Response.Reprompt.OutputSpeech;
            Assert.Equal("<speak>huh</speak>", reprompt.Ssml);
        }

        [Fact]
        public void OutputReprompt()
        {
            var output = new PlainTextOutputSpeech { Text = "huh" };
            var response = Fluent.Builder().WithReprompt(output).Response;
            Assert.NotNull(response.Response.Reprompt);
            Assert.NotNull(response.Response.Reprompt.OutputSpeech);
            Assert.Equal(output, response.Response.Reprompt.OutputSpeech);
        }
    }
}
