using System;
using System.Linq;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET.FluentResponse
{
    public class FluentResponseBuilder:IFluentResponse
    {
        IOutputSpeech _speech = null;
        Reprompt _reprompt = null;
        ICard _card = null;

        public SkillResponse Response => new SkillResponse { 
            Response = new ResponseBody {
                OutputSpeech = _speech,
                Reprompt = _reprompt,
                Card = _card
            } };

        public IFluentResponse AddSpeech(string text)
        {
            _speech = new PlainTextOutputSpeech { Text = text };
            return this;
        }

        public IFluentResponse AddSpeech(Speech speech)
        {
            _speech = new SsmlOutputSpeech { Ssml = speech.ToXml() };
            return this;
        }

        public IFluentResponse AddSpeech(IOutputSpeech speech)
        {
           _speech = speech;
            return this;
        }

		public IFluentResponse WithReprompt(string text)
        {
            _reprompt = new Reprompt { OutputSpeech = new PlainTextOutputSpeech { Text = text } };
            return this;
        }

        public IFluentResponse WithReprompt(Speech ssml)
        {
            _reprompt = new Reprompt { OutputSpeech = new SsmlOutputSpeech { Ssml = ssml.ToXml() } };
            return this;
        }

        public IFluentResponse WithReprompt(IOutputSpeech speech)
        {
            _reprompt = new Reprompt { OutputSpeech = speech };
            return this;            
        }

        public IFluentResponse WithSimpleCard(string title, string content)
        {
            _card = new SimpleCard { Title = title, Content = content };
            return this;
        }

		public IFluentResponse WithStandardCard(string title, string content)
		{
			return WithStandardCard(title, content, null, null);
		}

		public IFluentResponse WithStandardCard(string title, string content, string smallImageUri, string largeImageUri)
		{
			var card = new StandardCard { Title = title, Content = content };

			if(!string.IsNullOrWhiteSpace(smallImageUri) || !string.IsNullOrWhiteSpace(largeImageUri))
			{
				card.Image = new CardImage { SmallImageUrl = smallImageUri, LargeImageUrl = largeImageUri };
			}

			_card = card;
			return this;
		}

        public IFluentResponse WithLinkAccountCard()
        {
            _card = new LinkAccountCard();
            return this;
        }

        public IFluentResponse WithAskForPermissionConsentCard(params string[] permissions)
        {
            _card = new AskForPermissionsConsentCard{Permissions=permissions.ToList()};
            return this;
        }
    }
}
