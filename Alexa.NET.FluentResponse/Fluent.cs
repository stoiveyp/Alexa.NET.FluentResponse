using Alexa.NET.FluentResponse;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET
{
    public static class Fluent
    {      
        public static IFluentResponse Builder()
        {
            return new FluentResponseBuilder();
        }

        public static IFluentResponse Speak(string text)
        {
            return Builder().Speak(text);
        }

        public static IFluentResponse Speak(Speech speech)
        {
            return Builder().Speak(speech);
        }

        public static IFluentResponse Speak(IOutputSpeech output)
        {
            return Builder().Speak(output);
        }
    }
}
