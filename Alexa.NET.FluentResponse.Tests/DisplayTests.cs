using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexa.NET.Response.Directive;
using Alexa.NET.Response.Directive.Templates.Types;
using Xunit;

namespace Alexa.NET.FluentResponse.Tests
{
    public class DisplayTests
    {
        [Fact]
        public void AddRenderDirective()
        {
            var renderTemplate = new BodyTemplate7 {Title = "title"};
            var result = Fluent.Builder().AddRenderTemplateDirective(renderTemplate);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DisplayRenderTemplateDirective>(result.Response.Response.Directives.First());

            var dialog = (DisplayRenderTemplateDirective)result.Response.Response.Directives.First();
            Assert.Equal(renderTemplate,dialog.Template);
        }

        [Fact]
        public void AddHintDirective()
        {
            var hint = "this is a hint";
            var result = Fluent.Builder().AddHintDirective(hint);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<HintDirective>(result.Response.Response.Directives.First());

            var dialog = (HintDirective)result.Response.Response.Directives.First();
            Assert.Equal(hint, dialog.Hint.Text);
        }

        [Fact]
        public void AddVideoAppLaunchDirective()
        {
            var url = "test.com";
            var result = Fluent.Builder().AddVideoAppLaunchDirective(url);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<VideoAppDirective>(result.Response.Response.Directives.First());

            var directive = (VideoAppDirective)result.Response.Response.Directives.First();
            Assert.Equal(url, directive.VideoItem.Source);
            Assert.Null(directive.VideoItem.Metadata);
        }

        [Fact]
        public void AddVideoAppLaunchDirectiveWithText()
        {
            var url = "test.com";
            var title = "title";
            var subtitle = "subtitle";
            var result = Fluent.Builder().AddVideoAppLaunchDirective(url,title,subtitle);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<VideoAppDirective>(result.Response.Response.Directives.First());

            var directive = (VideoAppDirective)result.Response.Response.Directives.First();
            Assert.Equal(url, directive.VideoItem.Source);
            Assert.Equal(title, directive.VideoItem.Metadata.Title);
            Assert.Equal(subtitle, directive.VideoItem.Metadata.Subtitle);
        }
    }
}
