# explore-docker-vscode

This is a repo to explore Docker-related development with VS Code.

## Initial setup

- Edit the `.gitignore` file to include VS Code workspace files in source control

  ```
  !*.code-workspace
  ```

- Create `src`, `src\WebApi`, and `src\WebApp` folders

  ```powershell
  md src
  md src/WebApi
  md src/WebApp
  ```

- Create default WebApi and WebApp .NET Core applications

  ```dotnetcli
  dotnet new webapi --name WebApi --output src/WebApi
  dotnet new webapp --name WebApp --output src/WebApp
  ```

- Add the `src/WebApi` and `src/WebApp` folders as Workspace folders to the project as explained in the [Multi-root Workspaces](https://code.visualstudio.com/docs/editor/multi-root-workspaces) documentation page.

- Save the workspace file as `explore-docker-vscode.code-workspace`

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
