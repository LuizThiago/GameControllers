<a id="readme-top"></a>
<br />
<div align="center">
  <h3 align="center">Game Controllers</h3>

  <p align="center">
    A simple way to create game controllers/managers with global access using Scriptable Objects
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
        <li><a href="#usage">Usage</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

The `BaseController<T>` class provides a base for creating global controllers using ScriptableObject. It ensures that only one instance of the controller is created and globally accessible through the Instance property. The asset path of the controller must be specified by subclasses through the abstract `GetPath()` method, and the protected `OnLoad()` method can be overridden for specific initializations when the controller is loaded.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [![C#](https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white)](#)
* [![Unity](https://img.shields.io/badge/Unity-%23000000.svg?logo=unity&logoColor=white)](#)

<p align="right"><a href="#readme-top">back to top</a></p>



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple example steps.

### Installation

1. Download or fork this project
2. Move the content to your Unity project _(if preferred, only the Scripts folder is necessary)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Create a new script that inherits from `BaseController<T>`. Example:

1. _Create a global float variables script_
   `LogsController.cs`
   ```c#
   using System;
   using System.Collections.Generic;
   using UnityEngine;

   [CreateAssetMenu(menuName = "Controllers/Logs Controller", fileName = "LogsController")]
   public class LogsController : BaseController<LogsController>
   {
      public enum ELogType
      {
         Normal, Warning, Error
      }

      private static readonly Dictionary<ELogType, Action<string>> LogActions = new()
      {
         { ELogType.Normal, Debug.Log },
         { ELogType.Warning, Debug.LogWarning },
         { ELogType.Error, Debug.LogError }
      };

      public void Log(string message, ELogType type)
      {
         if (LogActions.TryGetValue(type, out var logAction))
         {
            logAction(message);
         }
         else
         {
            Debug.LogError($"Log type {type} not supported.");
         }
      }

      protected override string GetPath() => "Controllers/LogsController";
   }
   ```
2. _Create an instance of the controller by right-clicking on the desired folder in the Project tab window and choosing the option (in this example)_ `Create > Controllers > LogsController`
3. _Give your new controller a name, for example,_ `LogsController`
4. _Now, to access the LogController, simply invoke it using the static call `LogsController.Instance`. Example:_
   ```c#
    LogsController.Instance.Log("[TestLogsController] Normal log message", LogsController.ELogType.Normal);
   ```


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

LuizThiago - [@CodeLuiz](https://twitter.com/@CodeLuiz) - hello@luizthiago.com

Project Link: [https://github.com/LuizThiago/GameControllers](https://github.com/LuizThiago/GameControllers)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
