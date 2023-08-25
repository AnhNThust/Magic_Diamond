using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum EventID
{
	None,
	CanSpawnBrick,
	TotalDiamond,
	CountDiamond,
	TotalLevelChanged,
	CurrentMapChanged,
	CurrentLevelChanged,
	CanCheckChanged,
	BoxStop,
	TotalBoxMove,
	CanDetachGridLayout,
}

public class EventDispatcher
{
	[RuntimeInitializeOnLoadMethod]
	public static void Init()
	{
		SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
	}

	private static void SceneManager_sceneUnloaded(Scene arg0)
	{
		listeners.Clear();
	}

	static Dictionary<EventID, Action<object>> listeners = new Dictionary<EventID, Action<object>>();

	public static void PostEvent(EventID eventID, object parameter)
	{
		if (listeners.ContainsKey(eventID))
		{
			listeners[eventID].Invoke(parameter);
		}
	}

	public static void AddEvent(EventID eventID, Action<object> action)
	{
		if (!listeners.ContainsKey(eventID))
			listeners[eventID] = action;
		else
			listeners[eventID] += action;
	}

	public static void RemoveEvent(EventID eventID, Action<object> action)
	{
		if (listeners.ContainsKey(eventID))
			listeners[eventID] -= action;
	}
}
