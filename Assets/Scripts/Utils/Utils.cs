using UnityEngine;


public class Utils
{

	public static string MainDirectionString(Vector3 vec)
	{

		if (Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
		{
			if (vec.x > 0)
			{
				return "Right";
			} 
			else
			{
				return "Left";
			}
		}
		else
		{
			if (vec.y > 0)
			{
				return "Up";
			} 
			else
			{
				return "Down";
			}
		}
	}
}
