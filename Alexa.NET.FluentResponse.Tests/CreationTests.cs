using Xunit;
using Alexa.NET.Response;

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
    }
}
