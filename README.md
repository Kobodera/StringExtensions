# StringExtensions
A Class library containing useful string extensions

While doing things at home I always end up creating the same basic string extensions over and over again. I finally got tired of
doing the same thing over and over again so I started doing it in a more serious way that I can reuse in my other projects.

The basic functionality I always seem to add to my projects are these

ToInt - Converts a string to an integer
ToNullableInt - Converts a string to an integer. Empty strings are returned as null
ToDouble - Converts a string to a double
ToNullableDouble - Converts a double to an integer. Empty strings are returned as null
Cleanup - Removes parts of the string, case insensitive
Replace - The original replace method is case sensitive. This extension method give the user the ability to ignore case
