# Games in Godot! Let’s make a classic Paddle game with C#!

## Abstract

Let’s start from the ground up and get familiar with Godot to recreate a classic game. We’ll add two paddles, a ball, and some walls and bounce around!

## Link to Session Recording

*Session Recording will be updated after the event*

## Overview

In this session, we will discuss how to get started with Godot and C# from the ground up!

| **Goal**                 | Get an initial C# Godot project running with some basic interaction and code.              |
| -------------------------| ------------------------------------------------------------------------------------------ |
| **What will you learn**  | Setting up Godot & VS Code for C# development, Debugging, Basic Physics Engine Constructs. |
| **What you'll need**     | VS Code, Godot                                                                             |
| **Technology used**      | C#, Godot                                                                                  |
| **Follow along**         | We install the [`Mikeware.GoDotNet.BlankTemplate`](https://github.com/Mikeware/GoDotNet.BlankTemplate) template during the session to get started! |
| **Just want to try the app or see the solution?** | See the `src` folder and select the `project.godot` file to `Import` into Godot.  |
| **Slides**               | [PDF](slides.pdf)                                                                          |

## Pre-Learning

The template expects an `Environment Variable` to help locate the Godot installation on your machine, _this is optional_. However, if you're not familiar with this topic and looking for more information, then [this is a good article from TheWindowsClub](https://www.thewindowsclub.com/system-user-environment-variables-windows).

The Godot docs have plenty of information! We cover a lot in a short time during the session. So, if you're looking for more details on some of what we've covered, then look here:

- [Introduction to Godot — Godot Engine documentation](https://docs.godotengine.org/en/latest/getting_started/introduction/introduction_to_godot.html)
- [Nodes and Scenes — Godot Engine documentation](https://docs.godotengine.org/en/stable/getting_started/step_by_step/nodes_and_scenes.html)
- [Physics Introduction — Godot Engine documentation](https://docs.godotengine.org/en/stable/tutorials/physics/physics_introduction.html)
- [Physics Material — Godot Engine documentation](https://docs.godotengine.org/en/stable/classes/class_physicsmaterial.html)
  - [Linear Damp explanation](https://docs.godotengine.org/en/latest/classes/class_projectsettings.html#class-projectsettings-property-physics-2d-default-linear-damp)
- [Input Handling — Godot Engine documentation](https://docs.godotengine.org/en/stable/tutorials/inputs/index.html)
  - [Input.GetVector method](https://docs.godotengine.org/en/stable/classes/class_input.html#class-input-method-get-vector)

## Prerequisites

- [VS Code](https://code.visualstudio.com/Download) - IDE
    - Install the recommended extensions from `src/.vscode/extensions.json` (provided from the template below):
      - ms-dotnettools.csdevkit
      - geequlim.godot-tools
      - neikeq.godot-csharp-vscode
- [Godot Engine - .NET](https://godotengine.org/download) - **Important to grab the '.NET' version!**
- [`Mikeware.GoDotNet.BlankTemplate`](https://github.com/Mikeware/GoDotNet.BlankTemplate) - Minimal template with debugging settings configured to connect to Godot from VS Code or Visual Studio.

## Speaker(s)

**Michael A. Hawker** is a Senior Software Engineer at Microsoft. In his spare time, he loves tinkering with board and video game design and programming.
