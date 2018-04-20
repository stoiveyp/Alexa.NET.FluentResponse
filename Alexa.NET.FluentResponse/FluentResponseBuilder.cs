using System;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET.FluentResponse
{
    public class FluentResponseBuilder:IFluentResponse
    {
        IOutputSpeech _speech = null;
        Reprompt _reprompt = null;

        public SkillResponse Response => new SkillResponse { 
            Response = new ResponseBody {
                OutputSpeech = _speech,
                Reprompt = _reprompt
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
    }
}
