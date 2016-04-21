using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0.00000000001f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
