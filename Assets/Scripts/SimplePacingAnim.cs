using UnityEngine;
using System.Collections;
//using DG.Tweening;
/// <summary>
/// Simple pacing animation.
/// 
/// Makes the character walk left to right, pausing on the turn.
/// Nothing clever going on here just some tweening.
/// </summary>
public class SimplePacingAnim : MonoBehaviour 
{

	public Animator animator;

	bool walkRight = true;

	float distance = 40.0f;

	bool stopped = false;

	// Use this for initialization
	void Start () 
	{
		WalkRight ();
	}

	void WalkRight()
	{
		animator.SetTrigger ("walkRight");
		Debug.Log (this.gameObject.ToString () + " : WalkRight()");
	}

	void WalkLeft()
	{
		animator.SetTrigger ("walkLeft");
		Debug.Log (this.gameObject.ToString () + " : WalkRight()");
	}

	void Wait()
	{
		animator.SetTrigger ("wait");
		Timer.New (gameObject, 1.5f, () =>
		{
			if(!stopped)
			{
				if (walkRight)
				{
					WalkRight();
				}
				else
				{
					WalkLeft();
				}
			}

		});

	}

	public void Stop()
	{
		//transform.DOKill (false);
		stopped = true;
	}

}
