# Twitter
A simple console app to demonstrate Twitter-like functions.

## How to run
The app is written in C# using Visual Studio 2017 targeting .NET Framework 4.6.1. You must have .NET Framework 4.6.1+ installed.
- Open Twitter.sln file in Visual Studio
- Build solution by either from the menu under **Build** or using a shortcut, Ctrl+Shift+B
- Start without debugging by either from the menu under **Debug** or using a shortcut, Ctrl+F5

## Test ##
- Open a Test Explorer from the menu **Test > Windows > Test Explorer**
- Click **Run All** link on top of the Test Explorer pane

## Architecture
Top level folders represent layers which could have been individual projects. The folders are organised with clean architecture in mind.
- Application
- Domain
- Persistance
- Common

## Requirements of this exercise
Implement a console-based social networking application (similar to Twitter ) satisfying the scenarios
below.

### Features
**Posting**: A lice can publish messages to a personal timeline

> Alice -> I love the weather today

> Bob -> Damn! We lost!

> Bob -> Good game though.

**Reading**: I can view Alice and Bob’s timelines

> Alice

* I love the weather today (5 minutes ago)

> Bob

* Good game though. (1 minute ago)

* Damn! We lost! (2 minutes ago)

**Following**: Charlie can subscribe to Alice’s and Bob’s timelines, and view an aggregated list of all
subscriptions

> Charlie -> I'm in New York today! Anyone want to have a coffee?

> Charlie follows Alice

> Charlie wall

* Charlie - I'm in New York today! Anyone want to have a coffee? (2 seconds ago)
* Alice - I love the weather today (5 minutes ago)

> Charlie follows Bob

> Charlie wall

* Charlie - I'm in New York today! Anyone wants to have a coffee? (15 seconds ago)
* Bob - Good game though. (1 minute ago)
* Bob - Damn! We lost! (2 minutes ago)
* Alice - I love the weather today (5 minutes ago)

### Details

- The application must use the console for input and output.
- Users submit commands to the application. There are four commands. “posting”, “reading”, etc.
are not part of the commands; commands always start with the user’s name.

1. posting : {username} -> {message}
2. reading : {username}
3. following : {username} follows {another user}
4. wall : {username} wall
  
- Don't worry about handling any exceptions or invalid commands. Assume that the user will
always type the correct commands. Just focus on the sunny day scenarios.
- Don’t bother making it work over a network or across processes. It can all be done in memory,
assuming that users will all use the same terminal.
- Non-existing users should be created as they post their first message. Application should not start
with a pre-defined list of users.

