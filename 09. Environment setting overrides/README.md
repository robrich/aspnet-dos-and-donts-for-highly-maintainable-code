Environment-specific settings
=============================

It is really helpful to extract settings to a file that can be customized per environment.

Here's the best practice for settings:

1. Things that don't change should be in appsettings.json.

2. Things that change per environment should be in appsettings.ENV.json.

3. Things that are user-specific or override other appsettings should be in user secrets. Examples could be connection strings and security keys. Get to user secrets by right-clicking the project in Visual Studio and choosing user settings. This file is stored in `%appdata%`.  Add this content to the file:

```
{
  "Settings": {
    "UserSpecific": "user-specific value not in source control"
  }
}
```
