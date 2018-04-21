using System;
using System.Linq;
using Alexa.NET.Response.Directive;
using Xunit;

namespace Alexa.NET.FluentResponse.Tests
{
    public class AudioTests
    {
        [Fact]
        public void AddAudioPlayerDirective()
        {
            var uri = "test.com";
            var previousToken = "previous";
            var result = Fluent.Builder().AddAudioPlayerPlayDirective(PlayBehavior.Enqueue,uri,0,previousToken);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<AudioPlayerPlayDirective>(result.Response.Response.Directives.First());

            var dialog = (AudioPlayerPlayDirective)result.Response.Response.Directives.First();
            Assert.Equal(PlayBehavior.Enqueue, dialog.PlayBehavior);
            Assert.Equal(uri,dialog.AudioItem.Stream.Url);
            Assert.Equal(0,dialog.AudioItem.Stream.OffsetInMilliseconds);
            Assert.Equal(previousToken,dialog.AudioItem.Stream.Token);
        }

        [Fact]
        public void AddPlayerStopDirective()
        {
            var result = Fluent.Builder().AddAudioPlayerStopDirective();

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<StopDirective>(result.Response.Response.Directives.First());
        }

        [Fact]
        public void AddClearQueueDirective()
        {
            var behavior = ClearBehavior.ClearEnqueued;
            var result = Fluent.Builder().AddAudioPlayerClearQueueDirective(behavior);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<ClearQueueDirective>(result.Response.Response.Directives.First());

            var dialog = (ClearQueueDirective)result.Response.Response.Directives.First();
            Assert.Equal(ClearBehavior.ClearEnqueued, dialog.ClearBehavior);
        }
    }
}
