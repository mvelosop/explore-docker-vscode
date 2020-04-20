# explore-docker-vscode

This is a repo to explore Docker-related development with VS Code.

## Initial setup

- Create `src`, `src\WebApi`, and `src\WebApp` folders

  ```powershell
  md src
  md src/WebApi
  md src/WebApp
  ```

- Create default WebApi and WebApp .NET Core applications

  ```powershell
  cd src
  dotnet new webapi --name WebApi --output WebApi
  dotnet new webapp --name WebApp --output WebApp
  ```

- Create a solution file in the src folder and add both projects to the solution

  ```powershell
  dotnet new sln -n explore-docker-vscode
  dotnet sln explore-docker-vscode.sln add WebApi/WebApi.csproj
  dotnet sln explore-docker-vscode.sln add WebApp/WebApp.csproj
  ```

The project should look similar to this:

![](media/initial-project-setup.png)

## Run both applications from VS Code

We'll have both applications running from VS Code so we can then update the `WebApp` application to consume the WebApi REST API to display a web page.

Install the VS Code extensions to work with C#, as explained in the [Working with C#](https://code.visualstudio.com/docs/languages/csharp) documentation page.

Respond with `Yes` when you get a notification like the following to install build and debug assets:

![](media/install-build-and-debug-assets.png)

Configure the **`applicationUrl`** properties in `Properties/launchSettings.json` for both applications so they use different ports, as shown next:

For the **WebApi** application:

```json
{
  //...
    "WebApi": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "weatherforecast",
      "applicationUrl": "https://localhost:51443;http://localhost:51080",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

For the **WebApp** application:

```json
{
  //...
    "WebApp": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:50443;http://localhost:50080",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

Configure launch settings for the WebApi and WebApp applications, as explained in the [Debugging](https://code.visualstudio.com/Docs/editor/debugging) documentation page.

## Additional resources

- **Integrate with External Tools via Tasks** \
  <https://code.visualstudio.com/docs/editor/tasks>

- **Debugging - Multi-target debugging** \
  <https://code.visualstudio.com/Docs/editor/debugging#_multitarget-debugging>

- **Configuring launch.json for C# debugging** \
  <https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger-launchjson.md#starting-a-web-browser>
