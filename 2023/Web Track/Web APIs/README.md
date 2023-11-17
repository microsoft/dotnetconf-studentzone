# Minimal API + SPA, a perfect match

## Abstract

ASP.NET Minimal API is a delightful way to create a HTTP backend for any application. Let's take a look at how we can combine that with a modern JavaScript framework to create a rich SPA experience.

## Link to Session Recording

[Event Recording](https://aka.ms/netconf23/studentstream)

## Overview

In this session, we will discuss building a Single Page App, aka a SPA, that uses ASP.NET Minimal API as the backend for the app to read and write data to a data store. We'll look at how we can set this up with VS Code to ensure a great developer experience. While the demo application uses React, the pattern covered is applicable to any JavaScript framework.

| **Goal**                                          | _describe the goal of the workshop_                                                               |
| ------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| **What will you learn**                           | How to combine a JavaScript SPA with ASP.NET Minimal API                                          |
| **What you'll need**                              | [VSCode](https://code.visualstudio.com), [.NET 8](https://dot.net), [Node.js](https://nodejs.org) |
| **Technology used**                               | [ASP.NET Minimal API](https://dotnet.microsoft.com/apps/aspnet), [React](https://react.dev)       |
| **Follow along**                                  | [`start`](./start)                                                                                |
| **Just want to try the app or see the solution?** | [`finished`](./finished)                                                                          |
| **Slides**                                        | [Powerpoint](2023-dotnet-conf-student-zone-minimal-api-react.pptx)                                                                         |

## Prerequisites

For the easiest setup, you can either use GitHub Codespaces or VS Code Devcontainers for the project.

[![Open in GitHub - Codespaces](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub+Codespaces&message=Open&color=brightgreen&logo=github)](https://github.com/codespaces/new?hide_repo_select=true&ref=main&repo=624102171&machine=standardLinux32gb&devcontainer_path=2023/Web+Track/Web+APIs/start/.devcontainer%2Fdevcontainer.json&location=WestUs2)
[![Open in Remote - Containers](https://img.shields.io/static/v1?style=for-the-badge&label=Remote%20-%20Containers&message=Open&color=blue&logo=visualstudiocode)](https://vscode.dev/redirect?url=vscode://ms-vscode-remote.remote-containers/cloneInVolume?url=https://github.com/microsoft/dotnetconf-studentzone)

To setup manually, you will need:

-   A text editor, such as [VS Code](https://code.visualstudio.com)
-   [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [Node.js](https://nodejs.org)

### Starter project notes

Within the [`start`](./start) folder, there are two projects that have been scaffolded, a React + Typescript frontend (in the `frontend` folder) and the ASP.NET Minimal API backend (in the `backend` folder). The data that will be used for the application is in the `data` folder.

## Speaker(s)

[**Aaron Powell**](https://twitter.com/slace) - Aaron is a Developer Advocate at Microsoft with a passion for JavaScript, .NET, whacky ideas and running long distances.

