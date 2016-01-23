using UnityEngine;
using System.Collections;

/// <summary>
/// Knock back arguments.
/// 
/// Used to transfer data about the knockback to the reciever.
/// </summary>
public class KnockBackArgs
{
	public Vector2 center    { get; private set; }
	public float   magnitude { get; private set; }
	
	public KnockBackArgs(Vector2 center, float magnitude)
	{
		this.center = center;
		this.magnitude = magnitude;
	}
}
