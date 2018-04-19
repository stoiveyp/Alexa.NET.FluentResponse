using Alexa.NET.FluentResponse;
using Alexa.NET.Response;

namespace Alexa.NET.Response
{
    public static class FluentResponseExtensions
    {      

        public static IFluentResponse Fluent(this SkillResponse response)
        {
            return new FluentResponseBuilder(response);
        }
    }
}
