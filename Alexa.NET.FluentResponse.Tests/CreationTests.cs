using System.Collections.Generic;
using Xunit;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET.FluentResponse.Tests
{
    public class CreationTests
    {      
        [Fact]
        public void FluentBuilderGenerates()
		{
            var builder = Fluent.Builder();
			Assert.NotNull(builder);
		}

        [Fact]
        public void FluentBuilderSpeakPlainlyGenerates()
        {
            var speech = "test";
            var response = Fluent.Speak(speech).Response;

            Assert.IsType<PlainTextOutputSpeech>(response.Response.OutputSpeech);
            var plainText = (PlainTextOutputSpeech)response.Response.OutputSpeech;
            Assert.Equal(speech, plainText.Text);
            Assert.NotNull(response);
        }

        [Fact]
        public void FluentBuilderSpeakSsmlGenerates()
        {
            var result = Fluent.Speak(new Speech(new PlainText("test"))).Response;
            Assert.IsType<SsmlOutputSpeech>(result.Response.OutputSpeech);
            var plainText = (SsmlOutputSpeech)result.Response.OutputSpeech;
            Assert.Equal("<speak>test</speak>", plainText.Ssml);
            Assert.NotNull(result);
        }

        [Fact]
        public void FluentBuilderOutputGenerate()
        {
            var output = new PlainTextOutputSpeech { Text = "xxx" };
            var result = Fluent.Speak(output).Response;
            Assert.NotNull(result);
            Assert.Equal(output, result.Response.OutputSpeech);
        }

        [Fact]
        public void AndShouldEndSessionEndsAccordingly()
        {
            var response = Fluent.Builder().AndShouldEndSession(true);
            Assert.NotNull(response);
            Assert.True(response.Response.Response.ShouldEndSession);
        }

        [Fact]
        public void AndSendSession()
        {
            var session = new Dictionary<string, object>();
            var response = Fluent.Builder().WithSession(session);
            Assert.NotNull(response);
            Assert.Equal(session,response.Response.SessionAttributes);
        }
    }
}
