using System;
using System.Collections.Generic;
using System.Linq;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET.FluentResponse
{
    public class FluentResponseBuilder : IFluentResponse
    {
        private IOutputSpeech Speech;
        private Reprompt SpeechReprompt;
        private ICard Card;
        private readonly List<IDirective> Directives = new List<IDirective>();
        private bool? _shouldEndSession = null;

        public SkillResponse Response => new SkillResponse
        {
            Response = new ResponseBody
            {
                OutputSpeech = Speech,
                Reprompt = SpeechReprompt,
                Card = Card,
                Directives = Directives,
                ShouldEndSession = _shouldEndSession
            }
        };

        public IFluentResponse Speak(string text)
        {
            Speech = new PlainTextOutputSpeech { Text = text };
            return this;
        }

        public IFluentResponse Speak(Speech speech)
        {
            Speech = new SsmlOutputSpeech { Ssml = speech.ToXml() };
            return this;
        }

        public IFluentResponse Speak(IOutputSpeech speech)
        {
            Speech = speech;
            return this;
        }

        public IFluentResponse Reprompt(string text)
        {
            SpeechReprompt = new Reprompt { OutputSpeech = new PlainTextOutputSpeech { Text = text } };
            return this;
        }

        public IFluentResponse Reprompt(Speech ssml)
        {
            SpeechReprompt = new Reprompt { OutputSpeech = new SsmlOutputSpeech { Ssml = ssml.ToXml() } };
            return this;
        }

        public IFluentResponse Reprompt(IOutputSpeech speech)
        {
            SpeechReprompt = new Reprompt { OutputSpeech = speech };
            return this;
        }

        public IFluentResponse WithSimpleCard(string title, string content)
        {
            Card = new SimpleCard { Title = title, Content = content };
            return this;
        }

        public IFluentResponse WithStandardCard(string title, string content)
        {
            return WithStandardCard(title, content, null, null);
        }

        public IFluentResponse WithStandardCard(string title, string content, string smallImageUri, string largeImageUri)
        {
            var card = new StandardCard { Title = title, Content = content };

            if (!string.IsNullOrWhiteSpace(smallImageUri) || !string.IsNullOrWhiteSpace(largeImageUri))
            {
                card.Image = new CardImage { SmallImageUrl = smallImageUri, LargeImageUrl = largeImageUri };
            }

            Card = card;
            return this;
        }

        public IFluentResponse WithLinkAccountCard()
        {
            Card = new LinkAccountCard();
            return this;
        }

        public IFluentResponse WithAskForPermissionConsentCard(params string[] permissions)
        {
            Card = new AskForPermissionsConsentCard { Permissions = permissions.ToList() };
            return this;
        }

        public IFluentResponse AddDelegateDirective()
        {
            Directives.Add(new DialogDelegate());
            return this;
        }

        public IFluentResponse AddDelegateDirective(Intent updatedIntent)
        {
            Directives.Add(new DialogDelegate { UpdatedIntent = updatedIntent });
            return this;
        }

        public IFluentResponse AddElicitSlotDirective(string slotName)
        {
            Directives.Add(new DialogElicitSlot(slotName));
            return this;
        }

        public IFluentResponse AddElicitSlotDirective(string slotName, Intent updatedIntent)
        {
            Directives.Add(new DialogElicitSlot(slotName) { UpdatedIntent = updatedIntent });
            return this;
        }

        public IFluentResponse AddConfirmSlotDirective(string slotName)
        {
            Directives.Add(new DialogConfirmSlot(slotName));
            return this;
        }

        public IFluentResponse AddConfirmSlotDirective(string slotName, Intent updatedIntent)
        {
            Directives.Add(new DialogConfirmSlot(slotName) { UpdatedIntent = updatedIntent });
            return this;
        }

        public IFluentResponse AddConfirmIntentDirective()
        {
            Directives.Add(new DialogConfirmIntent());
            return this;
        }

        public IFluentResponse AddConfirmIntentDirective(Intent updatedIntent)
        {
            Directives.Add(new DialogConfirmIntent { UpdatedIntent = updatedIntent });
            return this;
        }

        public IFluentResponse AddAudioPlayerPlayDirective(PlayBehavior behavior, string url, int offsetMilliseconds,
            string previousToken)
        {
            Directives.Add(new AudioPlayerPlayDirective
            {
                PlayBehavior = behavior,
                AudioItem = new AudioItem
                {
                    Stream = new AudioItemStream
                    {
                        Token = previousToken,
                        Url = url,
                        OffsetInMilliseconds = offsetMilliseconds
                    }
                }
            });
            return this;
        }

        public IFluentResponse AddAudioPlayerStopDirective()
        {
            Directives.Add(new StopDirective());
            return this;
        }

        public IFluentResponse AddAudioPlayerClearQueueDirective(ClearBehavior behavior)
        {
            Directives.Add(new ClearQueueDirective{ClearBehavior = behavior});
            return this;
        }
    }
}
