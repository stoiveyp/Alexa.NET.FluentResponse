# Alexa.NET.FluentResponse
Small helper library that allows you to create Alexa.NET Responses using a fluent interface

### Creating a simple response
```csharp
Fluent
  .Speak("hello world").Response;
```

### Adding a card and end the session
```csharp
Fluent
  .Speak("here's a card")
  .WithSimpleCard("title","card content")
  .AndShouldEndSession(true)
  .Response;
```

### Creating a response, reprompt and maintain the current session
```csharp
Fluent
  .Speak("are you ok?")
  .Reprompt("I said are you okay?")
  .WithSession(sessionDictionary)
  .Response;
```