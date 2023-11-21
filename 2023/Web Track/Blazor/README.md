# Building an intelligent app with Blazor and Azure OpenAI

## Abstract

Let's build a Blazor application to summarise lengthy YouTube video using Azure OpenAI! Throughout this session, I'm going to quickly show you how to set up Blazor WebAssembly application, build reusable components, talk to backend APIs and integrate with JavaScript UI components.

## Link to Session Recording

[Event Recording](https://aka.ms/netconf23/studentstream)

## Overview

In this session, we will discuss how to start Blazor application development, build reusable components, add dependency injection and integrate with JavaScript UI components. We'll look at how we can set this up with GitHub Codespaces with C# Dev Kit to ensure a great developer experience. While the demo application uses Blazor Server, the pattern covered is applicable to any Blazor application.

| **Goal**                                          | *describe the goal of the workshop*                               |
| ------------------------------------------------- | ----------------------------------------------------------------- |
| **What will you learn**                           | How to build a Blazor Server application with reusable components |
| **What you'll need**                              | [Visual Studio Code](https://code.visualstudio.com?WT.mc_id=dotnet-104896-juyoo) or [GitHub Codespaces](https://docs.github.com/codespaces/overview), [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit&WT.mc_id=dotnet-104896-juyoo), [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0?WT.mc_id=dotnet-104896-juyoo) |
| **Technology used**                               | [ASP.NET Blazor](https://learn.microsoft.com/aspnet/core/blazor/?view=aspnetcore-8.0&WT.mc_id=dotnet-104896-juyoo), [Fluent UI](https://developer.microsoft.com/fluentui?WT.mc_id=dotnet-104896-juyoo) |
| **Follow along**                                  | [start](./start)                                                  |
| **Just want to try the app or see the solution?** | [complete](./complete/)                                           |
| **Slides** | [PDF](slides.pdf)                                                                                |

## Prerequisites

First of all, you may need the following:

- [Azure free subscription for students](https://azure.microsoft.com/free/students?WT.mc_id=dotnet-104896-juyoo)
- [Azure OpenAI Service](https://learn.microsoft.com/azure/ai-services/openai/overview?WT.mc_id=dotnet-104896-juyoo) &ndash; If you don't have it yet, [apply it](https://aka.ms/oaiapply) now

For the easiest setup, you can either use [GitHub Codespaces](https://docs.github.com/codespaces/overview) or [Visual Studio Code Dev Containers](https://code.visualstudio.com/docs/devcontainers/containers?WT.mc_id=dotnet-104896-juyoo) for the project.

[![Open in GitHub - Codespaces](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub+Codespaces&message=Open&color=brightgreen&logo=github)](https://github.com/codespaces/new?hide_repo_select=true&ref=main&repo=546887315&machine=standardLinux32gb&devcontainer_path=.devcontainer%2Fdevcontainer.json&location=WestUs2)
[![Open in Remote - Containers](https://img.shields.io/static/v1?style=for-the-badge&label=Remote%20-%20Containers&message=Open&color=blue&logo=visualstudiocode)](https://vscode.dev/redirect?url=vscode://ms-vscode-remote.remote-containers/cloneInVolume?url=https://github.com/microsoft/dotnetconf-studentzone)

Alternatively, you can set up your developer environment manually. You will need:

- An IDE such as [Visual Studio](https://visualstudio.microsoft.com/?WT.mc_id=dotnet-104896-juyoo) or [Visual Studio Code](https://code.visualstudio.com?WT.mc_id=dotnet-104896-juyoo) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit&WT.mc_id=dotnet-104896-juyoo) extension
- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0?WT.mc_id=dotnet-104896-juyoo)

## Speaker(s)

[**Justin Yoo**](https://twitter.com/justinchronicle) - Justin is a Senior Cloud Advocate from Microsoft. He is always looking for easy and convenient ways to build intelligent applications using the cutting-edge technologies with .NET and Azure.
