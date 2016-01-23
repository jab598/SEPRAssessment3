using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using DG.Tweening;

/// <summary>
/// Floating text.
/// 
/// GUI Text that floats away from a world space object.
/// </summary>
public class FloatingText : MonoBehaviour 
{
	Text _text;
	RectTransform _rect;

	//Where we float away from
	public Transform source;

	public Color color;

	public string textString;

	public float runTime;

	private float _elapsed;

	float finishY;

	public void BeginFloating()
	{
		_text = GetComponent<Text> ();
		_rect = GetComponent<RectTransform> ();

		_text.color = color;
		_text.text = textString;


		//_text.DOColor (new Color (color.r, color.g, color.b, 0.0f), runTime).SetEase(Ease.InQuad);

		_rect.position = source.position;

		_rect.transform.localScale = new Vector3 (0.2f, 0.2f, 1.0f);


		if (Camera.current != null)
		{
			finishY = 0.3f * Camera.current.orthographicSize;
		}

		//_rect.transform.DOLocalMoveY (, runTime);
	}

	void Update()
	{
		_elapsed += Time.deltaTime;

	
		_rect.position = source.position + new Vector3 (0, finishY * (_elapsed / runTime), 0);

	}

}
