using UnityEngine;
using System.Collections;

/// <summary>
/// Simple health bar.
/// 
/// Ataches a health manager and a sprite to render the health.
/// 
/// Changes the scale and color of the sprite renderer based on the 
/// helth provided by the health manager.
/// 
/// Must have the sprite renderer as its child.
/// </summary>
public class SimpleHealthBar : MonoBehaviour 
{

	public GameObject entityToWatch;

	//IHealthManager _healthManager;
	SpriteRenderer _renderer;
	
	void Start () 
	{
		_renderer = GetComponentInChildren<SpriteRenderer> ();

		//_healthManager = entityToWatch.GetComponent (typeof(IHealthManager)) as IHealthManager;
	}

	void Update () 
	{
		//float percentage = _healthManager.Health / _healthManager.MaxHealth;

		//Go from green to red with health decrease.
		//_renderer.color = new Color (1.0f - percentage, percentage, 0.1f);

		//Scale down with health decrease
		//transform.localScale = new Vector3 (percentage, 1, 1);
	}
}
