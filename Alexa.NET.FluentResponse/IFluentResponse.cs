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

        IFluentResponse WithReprompt(string text);
        IFluentResponse WithReprompt(Speech ssml);
        IFluentResponse WithReprompt(IOutputSpeech output);

        IFluentResponse WithSimpleCard(string title, string content);
		IFluentResponse WithStandardCard(string title, string content);
		IFluentResponse WithStandardCard(string title, string content, string smallImageUri, string largeImageUri);
		IFluentResponse WithLinkAccountCard();
    }
}
