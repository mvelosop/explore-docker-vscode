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
