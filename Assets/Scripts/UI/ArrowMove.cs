using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {

	[SerializeField] private GameController gameController;

	// Use this for initialization
	void OnEnable()
	{
		StartCoroutine (MoveArrow ());
	}

	IEnumerator MoveArrow()
	{
		LeanTween.moveLocalY (gameObject, 30f, .5f);
		yield return new WaitForSeconds (.5f);
		StartCoroutine (MoveArrow2 ());
	}

	IEnumerator MoveArrow2()
	{
		LeanTween.moveLocalY (gameObject, 0f, .5f);
		yield return new WaitForSeconds (.5f);
		StartCoroutine (MoveArrow ());
	}
}
