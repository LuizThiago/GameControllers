using UnityEngine;

//---------------------------------------------------------------------------------------------
// Inherit from this class to create a global access controller/manager using ScriptableObject
//---------------------------------------------------------------------------------------------
public abstract class BaseController<T> : ScriptableObject where T : ScriptableObject
{
	protected static T _instance;

	#region Properties

	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				//Lets create a temporary instance to get the resource path
				var tempInstance = CreateInstance<T>() as BaseController<T>;
				var path = tempInstance.GetPath();
				DestroyImmediate(tempInstance);

				//Load the controller in the memory
				_instance = Resources.Load<T>(path);
				(_instance as BaseController<T>).OnLoad();
			}

			return _instance;
		}
	}

	#endregion

	#region Protected

	protected virtual void OnLoad() { }

	protected abstract string GetPath(); //This is the path to the Controller asset in the Assets/Resources folder.

	#endregion
}