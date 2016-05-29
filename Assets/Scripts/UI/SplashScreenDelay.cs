using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreenDelay : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		StartCoroutine (FadeIn ());
		yield return new WaitForSeconds (2f);
		StartCoroutine (FadeOut ());
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (1);
	}

	IEnumerator FadeIn()
	{
		LeanTween.alpha (gameObject, 1f, 1.5f);
		yield return null;
	}

	IEnumerator FadeOut()
	{
		LeanTween.alpha (gameObject, 0f, 1.5f);
		yield return null;
	}

}
