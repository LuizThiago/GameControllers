using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Controllers/MyGameController", fileName = "MyGameController")]
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
