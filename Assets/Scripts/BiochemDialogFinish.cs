using UnityEngine;
using System.Collections;
//using DG.Tweening;

public class BiochemDialogFinish : MonoBehaviour {

	public GameObject particles;
	public GameObject exit;
	public GameObject biochemStudent;


	void OnEnable()
	{
		particles.SetActive (true);

		biochemStudent.GetComponentInChildren<SimplePacingAnim> ().Stop ();
		biochemStudent.GetComponentInChildren<Animator> ().SetTrigger ("wait");

		Timer.New (gameObject, 1.0f, () =>
		{
			//biochemStudent.GetComponentInChildren<SpriteRenderer>().DOFade(0.0f,3.0f);
		});

		Timer.New (gameObject, 1.5f, () =>
		{
			exit.SetActive(true);
		});
		
	}
}
