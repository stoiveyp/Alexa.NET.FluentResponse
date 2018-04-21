using System.Linq;
using Alexa.NET.Request;
using Alexa.NET.Response.Directive;
using Xunit;

namespace Alexa.NET.FluentResponse.Tests
{
    public class DirectiveTests
    {
        [Fact]
        public void AddDelegateDirective()
        {
            var result = Fluent.Builder().AddDelegateDirective();
            Assert.NotNull(result);
            Assert.IsType<DialogDelegate>(result.Response.Response.Directives.First());

            var dialog = (DialogDelegate)result.Response.Response.Directives.First();
            Assert.Null(dialog.UpdatedIntent);
        }

        [Fact]
        public void AddDelegateDirectiveWithIntent()
        {
            var intent = new Intent();
            var result = Fluent.Builder().AddDelegateDirective(intent);
            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DialogDelegate>(result.Response.Response.Directives.First());

            var dialog = (DialogDelegate)result.Response.Response.Directives.First();
            Assert.Equal(intent,dialog.UpdatedIntent);
        }

        [Fact]
        public void AddElicitSlotDirective()
        {
            var slotName = "test";
            var result = Fluent.Builder().AddElicitSlotDirective(slotName);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DialogElicitSlot>(result.Response.Response.Directives.First());

            var dialog = (DialogElicitSlot)result.Response.Response.Directives.First();
            Assert.Equal(slotName, dialog.SlotName);
            Assert.Null(dialog.UpdatedIntent);
        }

        [Fact]
        public void AddElicitSlotDirectiveWithIntent()
        {
            var slotName = "test";
            var intent = new Intent();
            var result = Fluent.Builder().AddElicitSlotDirective(slotName, intent);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DialogElicitSlot>(result.Response.Response.Directives.First());

            var dialog = (DialogElicitSlot)result.Response.Response.Directives.First();
            Assert.Equal(intent, dialog.UpdatedIntent);
            Assert.Equal(slotName,dialog.SlotName);
        }

        [Fact]
        public void AddConfirmSlotDirective()
        {
            var slotName = "test";
            var result = Fluent.Builder().AddConfirmSlotDirective(slotName);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DialogConfirmSlot>(result.Response.Response.Directives.First());

            var dialog = (DialogConfirmSlot)result.Response.Response.Directives.First();
            Assert.Equal(slotName, dialog.SlotName);
            Assert.Null(dialog.UpdatedIntent);
        }

        [Fact]
        public void AddConfirmSlotDirectiveWithIntent()
        {
            var slotName = "test";
            var intent = new Intent();
            var result = Fluent.Builder().AddConfirmSlotDirective(slotName, intent);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DialogConfirmSlot>(result.Response.Response.Directives.First());

            var dialog = (DialogConfirmSlot)result.Response.Response.Directives.First();
            Assert.Equal(intent, dialog.UpdatedIntent);
            Assert.Equal(slotName, dialog.SlotName);
        }

        [Fact]
        public void AddConfirmIntentDirective()
        {
            var result = Fluent.Builder().AddConfirmIntentDirective();

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DialogConfirmIntent>(result.Response.Response.Directives.First());

            var dialog = (DialogConfirmIntent)result.Response.Response.Directives.First();
            Assert.Null(dialog.UpdatedIntent);
        }

        [Fact]
        public void AddConfirmIntentDirectiveWithIntent()
        {
            var intent = new Intent();
            var result = Fluent.Builder().AddConfirmIntentDirective(intent);

            Assert.NotNull(result);
            Assert.Single(result.Response.Response.Directives);
            Assert.IsType<DialogConfirmIntent>(result.Response.Response.Directives.First());
            var dialog = (DialogConfirmIntent)result.Response.Response.Directives.First();
            Assert.Equal(intent, dialog.UpdatedIntent);
        }
    }
}
