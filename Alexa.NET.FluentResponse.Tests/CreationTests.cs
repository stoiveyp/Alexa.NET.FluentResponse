using Xunit;
using Alexa.NET.Response;

namespace Alexa.NET.FluentResponse.Tests
{
    public class CreationTests
    {      
        [Fact]
        public void FromSpeechGeneratesBuilder()
		{
			var builder = new SkillResponse().Fluent();
			Assert.NotNull(builder);
		}

        [Fact]
        public void ResponsePropertyAccessesOriginalResponse()
        {
            var response = new SkillResponse();
            var result = response.Fluent().Response;
            Assert.Equal(result, response);
        }
    }
}
