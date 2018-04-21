using System;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET.FluentResponse
{
    public interface IFluentResponse
    {
        SkillResponse Response { get; }

        IFluentResponse Speak(string text);
        IFluentResponse Speak(Speech speech);
        IFluentResponse Speak(IOutputSpeech speech);

        IFluentResponse Reprompt(string text);
        IFluentResponse Reprompt(Speech ssml);
        IFluentResponse Reprompt(IOutputSpeech output);

        IFluentResponse WithSimpleCard(string title, string content);
		IFluentResponse WithStandardCard(string title, string content);
		IFluentResponse WithStandardCard(string title, string content, string smallImageUri, string largeImageUri);
		IFluentResponse WithLinkAccountCard();
        IFluentResponse WithAskForPermissionConsentCard(params string[] permissions);

        IFluentResponse AddDelegateDirective();
        IFluentResponse AddDelegateDirective(Intent updatedIntent);
        IFluentResponse AddElicitSlotDirective(string slotName);
        IFluentResponse AddElicitSlotDirective(string slotName, Intent updatedIntent);
        IFluentResponse AddConfirmSlotDirective(string slotName);
        IFluentResponse AddConfirmSlotDirective(string slotName, Intent updatedIntent);
        IFluentResponse AddConfirmIntentDirective();
        IFluentResponse AddConfirmIntentDirective(Intent updatedIntent);
        IFluentResponse AddAudioPlayerPlayDirective(PlayBehavior behavior, string url, int offsetMilliseconds, string previousToken);
        IFluentResponse AddAudioPlayerStopDirective();
        IFluentResponse AddAudioPlayerClearQueueDirective(ClearBehavior behavior);
    }
}
