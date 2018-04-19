using System;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;

namespace Alexa.NET.FluentResponse
{
    public class FluentResponseBuilder:IFluentResponse
    {
		private SkillResponse _response;

        public FluentResponseBuilder(SkillResponse response)
        {
			_response = response;
            if(_response.Response == null)
            {
                _response.Response = new ResponseBody();
            }
        }

        public SkillResponse Response => _response;

        public IFluentResponse AddSpeech(string text)
        {
            _response.Response.OutputSpeech = new PlainTextOutputSpeech { Text = text };
            return this;
        }

        public IFluentResponse AddSpeech(Speech speech)
        {
            _response.Response.OutputSpeech = new SsmlOutputSpeech { Ssml = speech.ToXml() };
            return this;
        }

        public IFluentResponse AddSpeech(IOutputSpeech speech)
        {
            _response.Response.OutputSpeech = speech;
            return this;
        }
    }
}
