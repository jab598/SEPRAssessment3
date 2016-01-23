using UnityEngine;
using System.Collections;

/// <summary>
/// Timer.
/// 
/// Utility class for doing something after a certain period of time.
/// 
/// Works by adding a child gameobject with this component that calls
/// the callback when the timer ends then self destructs.
/// </summary>
public class Timer : MonoBehaviour 
{
	public delegate void TimerCallBack();

	/// <summary>
	/// New Timer with the specified host, time and callback.
	/// </summary>
	/// <param name="host">The object to atatch the timer to</param>
	/// <param name="time">Time that the timer runs for in seconds</param>
	/// <param name="callback">Function to call on complete</param>
	public static Timer New(GameObject host, float time, TimerCallBack callback)
	{
		var child = new GameObject ("Timer");
		child.transform.parent = host.transform;

		Timer timer = child.AddComponent<Timer> ();
		timer.callback = callback;
		timer.runTime = time;

		return timer;
	}

	private float elapsed;
	public float runTime;
	[HideInInspector] public TimerCallBack callback;
	bool done = false;

	void Update () 
	{
		if (!done)
		{
			if (elapsed < runTime)
			{
				elapsed += Time.deltaTime;
			} 
			else
			{
				done = true;
				callback ();
				Destroy (gameObject);
			}
		}
	}
}
