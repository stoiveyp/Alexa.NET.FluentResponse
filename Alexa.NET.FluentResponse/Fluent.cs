using Alexa.NET.FluentResponse;
using Alexa.NET.Response;

namespace Alexa.NET
{
    public static class Fluent
    {      
        public static IFluentResponse Builder()
        {
            return new FluentResponseBuilder();
        }
    }
}
