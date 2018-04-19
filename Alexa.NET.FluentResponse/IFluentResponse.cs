using System;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET.FluentResponse
{
    public interface IFluentResponse
    {
        SkillResponse Response { get; }

        IFluentResponse AddSpeech(string text);
        IFluentResponse AddSpeech(Speech speech);
        IFluentResponse AddSpeech(IOutputSpeech speech);
    }
}
